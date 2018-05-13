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

            if(presenter.getModel().p == null)
            {
                MessageBox.Show("Probability must be filled in and must be a number.");
                return;
            }

            double p2 = Convert.ToDouble(presenter.getModel().p);
            if (p2 < 0 || p2 > 1)
            {
                MessageBox.Show("Probabilty must be between 0 and 1.");
                return;
            }
            string cost1 = presenter.getModel().cost1;
            string cost2 = presenter.getModel().cost2;
            if (cost1 == null || cost2==null)
            {
                MessageBox.Show("Cost must be filled in and must be a number.");
                return;
            }

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
                uiDataGridViewColumn_VariableCheckD.Width = 50;
                uiDataGridViewColumn_VariableCheckI.Width = 50;
                uiDataGridView_Variables.Columns[0].ReadOnly = false;
                uiDataGridView_Variables.Columns[1].ReadOnly = false;
                uiDataGridView_Variables.Columns[2].ReadOnly = true;
                uiDataGridView_Variables.Columns[3].ReadOnly = true;
                Misclassification.DataBindings.Add("Checked", presenter.getModel(), "misclass");
                textBox1.DataBindings.Add("Text", presenter.getModel(), "p");
                textBox2.DataBindings.Add("Text", presenter.getModel(), "cost1");
                textBox3.DataBindings.Add("Text", presenter.getModel(), "cost2");
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
