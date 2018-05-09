using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoruST.Forms;
using NoruST.Models;
using NoruST.Presenters;
using NoruST.Domain;
using DataSet = NoruST.Domain.DataSet;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace NoruST.Presenters
{
    public class DiscriminantAnalysePresenter
    {
        private DiscriminantAnalyseForm view;
        private DiscriminantAnalyseModel model;
        private DataSetManagerPresenter dataSetPresenter;

        public DiscriminantAnalysePresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            model = new DiscriminantAnalyseModel();
        }

        public void openView()
        {
            view = view.createAndOrShowForm();
            view.setPresenter(this);
        }

        public BindingList<DataSet> dataSets()
        {
            return dataSetPresenter.getModel().getDataSets();
        }

        public static int ColumnLetterToColumnIndex(string columnLetter)
        {
            columnLetter = columnLetter.ToUpper();
            int sum = 0;

            for (int i = 0; i < columnLetter.Length; i++)
            {
                sum *= 26;
                sum += (columnLetter[i] - 'A' + 1);
            }
            return sum;
        }

        static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }

        //public void createRegression(List<Variable> variables)
        public void createDiscriminant(List<Variable> variablesD, List<Variable> variablesI, DataSet dataSet)
        {
            _Worksheet sheet = WorksheetHelper.NewWorksheet("Discriminant");
            sheet.Cells[100, 100] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variablesI[0].Range + ")";
            int length = Convert.ToInt32((sheet.Cells[100, 100] as Range).Value);
            sheet.Cells[100, 100] = "";

            int row = 1;
            int column = 1;
            sheet.Cells[2, 1] = "Sample Summary";
            sheet.Cells[3, 1] = "No";
            sheet.Cells[4, 1] = "Yes";

            sheet.Cells[1, 2] = "Sample";
            sheet.Cells[2, 2] = "Size";

            int i = 0;
            while (i<variablesI.Count)
            {
                sheet.Cells[1, 3+i] = "Mean";
                sheet.Cells[2, 3+i] = variablesI[i].name;
                sheet.Cells[8 + i, 1] = variablesI[i].name;
                i++;
            }
            row = 8 + i - 1 + 3;
            string let = ColumnIndexToColumnLetter(3 + i - 1);

            sheet.get_Range("A2", "J200").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet.get_Range("A2", let+"2").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

            sheet.Cells[7, 1] = "Discriminant Function";
            sheet.Cells[7, 2] = "Coefficient";

            sheet.get_Range("A7", "B7").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

            sheet.Cells[row, 1] = "Classification Matrix";
            sheet.Cells[row, 2] = "No";
            sheet.Cells[row, 3] = "Yes";
            sheet.Cells[row, 4] = "Correct";

            string num = Convert.ToString(row);

            row++;
            sheet.Cells[row++, 1] = "No";
            sheet.Cells[row, 1] = "Yes";

            sheet.get_Range("A"+num, "D"+num).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

            row = row + 3;
            num = Convert.ToString(row);
            sheet.Cells[row++, 1] = "Summary Classification";
            sheet.Cells[row++, 1] = "Correct";
            sheet.Cells[row++, 1] = "Base";
            sheet.Cells[row, 1] = "Improvement";
            sheet.get_Range("A" + num, "B" + num).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

            sheet.get_Range("B3", "B5").NumberFormat = "0.0000";
            //sheet.get_Range("B11", AddressConverter.CellAddress(14, variables.Count + 1, false, false)).NumberFormat = "0.000";
            sheet.get_Range("B18", "B20").NumberFormat = "0.0000";
            sheet.get_Range("D18", "E19").NumberFormat = "0.0000";

            //sheet.get_Range("B24", AddressConverter.CellAddress(23 + c, 2, false, false)).NumberFormat = "0.0000";
            //sheet.get_Range("C24", AddressConverter.CellAddress(23 + c, 8, false, false)).NumberFormat = "0.000000";
            //sheet.get_Range("C24", AddressConverter.CellAddress(23 + c, 8, false, false)).Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
            Globals.ExcelAddIn.Application.ActiveWindow.DisplayGridlines = false;


            ((Range)sheet.Cells[1, 1]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 2]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 3]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 4]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 5]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 6]).EntireColumn.AutoFit();
            
        }
    }
}
