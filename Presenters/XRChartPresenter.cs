using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoruST.Forms;
using NoruST.Models;
using NoruST.Presenters;
using NoruST.Domain;
using DataSet = NoruST.Domain.DataSet;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace NoruST.Presenters
{
    public class XRChartPresenter
    {
        private XRChartForm view;
        private XRChartModel model;
        private DataSetManagerPresenter dataSetPresenter;
        private int offset;

        public XRChartPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new XRChartModel();
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

        public bool checkInput(List<Variable> variables, bool rdbAllObservations, bool rdbObservationsInRange, DataSet dataSet, string uiTextBox_StopIndex, string uiTextBox_StartIndex, bool rdbPlotAllObservations, bool rdbPlotObservationsInRange, string uiTextBox_PlotStopIndex, string uiTextBox_PlotStartIndex)
        {
            int startindex = Convert.ToInt16(uiTextBox_StartIndex);
            int stopindex = Convert.ToInt16(uiTextBox_StopIndex);

            int plotstartindex = Convert.ToInt16(uiTextBox_PlotStartIndex);
            int plotstopindex = Convert.ToInt16(uiTextBox_PlotStopIndex);

            if ((rdbAllObservations || rdbObservationsInRange) && (rdbPlotAllObservations || rdbPlotObservationsInRange) && (dataSet != null) && (startindex <= stopindex) && (startindex >= 0 && stopindex >= 0) && (plotstartindex <= plotstopindex) && (plotstartindex >= 0 && plotstopindex >= 0))
            {

                offset = 320;

                if (rdbAllObservations)
                {
                    startindex = 0;
                    stopindex = dataSet.rangeSize() - 1;
                }
                
                if (rdbObservationsInRange && stopindex >= dataSet.rangeSize())
                {
                    stopindex = dataSet.rangeSize() - 1;
                }

                if (rdbPlotAllObservations)
                {
                    plotstartindex = 0;
                    plotstopindex = dataSet.rangeSize() - 1;
                }

                if (rdbPlotObservationsInRange && plotstopindex >= dataSet.rangeSize())
                {
                    plotstopindex = dataSet.rangeSize() - 1;
                }

                _Worksheet sheet = WorksheetHelper.NewWorksheet("XR Chart");
                
                generateXRChart(variables, startindex, stopindex, plotstartindex, plotstopindex, dataSet, offset, sheet);
             
                return true;
            }
            else
                MessageBox.Show("Please correct all fields to generate X/R-Chart", "XR-Chart error");
            return false;
        }

        public static int ColumnLetterToColumnIndex(string columnLetter)
        {
            columnLetter = columnLetter.ToUpper();
            int sum = 0;

            for (int i = 0; i < columnLetter.Length; i++)
            {
                sum *= 26;
                sum += (columnLetter[i] - 'A' + 1);
            }
            return sum;
        }

        static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }

        public void generateXRChart(List<Variable> variables, int startindex, int stopindex, int plotstartindex, int plotstopindex, DataSet dataSet,int offset, _Worksheet sheet)
        {
            int counter = 0;    
            int index = 0;
            int row = 1;
            int column = 1;
            double xControlLimitFactor, rControlLimitFactor1, rControlLimitFactor2;
            double[] averages = new double[dataSet.rangeSize()];
            double[] Rvalues = new double[dataSet.rangeSize()];
            double[] averageOfAverages = new double[dataSet.rangeSize()];
            double[] xChartUpperControlLimit = new double[dataSet.rangeSize()]; //amountOfVariables()
            double[] xChartLowerControlLimit = new double[dataSet.rangeSize()];
            double[] rChartUpperControlLimit = new double[dataSet.rangeSize()];
            double[] rChartLowerControlLimit = new double[dataSet.rangeSize()];
            double[] averageOfRvalues = new double[dataSet.rangeSize()];
            double[] RvaluesInRange = new double[stopindex - startindex]; // +1
            double[] averageOfAveragesInRange = new double[stopindex - startindex]; // +1
            int[] ArrayIndex = new int[plotstopindex - plotstartindex +1]; // +1
            double[] xChartConstants = new double[25] { 0.0, 1.128, 1.693, 2.059, 2.326, 2.534, 2.704, 2.847, 2.970, 3.078, 3.173, 3.258, 3.336, 3.407, 3.472, 3.532, 3.588, 3.640, 3.689, 3.735, 3.778, 3.819, 3.858, 3.895, 3.931 };
            double[] rChartConstants1 = new double[25] { 0, 0, 0, 0, 0, 0, 0.076, 0.136, 0.184, 0.223, 0.256, 0.283, 0.307, 0.328, 0.347, 0.363, 0.378, 0.391, 0.403, 0.415, 0.425, 0.434, 0.443, 0.451, 0.459 };
            double[] rChartConstants2 = new double[25] { 0, 3.267, 2.574, 2.282, 2.114, 2.004, 1.924, 1.864, 1.816, 1.777, 1.744, 1.717, 1.693, 1.672, 1.653, 1.637, 1.662, 1.607, 1.597, 1.585, 1.575, 1.566, 1.557, 1.548, 1.541 };
            sheet.Cells[row, column] = "Index";
            sheet.Cells[row, column + 1] = "Observation";
            sheet.Cells[row, column + 2] = "Average";
            sheet.Cells[row, column + 3] = "Max";
            sheet.Cells[row, column + 4] = "Min";
            sheet.Cells[row, column + 5] = "R";

            string colLetter = variables[0].Range[1].ToString();
            int columnIndex = ColumnLetterToColumnIndex(colLetter);
            int columnIndex2 = columnIndex + variables.Count-1;
            string colLetter2 = ColumnIndexToColumnLetter(columnIndex2);
            char chstart = variables[0].Range[3];
            int start = (int)Char.GetNumericValue(chstart);
            int final = 0;
            for (counter=1; counter <= dataSet.rangeSize(); counter++) //amountOfVariables()
            {
                row++;
                for (index = 0; index < variables.Count; index ++)
                {
                    sheet.Cells[row, column] = counter;
                    if (variables.Count > 1)
                    {
                        sheet.Cells[row, column + 1] = variables[0].name + "-" + variables[variables.Count-1].name;
                    } else
                    {
                        sheet.Cells[row, column + 1] = variables[index].name;
                    } 
                }
                int temp = counter;
                if (dataSet.getVariableNamesInFirstRowOrColumn())
                {
                    temp = counter + 1;
                }
                sheet.Cells[row, column + 2] = "=AVERAGE(" + dataSet.getWorksheet().Name + "!$" + colLetter + "$" + start + ":$" + colLetter2 + "$" + temp + ")";
                sheet.Cells[row, column + 3] = "=MAX(" + dataSet.getWorksheet().Name + "!$" + colLetter + "$" + temp + ":$" + colLetter2 + "$" + temp + ")";
                sheet.Cells[row, column + 4] = "=MIN(" + dataSet.getWorksheet().Name + "!$" + colLetter + "$" + temp + ":$" + colLetter2 + "$" + temp + ")";
                sheet.Cells[row, column + 5] = (double)(sheet.Cells[row, column + 3] as Range).Value - (double)(sheet.Cells[row, column + 4] as Range).Value;
                var cellValue = (double)sheet.Cells[row, column + 2].Value;
                if (cellValue < -214682680) cellValue = 0; // if cellValue is the result of a division by 0, set value to 0
                averages[counter - 1] = cellValue;
                cellValue = (double)(sheet.Cells[row, column + 5] as Range).Value;
                Rvalues[counter - 1] = cellValue;
                start = start + 1;
                final = temp;
            }

            for (counter = startindex; counter < stopindex; counter++)
            {
                RvaluesInRange[counter-startindex] = Rvalues[counter];
                averageOfAveragesInRange[counter-startindex] = averages[counter];
            }

            if (dataSet.getVariableNamesInFirstRowOrColumn())
            {
                xControlLimitFactor = xChartConstants[variables.Count-1];
                rControlLimitFactor1 = rChartConstants1[variables.Count-1];
                rControlLimitFactor2 = rChartConstants2[variables.Count-1];
            }
            else
            {
                xControlLimitFactor = xChartConstants[variables.Count];
                rControlLimitFactor1 = rChartConstants1[variables.Count];
                rControlLimitFactor2 = rChartConstants2[variables.Count];
            }
             
            for (counter = 0; counter <= final-2; counter++)
            {
                averageOfAverages[counter] = averageOfAveragesInRange.Average();
                xChartUpperControlLimit[counter] = averageOfAveragesInRange.Average() + 3.0*(Rvalues.Average()/(xControlLimitFactor*Math.Sqrt(variables.Count)));
                xChartLowerControlLimit[counter] = averageOfAveragesInRange.Average() - 3.0*(Rvalues.Average() / (xControlLimitFactor * Math.Sqrt(variables.Count)));
                averageOfRvalues[counter] = RvaluesInRange.Average();
                rChartUpperControlLimit[counter] = RvaluesInRange.Average() * rControlLimitFactor2;
                rChartLowerControlLimit[counter] = RvaluesInRange.Average() * rControlLimitFactor1;
            }

            // new subsets of arrays for plotting data

            double[] plotaverages = new double[plotstopindex - plotstartindex + 1];
            double[] plotRvalues = new double[plotstopindex - plotstartindex + 1];
            double[] plotaverageOfAverages = new double[plotstopindex - plotstartindex + 1];
            double[] plotxChartUpperControlLimit = new double[plotstopindex - plotstartindex + 1];
            double[] plotxChartLowerControlLimit = new double[plotstopindex - plotstartindex + 1];
            double[] plotrChartUpperControlLimit = new double[plotstopindex - plotstartindex + 1];
            double[] plotrChartLowerControlLimit = new double[plotstopindex - plotstartindex + 1];
            double[] plotaverageOfRvalues = new double[plotstopindex - plotstartindex + 1];

            for (int i = plotstartindex; i <= plotstopindex; i++)
            {
                ArrayIndex[i - plotstartindex] = i;
                plotaverages[i - plotstartindex] = averages[i];
                plotRvalues[i - plotstartindex] = Rvalues[i];
                plotaverageOfAverages[i - plotstartindex] = averageOfAverages[i];
                plotxChartUpperControlLimit[i - plotstartindex] = xChartUpperControlLimit[i];
                plotxChartLowerControlLimit[i - plotstartindex] = xChartLowerControlLimit[i];
                plotrChartUpperControlLimit[i - plotstartindex] = rChartUpperControlLimit[i];
                plotrChartLowerControlLimit[i - plotstartindex] = rChartLowerControlLimit[i];
                plotaverageOfRvalues[i - plotstartindex] = averageOfRvalues[i];
            }

                var Xcharts = (ChartObjects)sheet.ChartObjects();
                var XchartObject = Xcharts.Add(340, 20, 550, 300);
                var Xchart = XchartObject.Chart;
                Xchart.ChartType = XlChartType.xlXYScatterLines;
                Xchart.ChartWizard(Title: "X-Chart " + dataSet.Name, HasLegend: true);
                var XseriesCollection = (SeriesCollection)Xchart.SeriesCollection();
                var avgseries = XseriesCollection.NewSeries();
                var avgAvgseries = XseriesCollection.NewSeries();
                var UCLseries = XseriesCollection.NewSeries();
                var LCLseries = XseriesCollection.NewSeries();
                avgseries.Name = ("Observation Averages");
                avgAvgseries.Name = ("Center Line");
                UCLseries.Name = ("UCL");
                LCLseries.Name = ("LCL");
                avgseries.Values = plotaverages;
                avgAvgseries.Values = plotaverageOfAverages;
                UCLseries.Values = plotxChartUpperControlLimit;
                LCLseries.Values = plotxChartLowerControlLimit;
                avgseries.XValues = ArrayIndex;
                UCLseries.XValues = ArrayIndex;
                LCLseries.XValues = ArrayIndex;
                avgAvgseries.XValues = ArrayIndex;

                var Rcharts = (ChartObjects)sheet.ChartObjects();
                var RchartObject = Rcharts.Add(340, 20 + offset, 550, 300);
                var Rchart = RchartObject.Chart;
                Rchart.ChartType = XlChartType.xlXYScatterLines;
                Rchart.ChartWizard(Title: "R-Chart " + dataSet.Name, HasLegend: true);
                var RseriesCollection = (SeriesCollection)Rchart.SeriesCollection();
                var rSeries = RseriesCollection.NewSeries();
                var averageRSeries = RseriesCollection.NewSeries();
                var UCLSeries = RseriesCollection.NewSeries();
                var LCLSeries = RseriesCollection.NewSeries();
                rSeries.Name = ("Observation R");
                averageRSeries.Name = ("Center Line");
                UCLSeries.Name = ("UCL");
                LCLSeries.Name = ("LCL");
                rSeries.Values = plotRvalues;
                averageRSeries.Values = plotaverageOfRvalues;
                UCLSeries.Values = plotrChartUpperControlLimit;
                LCLSeries.Values = plotrChartLowerControlLimit;
                rSeries.XValues = ArrayIndex;
                averageRSeries.XValues = ArrayIndex;
                UCLSeries.XValues = ArrayIndex;
                LCLSeries.XValues = ArrayIndex;

            
        }
    }
}
