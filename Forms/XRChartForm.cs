using System;
using System.Windows.Forms;
using NoruST.Forms;
using NoruST.Presenters;
using NoruST.Domain;


namespace NoruST.Forms
{
    public partial class XRChartForm : Form
    {
        private XRChartPresenter presenter;
        private const string formTitle = "NoruST - XRChart";

        public XRChartForm()
        {
            InitializeComponent();

        }

        public void setPresenter(XRChartPresenter XRChartPresenter)
        {
            this.presenter = XRChartPresenter;
            bindModelToView();
            selectDataSet(selectedDataSet());
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
                //dataGridView1.DataSource = selectedDataSet().getVariables();
            };
        }

        private DataSet selectedDataSet()
        {
            return (DataSet)ui_ComboBox_SelectDataSets.SelectedItem;
        }

        public void selectDataSet(DataSet dataSet)
        {
            ui_ComboBox_SelectDataSets.SelectedItem = null;
            ui_ComboBox_SelectDataSets.SelectedItem = dataSet;
        }

        private void Cancelbutton_clicked(object sender, EventArgs e)
        {
            Close();
        }

        private void ObservationsInRange_CheckedChanged(object sender, EventArgs e)
        {
            uiTextBox_StartIndex.Visible = rdbObservationsInRange.Checked;
            uiTextBox_StopIndex.Visible = rdbObservationsInRange.Checked;
            lblStartIndex.Visible = rdbObservationsInRange.Checked;
            lblStopIndex.Visible = rdbObservationsInRange.Checked;
            uiTextBox_StartIndex.Text = "0";
            uiTextBox_StopIndex.Text = "0";
        }


        private void uiButton_Ok_Click(object sender, EventArgs e)
        {
            bool inputOk = presenter.checkInput(rdbAllObservations.Checked, rdbObservationsInRange.Checked, selectedDataSet(), uiTextBox_StopIndex.Text, uiTextBox_StartIndex.Text, rdbPlotAllObservations.Checked, rdbPlotOnlyObservationsWithin.Checked, uiTextbox_PlotStopIndex.Text, uiTextbox_PlotStartIndex.Text);
            if (inputOk)
            {
                Close();
            }
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

