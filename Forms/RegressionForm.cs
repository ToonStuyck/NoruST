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
			Close();
        }

        private void uiButton_Ok_Click(object sender, EventArgs e)
        {
			List<Variable> variablesD = new List<Variable>();
			List<Variable> variablesI = new List<Variable>();
			List<Variable> variablesPrediction = new List<Variable>();
			List<Variable> allvariablesPrediction = new List<Variable>();
			List<String> variablesNamesI = new List<String>();

			bool[] graphs = new bool[5];

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

			foreach (Variable elem in variablesI)
			{
				foreach (Variable elemP in selectedPredictionDataSet().getVariables())
				{
					if (elemP.name.Equals(elem.name))
					{
						variablesPrediction.Add(elemP);
						//System.Diagnostics.Debug.WriteLine("variableP name = " + elemP.name + "added to variablesPrediction");
					}

				}
			}
			graphs[0] = (chkFittedValuesVsActualYValues.Checked) ? true : false;
			graphs[1] = (chkResidualsVsFittedValues.Checked) ?  true : false;
			graphs[2] = (chkResidualsVsXValues.Checked) ?  true : false;
			graphs[3] = (chkActualVsX.Checked) ?  true : false;
			graphs[4] = (chkFittedVsX.Checked) ?  true : false;

			if(!checkOptions()) return;
			System.Diagnostics.Debug.WriteLine("selectedDataset.getRange= " + selectedDataSet().getRange().ToString());
			System.Diagnostics.Debug.WriteLine("selectedPredictionDataset.getRange= " + selectedPredictionDataSet().getRange().ToString());

			presenter.createRegression(variablesD, variablesI, selectedDataSet(), selectedPredictionDataSet(), graphs, variablesPrediction);
			presenter.resetNrofGraphs(); //to make sure that when redoing regression, the new graphs are drawn right below the data, io under previous graphs
			Close();
            
        }

		private bool checkOptions()
		{
			presenter.setConfLevel(Convert.ToDouble(nudConfidenceLevel.Value));
			presenter.setDW(chkBoxDW.Checked);

			if (chckBoxPrediction.Checked)
			{
				if (uiComboBox_DataSets.SelectedItem == comboBoxPredData.SelectedItem)
				{
					MessageBox.Show("Data set for prediction can't be the same as regression dataset");
					return false;

				}
				presenter.setPrediction(true);
				presenter.setPredictionLevel(Convert.ToDouble(nudPredictionLevel.Value));
			}
			else
				presenter.setPrediction(false);
			return true;
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
			chkFittedValuesVsActualYValues.Checked = chkCheckAllOptions.Checked;
			chkResidualsVsFittedValues.Checked = chkCheckAllOptions.Checked;
			chkResidualsVsXValues.Checked = chkCheckAllOptions.Checked;
			chkActualVsX.Checked = chkCheckAllOptions.Checked;
			chkFittedVsX.Checked = chkCheckAllOptions.Checked;
		}

		private void chckBoxPrediction_CheckedChanged(object sender, EventArgs e)
		{
				lblPredLevel.Enabled = chckBoxPrediction.Checked;
				lblPredData.Enabled = chckBoxPrediction.Checked;
				nudPredictionLevel.Enabled = chckBoxPrediction.Checked;
				comboBoxPredData.Enabled = chckBoxPrediction.Checked;
		}
	}
}