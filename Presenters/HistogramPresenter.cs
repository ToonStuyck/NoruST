using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Office.Interop.Excel;
using NoruST.Domain;
using NoruST.Forms;
using NoruST.Models;
using DataSet = NoruST.Domain.DataSet;

namespace NoruST.Presenters
{
    public class HistogramPresenter
    {
        private HistogramForm view;
        private HistogramModel model;
        private DataSetManagerPresenter dataSetPresenter;

        public HistogramPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new HistogramModel();
        }

        public HistogramModel getModel()
        {
            return model;
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

        public void createHistograms(List<Variable> variables, DataSet dataSet)
        {
            _Worksheet worksheet = WorksheetHelper.NewWorksheet("Histogram");
            int row = 1;
            int counter = 0;

            // Create the Histogram.
            foreach (Variable variable in variables)
            {
                PrintCategories(worksheet, row++, 1);
                PrintVariables(worksheet, row++, counter++, variable, dataSet);

                if (row < 15 * counter) row = 15 * counter;
            }
        }

        private void PrintCategories(_Worksheet _sheet, int _row, int firstColumn)
        {
            var column = firstColumn;
            _sheet.Cells[_row, column++] = "Histogram";
            _sheet.Cells[_row, column++] = "Bin Min.";
            _sheet.Cells[_row, column++] = "Bin Max.";
            _sheet.Cells[_row, column++] = "Bin Midpoint";
            _sheet.Cells[_row, column++] = "Freq.";
            _sheet.Cells[_row, column++] = "Rel. Freq.";
            _sheet.Cells[_row, column] = "Prb. Density";
        }

        public List<double> calcVal(List<List<double>> finalList, double[] yData, double start, double end)
        {
            List<double> temp = new List<double>();
            foreach(double val in yData)
            {
                if (val >= start && val < end)
                {
                    temp.Add(val);
                }
            }
            return temp;
        }

        private void PrintVariables(_Worksheet _sheet, int _row, int _counter, Variable variable, DataSet dataSet)
        {
            var function = Globals.ExcelAddIn.Application.WorksheetFunction;
            int numberOfBins = model.useBins && model.bins > 0 ? model.bins : (int)function.RoundUp(Math.Sqrt(function.Count(variable.getRange())), 0);

            _sheet.Cells[100, 100] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
            int length = Convert.ToInt32((_sheet.Cells[100, 100] as Range).Value);
            _sheet.Cells[100, 100] = "";

            int count = 0;
            int i = 0;
            int j = 0;
            double temp;
            double[] yData = new double[length];
            string ran = variable.Range.ToString();
            Array arr = dataSet.getWorksheet().Range[ran].Value;
            double[] vals = new double[length];
            foreach (var item in arr)
            {
                temp = Convert.ToDouble(item);
                yData[count] = temp;
                count++;
            }

            List<double> Y = new List<double>(yData);
            Y.Sort();

            yData = Y.ToArray();

            double start = yData[0];
            double end = yData[length-1];
            double step = (end - start)/numberOfBins;
            List<List<double>> finalList = new List<List<double>>();

            i = 0;
            double startVal = start;
            double endVal = startVal + step;
            while (i < numberOfBins)
            {
                List<double> tempList = calcVal(finalList, yData, startVal, endVal);
                finalList.Add(tempList);
                startVal = endVal;
                endVal = endVal + step;
                i++;
            }

            startVal = start;
            endVal = startVal + step;
            for (int bin = 0; bin < numberOfBins; bin++)
            {
                var column = 1;
                
                var range = variable.getRange().Address(true, true, true);
                _sheet.Cells[_row, column++] = "Bin #" + bin;
                _sheet.Cells[_row, column++] = startVal;
                _sheet.Cells[_row, column++] = endVal;
                _sheet.Cells[_row, column++] = startVal + (endVal-startVal)/2.0;
                //_sheet.WriteFunction(_row, column, bin == 0 ? "MIN(" + range + ")" : AddressConverter.CellAddress(_row - 1, column + 1)); column++;
                //_sheet.WriteFunction(_row, column, AddressConverter.CellAddress(_row, column - 1) + "+" + "ROUND((MAX(" + range + ")-MIN(" + range + "))/" + numberOfBins + ",0)"); column++;
                //_sheet.Cells[_row, column] = "=(" + AddressConverter.CellAddress(_row, column - 2) + "+" + AddressConverter.CellAddress(_row, column - 1) + ")/2"; column++;
                _sheet.WriteFunction(_row, column, "COUNTIF(" + range + ",\"<=\"&" + AddressConverter.CellAddress(_row, column - 2) + ")-COUNTIF(" + range + ",\"<\"&" + AddressConverter.CellAddress(_row, column - 3) + ")"); column++;
                _sheet.WriteFunction(_row, column, AddressConverter.CellAddress(_row, column - 1) + "/" + "COUNT(" + range + ")");
                double mean = (_sheet.Cells[_row, column] as Range).Value;
                column ++;
                _sheet.Cells[_row, column] = mean / (endVal - startVal);
                startVal = endVal;
                endVal = endVal + step;
                //_sheet.WriteFunction(_row, column, AddressConverter.CellAddress(_row, column - 1) + "/" + "ROUND((MAX(" + range + ")-MIN(" + range + "))/" + numberOfBins + ",0)");
                _row++;
            }

            // Create the chart.
            var charts = (ChartObjects)_sheet.ChartObjects();
            var chartObject = charts.Add(400, 225 * _counter, 100 * numberOfBins, 200);
            var chart = chartObject.Chart;
            chart.ChartType = XlChartType.xlColumnClustered;
            chart.ChartWizard(Title: "Histogram - " + variable.name, HasLegend: false);
            var seriesCollection = (SeriesCollection)chart.SeriesCollection();

            var series = seriesCollection.Add(_sheet.Range[_sheet.Cells[_row - numberOfBins, 5], _sheet.Cells[_row - 1, 5]]);
            series.ChartType = XlChartType.xlColumnClustered;
            series.XValues = _sheet.Range[_sheet.Cells[_row - numberOfBins, 4], _sheet.Cells[_row - 1, 4]];
        }
    }
}
