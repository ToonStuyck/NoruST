using System;
using System.Windows.Forms;
using NoruST.Domain;
using static System.Windows.Forms.DialogResult;
using static System.Windows.Forms.MessageBoxButtons;
using static System.Windows.Forms.MessageBoxIcon;
using static NoruST.Domain.RangeLayout;
using Microsoft.Office.Interop.Excel;
using NoruST.Presenters;

namespace NoruST.Forms
{
    public partial class DataSetManagerForm : Form
    {
        private const string formTitle = "NoruST - Data Set Manager";

        private DataSetManagerPresenter presenter;
        private SelectRangeForm selectRangeForm;

        public DataSetManagerForm()
        {
            InitializeComponent();
        }

        public void setPresenter(DataSetManagerPresenter presenter)
        {
            this.presenter = presenter;
            bindModelToView();
            selectDataSet(selectedDataSet());
        }

        private DataSet selectedDataSet()
        {
            return (DataSet) uiListBox_DataSets.SelectedItem;
        }

        private void bindModelToView()
        {
            uiListBox_DataSets.DataSource = presenter.getModel().getDataSets();
            uiListBox_DataSets.DisplayMember = "name";
            uiListBox_DataSets.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (presenter.getModel().getDataSets().Count == 0)
                {
                    uiDataGridView_Variables.DataSource = null;
                    uiTextBox_DataSetName.DataBindings.Clear();
                    uiTextBox_DataSetName.Text = "";
                    uiTextBox_DataSetRange.DataBindings.Clear();
                    uiTextBox_DataSetRange.Text = "";
                    rdbColumns.Checked = true;
                }
                else if (selectedDataSet() == null) return;
                else
                {
                    uiDataGridViewColumn_VariableName.DataPropertyName = "name";
                    uiDataGridViewColumn_VariableRange.DataPropertyName = "Range";
                    uiDataGridView_Variables.DataSource = selectedDataSet().getVariables();
                    uiTextBox_DataSetName.DataBindings.Clear();
                    uiTextBox_DataSetName.DataBindings.Add("Text", selectedDataSet(), "Name");
                    uiTextBox_DataSetName.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                    uiTextBox_DataSetRange.DataBindings.Clear();
                    uiTextBox_DataSetRange.DataBindings.Add("Text", selectedDataSet(), "Range");
                    uiTextBox_DataSetRange.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
                    if (selectedDataSet().getRangeLayout() == COLUMNS)
                        rdbColumns.Checked = true;
                    else
                        rdbRows.Checked = true;
                }
            };
        }

        public void selectDataSet(DataSet dataSet)
        {
            uiListBox_DataSets.ClearSelected();
            uiListBox_DataSets.SelectedItem = dataSet;
        }

        public void rangeSelected(string range)
        {
            uiTextBox_DataSetRange.Text = range;
        }

        public static bool ignoreIntersection(DataSet dataSet)
        {
            string message = "De geselecteerde range maakt reeds deel uit van data set '" + dataSet.Name +"'." +
                             Environment.NewLine + Environment.NewLine + 
                             "Wilt U van de huidige selectie een nieuwe data set maken?";
            DialogResult dialogResult = MessageBox.Show(message, formTitle, YesNo, Warning);
            return dialogResult != Yes;
        }

        public static bool addNewDataSet(Range range)
        {
            string message = "Wilt U de range " + range.Address(true, true) + " toevoegen als data set?";
            DialogResult dialogResult = MessageBox.Show(message, formTitle, YesNo, Question);
            return dialogResult == Yes;
        }

        private void uiButton_Range_Click(object sender, EventArgs e)
        {
            selectRangeForm = selectRangeForm.createAndOrShowForm();
            selectRangeForm.setPresenter(presenter);
        }

        private void uiButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uiRadioButton_Columns_Rows_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton changedRadioButton = sender as RadioButton;
            if (changedRadioButton != null && changedRadioButton.Checked)
            {
                presenter.setRangeLayoutFor(selectedDataSet(), rdbColumns.Checked ? COLUMNS : ROWS);
            }
        }

        private void uiCheckBox_HasHeaders_CheckedChanged(object sender, EventArgs e)
        {
            presenter.setVariableNamesInFirstRowOrColumn(selectedDataSet(), chkHasHeaders.Checked);
        }

        private void uiButton_Delete_Click(object sender, EventArgs e)
        {
            presenter.deleteDataSet(selectedDataSet());
        }

        private void uiButton_New_Click(object sender, EventArgs e)
        {
            presenter.addNewDataSet();
        }
    }
}