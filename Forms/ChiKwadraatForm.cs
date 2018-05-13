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
            selectDataSet(selectedDataSet());
            selectRange(selectedRange());
        }

        private void bindModelToView()
        {
            comboBox_dataSelect.DataSource = presenter.dataSets();
            comboBox_dataSelect.DisplayMember = "name";
            comboBox_dataSelect.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedDataSet() == null) return;
            };
            
        }

        private DataSet selectedDataSet()
        {
            return (DataSet)comboBox_dataSelect.SelectedItem;
        }

        private String selectedRange()
        {
            return (String)uiTextBox_DataSetRange.SelectedText;
        }

        public void selectDataSet(DataSet dataSet)
        {
            comboBox_dataSelect.SelectedItem = null;
            comboBox_dataSelect.SelectedItem = dataSet;
        }

        internal void selectRange(string range)
        {
            uiTextBox_DataSetRange.Text = null;
            uiTextBox_DataSetRange.Text = range;
        }

        private void uiButton_Range_Click(object sender, EventArgs e)
        {
            selectRangeForm = selectRangeForm.createAndOrShowForm();
            selectRangeForm.setPresenter(presenter);
        }

        private void ChiSquare_OK(object sender, MouseEventArgs e)
        {
           //String range = rangeSelected(string range)
            //presenter.createChiKwadraatPlot(selectedDataSet(),selectedRange());
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


