using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoruST.Domain;
using NoruST.Presenters;
using DataSet = NoruST.Domain.DataSet;

namespace NoruST.Forms
{
    public partial class OneWayAnovaForm : Form
    {
        private OneWayAnovaPresenter presenter;

        public OneWayAnovaForm()
        {
            InitializeComponent();
        }

        public void setPresenter(OneWayAnovaPresenter presenter)
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
            };
        }

        private DataSet selectedDataSet()
        {
            return uiComboBox_DataSets.SelectedItem as DataSet;
        }

        public void selectDataSet(DataSet dataSet)
        {
            uiComboBox_DataSets.SelectedItem = null;
            uiComboBox_DataSets.SelectedItem = dataSet;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            presenter.getModel().noCorrection = checkBox1.Checked;
            presenter.getModel().bonferroni = checkBox2.Checked;
            presenter.getModel().scheffe = checkBox4.Checked;
            presenter.getModel().confidenceLevel = (double)nudConfidenceLevel.Value / 100.0;

            List<Variable> variables = new List<Variable>();
            foreach (DataGridViewRow row in uiDataGridView_Variables.Rows)
            {
                if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheck.Name].Value) == true)
                {
                    variables.Add((Variable)row.DataBoundItem);
                }
            }

            presenter.createOneWayAnova(variables);
            Hide();
        }

        private void uiButton_Cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
