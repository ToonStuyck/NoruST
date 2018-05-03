//using NoruST.Analyses;
//using NoruST.Models;
//using System.Windows.Forms;
//using NoruST.Domain;
//using NoruST.Presenters;
//using System.Collections.Generic;

//using System;

//using System.ComponentModel;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

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
using Microsoft.Office.Interop.Excel;

namespace NoruST.Forms
{
	public partial class RegressionForm : Form
	{
		private RegressionPresenter presenter;

        public void setPresenter(RegressionPresenter regressionPresenter)
        {
            this.presenter = regressionPresenter;
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

        public RegressionForm()
        {
            InitializeComponent();
        }

        private void ui_Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uiButton_Ok_Click(object sender, EventArgs e)
        {
			_Worksheet sheet = WorksheetHelper.NewWorksheet("Regression");
			List<Variable> variables = new List<Variable>();

			presenter.createRegression(variables);
			Close();
            
        }

        private void bindModelToView()
        {
            uiComboBox_DataSets.DataSource = presenter.dataSets();
            uiComboBox_DataSets.DisplayMember = "name";
            //nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            //rangeDataGridViewTextBoxColumn.DataPropertyName = "Range";
            uiComboBox_DataSets.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedDataSet() == null) return;
                dgvDataSet.DataSource = selectedDataSet().getVariables();
                //uiDataGridViewColumn_VariableCheckX.Width = 20;
                //uiDataGridViewColumn_VariableCheckY.Width = 20;
                //uiDataGridView_Variables.Columns[2].ReadOnly = true;
                //uiDataGridView_Variables.Columns[3].ReadOnly = true;
            };
        }


	}
}