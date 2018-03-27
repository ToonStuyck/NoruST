using System;
using System.Windows.Forms;
using NoruST.Domain;
using NoruST.Presenters;

namespace NoruST.Forms
{
    public partial class UnstackedForm : Form
    {
        private UnstackedPresenter presenter;

        public UnstackedForm()
        {
            InitializeComponent();
        }

        public void SetPresenter(UnstackedPresenter unstackedPresenter)
        {
            this.presenter = unstackedPresenter;
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
				presenter.getModel().dataSet = selectedDataSet();
			};
			uiComboBox_Variables.SelectedIndexChanged += (obj, eventArgs) =>
			{
				if (selectedVariable() == null) return;
				presenter.getModel().variable = selectedVariable();
			};
		}

		private DataSet selectedDataSet()
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

		private void uiButton_Cancel_Click(object sender, EventArgs e)
		{
            Close();
        }

		private void uiButton_Ok_Click(object sender, EventArgs e)
		{
			presenter.createUnstacked(selectedDataSet());
			Close();
		}
	}
}
