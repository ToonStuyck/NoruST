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
                worksheet.Cells[3, 1] = "Sample mean";
                worksheet.Cells[3, 2] = "=AVERAGE(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
                worksheet.Cells[4, 1] = "Sample Std. Dev";
                worksheet.Cells[4, 2] = "=STDEV(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
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

            _sheet.Cells[row++, 1] = "t-Test Statistic";

            _sheet.Cells[row, 1] = "p-Value";
        }
    }
}
