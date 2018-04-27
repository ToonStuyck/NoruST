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
    public class ConfidencePresenter2
    {
        private Confidence2 view;
        private ConfidenceModel2 model;
        private DataSetManagerPresenter dataSetPresenter;

        public ConfidencePresenter2(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new ConfidenceModel2();
        }

        public ConfidenceModel2 getModel()
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
            if (variables.Count == 1)
            {
                foreach (Variable variable in variables)
                {
                    worksheet.Cells[1, 1] = "Conf. intervals (Proportion)";
                    worksheet.Cells[1, 2] = variable.name;
                    worksheet.Cells[2, 1] = "Sample size";
                    worksheet.Cells[2, 2] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
                    worksheet.Cells[3, 1] = "Sample proportion";
                    worksheet.Cells[3, 2] = "=COUNTIF(" + dataSet.getWorksheet().Name + "!" + variable.Range + "," + 0 + ") / " + (worksheet.Cells[2, 2] as Range).Value;
                    PrintCategories(worksheet, 4, dataSet);
                }
            } else if (variables.Count == 2)
            {
                worksheet.Cells[1, 1] = "Conf. intervals (Proportion)";
                worksheet.Cells[1, 2] = variables[0].name;
                worksheet.Cells[1, 3] = variables[1].name;
                worksheet.Cells[2, 1] = "Sample size";
                worksheet.Cells[2, 2] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variables[0].Range + ")";
                worksheet.Cells[2, 3] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variables[1].Range + ")";
                worksheet.Cells[3, 1] = "Sample proportion";
                worksheet.Cells[3, 2] = "=COUNTIF(" + dataSet.getWorksheet().Name + "!" + variables[0].Range + "," + 0 + ") / " + (worksheet.Cells[2, 2] as Range).Value;
                worksheet.Cells[3, 3] = "=COUNTIF(" + dataSet.getWorksheet().Name + "!" + variables[1].Range + "," + 0 + ") / " + (worksheet.Cells[2, 3] as Range).Value;
                PrintCategories2(worksheet, 4, dataSet);
            }
        }

        private void PrintCategories(_Worksheet _sheet, int rowIn, DataSet dataSet)
        {
            double alpha = (100.0 - model.confidence) / 200.0;
            double norm = _sheet.Application.WorksheetFunction.NormSInv(alpha);
            var pValue = (_sheet.Cells[3, 2] as Range).Value;
            double p = Convert.ToDouble(pValue);
            double n = Convert.ToDouble((_sheet.Cells[2, 2] as Range).Value);
            double sqrt = Math.Sqrt((p * (1.0 - p) / n));
            var row = rowIn;
            _sheet.Cells[row, 1] = "Confidence level";
            _sheet.Cells[row++, 2] = model.confidence.ToString();

            _sheet.Cells[row, 1] = "Lower limit";
            double tmp = p - Math.Abs((norm * sqrt));
            _sheet.Cells[row++, 2] = tmp;

            _sheet.Cells[row, 1] = "Upper limit";
            tmp = p + Math.Abs((norm * sqrt));
            _sheet.Cells[row++, 2] = tmp;
        }

        private void PrintCategories2(_Worksheet _sheet, int rowIn, DataSet dataSet)
        {
            double alpha = (100.0 - model.confidence) / 200.0;
            double norm = _sheet.Application.WorksheetFunction.NormSInv(alpha);
            var pValue = (_sheet.Cells[3, 2] as Range).Value;
            var pValue2 = (_sheet.Cells[3, 3] as Range).Value;
            double p = 1.0 - Convert.ToDouble(pValue);
            double p2 = 1.0 - Convert.ToDouble(pValue2);
            double n = Convert.ToDouble((_sheet.Cells[2, 2] as Range).Value);
            double n2 = Convert.ToDouble((_sheet.Cells[2, 3] as Range).Value);
            double sqrt = Math.Sqrt((p * (1.0 - p) / n) + (p2 * (1.0 - p2) / n2));
            var row = rowIn;
            _sheet.Cells[row, 1] = "Confidence level";
            _sheet.Cells[row++, 2] = model.confidence.ToString();

            _sheet.Cells[row, 1] = "Lower limit";
            double tmp = p - p2 - Math.Abs((norm * sqrt));
            _sheet.Cells[row++, 2] = tmp;

            _sheet.Cells[row, 1] = "Upper limit";
            tmp = p - p2 + Math.Abs((norm * sqrt));
            _sheet.Cells[row++, 2] = tmp;
        }
    }
}
