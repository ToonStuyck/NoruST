using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.Office.Interop.Excel;
using NoruST.Models;

// ReSharper disable InvertIf
// ReSharper disable LocalizableElement
// ReSharper disable LoopCanBePartlyConvertedToQuery

namespace NoruST.Analyses
{
    /// <summary>
    /// <para>Regression.</para>
    /// <para>Version: 0.1</para>
    /// <para>&#160;</para>
    /// <para>Author: Thomas Van Rompaey</para>
    /// <para>Edited by: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 24, 2016</para>
    /// </summary>
    /// <remarks>This function is not yet finished or working like it does in the example. There is a lot that can be improved upon but the limited time we had was the problem.</remarks>
    public class Regression
    {
        #region Fields

        private readonly WorksheetFunction _functions = Globals.ExcelAddIn.Application.WorksheetFunction;

        #endregion

        #region Public Methods

        /// <summary>
        /// Print the Discriminant Analysis to a new <see cref="Microsoft.Office.Interop.Excel._Worksheet"/>.
        /// </summary>
        /// <param name="dataSet">The <see cref="DataSet"/> which needs (a) Scatterplot(s).</param>
        /// <param name="doIncludeX">A <see cref="List{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Models.Data"/> in the <see cref="DataSet.DataList"/> should be included for X.</param>
        /// <param name="doIncludeY">A <see cref="List{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Models.Data"/> in the <see cref="DataSet.DataList"/> should be included for Y.</param>
        /// <param name="doCalculate">A collection of <see cref="bool"/>s that indicate which summary statistic has to be calculated.</param>
        /// <param name="confidenceLevel">The confidence level.</param>
        public bool Print(DataSet dataSet, List<bool> doIncludeX, List<bool> doIncludeY, SummaryStatisticsBool doCalculate, int confidenceLevel)
        {
            var valuesArraysX = new List<Models.Data>();
            var valuesArraysY = new List<Models.Data>();
            var sheet = WorksheetHelper.NewWorksheet("Regression");

            // Loop to add X
            for (var j = 0; j < dataSet.DataList.Count; j++)
            {
                // Check if the Set of Data is an X.
                if (!doIncludeX[j]) continue;

                var safe = true;
                foreach (var value in dataSet.DataList[j].GetValuesList())
                {
                    if (value != null) continue;

                    MessageBox.Show(dataSet.DataList[j].Name + " has null data and will not be included.", "NoruST - Discriminant Analysis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    safe = false;
                }

                // If the Set of Data is an X, add it to the list.
                if (safe)
                    valuesArraysX.Add(dataSet.DataList[j]);
            }

            for (var j = 0; j < dataSet.DataList.Count; j++)
            {
                // Check if the Set of Data is an Y.
                if (!doIncludeY[j]) continue;

                // If the Set of Data is Y add to list.
                valuesArraysY.Add(dataSet.DataList[j]);
                // only one Y (currently) so break loop if Y is found.
                break;
            }

            // create X matrix
            var matrixX = Matrix<double>.Build.Dense(valuesArraysX[0].GetValuesList().Count, valuesArraysX.Count + 1);
            // create 1 column with 1
            for (var i = 0; i < valuesArraysX[0].GetValuesList().Count; i++)
            {
                matrixX[i, 0] = 1;
                for (var j = 0; j < valuesArraysX.Count; j++)
                {
                    matrixX[i, j + 1] = valuesArraysX[j].GetValuesArray()[i];
                }
            }

            // create Y matrix
            var matrixY = Matrix<double>.Build.Dense(valuesArraysY[0].GetValuesList().Count, 1);
            // create 1 column with 1
            for (var i = 0; i < valuesArraysY[0].GetValuesList().Count; i++)
            {
                matrixY[i, 0] = valuesArraysY[0].GetValuesArray()[i];
            }

            var matrixXt = matrixX.Transpose();
            var matrixXtX = matrixXt * matrixX;
            var matrixInv = matrixXtX.Inverse();
            var matrixInvXt = matrixInv * matrixXt;
            var matrixResult = matrixInvXt * matrixY;

            // variables for sheet
            const int title = 1;
            const int name = 3;
            const int betaCoeff = 2;
            const int stdErrorName = betaCoeff + 1;
            const int pValuesName = stdErrorName + 1;
            const int lowerLimitName = pValuesName + 1;
            const int upperLimitName = lowerLimitName + 1;
            var summaryName = name + valuesArraysX.Count + 3;
            var anovaTableName = summaryName + 3;
            const int degreesOfFreedomName = 2;
            const int sumOfSquaresName = 3;
            const int meanOfSquaresName = 4;
            const int anovaFValueName = 5;
            const int anovaPValueName = 6;
            var dataName = anovaTableName + 4;

            // names of variables on sheet
            sheet.Cells[title, 1] = "Regression";
            sheet.Cells[name + 1, 1] = "Constant";
            sheet.Cells[name, betaCoeff] = "Beta";
            sheet.Cells[name, stdErrorName] = "Standard Error";
            sheet.Cells[name, pValuesName] = "P-Value";
            sheet.Cells[name, lowerLimitName] = "Lower Limit";
            sheet.Cells[name, upperLimitName] = "Upper Limit";
            sheet.Cells[summaryName + 1, 1] = "Regression Summary";
            sheet.Cells[summaryName, 2] = "R-Square";
            sheet.Cells[summaryName, 3] = "Adjusted R-Square";
            sheet.Cells[summaryName, 4] = "Standard Error of estimation";

            if (doCalculate.DisplayRegressionEquation)
            {
                sheet.Cells[summaryName, 5] = "Regression Equation";
                var regressionEquation = "" + matrixResult[0, 0];
                for (var i = 0; i < valuesArraysX.Count; i++)
                {
                    regressionEquation = regressionEquation + " + (" + matrixResult[i + 1, 0] + "*" + valuesArraysX[i].Name + ")";
                }
                sheet.Cells[summaryName + 1, 5] = valuesArraysY[0].Name + " = " + regressionEquation;

            }
            sheet.Cells[anovaTableName, 1] = "Anova Table";
            sheet.Cells[anovaTableName + 1, 1] = "Explained";
            sheet.Cells[anovaTableName + 2, 1] = "Unexplained";
            sheet.Cells[anovaTableName, degreesOfFreedomName] = "Degrees of Freedom";
            sheet.Cells[anovaTableName + 1, degreesOfFreedomName] = valuesArraysX.Count;
            var dF = valuesArraysY[0].GetValuesList().Count - 1 - valuesArraysX.Count;
            sheet.Cells[anovaTableName + 2, degreesOfFreedomName] = dF;
            sheet.Cells[anovaTableName, sumOfSquaresName] = "Sum of Squares";
            var sumOfSquare = CalculateSumOfSquares(valuesArraysX, valuesArraysY, matrixResult);
            sheet.Cells[anovaTableName + 1, sumOfSquaresName] = sumOfSquare[0];
            sheet.Cells[anovaTableName + 2, sumOfSquaresName] = sumOfSquare[1];
            sheet.Cells[anovaTableName, meanOfSquaresName] = "Mean of Squares";
            sheet.Cells[anovaTableName + 1, meanOfSquaresName] = sumOfSquare[0] / valuesArraysX.Count;
            sheet.Cells[anovaTableName + 2, meanOfSquaresName] = sumOfSquare[1] / (valuesArraysY[0].GetValuesList().Count - 1 - valuesArraysX.Count);
            sheet.Cells[anovaTableName, anovaFValueName] = "F";
            sheet.Cells[anovaTableName, anovaPValueName] = "P-Value";
            var fTest = (sumOfSquare[0] / valuesArraysX.Count) / (sumOfSquare[1] / (valuesArraysY[0].GetValuesList().Count - 1 - valuesArraysX.Count));
            sheet.Cells[anovaTableName + 1, anovaFValueName] = fTest;
            sheet.Cells[anovaTableName + 1, anovaPValueName] = _functions.FDist(fTest, valuesArraysX.Count, valuesArraysY[0].GetValuesList().Count - 1 - valuesArraysX.Count);
            sheet.Cells[dataName, 1] = "Data";
            sheet.Cells[dataName, 2] = "Y: " + valuesArraysY[0].Name;
            sheet.Cells[dataName, 3] = "Fit";
            sheet.Cells[dataName, 4] = "Residuals";

            // calculate r-square, adj r-square and std error of estimation
            var rSquare = CalculateRsquare(valuesArraysX, valuesArraysY, matrixResult);
            var adjRSquare = CalculateAdjRSquare(rSquare, matrixX);
            var stdErrorEstimation = CalculateStdErrorEstimation(valuesArraysX, valuesArraysY, matrixResult);
            sheet.Cells[summaryName + 1, 2] = rSquare;
            sheet.Cells[summaryName + 1, 3] = adjRSquare;
            sheet.Cells[summaryName + 1, 4] = stdErrorEstimation;

            for (int i = 1; i < matrixResult.RowCount; i++)
            {
                sheet.Cells[name + i + 1, 1] = valuesArraysX[i - 1].Name;
            }

            var meanOfSquaresError = sumOfSquare[1] / (valuesArraysY[0].GetValuesList().Count - 1 - valuesArraysX.Count);
            for (var i = 0; i < matrixResult.RowCount; i++)
            {
                var coeff = matrixResult[i, 0];
                var stdError = Math.Sqrt(matrixInv[i, i] * meanOfSquaresError);
                var pValue = _functions.TDist(Math.Abs(coeff / stdError), dF, 2);
                var confidenceConstant = _functions.T_Inv_2T(1 - confidenceLevel / 100.0, dF);
                var lower = coeff - stdError * confidenceConstant;
                var upper = coeff + stdError * confidenceConstant;
                sheet.Cells[name + i + 1, betaCoeff] = coeff;
                sheet.Cells[name + i + 1, stdErrorName] = stdError;
                sheet.Cells[name + i + 1, pValuesName] = pValue;
                sheet.Cells[name + i + 1, lowerLimitName] = lower;
                sheet.Cells[name + i + 1, upperLimitName] = upper;

            }

            for (var i = 0; i < valuesArraysX.Count; i++)
            {
                sheet.Cells[dataName, 5 + i] = valuesArraysX[i].Name;
            }


            var nextFigure = CreateDataRegression(matrixX, matrixY, matrixResult, dataName, sheet);
            if (doCalculate.FittedValuesVsActualYValues)
            {
                var rangeX = sheet.Range[sheet.Cells[dataName + 1, 2], sheet.Cells[dataName + valuesArraysY[0].GetValuesList().Count, 2]];
                var rangeY = sheet.Range[sheet.Cells[dataName + 1, 3], sheet.Cells[dataName + valuesArraysY[0].GetValuesList().Count, 3]];
                nextFigure = CreateNewFigure(rangeX, rangeY, nextFigure, "Fitted Values vs Actual Y-Values: " + valuesArraysY[0].Name, sheet);
            }

            if (doCalculate.ResidualsVsFittedValues)
            {
                var rangeX = sheet.Range[sheet.Cells[dataName + 1, 3], sheet.Cells[dataName + valuesArraysY[0].GetValuesList().Count, 3]];
                var rangeY = sheet.Range[sheet.Cells[dataName + 1, 4], sheet.Cells[dataName + valuesArraysY[0].GetValuesList().Count, 4]];
                nextFigure = CreateNewFigure(rangeX, rangeY, nextFigure, "Residuals vs Fitted Values", sheet);
            }

            if (doCalculate.ResidualsVsXValues)
            {
                var rangeY = sheet.Range[sheet.Cells[dataName + 1, 4], sheet.Cells[dataName + valuesArraysY[0].GetValuesList().Count, 4]];
                for (var i = 0; i < valuesArraysX.Count; i++)
                {
                    var rangeX = sheet.Range[sheet.Cells[dataName + 1, 5 + i], sheet.Cells[dataName + valuesArraysY[0].GetValuesList().Count, 5 + i]];
                    var nameX = valuesArraysX[i].Name;
                    nextFigure = CreateNewFigure(rangeX, rangeY, nextFigure, "Residuals vs " + nameX, sheet);
                }
            }

            return true;
        }

        #endregion

        #region Private Methods

        private int CreateDataRegression(Matrix<double> matrixX, Matrix<double> matrixY, Matrix<double> beta, int row, _Worksheet sheet)
        {
            var newRow = row + matrixY.RowCount + 2;

            for (var i = 0; i < matrixY.RowCount; i++)
            {
                var place = row + i + 1;
                sheet.Cells[place, 1] = i + 1;
                sheet.Cells[place, 2] = matrixY[i, 0];
                var fit = beta[0, 0];
                for (var j = 1; j < matrixX.ColumnCount; j++)
                {
                    sheet.Cells[place, 4 + j] = matrixX[i, j];
                    fit = fit + matrixX[i, j] * beta[j, 0];
                }
                sheet.Cells[place, 3] = fit;
                sheet.Cells[place, 4] = matrixY[i, 0] - fit;
            }
            return newRow;
        }
        private static int CreateNewFigure(Range rangeX, Range rangeY, int row, string name, _Worksheet sheet)
        {
            var charts = (ChartObjects)sheet.ChartObjects();
            var chartObject = charts.Add(10, row * 15, 400, 250);
            var chart = chartObject.Chart;

            chart.ChartType = XlChartType.xlXYScatter;
            chart.ChartWizard(Title: name, HasLegend: false);

            ((SeriesCollection)chart.SeriesCollection()).Add(rangeY);
            ((Series)chart.SeriesCollection(1)).Values = rangeY;
            ((Series)chart.SeriesCollection(1)).XValues = rangeX;
            ((Series)chart.SeriesCollection(1)).MarkerStyle = XlMarkerStyle.xlMarkerStyleCircle;

            return row + 20;
        }
        private double CalculateRsquare(IReadOnlyList<Models.Data> valueArrayX, IReadOnlyList<Models.Data> valueArrayY, Matrix<double> beta)
        {
            double ssTot = 0;
            double ssRes = 0;
            for (var i = 0; i < valueArrayY[0].GetValuesList().Count; i++)
            {
                ssTot = ssTot + (valueArrayY[0].GetValuesList()[i] - _functions.Average(valueArrayY[0].Range)) * (valueArrayY[0].GetValuesList()[i] - _functions.Average(valueArrayY[0].Range));
                var fittedValue = beta[0, 0];
                for (var j = 0; j < valueArrayX.Count; j++)
                {
                    fittedValue = fittedValue + beta[j + 1, 0] * valueArrayX[j].GetValuesList()[i];
                }
                ssRes = ssRes + (valueArrayY[0].GetValuesList()[i] - fittedValue) * (valueArrayY[0].GetValuesList()[i] - fittedValue);

            }
            var rSquare = 1 - ssRes / ssTot;
            return rSquare;
        }
        private double CalculateAdjRSquare(double rSquare, Matrix<double> matrixX)
        {
            double n = matrixX.RowCount;
            double p = matrixX.ColumnCount - 1;
            var adjRSquare = 1 - (1 - rSquare) * (n - 1) / (n - p - 1);
            return adjRSquare;
        }
        private double CalculateStdErrorEstimation(IReadOnlyList<Models.Data> valueArrayX, IReadOnlyList<Models.Data> valueArrayY, Matrix<double> beta)
        {
            double n = valueArrayY[0].GetValuesList().Count;
            double ssRes = 0;
            for (var i = 0; i < valueArrayY[0].GetValuesList().Count; i++)
            {
                var fittedValue = beta[0, 0];
                for (var j = 0; j < valueArrayX.Count; j++)
                {
                    fittedValue = fittedValue + beta[j + 1, 0] * valueArrayX[j].GetValuesList()[i];
                }
                ssRes = ssRes + (valueArrayY[0].GetValuesList()[i] - fittedValue) * (valueArrayY[0].GetValuesList()[i] - fittedValue);

            }
            var stdErrorEstimation = Math.Sqrt(ssRes / (n - 1 - valueArrayX.Count));
            return stdErrorEstimation;
        }
        private double[] CalculateSumOfSquares(IReadOnlyList<Models.Data> valueArrayX, IReadOnlyList<Models.Data> valueArrayY, Matrix<double> beta)
        {
            var sumOfSquare = new double[2];
            for (var i = 0; i < valueArrayY[0].GetValuesList().Count; i++)
            {
                var fittedValue = beta[0, 0];
                for (var j = 0; j < valueArrayX.Count; j++)
                {
                    fittedValue = fittedValue + beta[j + 1, 0] * valueArrayX[j].GetValuesList()[i];
                }
                sumOfSquare[0] = sumOfSquare[0] + (fittedValue - _functions.Average(valueArrayY[0].Range)) * (fittedValue - _functions.Average(valueArrayY[0].Range));
                sumOfSquare[1] = sumOfSquare[1] + (valueArrayY[0].GetValuesList()[i] - fittedValue) * (valueArrayY[0].GetValuesList()[i] - fittedValue);
            }
            return sumOfSquare;
        }

        #endregion
    }
}