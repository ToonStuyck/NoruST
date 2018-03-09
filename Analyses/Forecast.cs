using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using NoruST.Models;


namespace NoruST.Analyses
{
 public class Forecast
    {
        #region Fields

        private bool _doOptimizeParameters;
        private int _numberOfForecasts;
        private int _numberOfHoldouts;
        private int _seasonalPeriod;
        private int _span;
        private double _level;
        private double _trend;
        private double _seasonality;

        #endregion

        public bool Print(DataSet dataSet, List<bool> doInclude, SummaryStatisticsBool doCalculate, bool doOptimizeParameters, bool doUseLabels, int labelsId, int numberOfForecasts, int numberOfHoldouts, int seasonalPeriod, int span, string level, string trend, string seasonality)
        {
            _doOptimizeParameters = doOptimizeParameters;
            _numberOfForecasts = numberOfForecasts;
            _numberOfHoldouts = numberOfHoldouts;
            _seasonalPeriod = seasonalPeriod;
            _span = span;

            if (!double.TryParse(level, out _level))
            {
                MessageBox.Show("The Level is not a valid number.", "Forecast", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!double.TryParse(trend, out _trend))
            {
                MessageBox.Show("The Trend is not a valid number.", "Forecast", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!double.TryParse(seasonality, out _seasonality))
            {
                MessageBox.Show("The Seasonality is not a valid number.", "Forecast", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Create new lists (reference) for Data and labels
            var valuesArraysData = new List<Models.Data>();
            var valuesArraysLabel = new List<Models.Data>();

            // Create new sheet
            var sheet = WorksheetHelper.NewWorksheet("Forecast");

            // add data to the data list
            for (var j = 0; j < dataSet.DataList.Count; j++)
            {
                if (!doInclude[j]) continue;
                valuesArraysData.Add(dataSet.DataList[j]);
            }

            // add labels to labels list
            valuesArraysLabel.Add(dataSet.DataList[labelsId]);

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
            sheet.Cells[row, 1] = "Label";
            sheet.Cells[row, 2] = valuesArraysData[0].Name;

            // variables to count number of forecast, holdouts and data
            var nForecasts = Convert.ToDouble(numberOfForecasts);
            var nHoldouts = Convert.ToDouble(numberOfHoldouts);
            var nData = Convert.ToDouble(valuesArraysData[0].GetValuesList().Count);

            // create array to put in labels
            string[] arrayLabels = new string[valuesArraysLabel[0].GetValuesList().Count + Convert.ToInt16(nForecasts)];

            // put in labels in array if label box is checked and print out labels in excel
            if (doUseLabels)
            {
                for (int i = 0; i < valuesArraysLabel[0].GetValuesList().Count; i++)
                {
                    arrayLabels[i] = valuesArraysLabel[0].GetValuesList()[i].ToString() + " ";
                    sheet.Cells[row + 1 + i, 1] = arrayLabels[i];
                }
            } // else put in 1, 2, 3, ... and print out labels in excel
            else
            {
                for (int i = 0; i < valuesArraysLabel[0].GetValuesList().Count; i++)
                {
                    arrayLabels[i] = Convert.ToString(i + 1);
                    sheet.Cells[row + 1 + i, 1] = arrayLabels[i];
                }
            }

            // Add labels for forecast and print out labels in excel
            double differenceLabels = Convert.ToDouble(arrayLabels[arrayLabels.Length - 1 - Convert.ToInt16(nForecasts)]) - Convert.ToDouble(arrayLabels[arrayLabels.Length - 2 - Convert.ToInt16(nForecasts)]);
            for (int i = 0; i < nForecasts; i++)
            {
                int arrayPosition = valuesArraysLabel[0].GetValuesList().Count + i;
                arrayLabels[arrayPosition] = Convert.ToString(Convert.ToDouble(arrayLabels[arrayPosition - 1]) + differenceLabels);
                sheet.Cells[row + arrayPosition + 1, 1] = arrayLabels[arrayPosition];
            }

            // Print out Data in excel
            for (int i = 0; i < valuesArraysData[0].GetValuesList().Count; i++)
            {
                sheet.Cells[row + 1 + i, 2] = valuesArraysData[0].GetValuesList()[i];
            }

            // Plot next figure below the data and the forecast
            int rowFigure = row + valuesArraysLabel[0].GetValuesList().Count + Convert.ToInt16(nForecasts) + 2;

            // Calculate moving average forecast if box is checked
            if (doCalculate.MovingAverage)
            {
                EvaluateMovingAverage(valuesArraysData[0].GetValuesArray(), row, sheet);
                string name = "Forecast Moving Average: " + valuesArraysData[0].Name;
                var rangeLabels = sheet.Range[sheet.Cells[row + 1, 1], sheet.Cells[row + nData + nForecasts, 1]];
                var rangeData = sheet.Range[sheet.Cells[row + 1, 2], sheet.Cells[row + nData + nForecasts, 2]];
                var rangeForecast = sheet.Range[sheet.Cells[row + 1, 3], sheet.Cells[row + nData + nForecasts, 3]];
                new TimeSeriesGraph().CreateNewGraph(sheet, rowFigure, rangeData, rangeForecast, rangeLabels, name);
            }

            // Calculate exponential smoothing (simple) forecast if box is checked
            if (doCalculate.SimpleExponentialSmoothing)
            {
                CalculateSimple(valuesArraysData[0].GetValuesArray(), row, sheet);
                string name = "Forecast Exponential smoothing (Simple): " + valuesArraysData[0].Name;
                var rangeLabels = sheet.Range[sheet.Cells[row + 1, 1], sheet.Cells[row + nData + nForecasts, 1]];
                var rangeData = sheet.Range[sheet.Cells[row + 1, 2], sheet.Cells[row + nData + nForecasts, 2]];
                var rangeForecast = sheet.Range[sheet.Cells[row + 1, 4], sheet.Cells[row + nData + nForecasts, 4]];
                new TimeSeriesGraph().CreateNewGraph(sheet, rowFigure, rangeData, rangeForecast, rangeLabels, name);
            }


            // Calculate exponential smoothing (holt) forecast if box is checked
            if (doCalculate.HoltsExponentialSmoothing)
            {
                CalculateHolt(valuesArraysData[0].GetValuesArray(), row, sheet);
                string name = "Forecast Exponential smoothing (Holt): " + valuesArraysData[0].Name;
                var rangeLabels = sheet.Range[sheet.Cells[row + 1, 1], sheet.Cells[row + nData + nForecasts, 1]];
                var rangeData = sheet.Range[sheet.Cells[row + 1, 2], sheet.Cells[row + nData + nForecasts, 2]];
                var rangeForecast = sheet.Range[sheet.Cells[row + 1, 5], sheet.Cells[row + nData + nForecasts, 5]];
                new TimeSeriesGraph().CreateNewGraph(sheet, rowFigure, rangeData, rangeForecast, rangeLabels, name);
            }

            // Calculate exponential smoothing (winters) forecast if box is checked
            if (doCalculate.WintersExponentialSmoothing)
            {
                CalculateWinter(valuesArraysData[0].GetValuesArray(), row, sheet);
                string name = "Forecast Exponential smoothing (Winter): " + valuesArraysData[0].Name;
                var rangeLabels = sheet.Range[sheet.Cells[row + 1, 1], sheet.Cells[row + nData + nForecasts, 1]];
                var rangeData = sheet.Range[sheet.Cells[row + 1, 2], sheet.Cells[row + nData + nForecasts, 2]];
                var rangeForecast = sheet.Range[sheet.Cells[row + 1, 6], sheet.Cells[row + nData + nForecasts, 6]];
                new TimeSeriesGraph().CreateNewGraph(sheet, rowFigure, rangeData, rangeForecast, rangeLabels, name);
            }

            return true;
        }

        // Calculates the simple forecast, writes data and return the array to be plotted
        private void CalculateSimple(dynamic[] data, int row, _Worksheet sheet)
        {
            double level = Convert.ToDouble(_level);
            if (!_doOptimizeParameters)
                EvaluateSimple(level, data, row, sheet, writing: true);
            else
            {
                EvaluateSimple(level, data, row, sheet, writing: true);
                // OptimizeSimple(); // No optimization function available yet
            }

        }

        // Calculates the Winters forecast, writes data and return the array to be plotted
        private void CalculateWinter(dynamic[] data, int row, _Worksheet sheet)
        {
            double level = Convert.ToDouble(_level);
            double trend = Convert.ToDouble(_trend);
            double seasonality = Convert.ToDouble(_seasonality);
            if (!_doOptimizeParameters)
                EvaluateWinters(level, trend, seasonality, data, row, sheet, writing: true);
            else
            {
                EvaluateWinters(level, trend, seasonality, data, row, sheet, writing: true);
                //OptimizeWinters(); // No optimization function available yet
            }
        }

        // Calculates the Holt forecast, writes data and return the array to be plotted
        private void CalculateHolt(dynamic[] data, int row, _Worksheet sheet)
        {
            double level = Convert.ToDouble(_level);
            double trend = Convert.ToDouble(_trend);
            if (!_doOptimizeParameters)
                EvaluateHolt(level, trend, data, row, sheet, writing: true);
            else
            {
                EvaluateHolt(level, trend, data, row, sheet, writing: true);
                // OptimizeHolt(); // No optimization function available yet
            }

        }

        private void EvaluateMovingAverage(IReadOnlyList<dynamic> data, int row, _Worksheet sheet)
        {
            // parameters needed for loops and calculations
            int span = Convert.ToInt16(_span);
            int nHoldouts = Convert.ToInt16(_numberOfHoldouts);
            int nForecast = Convert.ToInt16(_numberOfForecasts);
            int nData = Convert.ToInt16(data.Count);
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
            sheet.Cells[4, 2] = span;

            // Write summary of the forecast    
            sheet.Cells[9, 2] = mae;
            sheet.Cells[10, 2] = rmse;
            sheet.Cells[11, 2] = mape;

            // Write forecast
            sheet.Cells[row, 3] = "Forecast";
            for (int i = 0; i < nData + nForecast - span; i++)
            {
                sheet.Cells[row + i + span + 1, 3] = forecast[i];
            }

            // Write error
            sheet.Cells[row, 4] = "Error";
            for (int i = 0; i < nError; i++)
            {
                sheet.Cells[row + i + span + 1, 4] = error[i];
            }
        }

        private void EvaluateSimple(double alpha, IReadOnlyList<dynamic> data, int row, _Worksheet sheet, bool writing = false)
        {
            // parameters needed for loops and calculations
            int nHoldouts = Convert.ToInt16(_numberOfHoldouts);
            int nForecast = Convert.ToInt16(_numberOfForecasts);
            int nData = Convert.ToInt16(data.Count);
            int nUsableData = nData - nHoldouts;

            // Create new array with usable data
            float[] usableData = new float[nData - nHoldouts];
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
            sheet.Cells[4, 2] = alpha;

            // Write summary of the forecast
            sheet.Cells[9, 2] = mae;
            sheet.Cells[10, 2] = rmse;
            sheet.Cells[11, 2] = mape;

            // Write level
            sheet.Cells[row, 3] = "Level";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, 3] = level[i];
            }

            // Write forecast
            sheet.Cells[row, 4] = "Forecast";
            for (int i = 0; i < nData + nForecast - 1; i++)
            {
                sheet.Cells[row + i + 2, 4] = forecast[i];
            }

            // Write error
            sheet.Cells[row, 5] = "Error";
            for (int i = 0; i < nError; i++)
            {
                sheet.Cells[row + i + 2, 5] = error[i];
            }
        }

        private void EvaluateHolt(double alpha, double beta, IReadOnlyList<dynamic> data, int row, _Worksheet sheet, bool writing = false)
        {
            // parameters needed for loops and calculations
            int nHoldouts = Convert.ToInt16(_numberOfHoldouts);
            int nForecast = Convert.ToInt16(_numberOfForecasts);
            int nData = Convert.ToInt16(data.Count);
            int nUsableData = nData - nHoldouts;

            // Create new array with usable data
            float[] usableData = new float[nData - nHoldouts];
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
            sheet.Cells[4, 2] = alpha;
            sheet.Cells[5, 1] = "Beta";
            sheet.Cells[5, 2] = beta;

            // Write summary of the forecast
            sheet.Cells[9, 2] = mae;
            sheet.Cells[10, 2] = rmse;
            sheet.Cells[11, 2] = mape;

            // Write level
            sheet.Cells[row, 3] = "Level";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, 3] = level[i];
            }

            // Write trend
            sheet.Cells[row, 4] = "Trend";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, 4] = trend[i];
            }

            // Write forecast
            sheet.Cells[row, 5] = "Forecast";
            for (int i = 0; i < nData + nForecast - 1; i++)
            {
                sheet.Cells[row + i + 2, 5] = forecast[i];
            }

            // Write errors
            sheet.Cells[row, 6] = "Error";
            for (int i = 0; i < nError; i++)
            {
                sheet.Cells[row + i + 2, 6] = error[i];
            }
        }

        private void EvaluateWinters(double alpha, double beta, double gamma, IReadOnlyList<dynamic> data, int row, _Worksheet sheet, bool writing = false)
        {
            // parameters needed for loops and calculations
            int nHoldouts = Convert.ToInt16(_numberOfHoldouts);
            int nForecast = Convert.ToInt16(_numberOfForecasts);
            int nSeasons = Convert.ToInt16(_seasonalPeriod);
            int nData = Convert.ToInt16(data.Count);
            int nUsableData = nData - nHoldouts;
            int nCycle = nUsableData / nSeasons;

            // Create new array with usable data
            float[] usableData = new float[nData - nHoldouts];
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
            trend[0] = (usableData[nUsableData - 1] / initSeasonality[nUsableData % nSeasons - 1] - usableData[0] / initSeasonality[0]) / nUsableData;
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
            sheet.Cells[4, 2] = alpha;
            sheet.Cells[5, 1] = "Beta";
            sheet.Cells[5, 2] = beta;
            sheet.Cells[6, 1] = "Gamma";
            sheet.Cells[6, 2] = gamma;

            // Write summary of the forecast
            sheet.Cells[9, 2] = mae;
            sheet.Cells[10, 2] = rmse;
            sheet.Cells[11, 2] = mape;

            // Write level 
            sheet.Cells[row, 3] = "Level";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, 3] = level[i];
            }

            // Write trend
            sheet.Cells[row, 4] = "Trend";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, 4] = trend[i];
            }

            // Write seasonality
            sheet.Cells[row, 5] = "Seasonality";
            for (int i = 0; i < nUsableData; i++)
            {
                sheet.Cells[row + i + 1, 5] = season[i];
            }

            // Write forecast
            sheet.Cells[row, 6] = "Forecast";
            for (int i = 0; i < nData + nForecast - 1; i++)
            {
                sheet.Cells[row + i + 2, 6] = forecast[i];
            }

            // Write errors
            sheet.Cells[row, 7] = "Error";
            for (int i = 0; i < nError; i++)
            {
                sheet.Cells[row + i + 2, 7] = error[i];
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