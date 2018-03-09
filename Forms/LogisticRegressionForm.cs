using NoruST.Analyses;

namespace NoruST.Forms
{
    /// <summary>
    /// <para>Logistic Regression Form.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Thomas Van Rompaey</para>
    /// <para>Edited by: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: May 05, 2016</para>
    /// </summary>
    public partial class LogisticRegressionForm : ExtendedForm
    {
        #region Constructors

        /// <summary>
        /// Constructor of the <see cref="LogisticRegressionForm"/> <see cref="System.Windows.Forms.Form"/>.
        /// </summary>
        public LogisticRegressionForm()
        {
            InitializeComponent();

            InitializeView(lstDataSets, dgvDataSet, btnOk, btnCancel);
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
            UpdateDataTable(checkX: DefaultCheck.Numeric, checkY: DefaultCheck.Numeric);
        }

        /// <summary>
        /// This adds extra functionality to the Ok <see cref="System.Windows.Forms.Button"/>
        /// </summary>
        public override bool OkButtonClick()
        {
            return new LogisticRegression().Print(SelectedDataSet, DoIncludeX, DoIncludeY);
        }

        #endregion
    }
}