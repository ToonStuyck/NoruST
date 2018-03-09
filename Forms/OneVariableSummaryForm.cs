using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NoruST.Domain;
using NoruST.Presenters;

namespace NoruST.Forms
{
    public partial class OneVariableSummaryForm : Form
    {
        private OneVariableSummaryPresenter presenter;

        public OneVariableSummaryForm()
        {
            InitializeComponent();
        }

        public void setPresenter(OneVariableSummaryPresenter presenter)
        {
            this.presenter = presenter;
            bindModelToView();
            selectDataSet(selectedDataSet());
        }

        private void bindModelToView()
        {
            uiComboBox_DataSets.DataSource = presenter.dataSets();
            uiComboBox_DataSets.DisplayMember = "name";
            uiComboBox_DataSets.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedDataSet() == null) return;
                uiDataGridView_Variables.DataSource = selectedDataSet().getVariables();
                uiDataGridViewColumn_VariableCheck.Width = 30;
                uiDataGridView_Variables.Columns[1].ReadOnly = true;
                uiDataGridView_Variables.Columns[2].ReadOnly = true;
                chkCount.DataBindings.Add("Checked", presenter.getModel(), "count");
                chkFirstQuartile.DataBindings.Add("Checked", presenter.getModel(), "firstQuartile");
                chkInterquartileRange.DataBindings.Add("Checked", presenter.getModel(), "interquartileRange");
                chkKurtosis.DataBindings.Add("Checked", presenter.getModel(), "kurtosis");
                chkMaximum.DataBindings.Add("Checked", presenter.getModel(), "maximum");
                chkMean.DataBindings.Add("Checked", presenter.getModel(), "mean");
                chkMeanAbsDev.DataBindings.Add("Checked", presenter.getModel(), "meanAbsDeviation");
                chkMedian.DataBindings.Add("Checked", presenter.getModel(), "median");
                chkMinimum.DataBindings.Add("Checked", presenter.getModel(), "minimum");
                chkMode.DataBindings.Add("Checked", presenter.getModel(), "mode");
                chkRange.DataBindings.Add("Checked", presenter.getModel(), "range");
                chkSkewness.DataBindings.Add("Checked", presenter.getModel(), "skewness");
                chkStandardDev.DataBindings.Add("Checked", presenter.getModel(), "standardDeviation");
                chkSum.DataBindings.Add("Checked", presenter.getModel(), "sum");
                chkThirdQuartile.DataBindings.Add("Checked", presenter.getModel(), "thirdQuartile");
                chkVariance.DataBindings.Add("Checked", presenter.getModel(), "variance");
            };
        }

        private DataSet selectedDataSet()
        {
            return (DataSet)uiComboBox_DataSets.SelectedItem;
        }

        public void selectDataSet(DataSet dataSet)
        {
            uiComboBox_DataSets.SelectedItem = null;
            uiComboBox_DataSets.SelectedItem = dataSet;
        }

        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {
            chkCount.Checked = presenter.getModel().count = chkAll.Checked;
            chkFirstQuartile.Checked = presenter.getModel().firstQuartile = chkAll.Checked;
            chkInterquartileRange.Checked = presenter.getModel().interquartileRange = chkAll.Checked;
            chkKurtosis.Checked = presenter.getModel().kurtosis = chkAll.Checked;
            chkMaximum.Checked = presenter.getModel().maximum = chkAll.Checked;
            chkMean.Checked = presenter.getModel().mean = chkAll.Checked;
            chkMeanAbsDev.Checked = presenter.getModel().meanAbsDeviation = chkAll.Checked;
            chkMedian.Checked = presenter.getModel().median = chkAll.Checked;
            chkMinimum.Checked = presenter.getModel().minimum = chkAll.Checked;
            chkMode.Checked = presenter.getModel().mode = chkAll.Checked;
            chkRange.Checked = presenter.getModel().range = chkAll.Checked;
            chkSkewness.Checked = presenter.getModel().skewness = chkAll.Checked;
            chkStandardDev.Checked = presenter.getModel().standardDeviation = chkAll.Checked;
            chkSum.Checked = presenter.getModel().sum = chkAll.Checked;
            chkThirdQuartile.Checked = presenter.getModel().thirdQuartile = chkAll.Checked;
            chkVariance.Checked = presenter.getModel().variance = chkAll.Checked;
        }

        private void uiButton_Cancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            List<Variable> variables = new List<Variable>();
            foreach (DataGridViewRow row in uiDataGridView_Variables.Rows)
            {
                if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheck.Name].Value))
                {
                    variables.Add((Variable)row.DataBoundItem);
                }
            }
            presenter.createSummaryStatistics(variables);
            Close();
        }
    }
}