using NoruST.Analyses;

namespace NoruST.Forms
{
    /// <summary>
    /// <para>Discriminant Analysis Form.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Thomas Van Rompaey</para>
    /// <para>Edited by: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 23, 2016</para>
    /// </summary>
    public partial class DiscriminantAnalysisForm : ExtendedForm
    {
        #region Constructors

        /// <summary>
        /// Constructor of the <see cref="ScatterplotForm"/> <see cref="System.Windows.Forms.Form"/>.
        /// </summary>
        public DiscriminantAnalysisForm()
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
            UpdateDataTable();
        }

        /// <summary>
        /// This adds extra functionality to the Ok <see cref="System.Windows.Forms.Button"/>
        /// </summary>
        public override bool OkButtonClick()
        {
            return new DiscriminantAnalysis().Print(SelectedDataSet, DoIncludeX, DoIncludeY, txtProbability.Text, txtMisclassification0.Text, txtMisclassification1.Text);
        }

        #endregion
    }
}