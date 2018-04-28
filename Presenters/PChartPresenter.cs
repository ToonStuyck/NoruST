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
    public class PChartPresenter
    {
        private PChartForm view;
        private PChartModel model;
        private DataSetManagerPresenter dataSetPresenter;
        private int offset;

        public PChartPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new PChartModel();
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

        public bool checkInput(List<Variable> variableX, List<Variable> variableY, bool radioButton2, bool rdbAllObservations, bool rdbObservationsInRange, DataSet dataSet, string uiTextBox_StopIndex, string uiTextBox_StartIndex, bool rdbPlotAllObservations, bool rdbPlotRange, string uiTextbox_PlotStopIndex, string uiTextbox_PlotStartIndex)
        {
            int startindex = Convert.ToInt16(uiTextBox_StartIndex);
            int stopindex = Convert.ToInt16(uiTextBox_StopIndex);

            int plotstartindex = Convert.ToInt16(uiTextbox_PlotStartIndex);
            int plotstopindex = Convert.ToInt16(uiTextbox_PlotStopIndex);

            if ((rdbAllObservations || rdbObservationsInRange) && (dataSet != null) && (startindex <= stopindex) && (startindex >= 0 && stopindex >= 0) && (plotstartindex <= plotstopindex) && (plotstartindex >= 0 && plotstopindex >= 0))
            {
                
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

                if (rdbPlotRange && plotstopindex >= dataSet.rangeSize())
                {
                    plotstopindex = dataSet.rangeSize() - 1;
                }

                _Worksheet sheet = WorksheetHelper.NewWorksheet("P Chart");

                generatePChart(variableX, variableY, radioButton2, startindex, stopindex, dataSet, sheet, plotstartindex, plotstopindex);
                
                return true;
            }
            else
                MessageBox.Show("Please correct all fields to generate P-Chart", "P-Chart error");
                return false;
        }

        private void generatePChart(List<Variable> variableX, List<Variable> variableY, bool radioButton2, int startindex, int stopindex, DataSet dataSet, _Worksheet sheet, int plotstartindex, int plotstopindex)
        {
            int index = 0;
            int row = 1;
            int column = 1;
            double[] pValues = new double[dataSet.rangeSize()];
            double[] sample = new double[dataSet.rangeSize()];
            double[] averageOfPValues = new double[dataSet.rangeSize()];
            double[] pValuesInRange = new double[stopindex - startindex+1];
            double[] pChartUpperControlLimit = new double[dataSet.rangeSize()];
            double[] pChartLowerControlLimit = new double[dataSet.rangeSize()];
            double[] pChartCorrection = new double[dataSet.rangeSize()];

            sheet.Cells[row, column] = "Index";
            sheet.Cells[row, column + 1] = "Sample Size";
            sheet.Cells[row, column + 2] = "Proportion";
            
            for(index = 1; index <= dataSet.rangeSize(); index ++)   
            {
                int temp = index+1;
                
                String N = "(" + dataSet.getWorksheet().Name + "!$" + variableY[0].Range[1] + "$" + temp + ")";
                String K = "(" + dataSet.getWorksheet().Name + "!$" + variableX[0].Range[1] + "$" + temp + ")";

                row++;
                sheet.Cells[row, column] = index;
                sheet.Cells[row, column + 1] = "=(" + dataSet.getWorksheet().Name + "!$" + variableX[0].Range[1] + "$" + temp + ")";
                if (radioButton2)
                {
                    sheet.Cells[row, column + 2] = "=" + N + "/" + K;
                } else
                {
                    sheet.Cells[row, column + 2] = "=(" + dataSet.getWorksheet().Name + "!$" + variableY[0].Range[1] + "$" + temp + ")";
                }
                
                var cellValue = (double)(sheet.Cells[row, column + 2] as Range).Value;
                if (cellValue < -214682680) cellValue = 0; // if cellValue is the result of a division by 0, set value to 0
                pValues[index-1] = cellValue;
                if(cellValue > 1)
                {
                    MessageBox.Show("Cannot generate P-Chart; Data in "+ dataSet.Name + " contains samples greater than 1");
                    return;
                }
                cellValue = (double)(sheet.Cells[row, column + 1] as Range).Value;
                if (cellValue < -214682680) cellValue = 0; // if cellValue is the result of a division by 0, set value to 0
                sample[index - 1] = cellValue;
            }

            for (index = startindex; index <= stopindex; index++)
            {
                pValuesInRange[index - startindex] = pValues[index];
            }

            for (index = 0; index <= dataSet.rangeSize()-1; index++)
            {
                pChartCorrection[index] = Math.Sqrt((pValuesInRange.Average() * (1 - pValuesInRange.Average())) / sample[index]);
                averageOfPValues[index] = pValuesInRange.Average();
                pChartUpperControlLimit[index] = pValues.Average() + 3.0*pChartCorrection[index];
                pChartLowerControlLimit[index] = pValues.Average() - 3.0*pChartCorrection[index];
            }

            // new arrays for subsets of existing arrays but within limits

            double[] plotpValues = new double[plotstopindex - plotstartindex + 1];
            double[] plotaverageOfPValues = new double[plotstopindex - plotstartindex + 1];
            double[] plotpChartUpperControlLimit = new double[plotstopindex - plotstartindex + 1];
            double[] plotpChartLowerControlLimit = new double[plotstopindex - plotstartindex + 1];
            int[] ArrayIndex = new int[plotstopindex - plotstartindex + 1];

            for (int i = plotstartindex; i <= plotstopindex; i++)
            {
                plotpValues[i - plotstartindex] = pValues[i];
                plotaverageOfPValues[i - plotstartindex] = averageOfPValues[i];
                plotpChartLowerControlLimit[i - plotstartindex] = pChartLowerControlLimit[i];
                plotpChartUpperControlLimit[i - plotstartindex] = pChartUpperControlLimit[i];
                ArrayIndex[i - plotstartindex] = i;
            }

                var Xcharts = (ChartObjects)sheet.ChartObjects();
                var XchartObject = Xcharts.Add(340, 20, 550, 300);
                var Xchart = XchartObject.Chart;
                Xchart.ChartType = XlChartType.xlXYScatterLines;
                Xchart.ChartWizard(Title: "P-Chart " + dataSet.Name, HasLegend: true);
                var XseriesCollection = (SeriesCollection)Xchart.SeriesCollection();
                var pseries = XseriesCollection.NewSeries();
                var CLseries = XseriesCollection.NewSeries();
                var UCLseries = XseriesCollection.NewSeries();
                var LCLseries = XseriesCollection.NewSeries();
                pseries.Name = ("Proportion");
                CLseries.Name = ("Center line");
                UCLseries.Name = ("UCL");
                LCLseries.Name = ("LCL");
                pseries.Values = plotpValues;
                CLseries.Values = plotaverageOfPValues;
                UCLseries.Values = plotpChartUpperControlLimit;
                LCLseries.Values = plotpChartLowerControlLimit;
                pseries.XValues = ArrayIndex;
                CLseries.XValues = ArrayIndex;
                UCLseries.XValues = ArrayIndex;
                LCLseries.XValues = ArrayIndex;
        }
    }
}
