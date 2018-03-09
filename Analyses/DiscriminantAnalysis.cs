using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using NoruST.Models;

// ReSharper disable LocalizableElement
// ReSharper disable LoopCanBePartlyConvertedToQuery
// ReSharper disable LoopCanBeConvertedToQuery

namespace NoruST.Analyses
{
    /// <summary>
    /// <para>Discriminant Analysis.</para>
    /// <para>Version: 0.1</para>
    /// <para>&#160;</para>
    /// <para>Author: Thomas Van Rompaey</para>
    /// <para>Edited by: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 23, 2016</para>
    /// </summary>
    /// <remarks>This function is not yet finished or working like it does in the example. There is a lot that can be improved upon but the limited time we had was the problem.</remarks>
    public class DiscriminantAnalysis
    {
        #region Public Methods

        /// <summary>
        /// Print the Discriminant Analysis to a new <see cref="Microsoft.Office.Interop.Excel._Worksheet"/>.
        /// </summary>
        /// <param name="dataSet">The <see cref="DataSet"/> which needs (a) Scatterplot(s).</param>
        /// <param name="doIncludeX">A <see cref="List{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Models.Data"/> in the <see cref="DataSet.DataList"/> should be included for X.</param>
        /// <param name="doIncludeY">A <see cref="List{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Models.Data"/> in the <see cref="DataSet.DataList"/> should be included for Y.</param>
        /// <param name="probablility">The prior probability.</param>
        /// <param name="misclassification0">Misclassification cost 0 as 1.</param>
        /// <param name="misclassification1">Misclassification cost 1 as 0.</param>
        public bool Print(DataSet dataSet, List<bool> doIncludeX, List<bool> doIncludeY, string probablility, string misclassification0, string misclassification1)
        {
            var valuesArraysX = new List<Models.Data>();
            var valuesArraysY = new List<Models.Data>();
            var sheet = WorksheetHelper.NewWorksheet("Discriminant Analysis");

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

            // Tables location
            const int setupName = 3;
            const int summaryName = setupName + 4;
            const int functionName = summaryName + 4;
            var matrixName = functionName + valuesArraysX.Count + 2;
            var classificationName = matrixName + 4;
            var covarsName = classificationName + 5;
            var cutOffName = covarsName + valuesArraysX.Count + 2;
            var dataName = cutOffName + 3;
            var discrimName = valuesArraysX.Count + 2;

            // write tables
            sheet.Cells[1, 1] = "Discriminant Analysis";

            sheet.Cells[setupName, 1] = "Setup";
            sheet.Cells[setupName, 2] = "Prior Probability of 0";
            sheet.Cells[setupName, 3] = "Misclassication cost: 0 as 1";
            sheet.Cells[setupName, 4] = "Misclassication cost: 1 as 0";
            sheet.Cells[setupName + 1, 2] = probablility;
            sheet.Cells[setupName + 1, 3] = misclassification0;
            sheet.Cells[setupName + 1, 4] = misclassification1;

            sheet.Cells[summaryName, 1] = "Sample Summary";
            sheet.Cells[summaryName + 1, 1] = "0";
            sheet.Cells[summaryName + 2, 1] = "1";
            sheet.Cells[summaryName, 2] = "Sample Size";
            for (var i = 0; i < valuesArraysX.Count; i++)
            {
                sheet.Cells[summaryName, 3 + i] = "Mean " + valuesArraysX[i].Name;
            }

            sheet.Cells[functionName, 1] = "Discriminant Function";
            sheet.Cells[functionName, 2] = "Coefficient";
            for (var i = 0; i < valuesArraysX.Count; i++)
            {
                sheet.Cells[functionName + 1 + i, 1] = valuesArraysX[i].Name;
            }

            sheet.Cells[matrixName, 1] = "Classification Matrix";
            sheet.Cells[matrixName + 1, 1] = "0";
            sheet.Cells[matrixName + 2, 1] = "1";
            sheet.Cells[matrixName, 2] = "0";
            sheet.Cells[matrixName, 3] = "1";
            sheet.Cells[matrixName, 4] = "Correct";

            sheet.Cells[classificationName, 1] = "Classification Summary";
            sheet.Cells[classificationName + 1, 1] = "Correct";
            sheet.Cells[classificationName + 2, 1] = "Base";
            sheet.Cells[classificationName + 3, 1] = "Improvement";

            sheet.Cells[covarsName, 1] = "Covariance Matrix";
            for (var i = 0; i < valuesArraysX.Count; i++)
            {
                sheet.Cells[covarsName + 1 + i, 1] = valuesArraysX[i].Name;
                sheet.Cells[covarsName, 2 + i] = valuesArraysX[i].Name;
            }

            sheet.Cells[cutOffName, 1] = "Cut off ";


            sheet.Cells[dataName, 1] = "Data";
            for (var i = 0; i < valuesArraysX.Count; i++)
            {
                sheet.Cells[dataName, 2 + i] = valuesArraysX[i].Name;
            }
            sheet.Cells[dataName, discrimName] = "Discriminant";
            sheet.Cells[dataName, discrimName + 1] = "Class";
            sheet.Cells[dataName, discrimName + 2] = "Analysis";


            // create X matrix
            var matrixX = Matrix<double>.Build.Dense(valuesArraysX[0].GetValuesList().Count, valuesArraysX.Count);
            for (var i = 0; i < valuesArraysX[0].GetValuesList().Count; i++)
            {
                for (var j = 0; j < valuesArraysX.Count; j++)
                {
                    matrixX[i, j] = valuesArraysX[j].GetValuesArray()[i];
                }
            }

            var mean = new double[valuesArraysX.Count];
            var mean0 = Matrix<double>.Build.Dense(valuesArraysX.Count, 1);
            var mean1 = Matrix<double>.Build.Dense(valuesArraysX.Count, 1);

            // mean for all X
            for (var i = 0; i < valuesArraysX.Count; i++)
            {
                mean[i] = matrixX.Column(i).Average();
            }

            var n = valuesArraysY[0].GetValuesList().Count;
            var n0 = 0;
            var n1 = 0;

            var total0 = new double[valuesArraysX.Count];
            var total1 = new double[valuesArraysX.Count];
            //mean for X_0 and X_1, total elements n_0 and n_1
            for (var i = 0; i < valuesArraysY[0].GetValuesList().Count; i++)
            {
                if (valuesArraysY[0].GetValuesList()[i] == 0)
                {
                    n0++;
                    for (var j = 0; j < valuesArraysX.Count; j++)
                    {
                        total0[j] = total0[j] + valuesArraysX[j].GetValuesList()[i];
                    }
                }
                else
                {
                    n1++;
                    for (var j = 0; j < valuesArraysX.Count; j++)
                    {
                        total1[j] = total1[j] + valuesArraysX[j].GetValuesList()[i];
                    }
                }
            }
            sheet.Cells[summaryName + 1, 2] = n0;
            sheet.Cells[summaryName + 2, 2] = n1;
            for (var i = 0; i < valuesArraysX.Count; i++)
            {
                mean0[i, 0] = total0[i] / Convert.ToDouble(n0);
                mean1[i, 0] = total1[i] / Convert.ToDouble(n1);
                sheet.Cells[summaryName + 1, 3 + i] = mean0[i, 0];
                sheet.Cells[summaryName + 2, 3 + i] = mean1[i, 0];
            }

            // create X_average matrix
            var matrixXAver = Matrix<double>.Build.Dense(valuesArraysX[0].GetValuesList().Count, valuesArraysX.Count);
            for (var i = 0; i < valuesArraysY[0].GetValuesList().Count; i++)
            {
                if (valuesArraysY[0].GetValuesList()[i] == 0)
                {
                    for (var j = 0; j < valuesArraysX.Count; j++)
                    {
                        matrixXAver[i, j] = mean0[j, 0];
                    }
                }
                else
                {
                    for (var j = 0; j < valuesArraysX.Count; j++)
                    {
                        matrixXAver[i, j] = mean1[j, 0];
                    }
                }
            }

            var matrixXTransposed = matrixX.Transpose() * matrixX;
            var matrixXAverTransposed = matrixXAver.Transpose() * matrixXAver;
            var matrixS = Matrix<double>.Build.Dense(matrixXTransposed.RowCount, matrixXTransposed.ColumnCount);
            for (var i = 0; i < matrixS.RowCount; i++)
            {
                for (var j = 0; j < matrixS.ColumnCount; j++)
                {
                    matrixS[i, j] = (matrixXTransposed[i, j] - matrixXAverTransposed[i, j]) / (n - valuesArraysX.Count);
                    sheet.Cells[covarsName + 1 + i, 2 + j] = matrixS[i, j];
                }
            }

            var matrixSInv = matrixS.Inverse();
            var matrixResult = matrixSInv * (mean0 - mean1);

            for (var i = 0; i < matrixResult.RowCount; i++)
            {
                sheet.Cells[functionName + 1 + i, 2] = matrixResult[i, 0];
            }

            var z0 = mean0.Transpose() * matrixResult;
            var z1 = mean1.Transpose() * matrixResult;

            var cutOff = (z0[0, 0] + z1[0, 0]) / 2 + Math.Log(Convert.ToDouble(misclassification1) * (1 - Convert.ToDouble(probablility)) / Convert.ToDouble(misclassification0) / Convert.ToDouble(probablility));

            sheet.Cells[cutOffName + 1, 1] = cutOff;

            var correctClass0 = 0;
            var correctClass1 = 0;
            for (var i = 0; i < valuesArraysY[0].GetValuesList().Count; i++)
            {
                sheet.Cells[dataName + 1 + i, 1] = i + 1;
                double discrim = 0;
                for (var j = 0; j < valuesArraysX.Count; j++)
                {
                    sheet.Cells[dataName + 1 + i, j + 2] = valuesArraysX[j].GetValuesList()[i];
                    discrim = discrim + valuesArraysX[j].GetValuesList()[i] * matrixResult[j, 0];
                }
                sheet.Cells[dataName + 1 + i, discrimName] = discrim;
                sheet.Cells[dataName + 1 + i, discrimName + 1] = valuesArraysY[0].GetValuesList()[i];
                if (discrim > cutOff)
                {
                    sheet.Cells[dataName + 1 + i, discrimName + 2] = 0;
                    if (valuesArraysY[0].GetValuesList()[i] == 0)
                    {
                        correctClass0++;
                    }
                }
                else
                {
                    sheet.Cells[dataName + 1 + i, discrimName + 2] = 1;
                    if (valuesArraysY[0].GetValuesList()[i] == 1)
                    {
                        correctClass1++;
                    }
                }
            }
            sheet.Cells[matrixName + 1, 2] = correctClass0;
            sheet.Cells[matrixName + 1, 3] = n0 - correctClass0;
            sheet.Cells[matrixName + 2, 3] = correctClass1;
            sheet.Cells[matrixName + 2, 2] = n1 - correctClass1;
            sheet.Cells[matrixName + 1, 4] = Convert.ToDouble(correctClass0) / Convert.ToDouble(n0);
            sheet.Cells[matrixName + 2, 4] = Convert.ToDouble(correctClass1) / Convert.ToDouble(n1);

            var correct = Convert.ToDouble(correctClass0 + correctClass1) / Convert.ToDouble(n);
            double basis;
            if (Convert.ToDouble(n0) * 2 > Convert.ToDouble(n))
                basis = Convert.ToDouble(n0) / Convert.ToDouble(n);
            else
                basis = Convert.ToDouble(n1) / Convert.ToDouble(n);
            var improvement = (correct - basis) / (1 - basis);

            sheet.Cells[classificationName + 1, 2] = correct;
            sheet.Cells[classificationName + 2, 2] = basis;
            sheet.Cells[classificationName + 3, 2] = improvement;

            return true;
        }

        #endregion
    }
}