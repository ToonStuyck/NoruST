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
    public partial class PChartForm : Form
    {

        private PChartPresenter presenter;

        public void setPresenter(PChartPresenter PChartPresenter)
        {
            this.presenter = PChartPresenter;
            bindModelToView();
            selectDataSet(selectedDataSet());
        }

        public void selectDataSet(DataSet dataSet)
        {
            ui_ComboBox_SelectDataSets.SelectedItem = null;
            ui_ComboBox_SelectDataSets.SelectedItem = dataSet;
        }

        private DataSet selectedDataSet()
        {
            return (DataSet)ui_ComboBox_SelectDataSets.SelectedItem;
        }

        public PChartForm()
        {
            InitializeComponent();
        }

        private void ui_Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
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
            bool inputOk = presenter.checkInput(variablesX, variablesY, radioButton2.Checked, rdbAllObservations.Checked, rdbObservationsInRange.Checked, selectedDataSet(), uiTextBox_StopIndex.Text, uiTextBox_StartIndex.Text,  rdbPlotAllObservations.Checked, rdbPlotOnlyObservationsWithin.Checked, uiTextbox_PlotStopIndex.Text, uiTextbox_PlotStartIndex.Text);
            if (inputOk)
            {
                Close();
            }
        }



        private void bindModelToView()
        {
            ui_ComboBox_SelectDataSets.DataSource = presenter.dataSets();
            ui_ComboBox_SelectDataSets.DisplayMember = "name";
            //nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            //rangeDataGridViewTextBoxColumn.DataPropertyName = "Range";
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

        private void rdbAllObservations_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdbObservationsInRange_CheckedChanged(object sender, EventArgs e)
        {
            uiTextBox_StartIndex.Visible = rdbObservationsInRange.Checked;
            uiTextBox_StopIndex.Visible = rdbObservationsInRange.Checked;
            lblStartIndex.Visible = rdbObservationsInRange.Checked;
            lblStopIndex.Visible = rdbObservationsInRange.Checked;
            uiTextBox_StartIndex.Text = "0";
            uiTextBox_StopIndex.Text = "0";
        }

        private void rdbPlotOnlyObservationsWithin_CheckedChanged(object sender, EventArgs e)
        {
            uiTextbox_PlotStartIndex.Visible = rdbPlotOnlyObservationsWithin.Checked;
            uiTextbox_PlotStopIndex.Visible = rdbPlotOnlyObservationsWithin.Checked;
            lblPlotStartIndex.Visible = rdbPlotOnlyObservationsWithin.Checked;
            lblPlotStopIndex.Visible = rdbPlotOnlyObservationsWithin.Checked;
            uiTextbox_PlotStartIndex.Text = "0";
            uiTextbox_PlotStopIndex.Text = "0";
        }
    }
}
