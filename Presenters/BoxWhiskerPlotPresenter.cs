using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using NoruST.Domain;
using NoruST.Forms;

namespace NoruST.Presenters
{
    public class BoxWhiskerPlotPresenter
    {
        private BoxWhiskerPlotForm view;
        private DataSetManagerPresenter dataSetPresenter;

        public BoxWhiskerPlotPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
        }

        public void openView()
        {
            view = view.createAndOrShowForm();
            view.setPresenter(this);
        }

        public BindingList<DataSet> dataSets()
        {
            return dataSetPresenter.getModel().getDataSets();
        }

        public void createBoxWhiskerPlot(List<Variable> variables)
        {
            _Worksheet sheet = WorksheetHelper.NewWorksheet("Box-Whisker Plot");
            var excel = Globals.ExcelAddIn.Application;

            List<double> yValues = new List<double>();

            // To center the mean and outliers, the secondary Y-Axis has to be divided in sections. Each Box-Whisker Plot has a section above and below so if 1 Box-Whisker Plot is needed, the dots will be at 50% of the max. secondary Y-Axis value. If 2 Box-Whisker Plots are needed, the dots will be at 25% for the 1st and 75% for the 2nd of the max. secondary Y-Axis value. 
            var section = 1.0 / (2 * variables.Count);
            for (var i = 0; i < variables.Count; i++)
                yValues.Add((2 * (i + 1) - 1) * section);

            // Create the chart.
            var charts = (ChartObjects)sheet.ChartObjects();
            var chartObject = charts.Add(0, 0, 500, 125 * variables.Count);
            var chart = chartObject.Chart;
            chart.ChartType = XlChartType.xlBarStacked;
            chart.ChartWizard(Title: "Box-Whisker Plot", HasLegend: false);
            var seriesCollection = (SeriesCollection)chart.SeriesCollection();
            
            // Add the Quartile 1 to the chart.
            double[] values = new double[variables.Count];
            for (int i = 0; i < variables.Count; i++)
            {
                values[i] = excel.Evaluate("=QUARTILE.INC(" + variables[i].getRange().Address(true, true, true) + ",1)");
            }
            var series = seriesCollection.NewSeries();
            series.Values = values;
            series.ChartType = XlChartType.xlBarStacked;
            series.Format.Fill.Solid();
            series.Format.Fill.Transparency = 1;

            // Add the lower halve to the chart.
            for (int i = 0; i < variables.Count; i++)
            {
                values[i] = excel.Evaluate("=MEDIAN(" + variables[i].getRange().Address(true, true, true) + ")-QUARTILE.INC(" + variables[i].getRange().Address(true, true, true) + ",1)");
            }
            series = seriesCollection.NewSeries();
            series.Values = values;
            series.ChartType = XlChartType.xlBarStacked;
            series.Format.Fill.Solid();
            series.Format.Fill.Transparency = 1;
            series.Border.LineStyle = XlLineStyle.xlContinuous;
            series.Format.Line.Weight = 1.5f;

            // Add the upper halve to the chart.
            for (int i = 0; i < variables.Count; i++)
            {
                values[i] = excel.Evaluate("=QUARTILE.INC(" + variables[i].getRange().Address(true, true, true) + ",3)-MEDIAN(" + variables[i].getRange().Address(true, true, true) + ")");
            }
            series = seriesCollection.NewSeries();
            series.Values = values;
            series.ChartType = XlChartType.xlBarStacked;
            series.Format.Fill.Solid();
            series.Format.Fill.Transparency = 1;
            series.Border.LineStyle = XlLineStyle.xlContinuous;
            series.Format.Line.Weight = 1.5f;

            // Set the Categories Axis.
            List<string> headers = new List<string>();
            foreach (Variable variable in variables)
            {
                headers.Add(variable.name);
            }
            ((Axis)chart.Axes(XlAxisType.xlCategory)).CategoryNames = headers.ToArray();

            // Add both the minus and plus whiskers to the chart.
            for (int i = 0; i < variables.Count; i++)
            {
                var range = variables[i].getRange().Address(true, true, true);
                double quartile1 = excel.Evaluate("=QUARTILE.INC(" + range + ",1)");
                double minimum = excel.Evaluate("=MIN(" + range + ")");
                double quartile3 = excel.Evaluate("=QUARTILE.INC(" + range + ",3)");
                double interquartileRange = quartile3 - quartile1;
                values[i] = quartile1 - minimum <= 1.5 * interquartileRange ? quartile1 - minimum : 1.5 * interquartileRange;
            }
            ((Series)chart.SeriesCollection(1)).ErrorBar(XlErrorBarDirection.xlY, XlErrorBarInclude.xlErrorBarIncludeMinusValues, XlErrorBarType.xlErrorBarTypeCustom, 0, values);
            ((Series)chart.SeriesCollection(1)).ErrorBars.Format.Line.Weight = 1.5f;
            for (int i = 0; i < variables.Count; i++)
            {
                var range = variables[i].getRange().Address(true, true, true);
                double quartile1 = excel.Evaluate("=QUARTILE.INC(" + range + ",1)");
                double maximum = excel.Evaluate("=MAX(" + range + ")");
                double quartile3 = excel.Evaluate("=QUARTILE.INC(" + range + ",3)");
                double interquartileRange = quartile3 - quartile1;
                values[i] = maximum - quartile3 <= 1.5 * interquartileRange ? maximum - quartile3 : 1.5 * interquartileRange;
            }
            ((Series)chart.SeriesCollection(3)).ErrorBar(XlErrorBarDirection.xlY, XlErrorBarInclude.xlErrorBarIncludePlusValues, XlErrorBarType.xlErrorBarTypeCustom, values, 0);
            ((Series)chart.SeriesCollection(3)).ErrorBars.Format.Line.Weight = 1.5f;
            
            // Add the means to the chart as a Scatterplot and change the layout.
            series = seriesCollection.Add();
            series.ChartType = XlChartType.xlXYScatter;
            series.Name = "Mean";
            series.Values = yValues.ToArray();
            for (int i = 0; i < variables.Count; i++)
            {
                values[i] = excel.Evaluate("=AVERAGE(" + variables[i].getRange().Address(true, true, true) + ")");
            }
            series.XValues = values;
            series.MarkerStyle = XlMarkerStyle.xlMarkerStyleX;
            series.MarkerForegroundColor = (int)XlRgbColor.rgbDarkBlue;

            // Add all the outliers to the chart as a Scatterplot and change the layout.
            
            List<List<double>> listOutliers = new List<List<double>>();

            
            List<List<double>> listY = new List<List<double>>();
            foreach (Variable variable in variables)
            {
                List<double> outliers = new List<double>();
                for (var i = 1; i <= variable.getRange().Rows.Count; i++)
                {
                    try
                    {
                        var range = variable.getRange().Address(true, true, true);
                        double quartile1 = excel.Evaluate("=QUARTILE.INC(" + range + ",1)");
                        double quartile3 = excel.Evaluate("=QUARTILE.INC(" + range + ",3)");
                        double interquartileRange = quartile3 - quartile1;
                        double value = (double)((Range)excel.Evaluate("=INDEX(" + range + "," + i + ")")).Value2;
                        if (value < quartile1 - 1.5 * interquartileRange)
                        {
                            outliers.Add(value);
                        }
                        if (value > quartile3 + 1.5 * interquartileRange)
                        {
                            outliers.Add(value);
                        }
                    }
                    catch
                    {
                    }
                }
                listOutliers.Add(outliers);
            }

            var sect = 1.0 / (2 * variables.Count);
            int count = 0;
            foreach (List<double> lst in listOutliers)
            {
                List<double> yOutliers = new List<double>();
                double val = (2 * (count + 1) - 1) * sect;
                for (var i = 0; i < lst.Count; i++)
                {
                    yOutliers.Add(val);
                }
                count = count + 1;
                listY.Add(yOutliers);
            }

            count = 0;
            foreach (List<double> outl in listOutliers)
            {
                if (outl.Count > 0)
                {
                    series = seriesCollection.Add();
                    series.ChartType = XlChartType.xlXYScatter;
                    series.Name = "Outliers";
                    series.Values = listY[count].ToArray();
                    series.XValues = outl.ToArray();
                    series.MarkerStyle = XlMarkerStyle.xlMarkerStyleSquare;
                    series.MarkerBackgroundColor = (int)XlRgbColor.rgbDarkRed;
                    series.MarkerForegroundColor = (int)XlRgbColor.rgbDarkRed;
                }
                count = count + 1;
            }

            // Hide the secondary axis and set max value.
            ((Axis)chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlSecondary)).MaximumScale = 1;
            chart.HasAxis[XlAxisType.xlValue, XlAxisGroup.xlSecondary] = false;
            
        }
    }
}
