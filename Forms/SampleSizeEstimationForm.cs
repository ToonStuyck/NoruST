using System.Windows.Forms;
using NoruST.Analyses;
using NoruST.Models;
using NoruST.Presenters;

namespace NoruST.Forms
{
    public partial class SampleSizeEstimationForm : Form
    {
        private SampleSizeEstimationPresenter presenter;

        public SampleSizeEstimationForm()
        {
            InitializeComponent();
        }

        public void setPresenter(SampleSizeEstimationPresenter presenter)
        {
            this.presenter = presenter;
        }

        private void estimateCheckedChanged(object sender, System.EventArgs e)
        {
            nudConfidenceLevel.Value = 95;
            txtMarginOfError.Text = "0.1";

            if (rdbMean.Checked)
            {
                lblEstimate1.Text = "Estimated Standard Deviation";
                txtEstimate1.Text = "1";
                lblEstimate2.Visible = false;
                txtEstimate2.Visible = false;
            }
            if (rdbProportion.Checked)
            {
                lblEstimate1.Text = "Estimated Proportion";
                txtEstimate1.Text = "0.1";
                lblEstimate2.Visible = false;
                txtEstimate2.Visible = false;
            }
            if (rdbDifferenceOfMeans.Checked)
            {
                lblEstimate1.Text = "Estimated Common Standard Deviation";
                txtEstimate1.Text = "1";
                lblEstimate2.Visible = false;
                txtEstimate2.Visible = false;
            }
            if (rdbDifferenceOfProportions.Checked)
            {
                lblEstimate1.Text = "Estimated Proportion 1";
                txtEstimate1.Text = "0.1";
                lblEstimate2.Visible = true;
                txtEstimate2.Visible = true;
                txtEstimate2.Text = "0.1";
            }
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            presenter.getModel().mean = rdbMean.Checked;
            presenter.getModel().proportion = rdbProportion.Checked;
            presenter.getModel().diffMean = rdbDifferenceOfMeans.Checked;
            presenter.getModel().diffProportion = rdbDifferenceOfProportions.Checked;
            presenter.getModel().confidenceLevel = (int) nudConfidenceLevel.Value;
            presenter.getModel().marginOfError = txtMarginOfError.Text;
            presenter.getModel().estimation1 = txtEstimate1.Text;
            presenter.getModel().estimation2 = txtEstimate2.Text;

            presenter.estimateSampleSize();
            Hide();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Hide();
        }
    }
}