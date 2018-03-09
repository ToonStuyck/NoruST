using System;
using System.Collections.Generic;
using NoruST.Models;
using Microsoft.Office.Interop.Excel;

namespace NoruST
{
    public partial class ExcelAddIn
    {
        #region Startup / Shutdown

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }

        #endregion

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddIn_Startup;
            Shutdown += ThisAddIn_Shutdown;
        }

        #endregion

        /// <summary>
        /// A list with the different <see cref="DataSet"/>s in the document.
        /// </summary>
        public List<DataSet> DataSets { get; set; } = new List<DataSet>();

        public _Worksheet getActiveWorksheet()
        {
            return Application.ActiveSheet;
        }

        public void evaluate(string formula)
        {
            Application.Evaluate(formula);
        }

        public Range getCurrentSelectionRange()
        {
            return getActiveWorksheet().Cells.Application.Selection;
        }

        public bool doRangesIntersect(Range firstRange, Range secondRange)
        {
            return firstRange != null && secondRange != null && Application.Intersect(firstRange, secondRange) != null;
        }

        public bool doesSelectedRangeIntersectWith(Range range)
        {
            return doRangesIntersect(range, getCurrentSelectionRange());
        }

        public Range getExpandedCurrentRange()
        {
            return iterativelyExpandRange(getCurrentSelectionRange(), getActiveWorksheet());
        }

        private Range iterativelyExpandRange(Range range, _Worksheet worksheet, bool foundFirstRow = false, bool foundFirstColumn = false, bool foundLastRow = false, bool foundLastColumn = false)
        {
            int firstRowIndex = range.Row;
            int firstColumnIndex = range.Column;
            int lastRowIndex = range.Row + range.Rows.Count - 1;
            int lastColumnIndex = range.Column + range.Columns.Count - 1;

            // Check if the cell a row higher has a value.
            if (!foundFirstRow && range.Row != 1 && ((Range)worksheet.Cells[firstRowIndex - 1, firstColumnIndex]).Value2 != null)
            {
                firstRowIndex -= 1;
                if (firstRowIndex == 1)
                    foundFirstRow = true;
            }
            else
                foundFirstRow = true;

            // Check if the cell a column before has a value.
            if (!foundFirstColumn && range.Column != 1 && ((Range)worksheet.Cells[firstRowIndex, firstColumnIndex - 1]).Value2 != null)
            {
                firstColumnIndex -= 1;
                if (firstColumnIndex == 1)
                    foundFirstColumn = true;
            }
            else foundFirstColumn = true;

            // Check if the cell a row lower has a value.
            if (!foundLastRow && ((Range)worksheet.Cells[lastRowIndex + 1, lastColumnIndex]).Value2 != null)
                lastRowIndex += 1;
            else
                foundLastRow = true;

            // Check if the cell a column after has a value.
            if (!foundLastColumn && ((Range)worksheet.Cells[lastRowIndex, lastColumnIndex + 1]).Value2 != null)
                lastColumnIndex += 1;
            else
                foundLastColumn = true;

            range = worksheet.Range[worksheet.Cells[firstRowIndex, firstColumnIndex], worksheet.Cells[lastRowIndex, lastColumnIndex]];

            return (foundFirstRow && foundFirstColumn && foundLastRow && foundLastColumn) ?
                range :
                iterativelyExpandRange(range, worksheet, foundFirstRow, foundFirstColumn, foundLastRow, foundLastColumn);
        }

    }
}