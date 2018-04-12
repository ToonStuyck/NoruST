using NoruST.Forms;
using NoruST.Models;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSet = NoruST.Domain.DataSet;
using NoruST.Domain;
using Microsoft.Office.Interop.Excel;

namespace NoruST.Presenters
{
    public class CorrelationCovariancePresenter
    {
        private CorrelationCovarianceForm view;
        private CorrelationCovariance model;
        private DataSetManagerPresenter dataSetPresenter;

        public CorrelationCovariancePresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new CorrelationCovariance();
        }

        public CorrelationCovariance getModel()
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

        public void createCorrelationCovariance(List<Variable> variablesX, DataSet dataSet)
        {
            _Worksheet sheet = WorksheetHelper.NewWorksheet("Correlation Covariance");
            int col = 1;
            int row = 1;
            int countX = variablesX.Count;
            int i = 0;
            sheet.Cells[row, col] = "Correlation";
            sheet.Cells[row + countX+2, col] = "Covariance";
            while (i<variablesX.Count)
            {
                col = col + 1;
                sheet.Cells[row, col] = variablesX[i].name.ToString();
                i++;
            }
            i = 0;
            col = 1;
            row = 1;
            while (i < variablesX.Count)
            {
                row = row + 1;
                sheet.Cells[row, col] = variablesX[i].name.ToString();
                i++;
            }

            row = countX + 3;
            col = 1;
            i = 0;
            while (i < variablesX.Count)
            {
                col = col + 1;
                sheet.Cells[row, col] = variablesX[i].name.ToString();
                i++;
            }
            i = 0;
            col = 1;
            row = countX + 3;
            while (i < variablesX.Count)
            {
                row = row + 1;
                sheet.Cells[row, col] = variablesX[i].name.ToString();
                i++;
            }

            // CORRELATION
            i = 0;
            row = 2;
            col = 2;
            while (i < variablesX.Count)
            {
                String range1 = variablesX[i].Range;
                int j = 0;
                while (j < variablesX.Count)
                {
                    String range2 = variablesX[j].Range;
                    sheet.Cells[row + i, col + j] = "=CORREL(" + dataSet.getWorksheet().Name + "!" + range1 + "," + dataSet.getWorksheet().Name + "!" + range2 + ")";
                    j++;
                }
                i++;
            }

            // COVARIANCE
            i = 0;
            row = countX + 4;
            col = 2;
            while (i < variablesX.Count)
            {
                String range1 = variablesX[i].Range;
                int j = 0;
                while (j < variablesX.Count)
                {
                    String range2 = variablesX[j].Range;
                    sheet.Cells[row + i, col + j] = "=COVARIANCE.S(" + dataSet.getWorksheet().Name + "!" + range1 + "," + dataSet.getWorksheet().Name + "!" + range2 + ")";
                    j++;
                }
                i++;
            }
        }
    }
}
