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
            if (variables.Count == 1)
            {
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
                    worksheet.Cells[3, 2] = prop;
                    if (model.equal)
                    {
                        PrintCategories(worksheet, 5, "equal", dataSet);
                    }
                    else if (model.greater)
                    {
                        PrintCategories(worksheet, 5, "greater", dataSet);
                    }
                }
            } else if (variables.Count == 2)
            {
                worksheet.Cells[1, 1] = "Hypothesis test";
                worksheet.Cells[1, 2] = variables[0].name;
                worksheet.Cells[1, 3] = variables[1].name;
                worksheet.Cells[2, 1] = "Sample size";
                worksheet.Cells[2, 2] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variables[0].Range + ")";
                worksheet.Cells[2, 3] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variables[1].Range + ")";
                worksheet.Cells[3, 1] = "Sample proportion";
                string ran = variables[0].Range.ToString();
                string ran1 = variables[1].Range.ToString();
                Array dist = dataSet.getWorksheet().Range[ran].Value;
                Array dist1 = dataSet.getWorksheet().Range[ran1].Value;
                double count = 0;
                double count1 = 0;
                foreach (var item in dist)
                {
                    if (Convert.ToInt32(item) == 0)
                    {
                        System.Diagnostics.Debug.WriteLine(item);
                        count = count + 1;
                    }
                }
                foreach (var item in dist1)
                {
                    if (Convert.ToInt32(item) == 0)
                    {
                        System.Diagnostics.Debug.WriteLine(item);
                        count1 = count1 + 1;
                    }
                }
                double n = (worksheet.Cells[2, 2] as Range).Value;
                double n1 = (worksheet.Cells[2, 3] as Range).Value;
                double prop = count / n;
                double prop1 = count1 / n1;
                worksheet.Cells[3, 2] = prop;
                worksheet.Cells[3, 3] = prop1;
                if (model.equal)
                {
                    PrintCategories2(worksheet, 5, "equal", dataSet);
                }
                else if (model.greater)
                {
                    PrintCategories2(worksheet, 5, "greater", dataSet);
                }
            }
            
        }

        private void PrintCategories(_Worksheet _sheet, int rowIn, String input, DataSet dataSet)
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

        private void PrintCategories2(_Worksheet _sheet, int rowIn, String input, DataSet dataSet)
        {
            double n = (_sheet.Cells[2, 2] as Range).Value;
            double n1 = (_sheet.Cells[2, 3] as Range).Value;
            double p = (_sheet.Cells[3, 2] as Range).Value;
            double p1 = (_sheet.Cells[3, 3] as Range).Value;
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
            var row = rowIn;

            _sheet.Cells[row, 1] = "Pooled Proportion";
            double pooled = ((int)(n * p) + (int)(n1 * p1)) / (n + n1);
            double error = Math.Sqrt((pooled * (1 - pooled)) * (1.0/n + 1.0/n1));
            _sheet.Cells[row++, 2] = pooled;

            _sheet.Cells[row, 1] = "Difference Between Proportions";
            _sheet.Cells[row++, 2] = p - p1;

            _sheet.Cells[row, 1] = "Hypothesized mean";
            _sheet.Cells[row++, 2] = 0;

            _sheet.Cells[row, 1] = "Alternative Hypothesis";
            if (input.Equals("equal"))
            {
                _sheet.Cells[row++, 2] = "'=/= " + 0;
            }
            else
            {
                _sheet.Cells[row++, 2] = "> " + 0;
            }

            _sheet.Cells[row, 1] = "Alpha";
            _sheet.Cells[row++, 2] = model.alpha;

            _sheet.Cells[row, 1] = "Standard Error";
            _sheet.Cells[row++, 2] = error;

            _sheet.Cells[row, 1] = "Test Statistic";
            double z = (p - p1) / error;
            _sheet.Cells[row++, 2] = z;

            _sheet.Cells[row, 1] = "p-Value";
            double pValue = _sheet.Application.WorksheetFunction.TDist(z, n - 1, tail);
            //double pValue = _sheet.Application.WorksheetFunction.NormSDist(z);
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
