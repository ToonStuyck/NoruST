using System;
using System.Windows.Forms;
using NoruST.Forms;
using NoruST.Presenters;
using NoruST.Domain;


namespace NoruST.Forms
{
    public partial class ProcessCapabilityForm : Form
    {
        private ProcessCapabilityPresenter presenter;
        private const string formTitle = "NoruST - Process Capability";

        public ProcessCapabilityForm()
        {
            InitializeComponent();

        }

        public void setPresenter(ProcessCapabilityPresenter ProcessCapabilityPresenter)
        {
            this.presenter = ProcessCapabilityPresenter;
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
            uiTextBox_UpperLimit.Text = "0";
            uiTextBox_LowerLimit.Text = "0";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiButton_Ok_Click(object sender, EventArgs e)
        {
            bool inputOk = presenter.checkInput(selectedDataSet(), uiTextBox_LowerLimit.Text, uiTextBox_UpperLimit.Text);
            if (inputOk)
            {
                Close();
            }
        }
    }
}

