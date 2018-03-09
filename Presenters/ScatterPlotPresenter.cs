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
    public class ScatterPlotPresenter
    {
        private ScatterplotForm view;
        private DataSetManagerPresenter dataSetPresenter;

        public ScatterPlotPresenter(DataSetManagerPresenter dataSetPresenter)
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

        public void createScatterPlot(List<Variable> variablesX, List<Variable> variablesY)
        {
            _Worksheet sheet = WorksheetHelper.NewWorksheet("Scatterplot");

            int offsetY = 0;
            foreach (Variable variableX in variablesX)
            {
                int offsetX = 0;

                foreach (Variable variableY in variablesY)
                {
                    var charts = (ChartObjects)sheet.ChartObjects();
                    var chartObject = charts.Add(offsetX * 300, offsetY * 200, 300, 200);
                    var chart = chartObject.Chart;
                    chart.ChartType = XlChartType.xlXYScatter;
                    chart.ChartWizard(Title: "Scatterplot " + variableX.name + " vs " + variableY.name, HasLegend: false);
                    var seriesCollection = (SeriesCollection)chart.SeriesCollection();

                    var series = seriesCollection.Add();
                    series.Values = variableX.getRange();
                    series.XValues = variableY.getRange();
                    series.MarkerStyle = XlMarkerStyle.xlMarkerStyleCircle;

                    offsetX++;
                }

                offsetY++;
            }
        }
    }
}
