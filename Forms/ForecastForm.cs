using System.Collections.Generic;
using NoruST.Analyses;
using System.Windows.Forms;
using NoruST.Presenters;
using NoruST.Domain;
using System;

namespace NoruST.Forms
{

    public partial class ForecastForm : Form
    {
        private ForecastPresenter presenter;
        private const string formTitle = "NoruST - Forecast";

        public ForecastForm()
        {
            InitializeComponent();
        }

        public void setPresenter(ForecastPresenter ForecastPresenter)
        {
            this.presenter = ForecastPresenter;
            bindModelToView();
            selectDataSet(selectedDataSet());
        }

        private void bindModelToView()
        {
            lstDataSets.DataSource = presenter.dataSets();
            lstDataSets.DisplayMember = "name";
            //nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            //rangeDataGridViewTextBoxColumn.DataPropertyName = "Range";
            lstDataSets.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedDataSet() == null) return;
                dgvDataSet.DataSource = selectedDataSet().getVariables();
            };
        }

        private DataSet selectedDataSet()
        {
            return (DataSet)lstDataSets.SelectedItem;
        }

        public void selectDataSet(DataSet dataSet)
        {
            lstDataSets.SelectedItem = null;
            lstDataSets.SelectedItem = dataSet;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            List<Variable> variables = new List<Variable>();
            foreach (DataGridViewRow row in dgvDataSet.Rows)
            {
                if (Convert.ToBoolean(row.Cells[dgvDataSet_Checked.Name].Value))
                {
                    variables.Add((Variable)row.DataBoundItem);
                }
            }

            bool check = presenter.checkInput(selectedDataSet(), variables, rdbMovingAverage.Checked, rdbSimpleExponentialSmoothing.Checked, rdbHoltsExponentialSmoothing.Checked,  rdbWintersExponentialSmoothing.Checked, chkOptimizeParameters.Checked, (int)nudNumberOfForecasts.Value, (int)nudNumberOfHoldouts.Value, (int)nudSeasonalPeriod.Value, (int)nudSpan.Value, txtLevel.Text, txtTrend.Text, txtSeasonality.Text);
            if (check)
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}