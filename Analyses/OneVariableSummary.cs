using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using NoruST.Models;

// ReSharper disable InvertIf

namespace NoruST.Analyses
{
    /// <summary>
    /// <para>One-Variable Summary.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 18, 2016</para>
    /// </summary>
    public class OneVariableSummary
    {
        #region Fields

        private SummaryStatisticsBool _doCalculate;
        private int _row;
        private int _column;

        #endregion

        #region Public Methods

        /// <summary>
        /// Print the Summary Statistics to a new <see cref="_Worksheet"/>.
        /// </summary>
        /// <param name="dataSet">The <see cref="DataSet"/> which needs it Correlation and/or Covariance printed.</param>
        /// <param name="doIncludeCategory">A <see cref="List{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Models.Data"/> in the <see cref="DataSet.DataList"/> should be included as the category.</param>
        /// <param name="doIncludeValue">A <see cref="List{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Models.Data"/> in the <see cref="DataSet.DataList"/> should be included as the value.</param>
        /// <param name="doCalculate">A collection of <see cref="bool"/>s that indicate which summary statistic has to be calculated.</param>
        /// <param name="meanConfidenceLevel">(Optional) The confidence level for the <see cref="SummaryStatistics.Mean"/>. Default is 0.</param>
        /// <param name="standardDeviationConfidenceLevel">(Optional) The confidence level for the <see cref="SummaryStatistics.StandardDeviation"/>. Default is 0.</param>
        /// <param name="row">(Optional) The first row the data will be written to. Default is 1.</param>
        /// <param name="column">(Optional) The first column the data will be written to. Default is 1.</param>
        /// <param name="sheet">(Optional) An existing <see cref="_Worksheet"/>. A new one will be created when left blank. Default is null.</param>
        /// <param name="sheetName">(Optional) The name of the sheet. Default is 'One-Variable Summary'.</param>
        /// <param name="doIsNumericCheck">(Optional) Set to 'false' if the IsNumeric check should be suppressed. Default is true.</param>
        /// <returns>A <see cref="bool"/> that indicates if the print was successful or not.</returns>
        public bool Print(DataSet dataSet, List<bool> doIncludeCategory, List<bool> doIncludeValue, SummaryStatisticsBool doCalculate, int meanConfidenceLevel = 0, int standardDeviationConfidenceLevel = 0, int row = 1, int column = 1, _Worksheet sheet = null, string sheetName = "One-Variable Summary", bool doIsNumericCheck = true)
        {
            // Save the variables as a field variables.
            _doCalculate = doCalculate;
            _column = column;

            // Check the input so everything is working like intended.
            var check = new CheckInput(dataSet, sheetName, doIncludeCategory, DefaultCheck.Nonnumeric, -1, doIncludeValue, DefaultCheck.Numeric, 1, doCalculate, isCategory: true, doIsNumericCheck: doIsNumericCheck);
            if (!check.Successful) return false;
            var categories = check.Categories;
            ValuesArray = check.Values;

            // Create a new sheet for the chart if none was provided.
            Sheet = sheet ?? WorksheetHelper.NewWorksheet(sheetName);

            // Create a new DataSet.
            dataSet = DataSet.GetByCategories(Sheet, categories[0], ValuesArray, row, _column + 1);

            // Create an array that holds the Sets of Data that need a Summary Statistic.
            ValuesArray = dataSet.DataList;

            // Print the categories to the sheet if there is at least 1 Set of Data selected.
            if (ValuesArray.Count > 0)
            {
                _row = dataSet.Range.Row + dataSet.Range.Rows.Count;
                PrintCategories(sheetName);
            }

            // Print the calculated variables for each DataSets Data.
            foreach (var valuesArray in ValuesArray)
            {
                _row = dataSet.Range.Row + dataSet.Range.Rows.Count;
                PrintValues(valuesArray, meanConfidenceLevel, standardDeviationConfidenceLevel);
            }

            return true;
        }

        /// <summary>
        /// Print the Summary Statistics to a new <see cref="_Worksheet"/>.
        /// </summary>
        /// <param name="dataSet">The <see cref="DataSet"/> which needs it Correlation and/or Covariance printed.</param>
        /// <param name="doInclude">A <see cref="List{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Models.Data"/> in the <see cref="DataSet.DataList"/> should be included.</param>
        /// <param name="doCalculate">A collection of <see cref="bool"/>s that indicate which summary statistic has to be calculated.</param>
        /// <param name="meanConfidenceLevel">(Optional) The confidence level for the <see cref="SummaryStatistics.Mean"/>. Default is 0.</param>
        /// <param name="standardDeviationConfidenceLevel">(Optional) The confidence level for the <see cref="SummaryStatistics.StandardDeviation"/>. Default is 0.</param>
        /// <param name="row">(Optional) The first row the data will be written to. Default is 1.</param>
        /// <param name="column">(Optional) The first column the data will be written to. Default is 1.</param>
        /// <param name="sheet">(Optional) An existing <see cref="_Worksheet"/>. A new one will be created when left blank. Default is null.</param>
        /// <param name="sheetName">(Optional) The name of the sheet. Default is 'One-Variable Summary'.</param>
        /// <param name="doIsNumericCheck">(Optional) Set to 'false' if the IsNumeric check should be suppressed. Default is true.</param>
        /// <returns>A <see cref="bool"/> that indicates if the print was successful or not.</returns>
        public bool Print(DataSet dataSet, List<bool> doInclude, SummaryStatisticsBool doCalculate, int meanConfidenceLevel = 0, int standardDeviationConfidenceLevel = 0, int row = 1, int column = 1, _Worksheet sheet = null, string sheetName = "One-Variable Summary", bool doIsNumericCheck = true)
        {
            // Save the variables as a field variables.
            _doCalculate = doCalculate;
            _column = column;

            // Check the input so everything is working like intended.
            var check = new CheckInput(dataSet, sheetName, doInclude, DefaultCheck.Numeric, doIsNumericCheck: doIsNumericCheck, doCalculate: doCalculate);
            if (!check.Successful) return false;
            ValuesArray = check.Values;

            // Create a new sheet for the chart if none was provided.
            Sheet = sheet ?? WorksheetHelper.NewWorksheet(sheetName);

            // Print the categories to the sheet if there is at least 1 Set of Data selected.
            if (ValuesArray.Count > 0)
            {
                _row = row;
                PrintCategories(sheetName);
            }

            // Print the calculated variables for each DataSets Data.
            foreach (var data in ValuesArray)
            {
                _row = row;
                PrintValues(data, meanConfidenceLevel, standardDeviationConfidenceLevel);
            }

            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Print the categories to the <see cref="_Worksheet"/>.
        /// </summary>
        /// <param name="name">The name of the Summary Statistics.</param>
        private void PrintCategories(string name)
        {
            // Write the categories to she sheet.
            HeaderRow = CheckCondition(true, name + "   ");

            // Base
            MeanRow = CheckCondition(_doCalculate.Mean || _doCalculate.BoxWhiskerPlot, nameof(MeanRow));
            VarianceRow = CheckCondition(_doCalculate.Variance, nameof(VarianceRow));
            StandardDeviationRow = CheckCondition(_doCalculate.StandardDeviation, nameof(StandardDeviationRow));
            MinimumRow = CheckCondition(_doCalculate.Minimum, nameof(MinimumRow));
            Quartile1Row = CheckCondition(_doCalculate.Quartile1 || _doCalculate.BoxWhiskerPlot, nameof(Quartile1Row));
            MedianRow = CheckCondition(_doCalculate.Median, nameof(MedianRow));
            Quartile3Row = CheckCondition(_doCalculate.Quartile3, nameof(Quartile3Row));
            MaximumRow = CheckCondition(_doCalculate.Maximum, nameof(MaximumRow));
            InterquartileRangeRow = CheckCondition(_doCalculate.InterquartileRange, nameof(InterquartileRangeRow));
            SkewnessRow = CheckCondition(_doCalculate.Skewness, nameof(SkewnessRow));
            KurtosisRow = CheckCondition(_doCalculate.Kurtosis, nameof(KurtosisRow));
            MeanAbsoluteDeviationRow = CheckCondition(_doCalculate.MeanAbsoluteDeviation, nameof(MeanAbsoluteDeviationRow));
            ModeRow = CheckCondition(_doCalculate.Mode, nameof(ModeRow));
            HasMode = new List<bool>();
            RangeRow = CheckCondition(_doCalculate.Range, nameof(RangeRow));
            CountRow = CheckCondition(_doCalculate.Count, nameof(CountRow));
            SumRow = CheckCondition(_doCalculate.Sum, nameof(SumRow));

            // Box-Whisker Plot
            Quartile1MedianRow = CheckCondition(_doCalculate.BoxWhiskerPlot, nameof(Quartile1MedianRow));
            MedianQuartile3Row = CheckCondition(_doCalculate.BoxWhiskerPlot, nameof(MedianQuartile3Row));
            MinusWhiskerRow = CheckCondition(_doCalculate.BoxWhiskerPlot, nameof(MinusWhiskerRow));
            PlusWhiskerRow = CheckCondition(_doCalculate.BoxWhiskerPlot, nameof(PlusWhiskerRow));

            // Base (but printed after the Box-Whisker Plot if required)
            CheckCondition(_doCalculate.Outliers || _doCalculate.BoxWhiskerPlot, nameof(OutliersRow));
            OutliersRow = new List<int>();

            // Confidence Interval
            SampleSizeRow = CheckCondition(_doCalculate.MeanConfidenceInterval || _doCalculate.StandardDeviationConfidenceInterval, nameof(SampleSizeRow));
            SampleMeanRow = CheckCondition(_doCalculate.MeanConfidenceInterval || _doCalculate.StandardDeviationConfidenceInterval, nameof(SampleMeanRow));
            SampleStandardDeviationRow = CheckCondition(_doCalculate.MeanConfidenceInterval || _doCalculate.StandardDeviationConfidenceInterval, nameof(SampleStandardDeviationRow));
            MeanConfidenceLevelRow = CheckCondition(_doCalculate.MeanConfidenceInterval, nameof(MeanConfidenceLevelRow));
            MeanAlphaRow = CheckCondition(_doCalculate.MeanConfidenceInterval, nameof(MeanAlphaRow));
            DegreesOfFreedomRow = CheckCondition(_doCalculate.MeanConfidenceInterval, nameof(DegreesOfFreedomRow));
            MeanConfidenceIntervalRow = CheckCondition(_doCalculate.MeanConfidenceInterval, nameof(MeanConfidenceIntervalRow));
            MeanLowerLimitRow = CheckCondition(_doCalculate.MeanConfidenceInterval, nameof(MeanLowerLimitRow));
            MeanUpperLimitRow = CheckCondition(_doCalculate.MeanConfidenceInterval, nameof(MeanUpperLimitRow));
            StandardDeviationConfidenceLevelRow = CheckCondition(_doCalculate.StandardDeviationConfidenceInterval, nameof(StandardDeviationConfidenceLevelRow));
            StandardDeviationAlphaRow = CheckCondition(_doCalculate.StandardDeviationConfidenceInterval, nameof(StandardDeviationAlphaRow));
            DegreesOfFreedomRow = CheckCondition(_doCalculate.StandardDeviationConfidenceInterval, nameof(DegreesOfFreedomRow));
            StandardDeviationConfidenceIntervalLowerLimitRow = CheckCondition(_doCalculate.StandardDeviationConfidenceInterval, nameof(StandardDeviationConfidenceIntervalLowerLimitRow));
            StandardDeviationConfidenceIntervalUpperLimitRow = CheckCondition(_doCalculate.StandardDeviationConfidenceInterval, nameof(StandardDeviationConfidenceIntervalUpperLimitRow));
            StandardDeviationLowerLimitRow = CheckCondition(_doCalculate.StandardDeviationConfidenceInterval, nameof(StandardDeviationLowerLimitRow));
            StandardDeviationUpperLimitRow = CheckCondition(_doCalculate.StandardDeviationConfidenceInterval, nameof(StandardDeviationUpperLimitRow));

            FirstValuesColumn = _column + 1;
        }

        /// <summary>
        /// Print the values to the <see cref="_Worksheet"/>.
        /// </summary>
        /// <param name="data">The <see cref="Models.Data"/></param>
        /// <param name="meanConfidenceLevel">(Optional) The confidence level for the <see cref="SummaryStatistics.Mean"/>. Default is 0.</param>
        /// <param name="standardDeviationConfidenceLevel">(Optional) The confidence level for the <see cref="SummaryStatistics.StandardDeviation"/>. Default is 0.</param>
        private void PrintValues(Models.Data data, int meanConfidenceLevel, int standardDeviationConfidenceLevel)
        {
            // Increment the column by 1.
            _column++;

            // Calculate the summary of the data.
            var summary = new SummaryStatistics(data.Range, _doCalculate, meanConfidenceLevel, standardDeviationConfidenceLevel);

            // Write the categories to she sheet.
            Sheet.Cells[_row++, _column] = data.Name;

            // Base
            WriteFunction(_doCalculate.Mean || _doCalculate.BoxWhiskerPlot, summary.Mean);
            WriteFunction(_doCalculate.Variance, summary.Variance);
            WriteFunction(_doCalculate.StandardDeviation, summary.StandardDeviation);
            WriteFunction(_doCalculate.Minimum, summary.Minimum);
            WriteFunction(_doCalculate.Quartile1 || _doCalculate.BoxWhiskerPlot, summary.Quartile1);
            WriteFunction(_doCalculate.Median, summary.Median);
            WriteFunction(_doCalculate.Quartile3, summary.Quartile3);
            WriteFunction(_doCalculate.Maximum, summary.Maximum);
            WriteFunction(_doCalculate.InterquartileRange, summary.InterquartileRange);
            WriteFunction(_doCalculate.Skewness, summary.Skewness);
            WriteFunction(_doCalculate.Kurtosis, summary.Kurtosis);
            WriteFunction(_doCalculate.MeanAbsoluteDeviation, summary.MeanAbsoluteDeviation);
            WriteFunction(_doCalculate.Mode, summary.Mode);
            HasMode.Add(summary.HasMode);
            WriteFunction(_doCalculate.Range, summary.Range);
            WriteFunction(_doCalculate.Count, summary.Count);
            WriteFunction(_doCalculate.Sum, summary.Sum);

            // Box-Whisker Plot
            WriteFunction(_doCalculate.BoxWhiskerPlot, summary.Quartile1Median);
            WriteFunction(_doCalculate.BoxWhiskerPlot, summary.MedianQuartile3);
            WriteFunction(_doCalculate.BoxWhiskerPlot, summary.MinusWhisker);
            WriteFunction(_doCalculate.BoxWhiskerPlot, summary.PlusWhisker);

            // Base (but printed after the Box-Whisker Plot if required)
            if (_doCalculate.Outliers || _doCalculate.BoxWhiskerPlot)
                foreach (var outlier in summary.Outliers)
                {
                    Sheet.Cells[_row++, _column] = "=" + outlier;
                    if (OutliersRow.Count < summary.Outliers.Count)
                        OutliersRow.Add(_row - 1);
                }

            // Confidence Interval
            WriteFunction(_doCalculate.MeanConfidenceInterval || _doCalculate.StandardDeviationConfidenceInterval, summary.Count);
            WriteFunction(_doCalculate.MeanConfidenceInterval || _doCalculate.StandardDeviationConfidenceInterval, summary.Mean);
            WriteFunction(_doCalculate.MeanConfidenceInterval || _doCalculate.StandardDeviationConfidenceInterval, summary.StandardDeviation);
            if (_doCalculate.MeanConfidenceInterval)
            {
                Sheet.Cells[_row, _column] = summary.MeanConfidenceLevel;
                MeanConfidenceLevelRow = _row;
                ((Range)Sheet.Cells[_row++, _column]).NumberFormat = "0.00%";
                summary.SetMeanAlpha(MeanConfidenceLevelRow, _column);
            }
            WriteFunction(_doCalculate.MeanConfidenceInterval, summary.MeanAlpha);
            WriteFunction(_doCalculate.MeanConfidenceInterval, summary.DegreesOfFreedom);
            WriteFunction(_doCalculate.MeanConfidenceInterval, summary.MeanConfidenceInterval);
            WriteFunction(_doCalculate.MeanConfidenceInterval, summary.MeanLowerLimit);
            WriteFunction(_doCalculate.MeanConfidenceInterval, summary.MeanUpperLimit);
            if (_doCalculate.StandardDeviationConfidenceInterval)
            {
                Sheet.Cells[_row, _column] = summary.StandardDeviationConfidenceLevel;
                StandardDeviationConfidenceLevelRow = _row;
                ((Range)Sheet.Cells[_row++, _column]).NumberFormat = "0.00%";
                summary.SetStandardDeviationAlpha(StandardDeviationConfidenceLevelRow, _column);
            }
            WriteFunction(_doCalculate.StandardDeviationConfidenceInterval, summary.StandardDeviationAlpha);
            WriteFunction(_doCalculate.StandardDeviationConfidenceInterval, summary.DegreesOfFreedom);
            WriteFunction(_doCalculate.StandardDeviationConfidenceInterval, summary.StandardDeviationConfidenceIntervalLowerLimit);
            WriteFunction(_doCalculate.StandardDeviationConfidenceInterval, summary.StandardDeviationConfidenceIntervalUpperLimit);
            WriteFunction(_doCalculate.StandardDeviationConfidenceInterval, summary.StandardDeviationLowerLimit);
            WriteFunction(_doCalculate.StandardDeviationConfidenceInterval, summary.StandardDeviationUpperLimit);
        }

        /// <summary>
        /// Check the condition, write the name to the sheet and return the row index.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="name">The name.</param>
        /// <returns>The row index.</returns>
        /// <remarks>The last 3 characters of the name will be trimmed.</remarks>
        private int CheckCondition(bool condition, string name)
        {
            if (condition)
            {
                Sheet.Cells[_row++, _column] = name.Substring(0, name.Length - 3);
                return _row - 1;
            }

            return 0;
        }

        /// <summary>
        /// Write the function to the sheet.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="function">The name.</param>
        private void WriteFunction(bool condition, string function)
        {
            if (condition)
            {
                Sheet.WriteFunction(_row, _column, function);
                _row++;
            }
        }

        #endregion

        #region Properties

        public _Worksheet Sheet { get; private set; }
        public List<Models.Data> ValuesArray { get; private set; }
        public int HeaderRow { get; private set; }

        // Base
        public int MeanRow { get; private set; }
        public int VarianceRow { get; private set; }
        public int StandardDeviationRow { get; private set; }
        public int MinimumRow { get; private set; }
        public int Quartile1Row { get; private set; }
        public int MedianRow { get; private set; }
        public int Quartile3Row { get; private set; }
        public int MaximumRow { get; private set; }
        public int InterquartileRangeRow { get; private set; }
        public int SkewnessRow { get; private set; }
        public int KurtosisRow { get; private set; }
        public int MeanAbsoluteDeviationRow { get; private set; }
        public int ModeRow { get; private set; }
        public List<bool> HasMode { get; private set; }
        public int RangeRow { get; private set; }
        public int CountRow { get; private set; }
        public int SumRow { get; private set; }
        public List<int> OutliersRow { get; private set; }

        // Box-Whisker Plot
        public int Quartile1MedianRow { get; private set; }
        public int MedianQuartile3Row { get; private set; }
        public int MinusWhiskerRow { get; private set; }
        public int PlusWhiskerRow { get; private set; }

        // Confidence Interval
        public int SampleSizeRow { get; private set; }
        public int SampleMeanRow { get; private set; }
        public int SampleStandardDeviationRow { get; private set; }
        public int DegreesOfFreedomRow { get; private set; }
        public int MeanConfidenceLevelRow { get; private set; }
        public int MeanAlphaRow { get; private set; }
        public int MeanConfidenceIntervalRow { get; private set; }
        public int MeanLowerLimitRow { get; private set; }
        public int MeanUpperLimitRow { get; private set; }
        public int StandardDeviationConfidenceLevelRow { get; private set; }
        public int StandardDeviationAlphaRow { get; private set; }
        public int StandardDeviationConfidenceIntervalLowerLimitRow { get; private set; }
        public int StandardDeviationConfidenceIntervalUpperLimitRow { get; private set; }
        public int StandardDeviationLowerLimitRow { get; private set; }
        public int StandardDeviationUpperLimitRow { get; private set; }

        public int FirstValuesColumn { get; private set; }

        #endregion
    }
}