using NoruST.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoruST.Domain;

namespace NoruST.Forms
{
    public partial class HypotheseForm2 : Form
    {
        private HypothesePresenter2 presenter;

        public HypotheseForm2()
        {
            InitializeComponent();
        }

        public void setPresenter(HypothesePresenter2 presenter)
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
                textBox1.DataBindings.Add("Text", presenter.getModel(), "Null");
                checkBox2.DataBindings.Add("Checked", presenter.getModel(), "equal");
                checkBox1.DataBindings.Add("Checked", presenter.getModel(), "greater");
                numericUpDown1.DataBindings.Add("Value", presenter.getModel(), "alpha");
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
            presenter.createHypothese(variables, selectedDataSet());
            Close();
        }

        private void uiButton_Cancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void tlpForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
