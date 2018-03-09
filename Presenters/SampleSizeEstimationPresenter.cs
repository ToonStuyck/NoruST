using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using NoruST.Forms;
using NoruST.Models;
using DataSet = NoruST.Domain.DataSet;

namespace NoruST.Presenters
{
    public class SampleSizeEstimationPresenter
    {
        private SampleSizeEstimationForm view;
        private SampleSizeEstimationModel model;
        private DataSetManagerPresenter dataSetPresenter;

        public SampleSizeEstimationPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new SampleSizeEstimationModel();
        }

        public SampleSizeEstimationModel getModel()
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

        public void estimateSampleSize()
        {
            //var doCalculate = new SummaryStatisticsBool(meanSampleSize: rdbMean.Checked, proportionSampleSize: rdbProportion.Checked, differenceOfMeansSampleSize: rdbDifferenceOfMeans.Checked, differenceOfProportionsSampleSize: rdbDifferenceOfProportions.Checked);

            //new SampleSize().Print(doCalculate, (int)nudConfidenceLevel.Value, txtMarginOfError.Text, txtEstimate1.Text, txtEstimate2.Text);
            double marginOfError, estimated1, estimated2 = 0.0, confidenceLevel = ((double)model.confidenceLevel) / 100.0;
            if (!double.TryParse(model.marginOfError.Replace(" ", "").Replace(".", ",").Trim(), out marginOfError) && !double.TryParse(model.marginOfError.Replace(" ", "").Replace(",", ".").Trim(), out marginOfError))
            {
                MessageBox.Show("The Margin of Error is not a valid number.", "NoruST - Sample Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(model.estimation1.Replace(" ", "").Replace(",", ".").Trim(), out estimated1) && !double.TryParse(model.estimation1.Replace(" ", "").Replace(".", ",").Trim(), out estimated1))
            {
                MessageBox.Show("The Estimation is not a valid number.", "NoruST - Sample Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (model.diffProportion && !double.TryParse(model.estimation2.Replace(" ", "").Replace(",", ".").Trim(), out estimated2) && !double.TryParse(model.estimation2.Replace(" ", "").Replace(".", ",").Trim(), out estimated2))
            {
                MessageBox.Show("The 2nd Estimation is not a valid number.", "NoruST - Sample Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Worksheet sheet = WorksheetHelper.NewWorksheet("Sample Size");
            int row = 1, column = 1;

            string txtValue = "Sample Size for ";
            txtValue += model.mean ? "Mean" : model.proportion ? "Proportion" : model.diffMean ? "Difference of Means" : "Difference of Proportions";
            sheet.Cells[row++, column] = txtValue;

            sheet.Cells[row, column] = "Confidence Level";
            var confidenceLevelRow = row;
            sheet.Cells[row, column + 1] = confidenceLevel;
            ((Range)sheet.Cells[row++, column + 1]).NumberFormat = "0.00%";
            sheet.Cells[row, column] = "Alpha";
            var alphaRow = row;
            sheet.Cells[row++, column + 1] = "=1-" + AddressConverter.CellAddress(confidenceLevelRow, column + 1);
            sheet.Cells[row, column] = "Margin of Error";
            var marginOfErrorRow = row;
            sheet.Cells[row++, column + 1] = marginOfError;

            txtValue = "Estimated ";
            txtValue += model.mean ? "Standard Deviation" : model.proportion ? "Proportion" : model.diffMean ? "Common Standard Deviation" : "Proportion 1";
            sheet.Cells[row, column] = txtValue;

            var estimate1Row = row;
            sheet.Cells[row++, column + 1] = estimated1;

            var estimate2Row = 0;
            if (model.diffProportion)
            {
                sheet.Cells[row, column] = "Estimated Proportion 2";
                estimate2Row = row;
                sheet.Cells[row++, column + 1] = estimated2;
            }

            sheet.Cells[row, column] = "Sample Size";

            if (model.mean)
                sheet.WriteFunction(row, column + 1, "CEILING.MATH(T.INV.2T(" + AddressConverter.CellAddress(alphaRow, column + 1) + ",1000000)^2*" + AddressConverter.CellAddress(estimate1Row, column + 1) + "^2/" + AddressConverter.CellAddress(marginOfErrorRow, column + 1) + "^2)");
            if (model.proportion)
                sheet.WriteFunction(row, column + 1, "CEILING.MATH(T.INV.2T(" + AddressConverter.CellAddress(alphaRow, column + 1) + ",1000000)^2*" + AddressConverter.CellAddress(estimate1Row, column + 1) + "*(1-" + AddressConverter.CellAddress(estimate1Row, column + 1) + ")/" + AddressConverter.CellAddress(marginOfErrorRow, column + 1) + "^2)");
            if (model.diffMean)
                sheet.WriteFunction(row, column + 1, "CEILING.MATH(2*T.INV.2T(" + AddressConverter.CellAddress(alphaRow, column + 1) + ",1000000)^2*" + AddressConverter.CellAddress(estimate1Row, column + 1) + "^2/" + AddressConverter.CellAddress(marginOfErrorRow, column + 1) + "^2)");
            if (model.diffProportion)
                sheet.WriteFunction(row, column + 1, "CEILING.MATH(T.INV.2T(" + AddressConverter.CellAddress(alphaRow, column + 1) + ",1000000)^2*(" + AddressConverter.CellAddress(estimate1Row, column + 1) + "*(1-" + AddressConverter.CellAddress(estimate1Row, column + 1) + ")+" + AddressConverter.CellAddress(estimate2Row, column + 1) + "*(1-" + AddressConverter.CellAddress(estimate2Row, column + 1) + "))/" + AddressConverter.CellAddress(marginOfErrorRow, column + 1) + "^2)");

            ((Range)sheet.Cells[1, 1]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 2]).EntireColumn.AutoFit();
        }
    }
}
