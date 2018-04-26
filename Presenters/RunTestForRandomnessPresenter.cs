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
    public class RunsTestForRandomnessPresenter
    {
        private RunsTestForRandomnessForm view;
        private RunsTestForRandomnessModel model;
        private DataSetManagerPresenter dataSetPresenter;

        public RunsTestForRandomnessPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new RunsTestForRandomnessModel();
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

        public bool checkInput(List<Variable> variables, DataSet selectedDataSet, bool rdbMean, bool rdbMedian)
        {
            if (variables.Count == 0) return false;
            
            _Worksheet worksheet = WorksheetHelper.NewWorksheet("Runs test");
            int column = 1;
            int row = 2;
            worksheet.Cells[row, column] = "Runs test for randomness";
            worksheet.Cells[row++, column] = "Observations";
            if (rdbMean) worksheet.Cells[row++, column] = "Mean";
            if (rdbMedian) worksheet.Cells[row++, column] = "Median";
            worksheet.Cells[row++, column] = "Below cutoff";
            worksheet.Cells[row++, column] = "Above cutoff";
            worksheet.Cells[row++, column] = "Number of runs";
            worksheet.Cells[row++, column] = "E(R)";
            worksheet.Cells[row++, column] = "Stddev(R)";
            worksheet.Cells[row++, column] = "Z-Value";
            worksheet.Cells[row++, column] = "P-Value (two-tailed)";
            ((Range)worksheet.Cells[row, column]).EntireColumn.AutoFit();

            row = 1;
            column = 2;
            foreach (Variable variable in variables)
            {
                worksheet.Cells[row++, column] = variable.name;
                var range = variable.getRange().Address(true, true, true);
                worksheet.Cells[row++, column] = selectedDataSet.rangeSize();
                var ntotal = selectedDataSet.rangeSize();
                if (rdbMean) worksheet.Cells[row++, column] = "=AVERAGE(" + range + ")";
                if (rdbMedian) worksheet.Cells[row++, column] = "=MEDIAN(" + range + ")";
                var cutoffValue = (double)worksheet.Cells[row-1, column].Value;
                int amountOfRuns = calculateRuns(worksheet, selectedDataSet, variable.getRange(), cutoffValue);
                worksheet.WriteFunction(row++, column, "COUNTIF(" + range + ",\"<\"&" + AddressConverter.CellAddress(row - 2, column) + ")");
                worksheet.WriteFunction(row++, column, "COUNTIF(" + range + ",\">\"&" + AddressConverter.CellAddress(row - 3, column) + ")");
                worksheet.Cells[row++, column] = amountOfRuns;
                worksheet.WriteFunction(row++, column, "1 + (2*" + AddressConverter.CellAddress(row - 4, column) + "*" + AddressConverter.CellAddress(row - 3, column) + ")/(" + AddressConverter.CellAddress(row - 4, column) + "+" + AddressConverter.CellAddress(row - 3, column) + ")");
                worksheet.WriteFunction(row++, column, "SQRT(2*" + AddressConverter.CellAddress(row - 5, column) + "*" + AddressConverter.CellAddress(row - 4, column) + "*(2*" + AddressConverter.CellAddress(row - 5, column) + "*" + AddressConverter.CellAddress(row - 4, column) + "-" + AddressConverter.CellAddress(row - 5, column) + "-" + AddressConverter.CellAddress(row - 4, column) + ")/((" + AddressConverter.CellAddress(row - 5, column) + "+" + AddressConverter.CellAddress(row - 4, column) + ")*(" + AddressConverter.CellAddress(row - 5, column) + "+" + AddressConverter.CellAddress(row - 4, column) + ")*(" + AddressConverter.CellAddress(row - 5, column) + "+" + AddressConverter.CellAddress(row - 4, column) + "-1)))");
                worksheet.WriteFunction(row++, column, "(" + AddressConverter.CellAddress(row - 4, column) + "-" + AddressConverter.CellAddress(row - 3, column) + ")/" + AddressConverter.CellAddress(row - 2, column));
                worksheet.WriteFunction(row++, column, "2*(1-NORMSDIST(ABS(" + AddressConverter.CellAddress(row - 2, column) + ")))");
                ((Range)worksheet.Cells[row, column]).EntireColumn.AutoFit();
                row = 1;
                column++;
            }
            return true;
        }

        private int calculateRuns(_Worksheet sheet, DataSet dataSet, Range range, double cutoff)
        {
            int runs = 1;
            double[,] array = RangeHelper.To2DDoubleArray(range);
            double[] array2 = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = array[i, 0];  
            }
            for(int i = 0; i < array.Length-1; i++)
            {
                if(Math.Sign(array2[i] - cutoff) != Math.Sign(array2[i+1] - cutoff))
                {
                    runs++;
                }
            }

            return runs;
        }
    }
}
