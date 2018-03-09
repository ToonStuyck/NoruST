using System;
using System.Windows.Forms;
using NoruST.Domain;
using NoruST.Presenters;

namespace NoruST.Forms
{
    public partial class LagForm : Form
    {
        private LagPresenter presenter;

        public LagForm()
        {
            InitializeComponent();
        }

        public void setPresenter(LagPresenter lagPresenter)
        {
            this.presenter = lagPresenter;
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
                uiComboBox_Variables.DataSource = selectedDataSet().getVariables();
                uiComboBox_Variables.DisplayMember = "name";
                uiNumericUpDown_Lag.Maximum = selectedDataSet().rangeSize() - 1;
                presenter.getModel().dataSet = selectedDataSet();
                presenter.getModel().numberOfLags = (int)uiNumericUpDown_Lag.Value;
            };
            uiComboBox_Variables.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedVariable() == null) return;
                presenter.getModel().variable = selectedVariable();
            };
            uiNumericUpDown_Lag.ValueChanged +=
                (obj, eventArgs) => presenter.getModel().numberOfLags = (int)uiNumericUpDown_Lag.Value;
        }

        private DataSet selectedDataSet()
        {
            return (DataSet)uiComboBox_DataSets.SelectedItem;
        }

        private Variable selectedVariable()
        {
            return (Variable) uiComboBox_Variables.SelectedItem;
        }

        public void selectDataSet(DataSet dataSet)
        {
            uiComboBox_DataSets.SelectedItem = null;
            uiComboBox_DataSets.SelectedItem = dataSet;
        }

        private void uiButton_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uiButton_Ok_Click(object sender, EventArgs e)
        {
            presenter.createLags();
            Close();
        }
    }
}