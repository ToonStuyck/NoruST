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
    public class AutoCorrPresenter
    {

        private AutoCorrForm view;
        private AutoCorrModel model;
        private DataSetManagerPresenter dataSetPresenter;

        public AutoCorrPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new AutoCorrModel();
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

        public bool checkInput(List<Variable> variablesX, DataSet dataSet)
        {
            string ran = variablesX[0].Range.ToString();
            Array arr = dataSet.getWorksheet().Range[ran].Value;
            if (dataSet != null)
            {
                _Worksheet sheet = WorksheetHelper.NewWorksheet("Autocorrelation");
                generateChart(arr, variablesX, sheet, dataSet);
                return true;
            }
            else
                MessageBox.Show("Please correct all fields to generate Autocorrelation", "Autocorrelation error");
            return false;
        }

        public void generateChart(Array arr, List<Variable> variables, _Worksheet sheet, DataSet dataSet)
        {
            sheet.Cells[1, 1] = "Autocorrelation Table";
            sheet.Cells[1, 2] = variables[0].name;

            sheet.Cells[2, 1] = "Number of Values";
            sheet.Cells[2, 2] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variables[0].Range + ")";

            int length = Convert.ToInt32((sheet.Cells[2, 2] as Range).Value);
            sheet.Cells[3, 1] = "Standard Error";
            sheet.Cells[3, 2] = 1.0 / Math.Sqrt(length);

            int rows = 4;
            int i = 1;

            double[] vals = new double[length];
            
            int count = 0;
            foreach (var item in arr)
            {
                double temp = Convert.ToDouble(item);
                vals[count] = temp;
                count = count + 1;
            }

            
            double var = sheet.Application.WorksheetFunction.Var_S(vals);
            while (i <= 12)
            {
                double[] temp1 = new double[length-i];
                double[] temp2 = new double[length-i];
                Array.Copy(vals, i, temp1, 0, length - i);
                double[] tmp = vals;
                Array.Reverse(tmp);
                Array.Copy(tmp, i, temp2, 0, length - i);
                Array.Reverse(temp2);

                double covar = sheet.Application.WorksheetFunction.Covariance_P(temp1, temp2);

                sheet.Cells[rows, 1] = "Lag #" + i;
                sheet.Cells[rows++, 2] = covar/var;
                i = i + 1;
            }
        }

    }
}
