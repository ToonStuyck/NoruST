using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace NoruST.Models
{
    public class CategoryDataSet
    {
        #region Public Methods

        public DataSet DataSet(_Worksheet sheet, Data categoryData, List<Data> valueData, int row, int column)
        {
            var firstRow = row;
            var firstColumn = column;
            foreach (var category in categoryData.GetCategories())
                foreach (var data in valueData)
                {
                    row = firstRow;
                    sheet.Cells[row++, column] = data.Name + " (" + category + ")";

                    for (var i = 1; i <= data.GetCount(); i++)
                        sheet.Cells[row++, column] = "=IF(INDEX(" + categoryData.RangeName.Name + "," + i + ")=\"" + category + "\",IF(INDEX(" + data.RangeName.Name + "," + i + ")<>0,INDEX(" + data.RangeName.Name + "," + i + "),\"\"),\"\")";
                    column++;
                }

            return new DataSet(sheet, sheet.Range[sheet.Cells[firstRow, firstColumn], sheet.Cells[firstRow + row - 2, firstColumn + column - 2]]);
        }

        #endregion
    }
}