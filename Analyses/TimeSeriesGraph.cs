using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using NoruST.Models;

namespace NoruST.Analyses
{
    /// <summary>
    /// <para>Time Series Graph.</para>
    /// <para>Version: 0.1</para>
    /// <para>&#160;</para>
    /// <para>Author: Thomas Van Rompaey</para>
    /// <para>Edited by: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 25, 2016</para>
    /// </summary>
    /// <remarks>This function is not yet finished or working like it does in the example. There is a lot that can be improved upon but the limited time we had was the problem.</remarks>
    public class TimeSeriesGraph
    {
        public bool CreateGraph(DataSet dataSet, List<bool> doInclude, bool doUseLabels, int labelsId)
        {
            // Create new lists (reference) for Data and labels
            var valuesArraysData = new List<Models.Data>();
            var valuesArraysLabel = new List<Models.Data>();

            // Create new sheet
            var sheet = WorksheetHelper.NewWorksheet("Time Series");

            // variables for writing on sheet and writing of title
            int title = 1;
            int row = 5;
            sheet.Cells[title, 1] = "Time series plot";

            // add data to the list
            for (var j = 0; j < dataSet.DataList.Count; j++)
            {
                if (!doInclude[j]) continue;
                valuesArraysData.Add(dataSet.DataList[j]);
            }

            // add labels to list
            valuesArraysLabel.Add(dataSet.DataList[labelsId]);

            // create array to put in labels
            string[] arrayLabels = new string[valuesArraysLabel[0].GetValuesList().Count];

            // put in labels in array if label box is checked
            if (doUseLabels)
            {
                for (int i = 0; i < valuesArraysLabel[0].GetValuesList().Count; i++)
                {
                    arrayLabels[i] = valuesArraysLabel[0].GetValuesList()[i].ToString() + " ";
                }
            } // else put in 1, 2, 3, ...
            else
            {
                for (int i = 0; i < valuesArraysLabel[0].GetValuesList().Count; i++)
                {
                    arrayLabels[i] = Convert.ToString(i + 1);
                }
            }

            // loop all data sets and make Time series figure
            for (int i = 0; i < valuesArraysData.Count; i++)
            {
                // name figure and plot of figure
                string name = "Time series " + valuesArraysData[i].Name;
                CreateNewGraph(sheet, row, valuesArraysData[i].GetValuesArray(), arrayLabels, name);

                // make room for next figure
                row = row + 20;
            }

            return true;
        }

        private void CreateNewGraph(_Worksheet sheet, int row, dynamic[] dataArray, string[] labelArray, string name)
        {
            var charts = (ChartObjects)sheet.ChartObjects(Type.Missing);
            var chartObject = (ChartObject)charts.Add(10, row * 15, 400, 250);
            var chart = chartObject.Chart;
            chart.ChartType = XlChartType.xlLineMarkers;
            chart.ChartWizard(Title: name, HasLegend: false);

            //var dataArray = (dataList as object) as Array;
            //var labelArray = (labelList as object) as Array;

            var seriesCollection = (SeriesCollection)chart.SeriesCollection();
            var series = seriesCollection.NewSeries();

            Axis xAxis = (Axis)chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
            var yAxis = (Axis)chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);
            //yAxis.HasTitle = true;
            //yAxis.AxisTitle.Text = "Y-Axis Title text";
            //yAxis.AxisTitle.Orientation = XlOrientation.xlUpward;
            xAxis.CategoryNames = labelArray;

            series.Values = dataArray;
            series.MarkerStyle = XlMarkerStyle.xlMarkerStyleCircle;
        }

        public void CreateNewGraph(_Worksheet sheet, int row, Range rangeData, Range rangeForecast, Range rangeLabels, string name)
        {
            var charts = (ChartObjects)sheet.ChartObjects(Type.Missing);
            var chartObject = (ChartObject)charts.Add(10, row * 15, 400, 250);
            var chart = chartObject.Chart;
            chart.ChartType = XlChartType.xlLineMarkers;
            chart.ChartWizard(Title: name, HasLegend: false);

            //var dataArray = (dataList as object) as Array;
            //var labelArray = (labelList as object) as Array;

            var seriesCollection = (SeriesCollection)chart.SeriesCollection();
            var series1 = seriesCollection.NewSeries();
            var series2 = seriesCollection.NewSeries();

            Axis xAxis = (Axis)chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
            var yAxis = (Axis)chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);
            //yAxis.HasTitle = true;
            //yAxis.AxisTitle.Text = "Y-Axis Title text";
            //yAxis.AxisTitle.Orientation = XlOrientation.xlUpward;
            xAxis.CategoryNames = rangeLabels;

            series1.Values = rangeData;
            series2.Values = rangeForecast;
            series1.MarkerStyle = XlMarkerStyle.xlMarkerStyleCircle;
        }

        public void CreateNewGraph2(_Worksheet sheet, int row, Range rangeData, Range rangeForecast, string name)
        {
            var charts = (ChartObjects)sheet.ChartObjects(Type.Missing);
            var chartObject = (ChartObject)charts.Add(10, row * 15, 400, 250);
            var chart = chartObject.Chart;
            chart.ChartType = XlChartType.xlLineMarkers;
            chart.ChartWizard(Title: name, HasLegend: false);

            //var dataArray = (dataList as object) as Array;
            //var labelArray = (labelList as object) as Array;

            var seriesCollection = (SeriesCollection)chart.SeriesCollection();
            var series1 = seriesCollection.NewSeries();
            var series2 = seriesCollection.NewSeries();

            Axis xAxis = (Axis)chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
            var yAxis = (Axis)chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);
            //yAxis.HasTitle = true;
            //yAxis.AxisTitle.Text = "Y-Axis Title text";
            //yAxis.AxisTitle.Orientation = XlOrientation.xlUpward;

            series1.Values = rangeData;
            series2.Values = rangeForecast;
            series1.MarkerStyle = XlMarkerStyle.xlMarkerStyleCircle;
        }
    }
}