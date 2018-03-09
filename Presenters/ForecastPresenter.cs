
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
using NoruST.Analyses;

namespace NoruST.Presenters
{
    public class ForecastPresenter
    {
        private ForecastForm view;
        private ForecastModel model;
        private DataSetManagerPresenter dataSetPresenter;

        private bool _doOptimizeParameters;
        private int _numberOfForecasts;
        private int _numberOfHoldouts;
        private int _seasonalPeriod;
        private int _span;
        private double _level;
        private double _trend;
        private double _seasonality;

        public ForecastPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new ForecastModel();
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

        public bool checkInput(DataSet dataSet, List<Variable> variables, bool rdbMovingAverage, bool rdbSimpleExponentialSmoothing, bool rdbHoltsExponentialSmoothing, bool rdbWintersExponentialSmoothing, bool doOptimizeParameters, int numberOfForecasts, int numberOfHoldouts, int seasonalPeriod, int span, string level, string trend, string seasonality)
        {
            _seasonality = Convert.ToDouble(seasonality);
            _trend = Convert.ToDouble(trend);
            _level = Convert.ToDouble(level);
            if (variables.Count != 0 ) //&& double.TryParse(seasonality, out _seasonality) && double.TryParse(trend, out _trend) && double.TryParse(level, out _level))
            {
                Print(dataSet, variables, rdbMovingAverage, rdbSimpleExponentialSmoothing, rdbHoltsExponentialSmoothing, rdbWintersExponentialSmoothing, doOptimizeParameters, numberOfForecasts, numberOfHoldouts, seasonalPeriod, span, level, trend, seasonality);
                return true;
            }
            else
            {
                MessageBox.Show("Please correct all fields to generate Forecast");
                return false;
            }
        }

        // vanaf hier copy van oude code

        public void Print(DataSet dataSet, List<Variable> variables, bool rdbMovingAverage, bool rdbSimpleExponentialSmoothing, bool rdbHoltsExponentialSmoothing, bool rdbWintersExponentialSmoothing , bool doOptimizeParameters, int numberOfForecasts, int numberOfHoldouts, int seasonalPeriod, int span, string level, string trend, string seasonality)
        {
            // Create new sheet
            var sheet = WorksheetHelper.NewWorksheet("Forecast");

            // use variables
            _doOptimizeParameters = doOptimizeParameters;
            _numberOfForecasts = numberOfForecasts;
            _numberOfHoldouts = numberOfHoldouts;
            _seasonalPeriod = seasonalPeriod;
            _span = span;

            // variables for writing on sheet and writing of title
            int title = 1;
            int forcastingConstants = 3;
            int summaryName = forcastingConstants + 5;
            int row = summaryName + 5;
            sheet.Cells[title, 1] = "Forecast ";
            sheet.Cells[forcastingConstants, 1] = "Forecasting Constants";
            sheet.Cells[summaryName, 1] = "Summary";
            sheet.Cells[summaryName + 1, 1] = "Mean Absolute Error";
            sheet.Cells[summaryName + 2, 1] = "Root Mean Squared Error";
            sheet.Cells[summaryName + 3, 1] = "Mean Absolute Percentage Error";
            ((Range)sheet.Cells[row, 1]).EntireColumn.AutoFit();

            // variables to count number of forecast, holdouts and data
            var nForecasts = Convert.ToDouble(numberOfForecasts);
            var nHoldouts = Convert.ToDouble(numberOfHoldouts);
            var nData = Convert.ToDouble(dataSet.rangeSize());

            
            int column = 2;
            foreach (Variable variable in variables)
            {
                row = 1;
                double[,] array = RangeHelper.To2DDoubleArray(variable.getRange());
                double[] array2 = new double[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                        array2[i] = array[i, 0]; // hier moet nog iets komen waardoor het mogelijk wordt om variabelen in rijen te verwerken
                }

                //Print data
                column++;
                sheet.Cells[row++, column] = variable.name;
                for(int i = 0; i<array2.Length; i++)
                {
                    sheet.Cells[row++, column] = array2[i];
                }
                row = 1;
                column++;
                // Plot next figure below the data and the forecast
                int rowFigure = row + variables.Count + Convert.ToInt16(nForecasts) + 2;
                // Calculate moving average forecast if box is checked
                if (rdbMovingAverage)
                {
                    EvaluateMovingAverage(array2, row, column, sheet);
                    string name = "Forecast Moving Average: " + variable.name;
                    //var rangeLabels = sheet.Range[sheet.Cells[row + 1, column], sheet.Cells[row + nData + nForecasts, column]];
                    var rangeData = sheet.Range[sheet.Cells[row + 2, column - 1], sheet.Cells[row + nData + nForecasts, column - 1]];
                    var rangeForecast = sheet.Range[sheet.Cells[row + 2, column], sheet.Cells[row + nData + nForecasts, column]];
                    new TimeSeriesGraph().CreateNewGraph2(sheet, rowFigure, rangeData, rangeForecast, name);
                }

                // Calculate exponential smoothing (simple) forecast if box is checked
                if (rdbSimpleExponentialSmoothing)
                {
                    CalculateSimple(array2, row, sheet, column);
                    string name = "Forecast Exponential smoothing (Simple): " + variable.name;
                    //var rangeLabels = sheet.Range[sheet.Cells[row + 1, column], sheet.Cells[row + nData + nForecasts, column]];
                    var rangeData = sheet.Range[sheet.Cells[row + 2, column -1], sheet.Cells[row + nData + nForecasts, column -1]];
                    var rangeForecast = sheet.Range[sheet.Cells[row + 2, column + 1], sheet.Cells[row + nData + nForecasts, column + 1]];
                    new TimeSeriesGraph().CreateNewGraph2(sheet, rowFigure, rangeData, rangeForecast, name);
                }


                // Calculate exponential smoothing (holt) forecast if box is checked
                if (rdbHoltsExponentialSmoothing)
                {
                    CalculateHolt(array2, row, sheet, column);
                    string name = "Forecast Exponential smoothing (Holt): " + variable.name;
                    //var rangeLabels = sheet.Range[sheet.Cells[row + 1, column], sheet.Cells[row + nData + nForecasts, column]];
                    var rangeData = sheet.Range[sheet.Cells[row + 2, column -1], sheet.Cells[row + nData + nForecasts, column -1]];
                    var rangeForecast = sheet.Range[sheet.Cells[row + 2, column + 2], sheet.Cells[row + nData + nForecasts, column + 2]];
                    new TimeSeriesGraph().CreateNewGraph2(sheet, rowFigure, rangeData, rangeForecast, name);
                }

                // Calculate exponential smoothing (winters) forecast if box is checked
                if (rdbWintersExponentialSmoothing)
                {
                    CalculateWinter(array2, row, sheet, column);
                    string name = "Forecast Exponential smoothing (Winter): " + variable.name;
                    //var rangeLabels = sheet.Range[sheet.Cells[row + 1, column], sheet.Cells[row + nData + nForecasts, column]];
                    var rangeData = sheet.Range[sheet.Cells[row + 2, column -1], sheet.Cells[row + nData + nForecasts, column -1]];
                    var rangeForecast = sheet.Range[sheet.Cells[row + 2, column + 3], sheet.Cells[row + nData + nForecasts, column + 3]];
                    new TimeSeriesGraph().CreateNewGraph2(sheet, rowFigure, rangeData, rangeForecast,  name);
                }
                column = column + 6;
            }
        }

        // Calculates the simple forecast, writes data and return the array to be plotted
        private void CalculateSimple(double[] data, int row, _Worksheet sheet, int column)
        {
            double level = Convert.ToDouble(_level);
            if (!_doOptimizeParameters)
                EvaluateSimple(level, data, row, column, sheet, writing: true);
            else
            {
                EvaluateSimple(level, data, row, column, sheet, writing: true);
                // OptimizeSimple(); // No optimization function available yet
            }

        }

        // Calculates the Winters forecast, writes data and return the array to be plotted
        private void CalculateWinter(double[] data, int row, _Worksheet sheet, int column)
        {
            double level = Convert.ToDouble(_level);
            double trend = Convert.ToDouble(_trend);
            double seasonality = Convert.ToDouble(_seasonality);
            if (!_doOptimizeParameters)
                EvaluateWinters(level, trend, seasonality, data, row, column, sheet, writing: true);
            else
            {
                EvaluateWinters(level, trend, seasonality, data, row, column, sheet, writing: true);
                //OptimizeWinters(); // No optimization function available yet
            }
        }

        // Calculates the Holt forecast, writes data and return the array to be plotted
        private void CalculateHolt(double[] data, int row, _Worksheet sheet, int column)
        {
            double level = Convert.ToDouble(_level);
            double trend = Convert.ToDouble(_trend);
            if (!_doOptimizeParameters)
                EvaluateHolt(level, trend, data, row, column, sheet, writing: true);
            else
            {
                EvaluateHolt(level, trend, data, row, column, sheet, writing: true);
                // OptimizeHolt(); // No optimization function available yet
            }

        }

        private void EvaluateMovingAverage(double[] data, int row, int column, _Worksheet sheet)
        {
            // parameters needed for loops and calculations
            int span = Convert.ToInt16(_span);
            int nHoldouts = Convert.ToInt16(_numberOfHoldouts);
            int nForecast = Convert.ToInt16(_numberOfForecasts);
            int nData = Convert.ToInt16(data.Length);
            int nUsableData = nData - nHoldouts;

            // Create new array with usable data
            double[] usableData = new double[nData - nHoldouts];
            for (int i = 0; i < nUsableData; i++)
            {
                usableData[i] = data[i];
            }

            // Arrays to store calculated data of forecast 
            double[] forecast = new double[nData + nForecast - span];

            for (int i = span; i < nData + nForecast; i++)
            {
                // Calculate average from #span previous data, if no data is available use previous forecast
                double mean = 0;
                for (int j = 0; j < span; j++)
                {
                    if (i - j > nUsableData)
                        mean = mean + forecast[i - j - 1 - span];
                    else
                        mean = mean + usableData[i - j - 1];
                }
                mean = mean / Convert.ToDouble(span);
                forecast[i - span] = mean;
            }
            // Calculate error
            double[] error = new double[nData - span];
            int nError = nData - span;
            for (int i = 0; i < nError; i++)
            {
                error[i] = Convert.ToDouble(data[i + span]) - forecast[i];
            }

            // Calculate MAE
            double mae = 0;
            for (int i = 0; i < nError; i++)
            {
                mae = mae + Math.Abs(error[i]);
            }
            mae = mae / Convert.ToDouble(nError);

            // Calculate RMSE
            double rmse = 0;
            for (int i = 0; i < nError; i++)
            {
                rmse = rmse + error[i] * error[i];
            }
            rmse = Math.Sqrt(rmse / nError);

            // Calculate MAPE
            double mape = 0;
            for (int i = 0; i < nError; i++)
            {
                mape = mape + Math.Abs(error[i] / data[i + span]);
            }
            mape = mape / Convert.ToDouble(nError);

            // Write the parameters of the forecast
            sheet.Cells[4, 1] = "span";
            sheet.Cells[4, column - 2] = span;

            // Write summary of the forecast    
            sheet.Cells[9, column - 2] = mae;
            sheet.Cells[10, column - 2] = rmse;
            sheet.Cells[11, column - 2] = mape;

            // Write forecast
            sheet.Cells[row, column] = "Forecast";
            for (int i = 0; i < nData + nForecast - span; i++)
            {
                sheet.Cells[row + i + span + 1, column] = forecast[i];
            }

            // Write error
            sheet.Cells[row, column+1] = "Error";
            for (int i = 0; i < nError; i++)
            {
                sheet.Cells[row + i + span + 1, column + 1] = error[i];
            }
        }

        private void EvaluateSimple(double alpha, double[] data, int row, int column, _Worksheet sheet, bool writing = false)
        {
            // parameters needed for loops and calculations
            int nHoldouts = Convert.ToInt16(_numberOfHoldouts);
            int nForecast = Convert.ToInt16(_numberOfForecasts);
            int nData = Convert.ToInt16(data.Length);
            int nUsableData = nData - nHoldouts;

            // Create new array with usable data
            double[] usableData = new double[nData - nHoldouts];
            for (int i = 0; i < nUsableData; i++)
            {
                usableData[i] = data[i];
            }

            // Arrays to store calculated data of forecast 
            double[] forecast = new double[nData + nForecast - 1];
            double[] level = new double[nUsableData];

            // Initial level and trend
            level[0] = usableData[0];

            for (int i = 1; i < nData + nForecast; i++)
            {
                // Forecast if previous data is still available
                if (i < nUsableData)
                {
                    forecast[i - 1] = level[i - 1];
                    level[i] = alpha * usableData[i] + (1 - alpha) * level[i - 1];
                }
                // Forecast if no data is available (forecast from previous forecasts)
                else
                {
                    forecast[i - 1] = level[nUsableData - 1];
                }
            }

            // Calculate error
            double[] error = new double[nData - 1];
            int nError = nData - 1;
            for (int i = 0; i < nError; i++)
            {
                error[i] = Convert.ToDouble(data[i + 1]) - forecast[i];
            }

            // Calculate MAE
            double mae = 0;
            for (int i = 0; i < nError; i++)
            {
                mae = mae + Math.Abs(error[i]);
            }
            mae = mae / Convert.ToDouble(nError);

            // Calculate RMSE
            double rmse = 0;
            for (int i = 0; i < nError; i++)
            {
                rmse = rmse + error[i] * error[i];
            }
            rmse = Math.Sqrt(rmse / nError);

            // Calculate MAPE
            double mape = 0;
            for (int i = 0; i < nError; i++)
            {
                mape = mape + Math.Abs(error[i] / data[i + 1]);
            }
            mape = mape / Convert.ToDouble(nError);

            // When optimization is running, writing on sheet is not necessary
            if (writing == false) return;

            // Write the parameters of the forecast
            sheet.Cells[4, 1] = "Alpha";
            sheet.Cells[4, column - 2] = alpha;

            // Write summary of the forecast
            sheet.Cells[9, column - 2] = mae;
            sheet.Cells[10, column - 2] = rmse;
            sheet.Cells[11, column - 2] = mape;

            // Write level
            sheet.Cells[row, column] = "Level";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, column] = level[i];
            }

            // Write forecast
            sheet.Cells[row, column+1] = "Forecast";
            for (int i = 0; i < nData + nForecast - 1; i++)
            {
                sheet.Cells[row + i + 2, column + 1] = forecast[i];
            }

            // Write error
            sheet.Cells[row, column+2] = "Error";
            for (int i = 0; i < nError; i++)
            {
                sheet.Cells[row + i + 2, column + 2] = error[i];
            }
        }

        private void EvaluateHolt(double alpha, double beta, double[] data, int row, int column, _Worksheet sheet, bool writing = false)
        {
            // parameters needed for loops and calculations
            int nHoldouts = Convert.ToInt16(_numberOfHoldouts);
            int nForecast = Convert.ToInt16(_numberOfForecasts);
            int nData = Convert.ToInt16(data.Length);
            int nUsableData = nData - nHoldouts;

            // Create new array with usable data
            double[] usableData = new double[nData - nHoldouts];
            for (int i = 0; i < nUsableData; i++)
            {
                usableData[i] = data[i];
            }

            // Arrays to store calculated data of forecast 
            double[] forecast = new double[nData + nForecast - 1];
            double[] trend = new double[nUsableData];
            double[] level = new double[nUsableData];

            // Initial level and trend
            level[0] = usableData[0];
            trend[0] = (usableData[nUsableData - 1] - usableData[0]) / nUsableData;


            for (int i = 1; i < nData + nForecast; i++)
            {
                // Forecast if previous data is still available
                if (i < nUsableData)
                {
                    forecast[i - 1] = level[i - 1] + trend[i - 1];
                    level[i] = alpha * usableData[i] + (1 - alpha) * (level[i - 1] + trend[i - 1]);
                    trend[i] = beta * (level[i] - level[i - 1]) + (1 - beta) * (trend[i - 1]);
                }
                // Forecast if no data is available (forecast from previous forecasts)
                else
                {
                    forecast[i - 1] = level[nUsableData - 1] + trend[nUsableData - 1] * (1 + i - nUsableData);
                }
            }

            // Calculate error
            double[] error = new double[nData - 1];
            int nError = nData - 1;
            for (int i = 0; i < nError; i++)
            {
                error[i] = Convert.ToDouble(data[i + 1]) - forecast[i];
            }

            // Calculate MAE
            double mae = 0;
            for (int i = 0; i < nError; i++)
            {
                mae = mae + Math.Abs(error[i]);
            }
            mae = mae / Convert.ToDouble(nError);

            // Calculate RMSE
            double rmse = 0;
            for (int i = 0; i < nError; i++)
            {
                rmse = rmse + error[i] * error[i];
            }
            rmse = Math.Sqrt(rmse / nError);

            // Calculate MAPE
            double mape = 0;
            for (int i = 0; i < nError; i++)
            {
                mape = mape + Math.Abs(error[i] / data[i + 1]);
            }
            mape = mape / Convert.ToDouble(nError);

            // When optimization is running, writing on sheet is not necessary
            if (writing == false) return;

            // Write the parameters of the forecast
            sheet.Cells[4, 1] = "Alpha";
            sheet.Cells[4, column - 2] = alpha;
            sheet.Cells[5, 1] = "Beta";
            sheet.Cells[5, column - 2] = beta;

            // Write summary of the forecast
            sheet.Cells[9, column - 2] = mae;
            sheet.Cells[10, column - 2] = rmse;
            sheet.Cells[11, column - 2] = mape;

            // Write level
            sheet.Cells[row, column] = "Level";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, column] = level[i];
            }

            // Write trend
            sheet.Cells[row, column+1] = "Trend";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, column + 1] = trend[i];
            }

            // Write forecast
            sheet.Cells[row, column+2] = "Forecast";
            for (int i = 0; i < nData + nForecast - 1; i++)
            {
                sheet.Cells[row + i + 2, column + 2] = forecast[i];
            }

            // Write errors
            sheet.Cells[row, column+3] = "Error";
            for (int i = 0; i < nError; i++)
            {
                sheet.Cells[row + i + 2, column + 3] = error[i];
            }
        }

        private void EvaluateWinters(double alpha, double beta, double gamma, double[] data, int row, int column, _Worksheet sheet, bool writing = false)
        {
            // parameters needed for loops and calculations
            int nHoldouts = Convert.ToInt16(_numberOfHoldouts);
            int nForecast = Convert.ToInt16(_numberOfForecasts);
            int nSeasons = Convert.ToInt16(_seasonalPeriod);
            int nData = Convert.ToInt16(data.Length);
            int nUsableData = nData - nHoldouts;
            int nCycle = nUsableData / nSeasons;

            // Create new array with usable data
            double[] usableData = new double[nData - nHoldouts];
            for (int i = 0; i < nUsableData; i++)
            {
                usableData[i] = data[i];
            }

            // Arrays to store calculated data of forecast 
            double[] forecast = new double[nData + nForecast - 1];
            double[] trend = new double[nUsableData];
            double[] season = new double[nUsableData];
            double[] level = new double[nUsableData];
            double[] initSeasonality = new double[nSeasons];

            // Average of each complete cycle (used to calculate initial estimates for seasonality)
            double[] cycleAverage = new double[nCycle];
            for (int i = 0; i < nCycle; i++)
            {
                double mean = 0;
                for (int j = 0; j < nSeasons; j++)
                {
                    mean = mean + usableData[i * nSeasons + j];
                }
                cycleAverage[i] = mean / nSeasons;
            }

            // Calculate initial estimates for seasonality
            for (int i = 0; i < nSeasons; i++)
            {
                initSeasonality[i] = 0;
            }
            for (int i = 0; i < nCycle; i++)
            {
                for (int j = 0; j < nSeasons; j++)
                {
                    initSeasonality[j] = initSeasonality[j] + usableData[i * nSeasons + j] / cycleAverage[i] / nCycle;
                }
            }

            // Initial level, trend and seasonality
            level[0] = usableData[0] / initSeasonality[0];
            trend[0] = (usableData[nUsableData - 1] / initSeasonality[nUsableData % nSeasons] - usableData[0] / initSeasonality[0]) / nUsableData; //nUsableData % nSeasons - 1
            season[0] = gamma * usableData[0] / level[0] + (1 - gamma) * initSeasonality[0];

            for (int i = 1; i < nData + nForecast; i++)
            {
                // Forecast if previous data is still available
                if (i < nUsableData)
                {
                    // First Forecast form initial estimates of seasonality  
                    if (i < nSeasons)
                    {
                        forecast[i - 1] = (level[i - 1] + trend[i - 1]) * initSeasonality[i - 1];
                        level[i] = alpha * usableData[i] / initSeasonality[i] + (1 - alpha) * (level[i - 1] + trend[i - 1]);
                        trend[i] = beta * (level[i] - level[i - 1]) + (1 - beta) * (trend[i - 1]);
                        season[i] = gamma * usableData[i] / level[i] + (1 - gamma) * initSeasonality[i];
                    }
                    // Forecasts for other data, using previous seasonality's
                    else
                    {
                        forecast[i - 1] = (level[i - 1] + trend[i - 1]) * season[i - nSeasons];
                        level[i] = alpha * usableData[i] / season[i - nSeasons] + (1 - alpha) * (level[i - 1] + trend[i - 1]);
                        trend[i] = beta * (level[i] - level[i - 1]) + (1 - beta) * (trend[i - 1]);
                        season[i] = gamma * usableData[i] / level[i] + (1 - gamma) * season[i - nSeasons];
                    }
                }
                // Forecast if no data is available (forecast from previous forecasts)
                else
                {
                    int nReturningCycles = ((i - nUsableData) / nSeasons) + 1;
                    forecast[i - 1] = (level[nUsableData - 1] + trend[nUsableData - 1] * (1 + i - nUsableData)) * season[i - nReturningCycles * nSeasons];
                }
            }

            // Calculate error
            double[] error = new double[nData - 1];
            int nError = nData - 1;
            for (int i = 0; i < nError; i++)
            {
                error[i] = Convert.ToDouble(data[i + 1]) - forecast[i];
            }

            // Calculate MAE
            double mae = 0;
            for (int i = 0; i < nError; i++)
            {
                mae = mae + Math.Abs(error[i]);
            }
            mae = mae / Convert.ToDouble(nError);

            // Calculate RMSE
            double rmse = 0;
            for (int i = 0; i < nError; i++)
            {
                rmse = rmse + error[i] * error[i];
            }
            rmse = Math.Sqrt(rmse / nError);

            // Calculate MAPE
            double mape = 0;
            for (int i = 0; i < nError; i++)
            {
                mape = mape + Math.Abs(error[i] / data[i + 1]);
            }
            mape = mape / Convert.ToDouble(nError);

            // When optimization is running, writing on sheet is not necessary
            if (writing == false) return;

            // Write the parameters of the forecast
            sheet.Cells[4, 1] = "Alpha";
            sheet.Cells[4, column - 2] = alpha;
            sheet.Cells[5, 1] = "Beta";
            sheet.Cells[5, column - 2] = beta;
            sheet.Cells[6, 1] = "Gamma";
            sheet.Cells[6, column - 2] = gamma;

            // Write summary of the forecast
            sheet.Cells[9, column - 2] = mae;
            sheet.Cells[10, column - 2] = rmse;
            sheet.Cells[11, column - 2] = mape;

            // Write level 
            sheet.Cells[row, column] = "Level";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, column] = level[i];
            }

            // Write trend
            sheet.Cells[row, column+1] = "Trend";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, column + 1] = trend[i];
            }

            // Write seasonality
            sheet.Cells[row, column+2] = "Seasonality";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, column + 2] = season[i];
            }

            // Write forecast
            sheet.Cells[row, column+3] = "Forecast";
            for (int i = 0; i < nData + nForecast - 1; i++)
            {
                sheet.Cells[row + i + 2, column + 3] = forecast[i];
            }

            // Write errors
            sheet.Cells[row, column+4] = "Error";
            for (int i = 0; i < nError; i++)
            {
                sheet.Cells[row + i + 2, column + 4] = error[i];
            }
        }

        private void OptimizeSimple()
        {
            // algorithm to optimize parameters of the forecast
            throw new NotImplementedException();
        }

        private void OptimizeHolt()
        {
            // algorithm to optimize parameters of the forecast
            throw new NotImplementedException();
        }

        private void OptimizeWinters()
        {
            // algorithm to optimize parameters of the forecast
            throw new NotImplementedException();
        }
    }




}

