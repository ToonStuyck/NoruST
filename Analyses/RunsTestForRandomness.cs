using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NoruST.Models;

namespace NoruST.Analyses
{

    public class RunsTestForRandomness
    {

        public bool Print(DataSet dataSet, List<bool> doInclude, SummaryStatisticsBool doCalculate, string customCutoff)
        {
            // Check if the margin of error and the estimates are numbers.
            double customCutoffValue;

            if (!double.TryParse(customCutoff, out customCutoffValue))
            {
                MessageBox.Show("The Custom Cutoff Value is not a valid number.", "NoruST - Runs Test for Randomness", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var functions = Globals.ExcelAddIn.Application.WorksheetFunction;
            var sheet = WorksheetHelper.NewWorksheet("Runs Test");
            var valuesArrays = new List<Models.Data>();

            for (var j = 0; j < dataSet.DataList.Count; j++)
            {
                // Check if the Set of Data needs a Box-Whisker Plot. It will go to the next Set if the current one doesn't need one.
                if (!doInclude[j]) continue;

                // If the Set of Data needs a Box-Whisker Plot, add it to the list.
                valuesArrays.Add(dataSet.DataList[j]);
            }

            // Create several arrays to hold the data that is needed to create the charts.
            var names = new string[valuesArrays.Count];
            var observations = new double[valuesArrays.Count];
            var cutoff = new double[valuesArrays.Count];
            var bCutoff = new double[valuesArrays.Count];
            var aCutoff = new double[valuesArrays.Count];
            var runs = new double[valuesArrays.Count];
            var expected = new double[valuesArrays.Count];
            var stdDev = new double[valuesArrays.Count];
            var zValue = new double[valuesArrays.Count];
            var pValue = new double[valuesArrays.Count];

            for (var i = 0; i < valuesArrays.Count; i++)
            {
                // Add them to their respective arrays.
                names[i] = valuesArrays[i].Name;
                if (doCalculate.Mean)
                    cutoff[i] = functions.Average(valuesArrays[i].Range);
                else if (doCalculate.Median)
                    cutoff[i] = functions.Median(valuesArrays[i].Range);
                else
                    throw new NotImplementedException();

                bCutoff[i] = 0;
                aCutoff[i] = 0;

                var control = "";

                // Calculate below and above cutoff, total number of runs
                foreach (var value in valuesArrays[i].GetValuesArray())
                {
                    if (value <= cutoff[i])
                    {
                        bCutoff[i]++;
                        if (control == "below")
                        {
                        }
                        else
                        {
                            runs[i]++;
                            control = "below";
                        }
                    }
                    else
                    {
                        aCutoff[i]++;
                        if (control == "above")
                        {
                        }
                        else
                        {
                            runs[i]++;
                            control = "above";
                        }
                    }
                    observations[i]++;

                }
                expected[i] = 2 * (bCutoff[i] * aCutoff[i]) / observations[i] + 1;
                stdDev[i] = Math.Sqrt((expected[i] - 1) * (expected[i] - 2) / (observations[i] - 1));
                zValue[i] = (runs[i] - expected[i]) / stdDev[i];
                pValue[i] = 2 * (1 - functions.NormSDist(Math.Abs(zValue[i])));

                sheet.Cells[1, i + 2] = names[i];
                sheet.Cells[2, i + 2] = observations[i];
                sheet.Cells[3, i + 2] = bCutoff[i];
                sheet.Cells[4, i + 2] = aCutoff[i];
                sheet.Cells[5, i + 2] = runs[i];
                sheet.Cells[6, i + 2] = cutoff[i];
                sheet.Cells[7, i + 2] = expected[i];
                sheet.Cells[8, i + 2] = stdDev[i];
                sheet.Cells[9, i + 2] = zValue[i];
                sheet.Cells[10, i + 2] = pValue[i];
            }
            string cutoffName;
            if (doCalculate.Mean)
                cutoffName = "mean";
            else if (doCalculate.Median)
                cutoffName = "median";
            else
                cutoffName = "cutoff";

            sheet.Cells[1, 1] = "name";
            sheet.Cells[2, 1] = "observations";
            sheet.Cells[3, 1] = "below " + cutoffName;
            sheet.Cells[4, 1] = "above" + cutoffName;
            sheet.Cells[5, 1] = "number of runs";
            sheet.Cells[6, 1] = cutoffName;
            sheet.Cells[7, 1] = "E(R)";
            sheet.Cells[8, 1] = "stdDev(R)";
            sheet.Cells[9, 1] = "z-Value";
            sheet.Cells[10, 1] = "p-Value";

            return true;
        }
    }
}