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
    public class ConfidencePresenter1
    {
        private confidence1 view;
        private ConfidenceModel1 model;
        private DataSetManagerPresenter dataSetPresenter;

        public ConfidencePresenter1(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new ConfidenceModel1();
        }

        public ConfidenceModel1 getModel()
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

        public void createConfidence(List<Variable> variables, DataSet dataSet)
        {
            _Worksheet worksheet = WorksheetHelper.NewWorksheet("Confidence");
            foreach (Variable variable in variables)
            {
                worksheet.Cells[1, 1] = "Conf. intervals";
                worksheet.Cells[1, 2] = variable.name;
                worksheet.Cells[2, 1] = "Sample size";
                worksheet.Cells[2, 2] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
                worksheet.Cells[3, 1] = "Sample mean";
                worksheet.Cells[3, 2] = "=AVERAGE(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
                worksheet.Cells[4, 1] = "Sample Std. Dev";
                worksheet.Cells[4, 2] = "=STDEV(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
                if (model.useMean && model.useStd)
                {
                    PrintCategories(worksheet, 5, "mean", dataSet, variable);
                    PrintCategories(worksheet, 8, "Std. Dev", dataSet, variable);
                } else if (model.useMean && !model.useStd)
                {
                    PrintCategories(worksheet, 5, "mean", dataSet, variable);
                } else if (!model.useMean && model.useStd)
                {
                    PrintCategories(worksheet, 5, "Std. Dev", dataSet, variable);
                }
                
                
            }
            System.Diagnostics.Debug.WriteLine("YES");
        }

        private void PrintCategories(_Worksheet _sheet, int rowIn, String input, DataSet dataSet, Variable variable)
        {
            var row = rowIn;
            _sheet.Cells[row, 1] = "Confidence level ("+ input + ")";
            if (input.Equals("mean"))
            {
                _sheet.Cells[row++, 2] = model.mean.ToString();
            } else
            {
                _sheet.Cells[row++, 2] = model.std.ToString();
            }
            _sheet.Cells[row, 1] = "Lower limit";
            if (input.Equals("mean"))
            {
                _sheet.Cells[row++, 2] = "=CONFIDENCE("+ 0.95.ToString() + ";" + 39921.92.ToString()+ ";" + 208.ToString() +")";
            }
            else
            {
                _sheet.Cells[row++, 2] = model.std.ToString();
            }

            _sheet.Cells[row, 1] = "Upper limit";
            if (input.Equals("mean"))
            {
                _sheet.Cells[row++, 2] = "=AVERAGE(" + dataSet.getWorksheet().Name + "!" + variable.Range + ") + CONFIDENCE(" + (model.mean / 100.0).ToString() + ",AVERAGE(" + dataSet.getWorksheet().Name + "!" + variable.Range + "),ROWS(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
            }
            else
            {
                _sheet.Cells[row++, 2] = model.std.ToString();
            }
        }
    }
}
