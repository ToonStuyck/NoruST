using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NoruST.Analyses;
using NoruST.Domain;
using NoruST.Presenters;

namespace NoruST.Forms
{
    public partial class ScatterplotForm : Form
    {
        private ScatterPlotPresenter presenter;

        public ScatterplotForm()
        {
            InitializeComponent();
        }

        public void setPresenter(ScatterPlotPresenter presenter)
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
                uiDataGridViewColumn_VariableCheckX.Width = 20;
                uiDataGridViewColumn_VariableCheckY.Width = 20;
                uiDataGridView_Variables.Columns[2].ReadOnly = true;
                uiDataGridView_Variables.Columns[3].ReadOnly = true;
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
            List<Variable> variablesX = new List<Variable>();
            List<Variable> variablesY = new List<Variable>();
            foreach (DataGridViewRow row in uiDataGridView_Variables.Rows)
            {
                if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheckX.Name].Value))
                {
                    variablesX.Add((Variable)row.DataBoundItem);
                }
                if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheckY.Name].Value))
                {
                    variablesY.Add((Variable)row.DataBoundItem);
                }
            }
            presenter.createScatterPlot(variablesX, variablesY);
            Close();
        }

        private void uiButton_Cancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}