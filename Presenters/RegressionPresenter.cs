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
using MathNet.Numerics.LinearRegression;
using MathNet;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NoruST.Presenters
{
	public class RegressionPresenter
	{
		private RegressionForm view;
		private RegressionModel model;
		private DataSetManagerPresenter dataSetPresenter;

		public RegressionPresenter(DataSetManagerPresenter dataSetPresenter)
		{
			this.dataSetPresenter = dataSetPresenter;
			model = new RegressionModel();
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
		public void createRegression(List<Variable> variablesD, List<Variable> variablesI, DataSet dataSet)
		{
			_Worksheet sheet = WorksheetHelper.NewWorksheet("Regression");
			sheet.Cells[100, 100] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variablesI[0].Range + ")";
			int length = Convert.ToInt32((sheet.Cells[100,100] as Range).Value);
			sheet.Cells[100, 100] = "";

			int row = 1;
			int column = 1;
			sheet.Cells[1, 1] = "Regression Summary";
			sheet.Cells[2, 1] = "R";
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

			double[] b = new double[variablesI.Count];
            double[] yData = calcYdata(variablesD, dataSet, length);
            double[,] xData = calcXdata(length, dataSet, variablesI);

            b = calculateCoefB(yData, xData, b);
            double a = b[0];

			sheet.Cells[16, 2] = a;
			row = 17;
			foreach (Variable var in variablesI)
			{
				sheet.Cells[row, 2] = b[row-16];
				row++;
			}

            var X = DenseMatrix.OfArray(xData);
            var B = new DenseVector(b);
            var Y = new DenseVector(yData);
            var yh = X.Multiply(B);
            var er = Y.Subtract(yh);
            double[] error = er.ToArray();

            double[] yhat = yh.ToArray();

            double R2 = sheet.Application.WorksheetFunction.Correl(yData, yhat);
            double R = Math.Pow(R2,2);
            double Radj = 1.0 - ((1-R)*(length-1)/(length-variablesI.Count-1));
            double err = 0;
            int i = 0;
            while (i < error.Length)
            {
                err = err + Math.Pow(error[i], 2);
                i++;
            }
            err = Math.Sqrt(err / (length - 4));

            FillR(sheet, R2, R, Radj, err);
            FillAnova(sheet);


        }

        public void FillAnova(_Worksheet sheet)
        {
            sheet.Cells[9, 1] = "ANOVA Table";
            sheet.Cells[10, 1] = "Explained";
            sheet.Cells[11, 1] = "Unexplained";
            sheet.Cells[10, 3] = "Squares";
            sheet.Cells[11, 3] = "Squares";
            sheet.Cells[10, 2] = "Freedom";
            sheet.Cells[11, 2] = "Freedom";
            sheet.Cells[10, 4] = "Squares";
            sheet.Cells[11, 4] = "Squares";
            sheet.Cells[10, 5] = "F-Ratio";
            sheet.Cells[10, 6] = "p-Value";
        }

        public void FillR(_Worksheet sheet, double R2, double R, double Radj, double err)
        {
            sheet.Cells[2, 2] = R2;
            sheet.Cells[3, 2] = R;
            sheet.Cells[4, 2] = Radj;
            sheet.Cells[5, 2] = err;
        }

        public double[] calcYdata(List<Variable> variablesD, DataSet dataSet, int length)
        {
            //bereken (Yi-Ygem)
            int count = 0;
            double[] yData = new double[length];
            foreach (Variable var in variablesD)
            {
                string ran = variablesD[0].Range.ToString();
                Array arr = dataSet.getWorksheet().Range[ran].Value;
                double[] vals = new double[length];
                foreach (var item in arr)
                {
                    double temp = Convert.ToDouble(item);
                    yData[count] = temp;
                    //temp2[count] = (temp - meansD);
                    count++;
                }
            }
            return yData;
        }

        public double[,] calcXdata(int length, DataSet dataSet, List<Variable> variablesI)
        {
            int count = 0;
            double[,] xData = new double[length, variablesI.Count + 1];
            //bereken (Xi-Xgem)
            while (count < length)
            {
                xData[count, 0] = 1;
                count++;
            }
            count = 0;
            foreach (Variable var in variablesI)
            {
                int i = 0;
                string ran = variablesI[count].Range.ToString();
                Array arr = dataSet.getWorksheet().Range[ran].Value;
                double[] vals = new double[length];
                foreach (var item in arr)
                {
                    double temp = Convert.ToDouble(item);
                    xData[i, count + 1] = temp;
                    //xData[count,i] = (temp - meansI[count]);
                    i++;
                }
                count++;
            }
            return xData;
        }

        public double[] calculateCoefB(double[] yData, double[,] xData, double[] b)
        {
            var X = DenseMatrix.OfArray(xData);
            var y = new DenseVector(yData);

            var p = X.QR().Solve(y);
            b = p.ToArray();

            return b;
        }
	}
}
