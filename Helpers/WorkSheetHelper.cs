using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace NoruST
{
    /// <summary>
    /// <para>WorksheetHelper.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 22, 2016</para>
    /// </summary>
    public static class WorksheetHelper
    {
        /// <summary>
        /// Add a new <see cref="_Worksheet"/> to the <see cref="_Workbook"/>.
        /// </summary>
        /// <param name="after">(Optional) The <see cref="_Worksheet"/> after which it must be added.</param>
        /// <param name="name"></param>
        /// <returns>The new <see cref="_Worksheet"/>.</returns>
        public static _Worksheet NewWorksheet(string name = null, _Worksheet after = null)
        {
            // Check if a worksheet is provided to add the new one after. If that is not the case, use the source sheet.
            if (after == null)
                after = Globals.ExcelAddIn.DataSets.Count == 0 ? Globals.ExcelAddIn.Application.ActiveWorkbook.Sheets[1] : Globals.ExcelAddIn.DataSets[0].Sheet;

            // Add the new sheet to the workbook.
            var sheet = (Worksheet)Globals.ExcelAddIn.Application.Worksheets.Add(After: after);

            // If a name is provided, also rename the sheet.
            if (!string.IsNullOrEmpty(name))
                sheet.Rename(name);

            // Return the newly added (and renamed) sheet.
            return sheet;
        }

        /// <summary>
        /// Safely rename the worksheet with the given name. If the sheet already exists a number will be added after the name.
        /// </summary>
        public static void Rename(this _Worksheet sheet, string name, int number = 0)
        {
            try
            {
                // Try to rename the sheet with the new name. If the number is not 0, add it to the sheet name.
                // The number is automatically incremented if a sheet with a similar name already exists.
                sheet.Name = number == 0 ? name : name + " " + number;
            }
            catch (COMException)
            {
                // If renaming the sheet failed because of a duplicate name, try again with an incremented number.
                sheet.Rename(name, ++number);
            }
        }

        /// <summary>
        /// Write a function to the <see cref="_Worksheet"/>. This will translate the English function to the localized one.
        /// </summary>
        /// <param name="sheet">The <see cref="_Worksheet"/>.</param>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <param name="function">The Excel function.</param>
        /// <returns>The row index.</returns>
        public static int WriteFunction(this _Worksheet sheet, int row, int column, string function)
        {
            ((Range)sheet.Cells[row, column]).Formula = "=" + function;
            var formulaLocal = ((Range)sheet.Cells[row, column]).FormulaLocal;
            ((Range)sheet.Cells[row, column]).FormulaLocal = formulaLocal;

            return row;
        }
    }
}