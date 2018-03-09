using System;
using Microsoft.Office.Interop.Excel;

namespace NoruST
{
    public static class AddressConverter
    {
        public static string Address(this Range range, bool absoluteRow = false, bool absoluteColumn = false, bool external = false)
        {
            try
            {
                return range.AddressLocal[absoluteRow, absoluteColumn, XlReferenceStyle.xlA1, external];
            }
            catch (Exception exception)
            {
                return "";
            }
        }

        public static string CellAddress(int row, int column, bool absoluteRow = true, bool absoluteColumn = true)
        {
            Worksheet sheet = (Worksheet)Globals.ExcelAddIn.Application.ActiveSheet;

            return sheet.Cells[row, column].Address(absoluteRow, absoluteColumn);
        }

        public static Range shiftRangeByColumns(this Range range, int numberOfColumnsToShift)
        {
            Worksheet sheet = (Worksheet)Globals.ExcelAddIn.Application.ActiveSheet;
            return sheet.Range[
                sheet.Cells[
                    range.Row, 
                    range.Column + numberOfColumnsToShift], 
                sheet.Cells[
                    range.Row + range.Rows.Count - 1, 
                    range.Column + numberOfColumnsToShift + range.Columns.Count - 1]];
        }

        public static Range shiftRangeByRows(this Range range, int numberOfRowsToShift)
        {
            Worksheet sheet = (Worksheet)Globals.ExcelAddIn.Application.ActiveSheet;
            return sheet.Range[
                sheet.Cells[
                    range.Row + numberOfRowsToShift,
                    range.Column],
                sheet.Cells[
                    range.Row + numberOfRowsToShift + range.Rows.Count - 1,
                    range.Column + range.Columns.Count - 1]];
        }

        public static Range extendRangeByColumns(this Range range, int numberOfColumnsToExtend, bool right = true)
        {
            Worksheet sheet = (Worksheet)Globals.ExcelAddIn.Application.ActiveSheet;
            return right
                ? sheet.Range[
                    sheet.Cells[
                        range.Row,
                        range.Column],
                    sheet.Cells[
                        range.Row + range.Rows.Count - 1,
                        range.Column + numberOfColumnsToExtend + range.Columns.Count - 1]]
                : sheet.Range[
                    sheet.Cells[
                        range.Row,
                        range.Column + range.Columns.Count - 1],
                    sheet.Cells[
                        range.Row + range.Rows.Count - 1,
                        range.Column - numberOfColumnsToExtend]];

        }

        public static Range extendRangeByRows(this Range range, int numberOfRowsToExtend, bool down = true)
        {
            Worksheet sheet = (Worksheet)Globals.ExcelAddIn.Application.ActiveSheet;
            return down
                ? sheet.Range[
                    sheet.Cells[
                        range.Row,
                        range.Column],
                    sheet.Cells[
                        range.Row + numberOfRowsToExtend + range.Rows.Count - 1,
                        range.Column + range.Columns.Count - 1]]
                : sheet.Range[
                    sheet.Cells[
                        range.Row + range.Rows.Count - 1,
                        range.Column],
                    sheet.Cells[
                        range.Row - numberOfRowsToExtend,
                        range.Column + range.Columns.Count - 1]];

        }

        public static Range first(this Range range)
        {
            Worksheet sheet = (Worksheet)Globals.ExcelAddIn.Application.ActiveSheet;
            return sheet.Cells[range.Row, range.Column];
        }
    }
}