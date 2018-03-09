using NoruST.Analyses;
using NoruST.Models;

namespace NoruST.Forms
{
    /// <summary>
    /// <para>Regression Form.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Thomas Van Rompaey</para>
    /// <para>Edited by: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 24, 2016</para>
    /// </summary>
    public partial class RegressionForm : ExtendedForm
    {
        #region Constructors

        /// <summary>
        /// Constructor of the <see cref="ScatterplotForm"/> <see cref="System.Windows.Forms.Form"/>.
        /// </summary>
        public RegressionForm()
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
            CreateDataTable(xy: DataTableColumn.Editable);

            // Update the view with new data.
            UpdateDataTable();
        }

        /// <summary>
        /// This adds extra functionality to the Ok <see cref="System.Windows.Forms.Button"/>
        /// </summary>
        public override bool OkButtonClick()
        {
            return new Regression().Print(SelectedDataSet, DoIncludeX, DoIncludeY, new SummaryStatisticsBool(fittedValuesVsActualYValues: chkFittedValuesVsActualYValues.Checked, residualsVsFittedValues: chkResidualsVsFittedValues.Checked, residualsVsXValues: chkResidualsVsXValues.Checked, displayRegressionEquation: chkDisplayRegressionEquation.Checked), (int)nudConfidenceLevel.Value);
        }

        #endregion
    }
}