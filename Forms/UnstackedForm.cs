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
            //bindModelToView();
            //selectDataSet(selectedDataSet());
        }

        private void uiButton_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
