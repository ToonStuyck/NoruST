using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoruST.Presenters;
using NoruST.Domain;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

namespace NoruST.Forms
{
    public partial class DiscriminantAnalyseForm : Form
    {

        private DiscriminantAnalysePresenter presenter;

        public void setPresenter(DiscriminantAnalysePresenter discriminantAnalysePresenter)
        {
            this.presenter = discriminantAnalysePresenter;
            bindModelToView();
            selectDataSet(selectedDataSet());
        }

        public void selectDataSet(DataSet dataSet)
        {
            uiComboBox_DataSets.SelectedItem = null;
            uiComboBox_DataSets.SelectedItem = dataSet;
        }

        private DataSet selectedDataSet()
        {
            return (DataSet)uiComboBox_DataSets.SelectedItem;
        }

        public DiscriminantAnalyseForm()
        {
            InitializeComponent();
        }

        private void ui_Button_Cancel_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("PRINTENNNNNNNNNNNNNNNN");
            Close();
        }

        private void uiButton_Ok_Click(object sender, EventArgs e)
        {
            List<Variable> variablesD = new List<Variable>();
            List<Variable> variablesI = new List<Variable>();
            List<Variable> variables = new List<Variable>();

            foreach (DataGridViewRow row in uiDataGridView_Variables.Rows)
            {
                if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheckD.Name].Value))
                {
                    variablesD.Add((Variable)row.DataBoundItem);
                }
                if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheckI.Name].Value))
                {
                    variablesI.Add((Variable)row.DataBoundItem);
                }
            }

            presenter.createDiscriminant(variablesD, variablesI, selectedDataSet());
            Close();

        }

        private void bindModelToView()
        {
            uiComboBox_DataSets.DataSource = presenter.dataSets();
            uiComboBox_DataSets.DisplayMember = "Name";
            //nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            //rangeDataGridViewTextBoxColumn.DataPropertyName = "Range";
            uiComboBox_DataSets.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedDataSet() == null) return;
                uiDataGridView_Variables.DataSource = selectedDataSet().getVariables();
                uiDataGridViewColumn_VariableCheckD.Width = 20;
                uiDataGridViewColumn_VariableCheckI.Width = 20;
                uiDataGridView_Variables.Columns[2].ReadOnly = true;
                uiDataGridView_Variables.Columns[3].ReadOnly = true;
            };
        }
    }
}
