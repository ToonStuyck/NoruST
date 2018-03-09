using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace NoruST.Models
{
    /// <summary>
    /// <para>DataSet.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 15, 2016</para>
    /// </summary>
    public class DataSet : IComparable, IComparable<DataSet>, IEquatable<DataSet>
    {
        #region Functions

        public int CompareTo(object obj)
        {
            if (obj != null && !(obj is DataSet))
                throw new ArgumentException("Object must be of type DataSet.");

            return CompareTo((DataSet)obj);
        }

        public int CompareTo(DataSet other)
        {
            return ReferenceEquals(other, null) ? 1 : string.CompareOrdinal(Name, other.Name);
        }

        public bool Equals(DataSet other)
        {
            return other != null && Name == other.Name;
        }

        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// A private constructor used for cloning a <see cref="DataSet"/>. This has no further use.
        /// </summary>
        private DataSet() { }

        /// <summary>
        /// Constructor of the <see cref="DataSet"/> class.
        /// </summary>
        /// <param name="sheet">The <see cref="Worksheet"/> on which the <see cref="DataSet"/> is located.</param>
        /// <param name="range">The <see cref="Microsoft.Office.Interop.Excel.Range"/> of the <see cref="DataSet"/>.</param>
        public DataSet(_Worksheet sheet, Range range) : this(sheet, range, "Data Set #" + (Globals.ExcelAddIn.DataSets.Count + 1), Layout.Columns, true) { }

        /// <summary>
        /// Constructor of the <see cref="DataSet"/> class.
        /// </summary>
        /// <param name="sheet">The <see cref="Worksheet"/> on which the <see cref="DataSet"/> is located.</param>
        /// <param name="range">The <see cref="Microsoft.Office.Interop.Excel.Range"/> of the <see cref="DataSet"/>.</param>
        /// <param name="name">The name of the <see cref="DataSet"/>.</param>
        /// <param name="layout">Specifies if the data is represented in columns or rows.</param>
        /// <param name="firstIsName">The indication if the first row/column has the names of the variables.</param>
        public DataSet(_Worksheet sheet, Range range, string name, Layout layout, bool firstIsName)
        {
            // Set some variables.
            Sheet = sheet;
            Range = range;
            Name = name;

            // Create the lists with data.
            DataList = new List<Data>();
            LagList = new List<Data>();
            DummyList = new List<Data>();

            // Update the list of data.
            UpdateDataList(layout, firstIsName);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Update the <see cref="DataList"/> based on different settings.
        /// </summary>
        /// <param name="layout">Specifies if the data is represented in columns or rows.</param>
        /// <param name="firstIsName">The indication if the first row/column has the names of the variables.</param>
        public void UpdateDataList(Layout layout, bool firstIsName)
        {
            // Set some variables.
            Layout = layout;
            FirstIsName = firstIsName;
            var offset = FirstIsName ? 1 : 0;

            // Remove the named ranges from the workbook.
            foreach (var data in DataList)
                Globals.ExcelAddIn.Application.ActiveWorkbook.Names.Item(data.RangeName.Name).Delete();

            // Clear the current list of date.
            DataList.Clear();
            LagList.Clear();
            DummyList.Clear();

            // Populate the list with data.
            if (Layout == Layout.Columns)
                for (var column = 0; column < Range.Columns.Count; column++)
                {
                    // Name of the variable.
                    var header = FirstIsName
                        ? Convert.ToString(((Range)Sheet.Cells[Range.Row, Range.Column + column]).Value2)
                        : "Var_" + (column + 1);

                    // Range of the data.
                    var upperLeftCell = Sheet.Cells[Range.Row + offset, Range.Column + column];
                    var lowerRightCell = Sheet.Cells[Range.Row + Range.Rows.Count - 1, Range.Column + column];
                    var dataRange = Sheet.Range[upperLeftCell, lowerRightCell];

                    // Add the data to the list.
                    DataList.Add(new Data(Sheet, dataRange, header));
                }
            else
                for (var row = 0; row < Range.Rows.Count; row++)
                {
                    // Name of the variable.
                    var header = FirstIsName
                        ? Convert.ToString(((Range)Sheet.Cells[Range.Row + row, Range.Column]).Value2)
                        : "";

                    // Range of the data.
                    var upperLeftCell = Sheet.Cells[Range.Row + row, Range.Column + offset];
                    var lowerRightCell = Sheet.Cells[Range.Row + row, Range.Column + Range.Columns.Count - 1];
                    var dataRange = Sheet.Range[upperLeftCell, lowerRightCell];

                    // Add the data to the list.
                    DataList.Add(new Data(Sheet, dataRange, header));
                }
        }

        /// <summary>
        /// Deep clone the <see cref="DataSet"/>.
        /// </summary>
        /// <returns>The deep cloned <see cref="DataSet"/>.</returns>
        public DataSet DeepClone()
        {
            var dataList = new List<Data>();
            var lagList = new List<Data>();
            var dummyList = new List<Data>();
            foreach (var data in DataList)
                dataList.Add(new Data(data.Sheet, data.Range, data.Name));
            foreach (var lag in lagList)
                lagList.Add(new Data(lag.Sheet, lag.Range, lag.Name));
            foreach (var dummy in dummyList)
                dummyList.Add(new Data(dummy.Sheet, dummy.Range, dummy.Name));

            var dataSet = new DataSet
            {
                Sheet = Sheet,
                Range = Range,
                Name = Name,
                FirstIsName = FirstIsName,
                DataList = dataList,
                LagList = lagList,
                DummyList = dummyList,
                Layout = Layout
            };

            return dataSet;
        }

        /// <summary>
        /// Removes the named <see cref="Microsoft.Office.Interop.Excel.Range"/>s.
        /// </summary>
        public void RemoveNamedRanges()
        {
            foreach (var data in DataList)
                data.RemoveNamedRange();
        }

        /// <summary>
        /// Create a new <see cref="DataSet"/> based on categories.
        /// </summary>
        /// <param name="sheet">The sheet where the data is on.</param>
        /// <param name="categoryData">The categories for the <see cref="DataSet"/>.</param>
        /// <param name="valueData">The values for the <see cref="DataSet"/>.</param>
        /// <param name="row">The first row the data will be written to.</param>
        /// <param name="column">The first column the data will be written to.</param>
        /// <returns>The <see cref="DataSet"/> based on the provided categories.</returns>
        public static DataSet GetByCategories(_Worksheet sheet, Data categoryData, List<Data> valueData, int row, int column)
        {
            var firstRow = row;
            var firstColumn = column;
            foreach (var category in categoryData.GetCategories())
                foreach (var data in valueData)
                {
                    row = firstRow;
                    sheet.Cells[row++, column] = data.Name + " (" + category + ")";

                    for (var i = 1; i <= data.GetCount(); i++)
                        sheet.Cells[row++, column] = "=IF(INDEX(" + categoryData.RangeName.Name + "," + i + ")=\"" + category + "\",IF(INDEX(" + data.RangeName.Name + "," + i + ")<>0,INDEX(" + data.RangeName.Name + "," + i + "),\"\"),\"\")";
                    column++;
                }

            return new DataSet(sheet, sheet.Range[sheet.Cells[firstRow, firstColumn], sheet.Cells[row - 1, column - 1]]);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The <see cref="Worksheet"/> on which the <see cref="DataSet"/> is located.
        /// </summary>
        public _Worksheet Sheet { get; private set; }

        /// <summary>
        /// The <see cref="Microsoft.Office.Interop.Excel.Range"/> of the <see cref="DataSet"/>.
        /// </summary>
        public Range Range { get; set; }

        /// <summary>
        /// The name of the <see cref="DataSet"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The indication if the first row/column has the names of the variables.
        /// </summary>
        public bool FirstIsName { get; private set; }

        /// <summary>
        /// A list with the available <see cref="Data"/>.
        /// </summary>
        public List<Data> DataList { get; private set; }

        /// <summary>
        /// A list with the available lag <see cref="Data"/>.
        /// </summary>
        public List<Data> LagList { get; private set; }

        /// <summary>
        /// A list with the available dummy <see cref="Data"/>.
        /// </summary>
        public List<Data> DummyList { get; private set; }

        /// <summary>
        /// Specifies if the data is represented in columns or rows.
        /// </summary>
        public Layout Layout { get; private set; }

        #endregion
    }
}