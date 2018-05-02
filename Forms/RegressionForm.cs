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

namespace NoruST.Forms
{

	//public partial class RegressionForm : ExtendedForm
	public partial class RegressionForm : Form
	{
		#region Constructors

		private RegressionPresenter presenter;

		/// <summary>
		/// Constructor of the <see cref="ScatterplotForm"/> <see cref="System.Windows.Forms.Form"/>.
		/// </summary>
		public RegressionForm()
        {
            InitializeComponent();

            //InitializeView(lstDataSets, dgvDataSet, chkCheckAllOptions, tlpOptions, btnOk, btnCancel);
			//DIT NOG DOEN!!
        }

		public void setPresenter(RegressionPresenter regPresenter)
		{
			this.presenter = regPresenter;
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
				dgvDataSet.DataSource = selectedDataSet().getVariables();
				/*uiDataGridViewColumn_VariableCheckX.Width = 20;
				uiDataGridViewColumn_VariableCheckY.Width = 20;
				uiDataGridView_Variables.Columns[2].ReadOnly = true;
				uiDataGridView_Variables.Columns[3].ReadOnly = true;*/
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

		#endregion

		#region Overwritten Methods

		/// <summary>
		/// This adds extra functionality to the DataSet<see cref="ListBox"/>.
		/// </summary>
		/*public override void DataSetListSelectedIndexChanged()
        {
            // Create a data table and add the required columns.
            CreateDataTable(xy: DataTableColumn.Editable);

            // Update the view with new data.
            UpdateDataTable();
        }

        /// <summary>
        /// This adds extra functionality to the Ok <see cref="System.Windows.Forms.Button"/>
        /// </summary>
        public override bool OkButtonClick()
        {
            return new Regression().Print(SelectedDataSet, DoIncludeX, DoIncludeY, new SummaryStatisticsBool(fittedValuesVsActualYValues: chkFittedValuesVsActualYValues.Checked, residualsVsFittedValues: chkResidualsVsFittedValues.Checked, residualsVsXValues: chkResidualsVsXValues.Checked, displayRegressionEquation: chkDisplayRegressionEquation.Checked), (int)nudConfidenceLevel.Value);
        }*/

		#endregion


	}
}