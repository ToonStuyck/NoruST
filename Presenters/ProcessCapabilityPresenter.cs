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

        public bool checkInput(DataSet dataSet, string uiTextBox_LowerLimit, string uiTextBox_UpperLimit)
        {
            double LSL = Convert.ToDouble(uiTextBox_LowerLimit);
            double USL = Convert.ToDouble(uiTextBox_UpperLimit);

            if ((dataSet != null) && (LSL < USL))
            {

                _Worksheet sheet = WorksheetHelper.NewWorksheet("Process Capability");
                
                generateProcessCapability(LSL, USL, dataSet, sheet);
             
                return true;
            }
            else
                MessageBox.Show("Please correct all fields to generate X/R-Chart", "XR-Chart error");
            return false;
        }


        public void generateProcessCapability(double LSL, double USL, DataSet dataSet, _Worksheet sheet)
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
            sheet.Cells[row, column + 3] = "Max";
            sheet.Cells[row, column + 4] = "Min";
            sheet.Cells[row, column + 5] = "R";

            for (index = 0; index < dataSet.amountOfVariables(); index++)
            {
                row++;
                sheet.Cells[row, column] = index;
                sheet.Cells[row, column + 1] = dataSet.getVariables()[index].name;
                sheet.Cells[row, column + 2] = "=AVERAGE(" + dataSet.getWorksheet().Name + "!" + dataSet.getVariables()[index].Range + ")";
                sheet.Cells[row, column + 3] = "=MAX(" + dataSet.getWorksheet().Name + "!" + dataSet.getVariables()[index].Range + ")";
                sheet.Cells[row, column + 4] = "=MIN(" + dataSet.getWorksheet().Name + "!" + dataSet.getVariables()[index].Range + ")";
                sheet.Cells[row, column + 5] = (double)(sheet.Cells[row, column + 3] as Range).Value - (double)(sheet.Cells[row, column + 4] as Range).Value;
                ArrayIndex[index] = index;
                var cellValue = (double)(sheet.Cells[row, column + 2] as Range).Value;
                if (cellValue < -214682680) cellValue = 0; // if cellValue is the result of a division by 0, set value to 0
                averages[index] = cellValue;
                cellValue = (double)(sheet.Cells[row, column + 5] as Range).Value;
                Rvalues[index] = cellValue;
            }

            if (dataSet.getVariableNamesInFirstRowOrColumn())
            {
                correctionFactor1 = constantC4[dataSet.rangeSize() - 1];
                correctionFactor2 = constantD2[dataSet.rangeSize() - 1];
            }
            else
                correctionFactor1 = constantC4[dataSet.rangeSize()];
                correctionFactor2 = constantD2[dataSet.rangeSize()];

            double sigma = Rvalues.Average() / correctionFactor2;
            double Cp = (USL - LSL) / (6 * sigma);
            double Cpk = Math.Min((USL - averages.Average()) / (3 * sigma), (averages.Average() - LSL) / (3 * sigma));

            row = 1;
            column = 1;
            sheet.Cells[row, column + 7] = "LSL";
            sheet.Cells[row, column + 8] = "USL";
            sheet.Cells[row, column + 9] = "Cp";
            sheet.Cells[row, column + 10] = "Cpk";
            row++;
            sheet.Cells[row, column + 7] = LSL;
            sheet.Cells[row, column + 8] = USL;
            sheet.Cells[row, column + 9] = Cp;
            sheet.Cells[row, column + 10] = Cpk;
        }
    }
}
