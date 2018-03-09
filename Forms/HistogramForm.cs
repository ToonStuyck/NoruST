using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NoruST.Analyses;
using NoruST.Domain;
using NoruST.Presenters;

namespace NoruST.Forms
{
    public partial class HistogramForm : Form
    {
        private HistogramPresenter presenter;

        public HistogramForm()
        {
            InitializeComponent();
        }

        public void setPresenter(HistogramPresenter presenter)
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
                checkBox1.DataBindings.Add("Checked", presenter.getModel(), "useBins");
                numericUpDown1.DataBindings.Add("Value", presenter.getModel(), "bins",false, DataSourceUpdateMode.OnPropertyChanged);
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

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            List<Variable> variables = new List<Variable>();
            foreach (DataGridViewRow row in uiDataGridView_Variables.Rows)
            {
                if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheck.Name].Value) == true)
                {
                    variables.Add((Variable)row.DataBoundItem);
                }
            }
            presenter.createHistograms(variables);
            Close();
        }

        private void uiButton_Cancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}