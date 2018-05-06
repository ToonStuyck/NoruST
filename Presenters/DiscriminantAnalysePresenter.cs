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

        //public void createRegression(List<Variable> variables)
        public void createDiscriminant(List<Variable> variablesD, List<Variable> variablesI, DataSet dataSet)
        {
            _Worksheet sheet = WorksheetHelper.NewWorksheet("Regression");
            sheet.Cells[100, 100] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variablesI[0].Range + ")";
            int length = Convert.ToInt32((sheet.Cells[100, 100] as Range).Value);
            sheet.Cells[100, 100] = "";

            int row = 1;
            int column = 1;
            sheet.Cells[1, 1] = "Regression Summary";
            sheet.Cells[2, 1] = "Multiple R";
            sheet.Cells[3, 1] = "R-square";
            sheet.Cells[4, 1] = "adjusted R-square";
            sheet.Cells[5, 1] = "stErr of Estimate";


            sheet.Cells[9, 1] = "ANOVA Table";
            sheet.Cells[10, 1] = "Explained";
            sheet.Cells[11, 1] = "Unexplained";
            sheet.Cells[8, 3] = "Sum of";
            sheet.Cells[9, 3] = "Squares";
            sheet.Cells[8, 2] = "Degrees of";
            sheet.Cells[9, 2] = "Freedom";
            sheet.Cells[8, 4] = "Mean";
            sheet.Cells[9, 4] = "Squares";
            sheet.Cells[9, 5] = "F-Ratio";
            sheet.Cells[9, 6] = "p-Value";


            sheet.Cells[15, 1] = "Regression Table";
            sheet.Cells[16, 1] = "Constant";
            row = 17;
            foreach (Variable var in variablesI)
            {
                sheet.Cells[row, 1] = var.name;
                row++;
            }

            sheet.Cells[15, 2] = "Coefficient";
            sheet.Cells[14, 3] = "Standard";
            sheet.Cells[15, 3] = "Error";
            sheet.Cells[15, 4] = "t-value";
            sheet.Cells[15, 5] = "p-value";
            sheet.Cells[14, 6] = "Confidence Interval";
            //sheet.Cells[14, 7] = ""; //value of given confidence interval
            sheet.Cells[15, 6] = "Lower";
            sheet.Cells[15, 7] = "Upper";







            ((Range)sheet.Cells[1, 1]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 2]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 3]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 4]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 5]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 6]).EntireColumn.AutoFit();
            sheet.get_Range("B1", "J200").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet.get_Range("A1", "B1").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            sheet.get_Range("A9", "F9").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            sheet.get_Range("A15", "G15").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            sheet.get_Range("B3", "B5").NumberFormat = "0.0000";
            //sheet.get_Range("B11", AddressConverter.CellAddress(14, variables.Count + 1, false, false)).NumberFormat = "0.000";
            sheet.get_Range("B18", "B20").NumberFormat = "0.0000";
            sheet.get_Range("D18", "E19").NumberFormat = "0.0000";

            //sheet.get_Range("B24", AddressConverter.CellAddress(23 + c, 2, false, false)).NumberFormat = "0.0000";
            //sheet.get_Range("C24", AddressConverter.CellAddress(23 + c, 8, false, false)).NumberFormat = "0.000000";
            //sheet.get_Range("C24", AddressConverter.CellAddress(23 + c, 8, false, false)).Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
            Globals.ExcelAddIn.Application.ActiveWindow.DisplayGridlines = false;

            int count = 0;
            double[] b = new double[variablesI.Count];
            double meansD = 0;
            double[] meansI = new double[variablesI.Count];

            //gemiddelde van elke (independant) kolom wordt berekend
            foreach (Variable var in variablesI)
            {
                string ran = variablesI[count].Range.ToString();
                Array arr = dataSet.getWorksheet().Range[ran].Value;
                double[] vals = new double[length];
                int count2 = 0;
                foreach (var item in arr)
                {
                    double temp = Convert.ToDouble(item);
                    vals[count2] = temp;
                    count2 = count2 + 1;
                }

                meansI[count] = sheet.Application.WorksheetFunction.Average(vals);
                System.Diagnostics.Debug.WriteLine(meansI[count]);
                count++;
            }

            //gemiddelde van elke dependant kolom wordt berekend
            foreach (Variable var in variablesD)
            {
                string ran = variablesD[0].Range.ToString();
                Array arr = dataSet.getWorksheet().Range[ran].Value;
                double[] vals = new double[length];
                int count2 = 0;
                foreach (var item in arr)
                {
                    double temp = Convert.ToDouble(item);
                    vals[count2] = temp;
                    count2 = count2 + 1;
                }

                meansD = sheet.Application.WorksheetFunction.Average(vals);
                System.Diagnostics.Debug.WriteLine(meansD);
            }




            count = 0;
            double temp1 = 0;
            double temp2 = 0;

            //bereken (Yi-Ygem)

            foreach (Variable var in variablesD)
            {
                string ran = variablesD[0].Range.ToString();
                Array arr = dataSet.getWorksheet().Range[ran].Value;
                double[] vals = new double[length];
                foreach (var item in arr)
                {
                    double temp = Convert.ToDouble(item);
                    temp2 = temp2 + (temp - meansD);
                }
                count++;

            }

            //bereken (Xi-Xgem)
            count = 0;
            foreach (Variable var in variablesI)
            {
                string ran = variablesI[count].Range.ToString();
                Array arr = dataSet.getWorksheet().Range[ran].Value;
                double[] vals = new double[length];
                foreach (var item in arr)
                {
                    double temp = Convert.ToDouble(item);
                    temp1 = temp1 + (temp - meansI[count]);
                }
                b[count] = (temp1 * temp2) / (length - 1) / (temp1 * temp1);    //formule zie slide 6 samenvatting H10, om de b van elke independant value te berekenen
                count++;
            }

            //waarde van a berekenen
            double a = meansD;
            int i = 0;
            while (i < b.Length)
            {
                a -= b[i] * meansI[i];
                i++;
            }

            sheet.Cells[16, 2] = a;
            row = 17;
            foreach (Variable var in variablesI)
            {
                sheet.Cells[row, 2] = b[row - 17];
                row++;
            }



        }
    }
}
