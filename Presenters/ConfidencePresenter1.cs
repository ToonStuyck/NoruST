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
            if (variables.Count == 1)
            {
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
                        PrintCategories(worksheet, 5, "mean", dataSet);
                        PrintCategories(worksheet, 8, "Std. Dev", dataSet);
                    }
                    else if (model.useMean && !model.useStd)
                    {
                        PrintCategories(worksheet, 5, "mean", dataSet);
                    }
                    else if (!model.useMean && model.useStd)
                    {
                        PrintCategories(worksheet, 5, "Std. Dev", dataSet);
                    }
                }
            } else if (variables.Count == 2)
            {
                worksheet.Cells[1, 1] = "Conf. intervals";
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
                //worksheet.Cells[4, 2] = "=STDEV(" + dataSet.getWorksheet().Name + "!" + tmp + ',' + tmp2 + ")";
                if (model.useMean && model.useStd)
                {
                    PrintCategories(worksheet, 5, "mean", dataSet);
                    PrintCategories(worksheet, 8, "Std. Dev", dataSet);
                }
                else if (model.useMean && !model.useStd)
                {
                    PrintCategories(worksheet, 5, "mean", dataSet);
                }
                else if (!model.useMean && model.useStd)
                {
                    PrintCategories(worksheet, 5, "Std. Dev", dataSet);
                }
            }
            
        }

        private void PrintCategories(_Worksheet _sheet, int rowIn, String input, DataSet dataSet)
        {
            double alpha = (100.0 - model.mean) / 200.0;
            double norm = _sheet.Application.WorksheetFunction.NormSInv(alpha);
            var stdValue = (_sheet.Cells[4, 2] as Range).Value;
            double std = Convert.ToDouble(stdValue);
            double sqrt = Math.Sqrt(Convert.ToDouble((_sheet.Cells[2,2] as Range).Value));
            double avr = Convert.ToDouble((_sheet.Cells[3, 2] as Range).Value);
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
                double tmp = avr - Math.Abs((norm * std / sqrt));
                _sheet.Cells[row++, 2] = tmp; 
            }
            else
            {
                double tmp = std - Math.Abs((norm * std / sqrt));
                _sheet.Cells[row++, 2] = tmp;
            }

            _sheet.Cells[row, 1] = "Upper limit";
            if (input.Equals("mean"))
            {
                double tmp = avr + Math.Abs((norm * std / sqrt));
                _sheet.Cells[row++, 2] = tmp;
            }
            else
            {
                double tmp = std + Math.Abs((norm * std / sqrt));
                _sheet.Cells[row++, 2] = tmp;
            }
        }
    }
}
