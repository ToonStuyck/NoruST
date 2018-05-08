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

namespace NoruST.Presenters
{
    public class ProcessCapabilityPresenter
    {
        private ProcessCapabilityForm view;
        private ProcessCapabilityModel model;
        private DataSetManagerPresenter dataSetPresenter;
        private int offset;

        public ProcessCapabilityPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new ProcessCapabilityModel();
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

        public bool checkInput(List<Variable> variables, DataSet dataSet, string uiTextBox_LowerLimit, string uiTextBox_UpperLimit)
        {
            double LSL = Convert.ToDouble(uiTextBox_LowerLimit);
            double USL = Convert.ToDouble(uiTextBox_UpperLimit);

            if ((dataSet != null) && (LSL < USL))
            {

                _Worksheet sheet = WorksheetHelper.NewWorksheet("Process Capability");
                
                generateProcessCapability(variables, LSL, USL, dataSet, sheet);
             
                return true;
            }
            else
                MessageBox.Show("Please correct all fields to generate X/R-Chart, LSL should be smaller than USL", "XR-Chart error");
            return false;
        }


        public void generateProcessCapability(List<Variable> variables, double LSL, double USL, DataSet dataSet, _Worksheet sheet)
        {
            int index = 0;
            int row = 1;
            int column = 1;
            double correctionFactor1, correctionFactor2;
            double[] averages = new double[dataSet.amountOfVariables()];
            double[] Rvalues = new double[dataSet.amountOfVariables()];
            double[] averageOfAverages = new double[dataSet.amountOfVariables()];
            double[] xChartUpperControlLimit = new double[dataSet.amountOfVariables()];
            double[] xChartLowerControlLimit = new double[dataSet.amountOfVariables()];
            double[] rChartUpperControlLimit = new double[dataSet.amountOfVariables()];
            double[] rChartLowerControlLimit = new double[dataSet.amountOfVariables()];
            double[] averageOfRvalues = new double[dataSet.amountOfVariables()];
            int[] ArrayIndex = new int[dataSet.amountOfVariables()];
            double[] constantC4 = new double[25] {0.0, 0.7979, 0.8862, 0.9213, 0.9400, 0.9515, 0.9594, 0.9650, 0.9693, 0.9727, 0.9754, 0.9776, 0.9794, 0.9810, 0.9823, 0.9835, 0.9845, 0.9854, 0.9862, 0.9869, 0.9876, 0.9882, 0.9887, 0.9892, 0.9896};
            double[] constantD2 = new double[25] { 0.0, 1.128, 1.693, 2.059, 2.326, 2.534, 2.704, 2.847, 2.970, 3.078, 3.173, 3.258, 3.336, 3.407, 3.472, 3.532, 3.588, 3.640, 3.689, 3.735, 3.778, 3.819, 3.858, 3.895, 3.931 };
            sheet.Cells[row, column] = "Index";
            sheet.Cells[row, column + 1] = "Observation";
            sheet.Cells[row, column + 2] = "Average";
            sheet.Cells[row, column + 3] = "STD DEV";
            sheet.Cells[row, column + 4] = "Max";
            sheet.Cells[row, column + 5] = "Min";
            sheet.Cells[row, column + 6] = "R";

            sheet.Cells[100, 100] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variables[0].Range + ")";
            int length = Convert.ToInt32((sheet.Cells[100, 100] as Range).Value);
            sheet.Cells[100, 100] = "";

            double temp=0;
            List<double> allVals = new List<double>();
            double[] all = new double[length * variables.Count];
            foreach ( Variable var in variables)
            {
                string ran = var.Range.ToString();
                Array arr = dataSet.getWorksheet().Range[ran].Value;
                double[] vals = new double[length];
                int count = 0;
                foreach (var item in arr)
                {
                    temp = Convert.ToDouble(item);
                    vals[count] = temp;
                    count++;
                }
                allVals.AddRange(vals);
            }
            all = allVals.ToArray();

            double totMean = 0;
            double totStd = 0;
            for (index = 0; index < variables.Count; index++)
            {
                row++;
                sheet.Cells[row, column] = index;
                sheet.Cells[row, column + 1] = variables[index].name;
                sheet.Cells[row, column + 2] = "=AVERAGE(" + dataSet.getWorksheet().Name + "!" + variables[index].Range + ")";
                sheet.Cells[row, column + 3] = "=STDEV(" + dataSet.getWorksheet().Name + "!" + variables[index].Range + ")";
                sheet.Cells[row, column + 4] = "=MAX(" + dataSet.getWorksheet().Name + "!" + variables[index].Range + ")";
                sheet.Cells[row, column + 5] = "=MIN(" + dataSet.getWorksheet().Name + "!" + variables[index].Range + ")";
                sheet.Cells[row, column + 6] = (double)(sheet.Cells[row, column + 4] as Range).Value - (double)(sheet.Cells[row, column + 5] as Range).Value;
                totMean = totMean + Convert.ToDouble((sheet.Cells[row, column + 2] as Range).Value);
                totStd = totStd + (Convert.ToDouble((sheet.Cells[row, column + 3] as Range).Value));
                ArrayIndex[index] = index;
                var cellValue = (double)(sheet.Cells[row, column + 2] as Range).Value;
                if (cellValue < -214682680) cellValue = 0; // if cellValue is the result of a division by 0, set value to 0
                averages[index] = cellValue;
                cellValue = (double)(sheet.Cells[row, column + 6] as Range).Value;
                Rvalues[index] = cellValue;
            }
            totMean = all.Average();
            totStd = sheet.Application.WorksheetFunction.StDev(all);
            //totMean = totMean / variables.Count;
            //totStd = totStd / variables.Count;

            if (dataSet.getVariableNamesInFirstRowOrColumn())
            {
                correctionFactor1 = constantC4[variables.Count - 1];
                correctionFactor2 = constantD2[variables.Count - 1];
            }
            else
                correctionFactor1 = constantC4[variables.Count];
                correctionFactor2 = constantD2[variables.Count];


            System.Diagnostics.Debug.WriteLine(totStd);
            double sigma = totStd;
            double Cp = (USL - LSL) / (6 * sigma);
            double Cpk = Math.Min((USL - totMean) / (3 * sigma), (totMean - LSL) / (3 * sigma));
            double Pbelow = sheet.Application.WorksheetFunction.NormDist(LSL, totMean, totStd, true);
            double Pabove = 1.0 - sheet.Application.WorksheetFunction.NormDist(USL, totMean, totStd, true);

            row = 1;
            column = 1;
            sheet.Cells[row, column + 8] = "LSL";
            sheet.Cells[row, column + 9] = "USL";
            sheet.Cells[row, column + 10] = "Cp";
            sheet.Cells[row, column + 11] = "Cpk";
            sheet.Cells[row, column + 12] = "P(below LSL)";
            sheet.Cells[row, column + 13] = " Per million";
            sheet.Cells[row, column + 14] = "P(above USL)";
            sheet.Cells[row, column + 15] = " Per million";

            row++;
            sheet.Cells[row, column + 8] = LSL;
            sheet.Cells[row, column + 9] = USL;
            sheet.Cells[row, column + 10] = Cp;
            sheet.Cells[row, column + 11] = Cpk;
            sheet.Cells[row, column + 12] = Pbelow;
            sheet.Cells[row, column + 13] = Pbelow * 1000000;
            sheet.Cells[row, column + 14] = Pabove;
            sheet.Cells[row, column + 15] = Pabove * 1000000;
        }
    }
}
