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
    public class TimeSeriesGraphPresenter
    {
        private TimeSeriesGraphForm view;
        private TimeSeriesGraphModel model;
        private DataSetManagerPresenter dataSetPresenter;

        public TimeSeriesGraphPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new TimeSeriesGraphModel();
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

        public bool checkInput(List<Variable> variablesX, DataSet dataSet)
        {

            if (dataSet != null)
            {
                _Worksheet sheet = WorksheetHelper.NewWorksheet("Time Series Graph");
                generateChart(variablesX, sheet, dataSet);
                return true;
            }
            else
                MessageBox.Show("Please correct all fields to generate Time Series Graph", "Time Series Graph error");
            return false;
        }


        public void generateChart(List<Variable> variablesX, _Worksheet sheet, DataSet dataSet)
        {
            int offsetY = 0;
            List<int> X = new List<int>();
            int count = 0;
            while (X.Count < variablesX.Count)
            { 
                X.Add(count + 1);
                count = count + 1;
            }
            System.Diagnostics.Debug.WriteLine(X.ToString());
            foreach (Variable variableX in variablesX)
            {
                int offsetX = 0;
                var charts = (ChartObjects)sheet.ChartObjects();
                var chartObject = charts.Add(offsetX * 450, offsetY * 250, 450, 250);
                var chart = chartObject.Chart;
                chart.ChartType = XlChartType.xlXYScatterLinesNoMarkers;
                chart.ChartWizard(Title: "Time Series " + dataSet.getName() + " - " + variableX.name, HasLegend: false);
                var seriesCollection = (SeriesCollection)chart.SeriesCollection();
                var series = seriesCollection.Add();
                series.Values = variableX.getRange();
                series.XValues = X.ToArray();
                series.MarkerStyle = XlMarkerStyle.xlMarkerStyleCircle;

                offsetX++;
                
                offsetY++;
            }
        }
    }
}
