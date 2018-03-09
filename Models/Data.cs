using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

// ReSharper disable LoopCanBePartlyConvertedToQuery

namespace NoruST.Models
{
    /// <summary>
    /// <para>Data.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 14, 2016</para>
    /// </summary>
    public class Data : IComparable, IComparable<Data>, IEquatable<Data>
    {
        #region Functions

        public int CompareTo(object obj)
        {
            if (obj != null && !(obj is Data))
                throw new ArgumentException("Object must be of type Data.");

            return CompareTo((Data)obj);
        }

        public int CompareTo(Data other)
        {
            return ReferenceEquals(other, null) ? 1 : string.CompareOrdinal(Name, other.Name);
        }

        public bool Equals(Data other)
        {
            return other != null && Name == other.Name;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of the <see cref="Data"/> class
        /// </summary>
        /// <param name="sheet">The sheet where the data is on.</param>
        /// <param name="range">The range of the data row/column.</param>
        /// <param name="name">The name of the data row/column.</param>
        public Data(_Worksheet sheet, Range range, string name)
        {
            Sheet = sheet;
            Range = range;
            SetName(name);

            // Check if the data all numeric by evaluating the values.
            IsNumeric = true;
            GetValuesList();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the name of the <see cref="Data"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        public void SetName(string name)
        {
            // Check if something has changed.
            if (Name == name) return;

            // Remove the named range from the workbook.
            if (RangeName != null)
                Globals.ExcelAddIn.Application.ActiveWorkbook.Names.Item(RangeName.Name).Delete();

            // Update the current one.
            Name = name;
            Range.Name = "NORUST_" + Regex.Replace(Name, @"[^A-Za-z0-9]+", "");
            RangeName = Range.Name;
        }

        /// <summary>
        /// Removes the named <see cref="Microsoft.Office.Interop.Excel.Range"/> from the <see cref="Workbook"/>.
        /// </summary>
        public void RemoveNamedRange()
        {
            try
            {
                if (RangeName != null)
                    Globals.ExcelAddIn.Application.ActiveWorkbook.Names.Item(RangeName.Name).Delete();
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// Get the number of elements in the <see cref="Data"/>.
        /// </summary>
        /// <returns>The number of elements in the <see cref="Data"/>.</returns>
        public int GetCount()
        {
            return Range.Columns.Count > 1 ? Range.Columns.Count : Range.Rows.Count;
        }

        /// <summary>
        /// Get the <see cref="List{dynamic}"/> with the values.
        /// </summary>
        /// <returns>A <see cref="List{dynamic}"/> with the values.</returns>
        public List<dynamic> GetValuesList()
        {
            var valuesList = new List<dynamic>();

            // Check if the data is in rows or columns and get the values.
            if (Range.Columns.Count > 1)
                for (var column = 0; column < Range.Columns.Count; column++)
                {
                    var value = ((Range)Sheet.Cells[Range.Row, Range.Column + column]).Value2;
                    valuesList.Add(value);

                    if (value != null && !Regex.IsMatch(value.ToString(), @"\d"))
                        IsNumeric = false;
                }
            else
                for (var row = 0; row < Range.Rows.Count; row++)
                {
                    var value = ((Range)Sheet.Cells[Range.Row + row, Range.Column]).Value2;
                    valuesList.Add(value);

                    if (value != null && !Regex.IsMatch(value.ToString(), @"\d"))
                        IsNumeric = false;
                }

            return valuesList;
        }

        /// <summary>
        /// Get the array with the values.
        /// </summary>
        /// <returns>An array with the values.</returns>
        public dynamic[] GetValuesArray()
        {
            return GetValuesList().ToArray();
        }

        /// <summary>
        /// Get the <see cref="List{dynamic}"/> with the categories.
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetCategories()
        {
            var categoriesList = new List<dynamic>();

            // Get the unique values.
            foreach (var d in GetValuesList())
                if (!categoriesList.Contains(d))
                    categoriesList.Add(d);

            return categoriesList;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The <see cref="Worksheet"/> the data is on.
        /// </summary>
        public _Worksheet Sheet { get; set; }

        /// <summary>
        /// The name of the data row/column.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The <see cref="Microsoft.Office.Interop.Excel.Range"/> of the data row/column.
        /// </summary>
        public Range Range { get; }

        /// <summary>
        /// The <see cref="Microsoft.Office.Interop.Excel.Name"/> of the <see cref="Microsoft.Office.Interop.Excel.Range"/>.
        /// </summary>
        public Name RangeName { get; set; }

        /// <summary>
        /// Indicates if the <see cref="Data"/> is numeric or not.
        /// </summary>
        public bool IsNumeric { get; set; }

        /// <summary>
        /// The values of the data.
        /// </summary>
        [Obsolete("Property has been replaced by the method GetValuesList().",true)]
        public List<dynamic> ValuesList { get; set; }

        /// <summary>
        /// The values of the data.
        /// </summary>
        [Obsolete("Property has been replaced by the method GetValuesArray().",true)]
        public dynamic[] ValuesArray { get; set; }

        #endregion
    }
}