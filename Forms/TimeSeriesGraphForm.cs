using System;
using System.Windows.Forms;
using NoruST.Forms;
using NoruST.Presenters;
using NoruST.Domain;
using System.Collections.Generic;

namespace NoruST.Forms
{
    public partial class TimeSeriesGraphForm : Form
    {
        private TimeSeriesGraphPresenter presenter;
        private const string formTitle = "NoruST - Time Series Graph";

        public TimeSeriesGraphForm()
        {
            InitializeComponent();

        }

        public void setPresenter(TimeSeriesGraphPresenter TimeSeriesGraphPresenter)
        {
            this.presenter = TimeSeriesGraphPresenter;
            bindModelToView();
            selectDataSet(selectedDataSet());
        }

        private void bindModelToView()
        {
            ui_ComboBox_SelectDataSets.DataSource = presenter.dataSets();
            ui_ComboBox_SelectDataSets.DisplayMember = "name";
            ui_ComboBox_SelectDataSets.SelectedIndexChanged += (obj, eventArgs) =>
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
            return (DataSet)ui_ComboBox_SelectDataSets.SelectedItem;
        }

        public void selectDataSet(DataSet dataSet)
        {
            ui_ComboBox_SelectDataSets.SelectedItem = null;
            ui_ComboBox_SelectDataSets.SelectedItem = dataSet;
        }

        private void Cancelbutton_clicked(object sender, EventArgs e)
        {
            Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiButton_Ok_Click(object sender, EventArgs e)
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
           bool inputOk = presenter.checkInput(variablesX, variablesY, selectedDataSet());
           if (inputOk)
           {
               Close();
           }
        }

    } 
}

