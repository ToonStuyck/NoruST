using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using NoruST.Presenters;

namespace NoruST.Forms
{
    public partial class SelectRangeForm : ExtendedForm
    {
        private Worksheet worksheet;
        private DataSetManagerPresenter presenter;

        public SelectRangeForm()
        {
            InitializeComponent();
        }

        public void setPresenter(DataSetManagerPresenter presenter)
        {
            this.presenter = presenter;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            worksheet = (Worksheet) Globals.ExcelAddIn.getActiveWorksheet();
            worksheet.SelectionChange += worksheet_SelectionChange;
        }

        void worksheet_SelectionChange(Range target)
        {
            this.uiTextBox_Range.Text = target.Address(true, true);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            worksheet.SelectionChange -= worksheet_SelectionChange;
        }

        private void uiButton_Ok_Click(object sender, EventArgs e)
        {
            presenter.rangeSelected(uiTextBox_Range.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void uiButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
