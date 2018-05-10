using System;
using System.Windows.Forms;
using NoruST.Domain;
using NoruST.Presenters;

namespace NoruST.Forms
{
    public partial class ChiKwadraatForm : Form
    {
        private ChiKwadraatPresenter presenter;
        private SelectRangeForm selectRangeForm;

        public ChiKwadraatForm()
        {
            InitializeComponent();
        }

        public void setPresenter(ChiKwadraatPresenter chiKwadraatPresenter)
        {
            this.presenter = chiKwadraatPresenter;
            bindModelToView();
            //selectDataSet(selectedDataSet());
        }

        private void bindModelToView()
        {
            /*uiComboBox_DataSets.DataSource = presenter.dataSets();
            uiComboBox_DataSets.DisplayMember = "name";
            uiComboBox_DataSets.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedDataSet() == null) return;
                uiComboBox_Variables.DataSource = selectedDataSet().getVariables();
                uiComboBox_Variables.DisplayMember = "name";
                presenter.getModel().dataSet = selectedDataSet();
            };
            uiComboBox_Variables.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedVariable() == null) return;
                presenter.getModel().variable = selectedVariable();
            };*/





            /*private DataSet selectedDataSet()
                {
                    return (DataSet)uiComboBox_DataSets.SelectedItem;
                }

                private Variable selectedVariable()
                {
                    return (Variable)uiComboBox_Variables.SelectedItem;
                }

                public void selectDataSet(DataSet dataSet)
                {
                    uiComboBox_DataSets.SelectedItem = null;
                    uiComboBox_DataSets.SelectedItem = dataSet;
                }
*/

        }

        internal void rangeSelected(string range)
        {
            uiTextBox_DataSetRange.Text = range;
        }

        private void uiButton_Range_Click(object sender, EventArgs e)
        {
            selectRangeForm = selectRangeForm.createAndOrShowForm();
            selectRangeForm.setPresenter(presenter);
        }



        private void ChiSquare_OK(object sender, MouseEventArgs e)
        {
            // lalala doe iets nuttig
            Close();
        }

        private void ChiSquare_Cancel(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void ChiSquare_Colums(object sender, EventArgs e)
        {

        }

        private void ChiSquare_Rows(object sender, EventArgs e)
        {

        }

        private void ChiSquare_both(object sender, EventArgs e)
        {
            ChiSquare_Colums(sender,e);
            ChiSquare_Rows(sender,e);
        }
    }
}


