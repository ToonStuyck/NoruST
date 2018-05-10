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
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

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

        public List<double[]> fillTable1(List<Variable> variablesD, List<Variable> variablesI, DataSet dataSet, int col, _Worksheet sheet)
        {
            List<double[]> final = new List<double[]>();
            List<int> posN = new List<int>();
            List<String> no = new List<String>();
            List<int> posY = new List<int>();
            string ran2 = variablesD[0].Range.ToString();
            Array distCat = dataSet.getWorksheet().Range[ran2].Value;
            no = distCat.OfType<String>().ToList();
            int i = 0;
            foreach (String str in no)
            {
                if (str.Equals("No"))
                {
                    posN.Add(i);
                }
                else
                {
                    posY.Add(i);
                }
                i++;
            }

            sheet.Cells[3, 2] = posN.Count;
            sheet.Cells[4, 2] = posY.Count;

            i = 0;
            
            foreach (Variable var in variablesI)
            {
                double[] meanN = new double[posN.Count];
                double[] meanY = new double[posY.Count];
                ran2 = variablesI[i].Range.ToString();
                distCat = dataSet.getWorksheet().Range[ran2].Value;
                List<double> all = distCat.OfType<double>().ToList();
                int j = 0;
                foreach (int val in posN)
                {
                    meanN[j] = all[val];
                    j++;
                }
                j = 0;
                foreach (int val in posY)
                {
                    meanY[j] = all[val];
                    j++;
                }

                final.Add(meanN);
                final.Add(meanY);

                sheet.Cells[3, 3+i] = meanN.Average();
                sheet.Cells[4, 3 + i] = meanY.Average();
                i++;
            }
            return final;
        }

        public static Matrix<double> GetCovarianceMatrix(Matrix<double> matrix)
        {
            var columnAverages = matrix.ColumnSums() / matrix.RowCount;
            var centeredColumns = matrix.EnumerateColumns().Zip(columnAverages, (col, avg) => col - avg);
            var centered = DenseMatrix.OfColumnVectors(centeredColumns);
            var normalizationFactor = matrix.RowCount == 1 ? 1 : matrix.RowCount - 1;
            return centered.TransposeThisAndMultiply(centered) / normalizationFactor;
        }

        public double[] calcCoef(List<double[]> final, int numberOfVar, _Worksheet sheet)
        {
            double[] coef = new double[numberOfVar];
            int i = 0;
            int j = 0;
            double[] tempNo = new double[numberOfVar * final[0].Length]; //numberOfVar*final[0].Length
            double[] tempYes = new double[numberOfVar * final[1].Length]; //numberOfVar * final[1].Length
            double[] meanNo = new double[numberOfVar];
            double[] meanYes = new double[numberOfVar];
            int counter = 0;
            while (i<2*numberOfVar)
            {
                //tempNo = tempNo.Concat(final[i]).ToArray();
                double[] temp = final[i];
                int count = 0;
                while (count < final[i].Length)
                {
                    tempNo[counter] = temp[count];
                    count++;
                    counter++;
                }
                meanNo[j] = final[i].Average();
                i = i + 2;
                j++;
            }
            i = 1;
            j = 0;
            counter = 0;
            while (i < 2 * numberOfVar)
            {
                double[] temp = final[i];
                int count = 0;
                while (count < final[i].Length)
                {
                    tempYes[counter] = temp[count];
                    count++;
                    counter++;
                }
                meanYes[j] = final[i].Average();
                i = i + 2;
                j++;
            }
            Matrix<double> no = new DenseMatrix(final[0].Length, numberOfVar, tempNo);
            Matrix<double> yes = new DenseMatrix(final[1].Length, numberOfVar, tempYes);

            int n1 = final[0].Length;
            int n2 = final[1].Length;

            Matrix<double> CovNo = GetCovarianceMatrix(no);//(no.Transpose().Multiply(no)).Divide(n1);
            Matrix<double> CovYes = GetCovarianceMatrix(yes);//(yes.Transpose().Multiply(yes)).Divide(n2);

            
            Matrix<double> Cov = (CovNo.Multiply(n1-1) + CovYes.Multiply(n2-1)).Divide(n1 + n2 - 2);

            Matrix<double> CovInv = Cov.Inverse();

            Vector<double> mean1 = new DenseVector(meanNo);
            Vector<double> mean2 = new DenseVector(meanYes);

            Vector<double> b = CovInv.Multiply(mean1.Subtract(mean2));
            coef = b.ToArray();

            i = 0;
            while (i < numberOfVar)
            {
                sheet.Cells[8+i, 2] = coef[i];
                i++;
            }
            
            return coef;
        }

        public List<Matrix<double>> getMat(List<double[]> final, int numberOfVar)
        {
            int i = 0;
            int j = 0;
            double[] tempNo = new double[numberOfVar * final[0].Length]; //numberOfVar*final[0].Length
            double[] tempYes = new double[numberOfVar * final[1].Length]; //numberOfVar * final[1].Length
            int counter = 0;
            while (i < 2 * numberOfVar)
            {
                double[] temp = final[i];
                int count = 0;
                while (count < final[i].Length)
                {
                    tempNo[counter] = temp[count];
                    count++;
                    counter++;
                }
                i = i + 2;
                j++;
            }
            i = 1;
            j = 0;
            counter = 0;
            while (i < 2 * numberOfVar)
            {
                double[] temp = final[i];
                int count = 0;
                while (count < final[i].Length)
                {
                    tempYes[counter] = temp[count];
                    count++;
                    counter++;
                }
                i = i + 2;
                j++;
            }
            Matrix<double> no = new DenseMatrix(final[0].Length, numberOfVar, tempNo);
            Matrix<double> yes = new DenseMatrix(final[1].Length, numberOfVar, tempYes);

            List<Matrix<double>> mat = new List<Matrix<double>>();
            mat.Add(no);
            mat.Add(yes);
            return mat;
        }

        public void classification(double cutoff, double[] coef, List<double[]> final, int numberOfVar, _Worksheet sheet, int row)
        {
            double noNo = 0;
            double noYes = 0;

            double yesNo = 0;
            double yesYes = 0;

            Vector<double> B = new DenseVector(coef);
            List<Matrix<double>> mat = getMat(final, numberOfVar);
            Matrix<double> no = mat[0];
            Matrix<double> yes = mat[1];
            Vector<double> score1 = no.Multiply(B);
            Vector<double> score2 = yes.Multiply(B);

            foreach (double el in score1)
            {
                if (el > cutoff)
                {
                    noNo++;
                } else
                {
                    noYes++;
                }
            }
            foreach (double el in score2)
            {
                if (el > cutoff)
                {
                    yesNo++;
                }
                else
                {
                    yesYes++;
                }
            }

            double cor1 = ((noNo) / (noNo + noYes));
            double cor2 = ((yesYes) / (yesNo + yesYes));

            sheet.Cells[row-1, 2] = (int)noNo;
            sheet.Cells[row - 1, 3] = (int)noYes;
            sheet.Cells[row - 1, 4] = cor1 ;
            sheet.Cells[row, 2] = (int)yesNo;
            sheet.Cells[row, 3] = (int)yesYes;
            sheet.Cells[row, 4] = cor2;

            row = row + 4;
            double correct = (noNo + yesYes) / (noNo + noYes + yesNo + yesYes);
            double Base = (noNo + noYes) / (noNo + noYes + yesNo + yesYes);
            double improv = (correct - Base) / (1 - Base);
            sheet.Cells[row++, 2] = correct;
            sheet.Cells[row++, 2] = Base;
            sheet.Cells[row, 2] = improv;


        }

        public double cutoff(double[] coef, List<double[]> final, int numberOfVar, _Worksheet sheet)
        {
            double cutoff = 0;
            double[] meanNo = new double[numberOfVar];
            double[] meanYes = new double[numberOfVar];
            int i = 0;
            int j = 0;
            while (i < 2 * numberOfVar)
            {
                double[] temp = final[i];
                meanNo[j] = final[i].Average();
                i = i + 2;
                j++;
            }
            i = 1;
            j = 0;
            while (i < 2 * numberOfVar)
            {
                double[] temp = final[i];
                meanYes[j] = final[i].Average();
                i = i + 2;
                j++;
            }

            Vector<double> B = new DenseVector(coef);
            Vector<double> x1 = new DenseVector(meanNo);
            Vector<double> x2 = new DenseVector(meanYes);

            double z1 = B.DotProduct(x1);
            double z2 = B.DotProduct(x2);

            cutoff = (z1 + z2) / 2.0;
            System.Diagnostics.Debug.WriteLine(cutoff);

            return cutoff;
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
            column = 3 + i - 1;
            string let = ColumnIndexToColumnLetter(3 + i - 1);

            List<double[]> final = fillTable1(variablesD, variablesI, dataSet, 3, sheet);

            double[] coef = calcCoef(final, variablesI.Count, sheet);

            sheet.get_Range("A2", "J200").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet.get_Range("A2", let+"2").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

            sheet.Cells[7, 1] = "Discriminant Function";
            sheet.Cells[7, 2] = "Coefficient";

            sheet.get_Range("A7", "B7").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

            sheet.Cells[row, 1] = "Classification Matrix";
            sheet.Cells[row, 2] = "No";
            sheet.Cells[row, 3] = "Yes";
            sheet.Cells[row, 4] = "Correct";

            double cut = cutoff(coef,final, variablesI.Count, sheet);

            string num = Convert.ToString(row);

            row++;
            sheet.Cells[row++, 1] = "No";
            sheet.Cells[row, 1] = "Yes";

            classification(cut,coef,final,variablesI.Count,sheet,row);

            sheet.get_Range("A"+num, "D"+num).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

            row = row + 3;
            num = Convert.ToString(row);
            sheet.Cells[row++, 1] = "Summary Classification";
            sheet.Cells[row++, 1] = "Correct";
            sheet.Cells[row++, 1] = "Base";
            sheet.Cells[row, 1] = "Improvement";
            sheet.get_Range("A" + num, "B" + num).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

            //sheet.get_Range("B3", "B5").NumberFormat = "0.0000";
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
