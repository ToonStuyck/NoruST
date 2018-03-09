using NoruST.Models;
using CorrelationCovariance = NoruST.Analyses.CorrelationCovariance;

namespace NoruST.Forms
{
    /// <summary>
    /// <para>The Correlation & Covariance Form.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 20, 2016</para>
    /// </summary>
    public partial class CorrelationCovarianceForm : ExtendedForm
    {
        #region Constructors

        /// <summary>
        /// Constructor of the <see cref="CorrelationCovarianceForm"/> <see cref="System.Windows.Forms.Form"/>.
        /// </summary>
        public CorrelationCovarianceForm()
        {
            InitializeComponent();

            InitializeView(lstDataSets, dgvDataSet, chkCheckAllOptions, tlpOptions, btnOk, btnCancel);
        }

        #endregion

        #region Overwritten Methods

        /// <summary>
        /// This adds extra functionality to the DataSet<see cref="System.Windows.Forms.ListBox"/>.
        /// </summary>
        public override void DataSetListSelectedIndexChanged()
        {
            // Create a data table and add the required columns.
            CreateDataTable(DataTableColumn.Editable);

            // Update the view with new data.
            UpdateDataTable(DefaultCheck.Numeric);
        }

        /// <summary>
        /// This adds extra functionality to the Ok <see cref="System.Windows.Forms.Button"/>
        /// </summary>
        public override bool OkButtonClick()
        {
            var doCalculate = new SummaryStatisticsBool(correlation: chkCorrelation.Checked, covariance: chkCovariance.Checked);

            return new CorrelationCovariance().Print(SelectedDataSet, DoInclude, doCalculate);
        }

        #endregion
    }
}