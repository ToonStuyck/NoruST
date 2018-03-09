using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using NoruST.Models;

// ReSharper disable LocalizableElement

namespace NoruST.Analyses
{
    /// <summary>
    /// <para>Sample Size.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 21, 2016</para>
    /// </summary>
    public class SampleSize
    {
        #region Public Methods

        /// <summary>
        /// Print the Summary Statistics to a new <see cref="_Worksheet"/>.
        /// </summary>
        /// <param name="doCalculate">A collection of <see cref="bool"/>s that indicate which summary statistic has to be calculated.</param>
        /// <param name="confidenceLevel">The confidence level.</param>
        /// <param name="marginOfError">The margin of error.</param>
        /// <param name="estimated1">The estimated Standard Deviation or Proportion.</param>
        /// <param name="estimated2">The 2nd estimated proportion.</param>
        /// <param name="row">(Optional) The first row the data will be written to. Default is 1.</param>
        /// <param name="column">(Optional) The first column the data will be written to. Default is 1.</param>
        /// <param name="sheetName">(Optional) The name of the sheet. Default is 'Sample Size'.</param>
        /// <returns>A <see cref="bool"/> that indicates if the print was successful or not.</returns>
        /// <remarks><see cref="estimated2"/> is only used for the calculation of the <see cref="SummaryStatisticsBool.DifferenceOfProportionsSampleSize"/>.</remarks>
        public bool Print(SummaryStatisticsBool doCalculate, int confidenceLevel, string marginOfError, string estimated1, string estimated2, int row = 1, int column = 1, string sheetName = "Sample Size")
        {
            // Check if the margin of error and the estimates are numbers.
            double marginOfErrorValue, estimated1Value, estimated2Value;

            if (!double.TryParse(marginOfError, out marginOfErrorValue))
            {
                MessageBox.Show("The Margin of Error is not a valid number.", "NoruST - Sample Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(estimated1.Replace(" ", "").Replace(",", ".").Trim(), out estimated1Value))
            {
                MessageBox.Show("The Estimation is not a valid number.", "NoruST - Sample Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (doCalculate.DifferenceOfProportionsSampleSize && !double.TryParse(estimated2.Replace(" ", "").Replace(",", ".").Trim(), out estimated2Value))
            {
                MessageBox.Show("The 2nd Estimation is not a valid number.", "NoruST - Sample Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Create a new sheet for the chart if none was provided.
            var sheet = WorksheetHelper.NewWorksheet(sheetName);

            // Print the categories and calculated variables to the sheet.
            if (doCalculate.MeanSampleSize)
                sheet.Cells[row++, column] = "Sample Size for Mean";
            if (doCalculate.ProportionSampleSize)
                sheet.Cells[row++, column] = "Sample Size for Proportion";
            if (doCalculate.DifferenceOfMeansSampleSize)
                sheet.Cells[row++, column] = "Sample Size for Difference of Means";
            if (doCalculate.DifferenceOfProportionsSampleSize)
                sheet.Cells[row++, column] = "Sample Size for Difference of Proportions";

            sheet.Cells[row, column] = "Confidence Level";
            var confidenceLevelRow = row;
            sheet.Cells[row, column + 1] = confidenceLevel / 100.0;
            ((Range)sheet.Cells[row++, column + 1]).NumberFormat = "0.00%";
            sheet.Cells[row, column] = "Alpha";
            var alphaRow = row;
            sheet.Cells[row++, column + 1] = "=1-" + AddressConverter.CellAddress(confidenceLevelRow, column + 1);
            sheet.Cells[row, column] = "Margin of Error";
            var marginOfErrorRow = row;
            sheet.Cells[row++, column + 1] = marginOfErrorValue;

            if (doCalculate.MeanSampleSize)
                sheet.Cells[row, column] = "Estimated Standard Deviation";
            if (doCalculate.ProportionSampleSize)
                sheet.Cells[row, column] = "Estimated Proportion";
            if (doCalculate.DifferenceOfMeansSampleSize)
                sheet.Cells[row, column] = "Estimated Common Standard Deviation";
            if (doCalculate.DifferenceOfProportionsSampleSize)
                sheet.Cells[row, column] = "Estimated Proportion 1";

            var estimate1Row = row;
            sheet.Cells[row++, column + 1] = estimated1;

            var estimate2Row = 0;
            if (doCalculate.DifferenceOfProportionsSampleSize)
            {
                sheet.Cells[row, column] = "Estimated Proportion 2";
                estimate2Row = row;
                sheet.Cells[row++, column + 1] = estimated2;
            }

            sheet.Cells[row, column] = "Sample Size";

            if (doCalculate.MeanSampleSize)
                sheet.WriteFunction(row, column + 1, "CEILING.MATH(T.INV.2T(" + AddressConverter.CellAddress(alphaRow, column + 1) + ",1000000)^2*" + AddressConverter.CellAddress(estimate1Row, column + 1) + "^2/" + AddressConverter.CellAddress(marginOfErrorRow, column + 1) + "^2)");
            if (doCalculate.ProportionSampleSize)
                sheet.WriteFunction(row, column + 1, "CEILING.MATH(T.INV.2T(" + AddressConverter.CellAddress(alphaRow, column + 1) + ",1000000)^2*" + AddressConverter.CellAddress(estimate1Row, column + 1) + "*(1-" + AddressConverter.CellAddress(estimate1Row, column + 1) + ")/" + AddressConverter.CellAddress(marginOfErrorRow, column + 1) + "^2)");
            if (doCalculate.DifferenceOfMeansSampleSize)
                sheet.WriteFunction(row, column + 1, "CEILING.MATH(2*T.INV.2T(" + AddressConverter.CellAddress(alphaRow, column + 1) + ",1000000)^2*" + AddressConverter.CellAddress(estimate1Row, column + 1) + "^2/" + AddressConverter.CellAddress(marginOfErrorRow, column + 1) + "^2)");
            if (doCalculate.DifferenceOfProportionsSampleSize)
                sheet.WriteFunction(row, column + 1, "CEILING.MATH(T.INV.2T(" + AddressConverter.CellAddress(alphaRow, column + 1) + ",1000000)^2*(" + AddressConverter.CellAddress(estimate1Row, column + 1) + "*(1-" + AddressConverter.CellAddress(estimate1Row, column + 1) + ")+" + AddressConverter.CellAddress(estimate2Row, column + 1) + "*(1-" + AddressConverter.CellAddress(estimate2Row, column + 1) + "))/" + AddressConverter.CellAddress(marginOfErrorRow, column + 1) + "^2)");

            return true;
        }

        #endregion
    }
}