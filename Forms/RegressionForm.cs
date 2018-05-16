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
using System.Diagnostics;
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

		private DataSet selectedPredictionDataSet()
		{
			return (DataSet)comboBoxPredData.SelectedItem;
		}

		public RegressionForm()
        {
            InitializeComponent();
        }

        private void ui_Button_Cancel_Click(object sender, EventArgs e)
        {
			//Debug.WriteLine("PRINTENNNNNNNNNNNNNNNN");
			Close();
        }

        private void uiButton_Ok_Click(object sender, EventArgs e)
        {
			List<Variable> variablesD = new List<Variable>();
			List<Variable> variablesI = new List<Variable>();
			List<Variable> variablesPrediction = new List<Variable>();

			bool[] graphs = new bool[5];

			//selectedPredictionDataSet().getVariables()

			foreach (DataGridViewRow row in uiDataGridView_Variables.Rows)
			{
				if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheckD.Name].Value))
				{
					variablesD.Add((Variable)row.DataBoundItem);

				}
				if (Convert.ToBoolean(row.Cells[uiDataGridViewColumn_VariableCheckI.Name].Value))
				{
					variablesI.Add((Variable)row.DataBoundItem);
					System.Diagnostics.Debug.WriteLine("row.headercell = {0} ", row.HeaderCell); 
				}
			}
			graphs[0] = (chkFittedValuesVsActualYValues.Checked) ? true : false;
			graphs[1] = (chkResidualsVsFittedValues.Checked) ?  true : false;
			graphs[2] = (chkResidualsVsXValues.Checked) ?  true : false;
			graphs[3] = (chkActualVsX.Checked) ?  true : false;
			graphs[4] = (chkFittedVsX.Checked) ?  true : false;

			checkOptions();

			//presenter.createRegression(variablesD, variablesI, selectedDataSet(), confidenceLevel, selectedDataSet(), graphs);
			presenter.createRegression(variablesD, variablesI, selectedDataSet(), selectedPredictionDataSet(), graphs);
			presenter.resetNrofGraphs(); //to make sure that when redoing regression, the new graphs are drawn right below the data, io under previous graphs
			Close();
            
        }

		private void checkOptions()
		{
			presenter.setConfLevel(Convert.ToDouble(nudConfidenceLevel.Value));
			if (chkBoxDW.Checked)
				presenter.setDW(true);
			else
				presenter.setDW(false);

			if (chckBoxPrediction.Checked)
			{
				if (uiComboBox_DataSets.SelectedItem == comboBoxPredData.SelectedItem)
				{
					MessageBox.Show("Data set for prediction can't be the same as regression dataset");
					return;

				}
				presenter.setPrediction(true);
				presenter.setPredictionLevel(Convert.ToDouble(nudPredictionLevel.Value));
			}
			else
				presenter.setPrediction(false);
		}

        private void bindModelToView()
        {
            uiComboBox_DataSets.DataSource = presenter.dataSets();
            uiComboBox_DataSets.DisplayMember = "Name";

			var DataSetListCopy = new BindingList<DataSet>();//make copy of datasets
			foreach(DataSet v in presenter.dataSets())
			{
				DataSetListCopy.Add(v);
			}
			comboBoxPredData.DataSource = DataSetListCopy;
			comboBoxPredData.DisplayMember = "name";

			//nameDataGridViewTextBoxColumn.DataPropertyName = "name";
			//rangeDataGridViewTextBoxColumn.DataPropertyName = "Range";
			uiComboBox_DataSets.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedDataSet() == null) return;
				uiDataGridView_Variables.DataSource = selectedDataSet().getVariables();
                uiDataGridViewColumn_VariableCheckD.Width = 50;
                uiDataGridViewColumn_VariableCheckI.Width = 50;
                uiDataGridView_Variables.Columns[2].ReadOnly = true;
                uiDataGridView_Variables.Columns[3].ReadOnly = true;
            };
        }

		private void chkCheckAllOptions_CheckedChanged(object sender, EventArgs e)
		{
			if (chkCheckAllOptions.Checked)
			{
				chkFittedValuesVsActualYValues.Checked = true;
				chkResidualsVsFittedValues.Checked = true;
				chkResidualsVsXValues.Checked = true;
				chkActualVsX.Checked = true;
				chkFittedVsX.Checked = true;
			}
			else
			{
				chkFittedValuesVsActualYValues.Checked = false;
				chkResidualsVsFittedValues.Checked = false;
				chkResidualsVsXValues.Checked = false;
				chkActualVsX.Checked = false;
				chkFittedVsX.Checked = false;
			}
		}

		private void chckBoxPrediction_CheckedChanged(object sender, EventArgs e)
		{
			if (chckBoxPrediction.Checked)
			{
				lblPredLevel.Enabled = true;
				lblPredData.Enabled = true;
				nudPredictionLevel.Enabled = true;
				comboBoxPredData.Enabled = true;
			}
			else
			{
				lblPredLevel.Enabled = false;
				lblPredData.Enabled = false;
				nudPredictionLevel.Enabled = false;
				comboBoxPredData.Enabled = false;
			}
		}
	}
}