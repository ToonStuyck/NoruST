using System;
using System.Windows.Forms;
using NoruST.Forms;
using NoruST.Presenters;
using NoruST.Domain;
using System.Collections.Generic;

namespace NoruST.Forms
{
    public partial class RunsTestForRandomnessForm : Form
    {
        private RunsTestForRandomnessPresenter presenter;
        private const string formTitle = "NoruST - Runs Test";

        public RunsTestForRandomnessForm()
        {
            InitializeComponent();
        }

        public void setPresenter(RunsTestForRandomnessPresenter RunsTestForRandomnessPresenter)
        {
            this.presenter = RunsTestForRandomnessPresenter;
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


        private void ui_Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            List<Variable> variables = new List<Variable>();
            foreach (DataGridViewRow row in uiDataGridView_Variables.Rows)
            {
                if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheck.Name].Value))
                {
                    variables.Add((Variable)row.DataBoundItem);
                }
            }

            bool check = presenter.checkInput(variables, selectedDataSet(), rdbMean.Checked, rdbMedian.Checked, rdbCustomValue.Checked, uiTextBox_CustomCutoffValue.Text);
            if (check)
            {
                Close();
            }
        }
    }
}