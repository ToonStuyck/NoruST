using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using NoruST.Models;

// ReSharper disable LocalizableElement
// ReSharper disable LoopCanBeConvertedToQuery

namespace NoruST.Analyses
{
    /// <summary>
    /// <para>Correlation & Covariance.</para>
    /// <para>Version: 2.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 18, 2016</para>
    /// </summary>
    public class CorrelationCovariance
    {
        #region Fields

        private _Worksheet _sheet;
        private List<Models.Data> _valuesArray;
        private int _row;
        private int _column;

        #endregion

        #region Public Methods

        /// <summary>
        /// Print the Correlation and/or Covariance to a new <see cref="Worksheet"/>.
        /// </summary>
        /// <param name="dataSet">The <see cref="DataSet"/> which needs it Correlation and/or Covariance printed.</param>
        /// <param name="doInclude">A <see cref="List{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Models.Data"/> in the <see cref="DataSet.DataList"/> should be included.</param>
        /// <param name="doCalculate">A collection of <see cref="bool"/>s that indicate which summary statistic has to be calculated.</param>
        /// <param name="row">(Optional) The first row the data will be written to. Default is 1.</param>
        /// <param name="column">(Optional) The first column the data will be written to. Default is 1.</param>
        /// <returns>A <see cref="bool"/> that indicates if the print was successful or not.</returns>
        public bool Print(DataSet dataSet, List<bool> doInclude, SummaryStatisticsBool doCalculate, int row = 1, int column = 1)
        {
            // Check the input so everything is working like intended.
            var check = new CheckInput(dataSet, "Correlation & Covariance", doInclude, DefaultCheck.Numeric, doCalculate: doCalculate);
            if (!check.Successful) return false;
            _valuesArray = check.Values;

            // Save the variables as a field variables.
            _row = row;
            _column = column;

            // Create a new sheet for the chart and print the categories to the sheet.
            if (doCalculate.Correlation && doCalculate.Covariance)
            {
                PrintCategories("Correlation");
                _row++;
                PrintCategories("Covariance");
            }
            else if (doCalculate.Correlation)
                PrintCategories("Correlation");
            else
                PrintCategories("Covariance");

            _row = row;
            _column++;
            // Print the values to the sheet.
            PrintValues(doCalculate);

            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Print the categories to the <see cref="_Worksheet"/>.
        /// </summary>
        /// <param name="title">The category title.</param>
        private void PrintCategories(string title)
        {
            // Create a new sheet for the chart.
            if (_sheet == null)
                _sheet = WorksheetHelper.NewWorksheet(title);
            else
                _sheet.Rename(Regex.Replace(_sheet.Name, @"[^A-Za-z]+", "") + " & " + title);

            // Write the title to the sheet.
            _sheet.Cells[_row++, _column] = title;

            // Write the categories to she sheet.
            foreach (var valuesArray in _valuesArray)
                _sheet.Cells[_row++, _column] = valuesArray.Name;
        }

        /// <summary>
        /// Print the values to the <see cref="_Worksheet"/>.
        /// </summary>
        /// <param name="doCalculate">A collection of <see cref="bool"/>s that indicate which summary statistic has to be calculated.</param>
        private void PrintValues(SummaryStatisticsBool doCalculate)
        {
            // Save the initial row.
            var initialRow = _row;

            // Calculate the Correlation and/or Covariance of the data.
            var ranges = new List<Range>();
            foreach (var valuesArray in _valuesArray)
                ranges.Add(valuesArray.Range);
            var calc = new Models.CorrelationCovariance(ranges, doCalculate);

            // Write the values to she sheet.
            for (var i = 0; i < _valuesArray.Count; i++)
            {
                _row = initialRow;

                if (calc.HasCorrelations)
                {
                    _sheet.Cells[_row, _column] = _valuesArray[i].Name;
                    for (var j = 0; j < calc.Dimension; j++)
                        _sheet.Cells[++_row, _column] = "=" + calc.Correlations[i * calc.Dimension + j];
                    _row += 2;
                }

                if (calc.HasCovariances)
                {
                    _sheet.Cells[_row, _column] = _valuesArray[i].Name;
                    for (var j = 0; j < calc.Dimension; j++)
                        _sheet.Cells[++_row, _column] = "=" + calc.Covariances[i * calc.Dimension + j];
                }

                _column++;
            }
        }

        #endregion
    }
}