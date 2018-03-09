using System;
using Microsoft.Office.Interop.Excel;

namespace NoruST
{
    public static class RangeHelper
    {
        public static Range ExpandSelection(this Range range, _Worksheet sheet, bool foundFirstRow = false, bool foundFirstColumn = false, bool foundLastRow = false, bool foundLastColumn = false)
        {
            // Check for invalid arguments.
            if (sheet == null) throw new ArgumentNullException(nameof(sheet));
            if (range == null) throw new ArgumentNullException(nameof(range));

            // Declare some variables for later.
            var firstRow = range.Row;
            var firstColumn = range.Column;
            var lastRow = range.Row + range.Rows.Count - 1;
            var lastColumn = range.Column + range.Columns.Count - 1;

            // Check if the cell a row higher has a value.
            if (!foundFirstRow && range.Row != 1 && ((Range)sheet.Cells[firstRow - 1, firstColumn]).Value2 != null)
            {
                firstRow -= 1;
                if (firstRow == 1)
                    foundFirstRow = true;
            }
            else
                foundFirstRow = true;

            // Check if the cell a column before has a value.
            if (!foundFirstColumn && range.Column != 1 && ((Range)sheet.Cells[firstRow, firstColumn - 1]).Value2 != null)
            {
                firstColumn -= 1;
                if (firstColumn == 1)
                    foundFirstColumn = true;
            }
            else foundFirstColumn = true;

            // Check if the cell a row lower has a value.
            if (!foundLastRow && ((Range)sheet.Cells[lastRow + 1, lastColumn]).Value2 != null)
                lastRow += 1;
            else
                foundLastRow = true;

            // Check if the cell a column after has a value.
            if (!foundLastColumn && ((Range)sheet.Cells[lastRow, lastColumn + 1]).Value2 != null)
                lastColumn += 1;
            else
                foundLastColumn = true;

            // Set the new range to check.
            range = sheet.Range[sheet.Cells[firstRow, firstColumn], sheet.Cells[lastRow, lastColumn]];

            // Check the new range for more missing data.
            if (!foundFirstRow || !foundFirstColumn || !foundLastRow || !foundLastColumn)
                range = range.ExpandSelection(sheet, foundFirstRow, foundFirstColumn, foundLastRow, foundLastColumn);

            // Return the new found range
            return range;
        }

        public static double[,] To2DDoubleArray(this Range range)
        {
            double[,] values = new double[range.Rows.Count,range.Columns.Count];
            Array.Copy(range.Value2, values, range.Columns.Count * range.Rows.Count);
            return values;
        }
    }
}