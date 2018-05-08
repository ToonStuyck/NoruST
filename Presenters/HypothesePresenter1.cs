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
    public class HypothesePresenter1
    {
        private HypotheseForm1 view;
        private HypotheseModel1 model;
        private DataSetManagerPresenter dataSetPresenter;

        public HypothesePresenter1(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new HypotheseModel1();
        }

        public HypotheseModel1 getModel()
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
                    worksheet.Cells[3, 1] = "Sample mean";
                    worksheet.Cells[3, 2] = "=AVERAGE(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
                    worksheet.Cells[4, 1] = "Sample Std. Dev";
                    worksheet.Cells[4, 2] = "=STDEV(" + dataSet.getWorksheet().Name + "!" + variable.Range + ")";
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
                worksheet.Cells[1, 2] = variables[0].name + " - " + variables[1].name;
                worksheet.Cells[2, 1] = "Sample size";
                worksheet.Cells[2, 2] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + variables[0].Range + ")";
                worksheet.Cells[3, 1] = "Sample mean";
                worksheet.Cells[3, 2] = "=AVERAGE(" + dataSet.getWorksheet().Name + "!" + variables[0].Range + ") - AVERAGE(" + dataSet.getWorksheet().Name + "!" + variables[1].Range + ")";
                worksheet.Cells[4, 1] = "Sample Std. Dev";

                int length = Convert.ToInt32((worksheet.Cells[2, 2] as Range).Value);
                double[] vals1 = new double[length];
                string ran1 = variables[0].Range.ToString();
                Array arr1 = dataSet.getWorksheet().Range[ran1].Value;

                double[] vals2 = new double[length];
                string ran2 = variables[1].Range.ToString();
                Array arr2 = dataSet.getWorksheet().Range[ran2].Value;

                int count = 0;
                foreach (var item in arr1)
                {
                    double temp = Convert.ToDouble(item);
                    vals1[count] = temp;
                    count = count + 1;
                }
                count = 0;
                foreach (var item in arr2)
                {
                    double temp = Convert.ToDouble(item);
                    vals2[count] = temp;
                    count = count + 1;
                }

                count = 0;
                while (count < vals2.Length)
                {
                    vals2[count] = vals2[count] - vals1[count];
                    count++;
                }

                double std = worksheet.Application.WorksheetFunction.StDev(vals2);
                worksheet.Cells[4, 2] = std;


                //worksheet.Cells[4, 2] = "=STDEV(" + dataSet.getWorksheet().Name + "!" + variables[0].Range + ") + STDEV(" + dataSet.getWorksheet().Name + "!" + variables[1].Range + ")";
                if (model.equal)
                {
                    PrintCategories(worksheet, 5, "equal", dataSet);
                }
                else if (model.greater)
                {
                    PrintCategories(worksheet, 5, "greater", dataSet);
                }
            }
            
        }

        private void PrintCategories(_Worksheet _sheet, int rowIn, String input, DataSet dataSet)
        {
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
            double mean = (_sheet.Cells[3, 2] as Range).Value;
            double s = (_sheet.Cells[4, 2] as Range).Value;
            double n = (_sheet.Cells[2, 2] as Range).Value;
            double den = (s / Math.Sqrt(n));
            double mu = Convert.ToDouble(model.Null);
            double nom = mean - mu;
            double t = nom / den;
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
                _sheet.Cells[row++, 2] = "> " +model.Null;
            }
            _sheet.Cells[row, 1] = "Alpha";
            _sheet.Cells[row++, 2] = model.alpha;

            _sheet.Cells[row, 1] = "t-Test Statistic";
            _sheet.Cells[row++, 2] = t;

            double p = _sheet.Application.WorksheetFunction.TDist(Math.Abs(t), n - 1, tail);

            _sheet.Cells[row, 1] = "p-Value";
            _sheet.Cells[row++, 2] = p;

            _sheet.Cells[row, 1] = "Null Hypothesis";
            if (p <= alpha)
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
