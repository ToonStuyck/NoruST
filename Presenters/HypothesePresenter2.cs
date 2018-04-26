using Microsoft.Office.Interop.Excel;
using NoruST.Domain;
using NoruST.Forms;
using NoruST.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSet = NoruST.Domain.DataSet;

namespace NoruST.Presenters
{
    public class HypothesePresenter2
    {
        private HypotheseForm2 view;
        private HypotheseModel2 model;
        private DataSetManagerPresenter dataSetPresenter;

        public HypothesePresenter2(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new HypotheseModel2();
        }

        public HypotheseModel2 getModel()
        {
            return model;
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

        public void createHypothese(List<Variable> variables, DataSet dataSet)
        {
            _Worksheet worksheet = WorksheetHelper.NewWorksheet("Hypothesis test");
            foreach (Variable variable in variables)
            {
                worksheet.Cells[1, 1] = "Hypothesis test";
                worksheet.Cells[1, 2] = variable.name;
                worksheet.Cells[2, 1] = "Sample size";
                worksheet.Cells[2, 2] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
                worksheet.Cells[3, 1] = "Sample proportion";
                string ran = variable.Range.ToString();
                Array dist = dataSet.getWorksheet().Range[ran].Value;
                double count = 0;
                foreach (var item in dist)
                {
                    if (Convert.ToInt32(item) == 0)
                    {
                        System.Diagnostics.Debug.WriteLine(item);
                        count = count + 1;
                    }
                }
                double n = (worksheet.Cells[2, 2] as Range).Value;
                double prop = count / n;
                worksheet.Cells[3, 2] = 1.0 - prop;
                if (model.equal)
                {
                    PrintCategories(worksheet, 5, "equal", dataSet, variable);
                }
                else if (model.greater)
                {
                    PrintCategories(worksheet, 5, "greater", dataSet, variable);
                }
            }
        }

        private void PrintCategories(_Worksheet _sheet, int rowIn, String input, DataSet dataSet, Variable variable)
        {
            double n = (_sheet.Cells[2, 2] as Range).Value;
            double p = (_sheet.Cells[3, 2] as Range).Value;
            double alpha = (double)model.alpha;
            int tail = 1;
            if (input.Equals("equal"))
            {
                alpha = alpha / 200.0;
                tail = 2;
            }
            else
            {
                alpha = alpha / 100.0;
                tail = 1;
            }
            double p0 = Convert.ToDouble(model.Null);
            double error = Math.Sqrt((p0*(1-p0)) / n);
            var row = rowIn;
            _sheet.Cells[row, 1] = "Hypothesized mean";
            _sheet.Cells[row++, 2] = model.Null;

            _sheet.Cells[row, 1] = "Alternative Hypothesis";
            if (input.Equals("equal"))
            {
                _sheet.Cells[row++, 2] = "'=/= " + model.Null;
            }
            else
            {
                _sheet.Cells[row++, 2] = "> " + model.Null;
            }

            _sheet.Cells[row, 1] = "Alpha";
            _sheet.Cells[row++, 2] = model.alpha;

            _sheet.Cells[row, 1] = "Standard Error";
            _sheet.Cells[row++, 2] = error;

            _sheet.Cells[row, 1] = "Z-Test Statistic";
            double z = (p - p0) / error;
            _sheet.Cells[row++, 2] = z;

            _sheet.Cells[row, 1] = "p-Value";
            double pValue = _sheet.Application.WorksheetFunction.NormSDist(z);
            _sheet.Cells[row++, 2] = pValue;


            _sheet.Cells[row, 1] = "Null Hypothesis";
            if (pValue <= alpha)
            {
                _sheet.Cells[row, 2] = "Reject";
            }
            else
            {
                _sheet.Cells[row, 2] = "Accept";
            }
        }
    }
}
