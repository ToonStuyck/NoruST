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
		private int nrOfGraphs = 0;
		private int lowestDataRow = 0;

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

		public void resetNrofGraphs()
		{
			nrOfGraphs = 0;
		}

		public void setPrediction(bool value)
		{
			model.doPrediction = value;
		}

		public void setConfLevel(double value)
		{
			model.confidenceLevel = value;
		}
		public void setPredictionLevel(double value)
		{
			model.predictionLevel = value;
		}
		public void setDW(bool value)
		{
			model.doDurbinWatson = value;
		}

		public void createRegression(List<Variable> variablesD, List<Variable> variablesI, DataSet dataSet, DataSet dataSet2, bool[] graphs, List<Variable> variablesPrediction)
		{
			_Worksheet sheet = WorksheetHelper.NewWorksheet("Regression");
			double confLevel = model.confidenceLevel;

			sheet.Cells[100, 100] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variablesI[0].Range + ")";
			int length = Convert.ToInt32((sheet.Cells[100,100] as Range).Value);
			sheet.Cells[100, 100] = "";

			int row = 1;
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
			lowestDataRow = row;

			sheet.Cells[15, 2] = "Coefficient";
			sheet.Cells[14, 3] = "Standard";
			sheet.Cells[15, 3] = "Error";
			sheet.Cells[15, 4] = "t-value";
			sheet.Cells[15, 5] = "p-value";
			sheet.Cells[14, 6] = "Confidence Interval " + confLevel.ToString() + "%";
			sheet.Range[sheet.Cells[14, 6], sheet.Cells[14, 7]].Merge();
			sheet.Cells[15, 6] = "Lower";
			sheet.Cells[15, 7] = "Upper";


			sheet.get_Range("B1", "J200").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
			sheet.get_Range("A1", "B1").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
			sheet.get_Range("A9", "F9").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
			sheet.get_Range("A15", "G15").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
			sheet.get_Range("B3", "B5").NumberFormat = "0.0000";
			sheet.get_Range("B18", "B20").NumberFormat = "0.0000";
			sheet.get_Range("D18", "E19").NumberFormat = "0.0000";

		Globals.ExcelAddIn.Application.ActiveWindow.DisplayGridlines = false;


			//
			//calculate values of regression
			//
			double[] b = new double[variablesI.Count];
            double[] yData = calcYdata(variablesD, dataSet, length);
            double[,] xData = calcXdata(length, dataSet, variablesI);


            b = calculateCoefB(yData, xData, b);
            double a = b[0];

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

			
			double[] anovaResults = calculateAnova(yData, yhat, variablesI.Count(), sheet);

			multicollinearity(sheet, xData, variablesI.Count);
			if (model.doDurbinWatson == true)
				DurbinWatson(sheet, error);

			//
			//Calculate regressionTable
			//
			double MSE = anovaResults[6];
			var Xt = X.Transpose();
			var tempM = (Xt.Multiply(X)).Inverse();
			var variancesM = tempM.Multiply(MSE);
			double[] variances = variancesM.Diagonal().ToArray();
			double[] std = new double[variances.Length];

			int index = 0;
			foreach(double elem in variances)
			{
				std[index] = Math.Sqrt(elem);
				//System.Diagnostics.Debug.WriteLine(std[index]);
				index++;
			}

			double[] tValue = new double[b.Length];
			double[] pValue = new double[b.Length];
			double[] lowerInt = new double[b.Length];
			double[] higherInt = new double[b.Length];
			for(index = 0; index < b.Length; index++)
			{
				tValue[index] = b[index] / std[index];
				pValue[index] = sheet.Application.WorksheetFunction.TDist(Math.Abs(tValue[index]), length - variablesI.Count - 1, 2);
				lowerInt[index] = b[index] - sheet.Application.WorksheetFunction.TInv(1-confLevel/100, length - variablesI.Count - 1)*std[index];
				higherInt[index] = b[index] + sheet.Application.WorksheetFunction.TInv(1-confLevel/100, length - variablesI.Count - 1)*std[index];
				//System.Diagnostics.Debug.WriteLine("{0}, p={1}, lower = {2}, n={3}, inv={4}, std={5}, inv2={6}",real_p, pValue[index], lowerInt[index], length - 1, sheet.Application.WorksheetFunction.TInv(1-0.975, length - 1), std[index], sheet.Application.WorksheetFunction.TInv(1 - 0.95, length - 1));
			}

			//
			//Prediction
			//
			if (model.doPrediction)
			{
				double[,] xDataPred = calcXdata(dataSet2.getNrDataRows(), dataSet2, variablesPrediction);
				int[] rightCell = { dataSet2.getRange().Row, dataSet2.getRange().Column + dataSet2.amountOfVariables() }; //{row, column}

				prediction(dataSet2.getWorksheet(), xDataPred, b, length, variablesI.Count, X, MSE, rightCell, variablesD[0].name); 
				setPrediction(false);
			}
			


			//
			//Draw graphs
			//
			if (graphs[0])
			{
				drawGraphs(sheet, yData, yhat, "Scatter plot of fitted values vs. actual values");
			}
			if (graphs[1])
			{
				drawGraphs(sheet, yData, error, "Scatter plot of residuals vs. fitted values");
			}
			if (graphs[2])
			{
				int varNumber = 1;
				foreach (Variable var in variablesI)
				{
					double[] xDataTemp = new double[xData.GetLength(0)];
					for(int x = 0; x < xData.GetLength(0); x++)
					{
						xDataTemp[x] = xData[x, varNumber];
					}
					drawGraphs(sheet, xDataTemp, error, "Scatter plot of residuals vs. " + var.name);
					varNumber++;
				}
			}
			if (graphs[3])
			{
				int varNumber = 1;
				foreach (Variable var in variablesI)
				{
					double[] xDataTemp = new double[xData.GetLength(0)];
					for(int x = 0; x < xData.GetLength(0); x++)
					{
						xDataTemp[x] = xData[x, varNumber];
					}
					drawGraphs(sheet, xDataTemp, yData, "Scatter plot of actual Y values vs. " + var.name);
					varNumber++;
				}
			}
			if (graphs[4])
			{
				int varNumber = 1;
				foreach (Variable var in variablesI)
				{
					double[] xDataTemp = new double[xData.GetLength(0)];
					for(int x = 0; x < xData.GetLength(0); x++)
					{
						xDataTemp[x] = xData[x, varNumber];
					}
					drawGraphs(sheet, xDataTemp, yhat, "Scatter plot of fitted Y values vs. " + var.name);
					varNumber++;
				}
			}

			//
			//print results to excel sheet
			//
			sheet.Cells[16, 2] = a;
			row = 17;
			foreach (Variable var in variablesI)
			{
				sheet.Cells[row, 2] = b[row - 16];
				row++;
			}


			FillR(sheet, R2, R, Radj, err);
            FillAnova(sheet, anovaResults);
			FillRegressionTable(sheet, std, tValue, pValue, lowerInt, higherInt);


			((Range)sheet.Cells[1, 1]).EntireColumn.AutoFit();
			((Range)sheet.Cells[1, 2]).EntireColumn.AutoFit();
			((Range)sheet.Cells[1, 3]).EntireColumn.AutoFit();
			((Range)sheet.Cells[1, 4]).EntireColumn.AutoFit();
			((Range)sheet.Cells[1, 5]).EntireColumn.AutoFit();
			((Range)sheet.Cells[1, 6]).EntireColumn.ColumnWidth = 13;
			((Range)sheet.Cells[1, 7]).EntireColumn.ColumnWidth = 13;
			((Range)sheet.Cells[1, 8]).EntireColumn.ColumnWidth = 13;
			((Range)sheet.Cells[1, 9]).EntireColumn.ColumnWidth = 13;
			((Range)sheet.Cells[1, 10]).EntireColumn.AutoFit();

		}

        public void FillAnova(_Worksheet sheet, double[] values)
        {
            sheet.Cells[9, 1] = "ANOVA Table";
            sheet.Cells[10, 1] = "Explained";
            sheet.Cells[11, 1] = "Unexplained";
            sheet.Cells[10, 3] = values[3]; //SSR
			sheet.Cells[11, 3] = values[4]; //SSE
            sheet.Cells[10, 2] = values[2];	//k, explained degrees of freedom
            sheet.Cells[11, 2] = (values[1]-values[2]-1);	//n-k-1, unexplained degrees of freedom
            sheet.Cells[10, 4] = values[5]; //MSR
            sheet.Cells[11, 4] = values[6]; //MSE
			sheet.Cells[10, 5] = values[0]; //f-value
			if (values[7] < 0.0001)
				sheet.Cells[10, 6] = "<0.0001";
			else
				sheet.Cells[10, 6] = Math.Round(values[7], 4);
        }

        public void FillR(_Worksheet sheet, double R2, double R, double Radj, double err)
        {
            sheet.Cells[2, 2] = R2;
            sheet.Cells[3, 2] = R;
            sheet.Cells[4, 2] = Radj;
            sheet.Cells[5, 2] = err;
        }

		public void FillRegressionTable(_Worksheet sheet, double[] std, double[] tValue, double[] pValue, double[] lowerInt, double[] higherInt)
		{
			int row = 16;
			foreach(double item in std)
			{
				sheet.Cells[row, 3] = std[row - 16];
				sheet.Cells[row, 4] = tValue[row - 16];
				if (pValue[row - 16] < 0.0001)
					sheet.Cells[row, 5] = "<0.0001";
				else
					sheet.Cells[row, 5] = Math.Round(pValue[row - 16], 4);
				sheet.Cells[row, 6] = lowerInt[row - 16];
				sheet.Cells[row, 7] = higherInt[row - 16];
				row++;
			}
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
			System.Diagnostics.Debug.WriteLine("lengte xdata is = {0}", length);
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
					if (item.GetType() ==typeof( string))
					{
						MessageBox.Show("Please use numeric data", "Invalid data type error");
						break;
					}
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

		//calculates f-ratio
		//k = number of explanatory variables
		//n = sample size
		//results = [f-value, n, k, SSR, SSE, MSR, MSE, p-value]
		public double[] calculateAnova(double[] yData, double[] yHoed, int k, _Worksheet sheet)
		{
			double[] results = new double[8];
			int n = yData.Length;

			var yDataM = new DenseVector(yData);
			double[] yData_temp = yDataM.ToArray();
			var yHoedM = new DenseVector(yHoed);
			double[] yHoed_temp = yHoedM.ToArray();
			double yGem = yData.Average();
			
			var SSR_sub = yHoedM.Subtract(yGem);	//yHat-yGem
			var SSR_exp = SSR_sub.PointwiseMultiply(SSR_sub);
			double MSR = SSR_exp.Sum()/k;
			System.Diagnostics.Debug.WriteLine("sum of squares R = {0}", SSR_exp.Sum());
			System.Diagnostics.Debug.WriteLine("MSR = {0}", MSR);

			var SSE_sub = yDataM.Subtract(yHoedM);	//yi-yHat
			var SSE_exp = SSE_sub.PointwiseMultiply(SSE_sub);
			double MSE = SSE_exp.Sum() / ((n - k - 1));
			System.Diagnostics.Debug.WriteLine("sum of squares E = {0}", SSE_exp.Sum());
			System.Diagnostics.Debug.WriteLine("MSE = {0}", MSE);

			double pVal = sheet.Application.WorksheetFunction.F_Dist(results[0], k, n - k, true);
			
			

			results[0] = Math.Round(MSR / MSE, 2);  //Problem: Excel shows value multiplied by a factor of more than 1000. 
													//Solution: this doesn't happen when value is rounded
			results[1] = n;
			results[2] = k;
			results[3] = Math.Round(SSR_exp.Sum(), 2); //sum of squares explained
			results[4] = Math.Round(SSE_exp.Sum(), 2); //sum of squares unexplained
			results[5] = Math.Round(MSR, 2); //mean of squares explained
			results[6] = Math.Round(MSE, 2); //mean of squares unexplained
			results[7] = pVal;

			return results;
		}

		public void multicollinearity(_Worksheet sheet, double[,] xData, int nrVariablesX)
		{
			int row = 15;
			sheet.Cells[row-1, 8] = "Multicollinearity checking";
			sheet.Range[sheet.Cells[row-1, 8], sheet.Cells[row-1, 9]].Merge();
			sheet.Cells[row, 8] = "VIF";
			sheet.Cells[row, 9] = "R-square";
			sheet.Range[sheet.Cells[row, 8], sheet.Cells[row, 9]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

			//calculate Rj² values, coefficient of determination when Xj is regressed on all other predictor variables in the model.
			for (int k = 1; k < xData.GetLength(1); k++) //first column is full of value 1, skip this one, it has no data of parameters
			{
				double[,] xDataNew = new double[xData.GetLength(0), xData.GetLength(1) - 1]; //will contain xData without data of iterated parameter
				double[] yDataNew = new double[xData.GetLength(0)]; //contains data of current iterated parameter
				int writeKol = 0;
				for (int j = 0; j < xData.GetLength(1); j++)
				{
					if (j != k)
					{
						for (int l = 0; l < xData.GetLength(0); l++)
						{
							xDataNew[l, writeKol] = xData[l, j];
						}
						writeKol++;
					}
					else
					{
						for (int l = 0; l < xData.GetLength(0); l++)
						{
							yDataNew[l] = xData[l, j];
						}
					}

				}
				double[] bT = new double[nrVariablesX - 1]; //T = Temp
				bT = calculateCoefB(yDataNew, xDataNew, bT);
				double aT = bT[0];

				var XT = DenseMatrix.OfArray(xDataNew);
				var BT = new DenseVector(bT);
				var YT = new DenseVector(yDataNew);
				var yhT = XT.Multiply(BT);

				double[] yhatT = yhT.ToArray();

				double R2T = sheet.Application.WorksheetFunction.Correl(yDataNew, yhatT);
				double RT = Math.Pow(R2T, 2);
				double VIF = 1 / (1 - RT);
				sheet.Cells[row+k+1, 8] = VIF;
				sheet.Cells[row+k+1, 9] = RT;

				//printing xData
				/*for (int j = 0; j < xDataNew.GetLength(1); j++)
				{
					for (int l = 0; l < xDataNew.GetLength(0); l++)
					{
						sheet.Cells[rij + l, kol + j] = xDataNew[l, j];
					}
				}
				kol += xDataNew.GetLength(1) + 1;

				//printing yData
				for (int l = 0; l < yDataNew.GetLength(0); l++)
				{
					sheet.Cells[rij + l, kol] = yDataNew[l];
				}
				kol += 2;*/

			}
		}

		public double DurbinWatson(_Worksheet sheet, double[] error)
		{
			double DW = 0;
			double Num = 0;	//Numerator
			double Den = 0; //Denominator
			for (int i = 1; i < error.Length; i++)
			{
				Num += Math.Pow((error[i] - error[i - 1]), 2);
				Den += Math.Pow(error[i],2);
			}
			Den += Math.Pow(error[0], 2); //first element has been skipped in the loop, so still needs te be added
			DW = Num / Den;

			sheet.Cells[6, 1] = "Durbin Watson ";
			///sheet.Cells[6, 2] = Math.Round(DW, 3).ToString();
			sheet.Cells[6, 2] = Math.Round(DW, 3);
			return DW;
		}

		public void drawGraphs(_Worksheet sheet, double[] xData, double[] yData, String name)
		{
			
			var Xcharts = (ChartObjects)sheet.ChartObjects();
			var XchartObject = Xcharts.Add(20, (lowestDataRow+2)*15 + nrOfGraphs*230, 350, 200);
			var Xchart = XchartObject.Chart;
			Xchart.ChartType = XlChartType.xlXYScatter;
			Xchart.ChartWizard(Title: name, HasLegend: false);
			var XseriesCollection = (SeriesCollection)Xchart.SeriesCollection();
			var graph = XseriesCollection.NewSeries();
			graph.Values = yData;
			graph.XValues = xData;
			nrOfGraphs++;

		}

		public void prediction(_Worksheet sheet, double[,]xDataNewN, double[] coefficients, int n, int k, DenseMatrix X, double MSE, int[] topRightCell, String predVarName)
		{
			//source for calculations: http://www.real-statistics.com/multiple-regression/confidence-and-prediction-intervals/

			sheet.Cells[topRightCell[0], topRightCell[1]] = predVarName;
			sheet.Cells[topRightCell[0], topRightCell[1] + 1] = "lower limit";
			sheet.Cells[topRightCell[0], topRightCell[1] + 2] = "higher limit";

			double predLevel = model.predictionLevel;
			double[,] results = new double[xDataNewN.GetLength(0), 3];

			for (int dataNr = 0; dataNr < xDataNewN.GetLength(0);dataNr++)
			{
				double yNew = 0;
				double[] currentXdata = new double[xDataNewN.GetLength(1)];
				for(int xIndex = 0; xIndex< xDataNewN.GetLength(1); xIndex++)
				{
					currentXdata[xIndex] = xDataNewN[dataNr, xIndex];
				}

				var XhVector = DenseVector.OfArray(currentXdata);
				var Xh = XhVector.ToColumnMatrix();
				var Xht = Xh.Transpose();
				var Xt = X.Transpose();
				var XproductInv = (Xt.Multiply(X)).Inverse();
				var XhtXproduct = Xht.Multiply(XproductInv);
				var XhtXproductXh = XhtXproduct.Multiply(Xh);
				double[][] productArray = XhtXproductXh.ToColumnArrays();
				double product = productArray[0][0];
				double s2 = MSE * (1 + product); //MSE*(1 + Xh'.(X'.X)^(-1).Xh)
				double s = Math.Sqrt(s2);
				for (int i = 0; i < coefficients.Length; i++)
				{
					yNew += coefficients[i] * xDataNewN[dataNr, i];
				}

				yNew = Math.Round(yNew, 2);
				double lowLimit= Math.Round((yNew - sheet.Application.WorksheetFunction.TInv(1 - predLevel / 100, n-k-1) * s), 2);
				double highLimit = Math.Round((yNew + sheet.Application.WorksheetFunction.TInv(1 - predLevel / 100, n - k - 1) * s), 2);
				//System.Diagnostics.Debug.WriteLine("{0}\t\t{1}\t\t{2}",yNew, lowLimit, highLimit);

				sheet.Cells[topRightCell[0]+dataNr+1, topRightCell[1]] = yNew;
				sheet.Cells[topRightCell[0]+dataNr+1, topRightCell[1]+1] = lowLimit;
				sheet.Cells[topRightCell[0]+dataNr+1, topRightCell[1]+2] = highLimit;
			}
			((Range)sheet.Cells[topRightCell[0], topRightCell[1]]).EntireColumn.AutoFit();
			((Range)sheet.Cells[topRightCell[0], topRightCell[1]+1]).EntireColumn.AutoFit();
			((Range)sheet.Cells[topRightCell[0], topRightCell[1]+2]).EntireColumn.AutoFit();

		}
	}
}
