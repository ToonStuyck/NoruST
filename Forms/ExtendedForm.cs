using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DataSet = NoruST.Models.DataSet;

namespace NoruST.Forms
{
    public class ExtendedForm : Form
    {
        #region Fields

        private bool _doTakeBackUp;

        private ListBox _dataSetList;
        private CheckBox _dataSetPerCategorie;
        private CheckBox _checkAllOptions;
        private CheckState _checkState;
        private TableLayoutPanel _optionsPanel;
        private Button _okButton;
        private Button _closeButton;

        #endregion

        #region Public Methods


        /// <summary>
        /// Initialize the view so the proper data is shown.
        /// </summary>
        public void InitializeView(Button okButton, Button closeButton)
        {
            InitializeView(null, null, null, null, null, okButton, closeButton);
        }

        /// <summary>
        /// Initialize the view so the proper data is shown.
        /// </summary>
        public void InitializeView(ListBox dataSetList, DataGridView dataSetView, Button okButton, Button closeButton, bool doTakeBackUp = false)
        {
            InitializeView(dataSetList, null, dataSetView, null, null, okButton, closeButton, doTakeBackUp);
        }

        /// <summary>
        /// Initialize the view so the proper data is shown.
        /// </summary>
        public void InitializeView(ListBox dataSetList, CheckBox dataSetPerCategorie, DataGridView dataSetView, Button okButton, Button closeButton)
        {
            InitializeView(dataSetList, dataSetPerCategorie, dataSetView, null, null, okButton, closeButton);
        }

        /// <summary>
        /// Initialize the view so the proper data is shown.
        /// </summary>
        public void InitializeView(ListBox dataSetList, DataGridView dataSetView, CheckBox checkAllOptions, TableLayoutPanel optionsPanel, Button okButton, Button closeButton)
        {
            InitializeView(dataSetList, null, dataSetView, checkAllOptions, optionsPanel, okButton, closeButton);
        }

        /// <summary>
        /// Initialize the view so the proper data is shown.
        /// </summary>
        public void InitializeView(ListBox dataSetList, CheckBox dataSetPerCategorie, DataGridView dataSetView, CheckBox checkAllOptions, TableLayoutPanel optionsPanel, Button okButton, Button closeButton, bool doTakeBackUp = false)
        {
            // Link the controls to the base controls.
            _dataSetList = dataSetList;
            _dataSetPerCategorie = dataSetPerCategorie;
            DataSetView = dataSetView;
            _checkAllOptions = checkAllOptions;
            _optionsPanel = optionsPanel;
            _okButton = okButton;
            _closeButton = closeButton;

            // Hook up events.
            if (_dataSetList != null)
                _dataSetList.SelectedIndexChanged += (s, e) =>
                {
                    SelectedDataSet = (DataSet)_dataSetList.SelectedItem;
                    if (SelectedDataSet == null) return;
                    DataSetListSelectedIndexChanged();
                };

            if (_dataSetPerCategorie != null)
                _dataSetPerCategorie.CheckedChanged += (s, e) =>
                {
                    if (_dataSetPerCategorie.Checked)
                    {
                        // Rename both columns so they would make more sense for the user.
                        ColX = "Cat";
                        ColY = "Var";

                        // Create a data table and add the required columns.
                        CreateDataTable(xy: DataTableColumn.Editable);

                        // Update the view with new data.
                        UpdateDataTable(checkX: DefaultCheck.Nonnumeric, checkY: DefaultCheck.Numeric);
                    }
                    else
                        DataSetListSelectedIndexChanged();
                };

            if (_checkAllOptions != null)
            {
                _checkState = _checkAllOptions.CheckState;
                _checkAllOptions.CheckedChanged += CheckAllOptionsCheckedChanged;
                foreach (var control in _optionsPanel.Controls)
                    if (control is CheckBox && (CheckBox)control != _checkAllOptions)
                        ((CheckBox)control).CheckedChanged += OptionsCheckedChanged;
            }

            if (_okButton != null)
                _okButton.Click += (s, e) => { if (OkButtonClick()) Close(); };

            if (_closeButton != null)
                _closeButton.Click += (s, e) => { if (CloseButtonClick()) Close(); };

            // Populate the listBox with the available DataSets.
            if (_dataSetList != null)
            {
                _dataSetList.DataSource = null;
                _dataSetList.DataSource = Globals.ExcelAddIn.DataSets;
            }

            // Check if a backup has to be taken.
            _doTakeBackUp = doTakeBackUp;
            if (!_doTakeBackUp) return;

            // Take the backup.
            BackupDataSet = new List<DataSet>();
            foreach (var dataSet in Globals.ExcelAddIn.DataSets)
                BackupDataSet.Add(dataSet.DeepClone());
        }

        /// <summary>
        /// Create a <see cref="System.Data.DataTable"/> and add the required columns.
        /// </summary>
        /// <returns>The created <see cref="System.Data.DataTable"/>.</returns>
        public DataTable CreateDataTable(DataTableColumn check = DataTableColumn.Hidden, DataTableColumn xy = DataTableColumn.Hidden, DataTableColumn varName = DataTableColumn.ReadOnly, DataTableColumn range = DataTableColumn.ReadOnly, DataTableColumn rangeName = DataTableColumn.ReadOnly, DataTableColumn numerical = DataTableColumn.ReadOnly)
        {
            // Create the DataTable.
            DataTable = new DataTable();

            /* All if's below check if the appropriate column should be added to the DataTable.
             * If the column should be added, add it and set if it's ReadOnly or not.
             * Other things specific to the column are explained there. */

            if (check != DataTableColumn.Hidden)
            {
                DataTable.Columns.Add(new DataColumn(ColCheck, typeof(bool)));
                DataTable.Columns[ColCheck].ReadOnly = check == DataTableColumn.ReadOnly;

                // Initialize the list with bools that indicate if the data has to be included in the called method.
                DoInclude = new List<bool>();

                // Link the CellValueChanged event specific for this column.
                DataSetView.CellValueChanged += (s, e) =>
                {
                    // If the changed value is in the correct column, update the list that keeps track of what to include in the chart.
                    if (DataSetView.Columns[e.ColumnIndex].Name == ColCheck)
                        DoInclude[e.RowIndex] = DataSetView[e.ColumnIndex, e.RowIndex].Value as bool? ?? false;
                };

                // Link the ColumnHeaderMouseClick event.
                DataSetView.ColumnHeaderMouseClick += (s, e) =>
                {
                    // If the correct column header is clicked, (de)select all the CheckBoxes.
                    if (DataSetView.Columns[e.ColumnIndex].Name == ColCheck)
                        UpdateDataTable(DoInclude[0] ? DefaultCheck.None : DefaultCheck.All);
                };
            }

            if (xy != DataTableColumn.Hidden)
            {
                DataTable.Columns.Add(new DataColumn(ColX, typeof(bool)));
                DataTable.Columns.Add(new DataColumn(ColY, typeof(bool)));
                DataTable.Columns[ColX].ReadOnly = xy == DataTableColumn.ReadOnly;
                DataTable.Columns[ColY].ReadOnly = xy == DataTableColumn.ReadOnly;

                // Initialize the lists with bools that indicate if the data has to be included in the called method.
                DoIncludeX = new List<bool>();
                DoIncludeY = new List<bool>();

                // Link the CellValueChanged event specific for these columns.
                DataSetView.CellValueChanged += (s, e) =>
                {
                    // If the changed value is in the correct column, update the list that keeps track of what to include in the chart.
                    if (DataSetView.Columns[e.ColumnIndex].Name == ColX)
                        DoIncludeX[e.RowIndex] = DataSetView[e.ColumnIndex, e.RowIndex].Value as bool? ?? false;

                    // If the changed value is in the correct column, update the list that keeps track of what to include in the chart.
                    if (DataSetView.Columns[e.ColumnIndex].Name == ColY)
                        DoIncludeY[e.RowIndex] = DataSetView[e.ColumnIndex, e.RowIndex].Value as bool? ?? false;
                };

                // Link the ColumnHeaderMouseClick event.
                DataSetView.ColumnHeaderMouseClick += (s, e) =>
                {
                    // If the correct column header is clicked, (de)select all the CheckBoxes.
                    if (DataSetView.Columns[e.ColumnIndex].Name == ColX)
                        UpdateDataTable(checkX: DoIncludeX[0] ? DefaultCheck.None : DefaultCheck.All, checkY: DefaultCheck.LastState);

                    // If the correct column header is clicked, (de)select all the CheckBoxes.
                    if (DataSetView.Columns[e.ColumnIndex].Name == ColY)
                        UpdateDataTable(checkX: DefaultCheck.LastState, checkY: DoIncludeY[0] ? DefaultCheck.None : DefaultCheck.All);
                };
            }

            if (varName != DataTableColumn.Hidden)
            {
                DataTable.Columns.Add(new DataColumn(ColVarName, typeof(string)));
                DataTable.Columns[ColVarName].ReadOnly = varName == DataTableColumn.ReadOnly;
            }

            if (range != DataTableColumn.Hidden)
            {
                DataTable.Columns.Add(new DataColumn(ColRange, typeof(string)));
                DataTable.Columns[ColRange].ReadOnly = range == DataTableColumn.ReadOnly;
            }

            if (rangeName != DataTableColumn.Hidden)
            {
                DataTable.Columns.Add(new DataColumn(ColRangeName, typeof(string)));
                DataTable.Columns[ColRangeName].ReadOnly = rangeName == DataTableColumn.ReadOnly;
            }

            if (numerical != DataTableColumn.Hidden)
            {
                DataTable.Columns.Add(new DataColumn(ColNumeric, typeof(bool)));
                DataTable.Columns[ColNumeric].ReadOnly = numerical == DataTableColumn.ReadOnly;
            }

            return DataTable;
        }

        /// <summary>
        /// Set a given column's property ReadOnly.
        /// </summary>
        /// <param name="columnName">The column.</param>
        /// <param name="readOnly">True for ReadOnly, false for Editable.</param>
        public void SetColumnReadOnly(string columnName, bool readOnly)
        {
            DataTable.Columns[columnName].ReadOnly = readOnly;
        }

        /// <summary>
        /// Update the <see cref="System.Data.DataTable"/> and <see cref="DataGridView"/> so it shows the updated data.
        /// </summary>
        /// <param name="check">The default value for the <see cref="ColCheck"/> column.</param>       
        /// <param name="checkX">The default value for the <see cref="ColX"/> column.</param>        
        /// <param name="checkY">The default value for the <see cref="ColY"/> column.</param>
        public void UpdateDataTable(DefaultCheck check = DefaultCheck.None, DefaultCheck checkX = DefaultCheck.None, DefaultCheck checkY = DefaultCheck.None)
        {
            // Clear the data and view so no duplicates will be shown.
            DataSetView.DataSource = null;
            DataTable.Clear();
            if (check != DefaultCheck.LastState)
                DoInclude = new List<bool>();
            if (checkX != DefaultCheck.LastState)
                DoIncludeX = new List<bool>();
            if (checkY != DefaultCheck.LastState)
                DoIncludeY = new List<bool>();

            // Get the new data.
            for (var i = 0; i < SelectedDataSet.DataList.Count; i++)
            {
                var row = DataTable.NewRow();
                if (DataTable.Columns.Contains(ColCheck))
                {
                    switch (check)
                    {
                        case DefaultCheck.All:
                            row[ColCheck] = true;
                            break;
                        case DefaultCheck.Numeric:
                            row[ColCheck] = SelectedDataSet.DataList[i].IsNumeric;
                            break;
                        case DefaultCheck.Nonnumeric:
                            row[ColCheck] = !SelectedDataSet.DataList[i].IsNumeric;
                            break;
                        case DefaultCheck.None:
                            row[ColCheck] = false;
                            break;
                        case DefaultCheck.LastState:
                            row[ColCheck] = DoInclude[i];
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(check), check, null);
                    }
                    if (DoInclude.Count != SelectedDataSet.DataList.Count)
                        DoInclude.Add(row[ColCheck] as bool? ?? false);
                    else
                        DoInclude[i] = row[ColCheck] as bool? ?? false;
                }
                if (DataTable.Columns.Contains(ColX) && DataTable.Columns.Contains(ColY))
                {
                    switch (checkX)
                    {
                        case DefaultCheck.All:
                            row[ColX] = true;
                            break;
                        case DefaultCheck.Numeric:
                            row[ColX] = SelectedDataSet.DataList[i].IsNumeric;
                            break;
                        case DefaultCheck.Nonnumeric:
                            row[ColX] = !SelectedDataSet.DataList[i].IsNumeric;
                            break;
                        case DefaultCheck.None:
                            row[ColX] = false;
                            break;
                        case DefaultCheck.LastState:
                            row[ColX] = DoIncludeX[i];
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(check), check, null);
                    }
                    switch (checkY)
                    {
                        case DefaultCheck.All:
                            row[ColY] = true;
                            break;
                        case DefaultCheck.Numeric:
                            row[ColY] = SelectedDataSet.DataList[i].IsNumeric;
                            break;
                        case DefaultCheck.Nonnumeric:
                            row[ColY] = !SelectedDataSet.DataList[i].IsNumeric;
                            break;
                        case DefaultCheck.None:
                            row[ColY] = false;
                            break;
                        case DefaultCheck.LastState:
                            row[ColY] = DoIncludeY[i];
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(check), check, null);
                    }
                    if (DoIncludeX.Count != SelectedDataSet.DataList.Count)
                        DoIncludeX.Add(row[ColX] as bool? ?? false);
                    else
                        DoIncludeX[i] = row[ColX] as bool? ?? false;
                    if (DoIncludeY.Count != SelectedDataSet.DataList.Count)
                        DoIncludeY.Add(row[ColY] as bool? ?? false);
                    else
                        DoIncludeY[i] = row[ColY] as bool? ?? false;
                }
                if (DataTable.Columns.Contains(ColVarName))
                    row[ColVarName] = SelectedDataSet.DataList[i].Name;
                if (DataTable.Columns.Contains(ColRange))
                    row[ColRange] = SelectedDataSet.DataList[i].Range.Address();
                if (DataTable.Columns.Contains(ColRangeName))
                    row[ColRangeName] = SelectedDataSet.DataList[i].RangeName.Name;
                if (DataTable.Columns.Contains(ColNumeric))
                    row[ColNumeric] = SelectedDataSet.DataList[i].IsNumeric;
                DataTable.Rows.Add(row);
            }

            // Update the view.
            DataSetView.DataSource = DataTable;
            DataSetView.Sort(DataSetView.Columns[ColRange], ListSortDirection.Ascending);
        }

        #endregion

        #region Overwritten Methods

        /// <summary>
        /// Refresh the view.
        /// </summary>
        public override void Refresh()
        {
            InitializeView(_dataSetList, _dataSetPerCategorie, DataSetView, _checkAllOptions, _optionsPanel, _okButton, _closeButton, _doTakeBackUp);
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Override this method if the DataSetList <see cref="ListBox"/> needs extra functionality.
        /// </summary>
        /// <remarks>This method does nothing by default.</remarks>
        public virtual void DataSetListSelectedIndexChanged() { }

        /// <summary>
        /// Override this method if the Ok <see cref="Button"/> needs extra functionality.
        /// </summary>
        /// <remarks>This method does nothing by default.</remarks>
        public virtual bool OkButtonClick() { return true; }

        /// <summary>
        /// Override this method if the Close/Cancel <see cref="Button"/> needs extra functionality.
        /// </summary>
        /// <remarks>This method does nothing by default.</remarks>
        public virtual bool CloseButtonClick() { return true; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Fired when the <see cref="CheckBox.Checked"/> for the check all <see cref="CheckBox"/> changes from true to false or vice versa.
        /// </summary>
        private void CheckAllOptionsCheckedChanged(object sender, EventArgs e)
        {
            if (_checkState == CheckState.Indeterminate)
                _checkAllOptions.Checked = true;

            foreach (var control in _optionsPanel.Controls)
                if (control is CheckBox && (CheckBox)control != _checkAllOptions)
                    ((CheckBox)control).CheckedChanged -= OptionsCheckedChanged;

            foreach (var control in _optionsPanel.Controls)
                if (control is CheckBox && (CheckBox)control != _checkAllOptions)
                    ((CheckBox)control).Checked = _checkAllOptions.Checked;

            foreach (var control in _optionsPanel.Controls)
                if (control is CheckBox && (CheckBox)control != _checkAllOptions)
                    ((CheckBox)control).CheckedChanged += OptionsCheckedChanged;

            _checkState = _checkAllOptions.CheckState;
        }

        /// <summary>
        /// Fired when the <see cref="CheckBox.Checked"/> for the options <see cref="CheckBox"/>es changes from true to false or vice versa.
        /// </summary>
        private void OptionsCheckedChanged(object sender, EventArgs e)
        {
            var optionsCounter = 0;
            var checkedCounter = 0;

            foreach (var control in _optionsPanel.Controls)
                if (control is CheckBox && (CheckBox)control != _checkAllOptions)
                {
                    optionsCounter++;
                    if (((CheckBox)control).Checked)
                        checkedCounter++;
                }

            if (optionsCounter == 0) throw new Exception("There are no options available. Use InitializeView without 'CheckBox checkAllOptions' and 'TableLayoutPanel optionsPanel'.");

            if (0 < checkedCounter && checkedCounter < optionsCounter)
                SetCheckState(CheckState.Indeterminate);

            if (checkedCounter == optionsCounter)
                SetCheckState(CheckState.Checked);

            if (checkedCounter == 0)
                SetCheckState(CheckState.Unchecked);
        }

        /// <summary>
        /// Change the <see cref="CheckBox.CheckState"/> of the <see cref="_checkAllOptions"/> <see cref="CheckBox"/>.
        /// </summary>
        /// <param name="checkState">The new <see cref="CheckState"/>.</param>
        private void SetCheckState(CheckState checkState)
        {
            _checkAllOptions.CheckedChanged -= CheckAllOptionsCheckedChanged;
            _checkState = _checkAllOptions.CheckState = checkState;
            _checkAllOptions.CheckedChanged += CheckAllOptionsCheckedChanged;
        }

        #endregion

        #region Properties

        public List<DataSet> BackupDataSet { get; private set; }

        public DataSet SelectedDataSet { get; set; }

        public DataTable DataTable { get; private set; }
        public string ColCheck => " ";
        public string ColX { get; set; } = "X";
        public string ColY { get; set; } = "Y";
        public string ColVarName => "Variable Name";
        public string ColRange => "Range";
        public string ColRangeName => "Range Name";
        public string ColNumeric => "Numeric";

        public DataGridView DataSetView { get; private set; }

        public List<bool> DoInclude { get; private set; }
        public List<bool> DoIncludeX { get; private set; }
        public List<bool> DoIncludeY { get; private set; }

        #endregion
    }
}