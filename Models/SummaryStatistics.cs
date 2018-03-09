using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

// ReSharper disable InvertIf

namespace NoruST.Models
{
    /// <summary>
    /// <para>DynamicSummaryStatistics.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 23, 2016</para>
    /// </summary>
    public class SummaryStatistics
    {
        #region Constructors

        /// <summary>
        /// Generate dynamic summary statistics as <see cref="string"/>s.
        /// </summary>
        /// <param name="range">The <see cref="Microsoft.Office.Interop.Excel.Range"/> of the data that needs summary statistics.</param>
        /// <param name="doCalculate">Defines which variables in the summary have to be calculated.</param>        
        /// <param name="meanConfidenceLevel">(Optional) The confidence level for the <see cref="Mean"/>. Default is 0.</param>
        /// <param name="standardDeviationConfidenceLevel">(Optional) The confidence level for the <see cref="StandardDeviation"/>. Default is 0.</param>
        /// <param name="numberOfBins">(Optional) If a fixed number of bins, this is the value. Default is -1.</param>
        /// <remarks>In order for these calculations to be only based on the confidence level (this will always be a fixed value), the methods <see cref="SetMeanAlpha"/> and/or <see cref="SetStandardDeviationAlpha"/> must be called.</remarks>
        public SummaryStatistics(Range range, SummaryStatisticsBool doCalculate, int meanConfidenceLevel = 0, int standardDeviationConfidenceLevel = 0, int numberOfBins = -1)
        {
            // The DataSet name in Excel and functions.
            Name = ((Name)range.Name).Name;
            var function = Globals.ExcelAddIn.Application.WorksheetFunction;

            // Base
            if (doCalculate.Mean || doCalculate.BoxWhiskerPlot || doCalculate.MeanConfidenceInterval || doCalculate.StandardDeviationConfidenceInterval) Mean = "AVERAGE(" + Name + ")";
            if (doCalculate.Variance) Variance = "VAR.S(" + Name + ")";
            if (doCalculate.StandardDeviation || doCalculate.MeanConfidenceInterval || doCalculate.StandardDeviationConfidenceInterval) StandardDeviation = "STDEV.S(" + Name + ")";
            if (doCalculate.Minimum || doCalculate.Range || doCalculate.BoxWhiskerPlot || doCalculate.Histogram) Minimum = "MIN(" + Name + ")";
            if (doCalculate.Quartile1 || doCalculate.InterquartileRange || doCalculate.BoxWhiskerPlot) Quartile1 = "QUARTILE.INC(" + Name + ",1)";
            if (doCalculate.Median || doCalculate.BoxWhiskerPlot) Median = "MEDIAN(" + Name + ")";
            if (doCalculate.Quartile3 || doCalculate.InterquartileRange || doCalculate.BoxWhiskerPlot) Quartile3 = "QUARTILE.INC(" + Name + ",3)";
            if (doCalculate.Maximum || doCalculate.Range || doCalculate.BoxWhiskerPlot || doCalculate.Histogram) Maximum = "MAX(" + Name + ")";
            if (doCalculate.InterquartileRange || doCalculate.BoxWhiskerPlot) InterquartileRange = Quartile3 + "-" + Quartile1;
            if (doCalculate.Skewness) Skewness = "SKEW(" + Name + ")";
            if (doCalculate.Kurtosis) Kurtosis = "KURT(" + Name + ")";
            if (doCalculate.MeanAbsoluteDeviation) MeanAbsoluteDeviation = "AVEDEV(" + Name + ")";
            if (doCalculate.Mode)
            {
                Mode = "MODE.SNGL(" + Name + ")";
                try
                {
                    Globals.ExcelAddIn.Application.WorksheetFunction.Mode_Sngl(range);
                    HasMode = true;
                }
                catch
                {
                    HasMode = false;
                }
            }
            if (doCalculate.Range || doCalculate.Histogram) Range = Maximum + "-" + Minimum;
            if (doCalculate.Count || doCalculate.MeanConfidenceInterval || doCalculate.StandardDeviationConfidenceInterval || doCalculate.Histogram) Count = "COUNT(" + Name + ")";
            if (doCalculate.Sum) Sum = "SUM(" + Name + ")";
            if (doCalculate.Outliers || doCalculate.BoxWhiskerPlot)
            {
                Outliers = new List<string>();
                for (var i = 1; i <= range.Rows.Count; i++)
                    Outliers.Add("IF(OR(INDEX(" + Name + "," + i + ")<" + Quartile1 + "-1.5*(" + InterquartileRange + "),INDEX(" + Name + "," + i + ")>" + Quartile3 + "+1.5*(" + InterquartileRange + ")),IF(INDEX(" + Name + "," + i + ")<>\"\",INDEX(" + Name + "," + i + "),NA()),NA())");
            }

            // Box-Whisker Plot
            if (doCalculate.BoxWhiskerPlot)
            {
                Quartile1Median = Median + "-" + Quartile1;
                MedianQuartile3 = Quartile3 + "-" + Median;
                MinusWhisker = "IF(" + Quartile1 + "-" + Minimum + "<=1.5*(" + InterquartileRange + ")," + Quartile1 + "-" + Minimum + ",1.5*(" + InterquartileRange + "))";
                PlusWhisker = "IF(" + Maximum + "-" + Quartile3 + "<=1.5*(" + InterquartileRange + ")," + Maximum + "-" + Quartile3 + ",1.5*(" + InterquartileRange + "))";
            }

            // Confidence Interval
            if (doCalculate.MeanConfidenceInterval || doCalculate.StandardDeviationConfidenceInterval)
            {
                DegreesOfFreedom = Count + "-1";
            }
            if (doCalculate.MeanConfidenceInterval)
            {
                MeanConfidenceLevel = meanConfidenceLevel / 100.0;
                MeanConfidenceInterval = "CONFIDENCE.T(" + MeanAlpha + "," + StandardDeviation + "," + Count + ")";
                MeanLowerLimit = Mean + "-" + MeanConfidenceInterval;
                MeanUpperLimit = Mean + "+" + MeanConfidenceInterval;
            }
            if (doCalculate.StandardDeviationConfidenceInterval)
            {
                StandardDeviationConfidenceLevel = standardDeviationConfidenceLevel / 100.0;
                StandardDeviationConfidenceIntervalLowerLimit = "CHISQ.INV(1-(" + StandardDeviationAlpha + ")/2," + DegreesOfFreedom + ")";
                StandardDeviationConfidenceIntervalUpperLimit = "CHISQ.INV((" + StandardDeviationAlpha + ")/2," + DegreesOfFreedom + ")";
                StandardDeviationLowerLimit = StandardDeviation + "*SQRT((" + DegreesOfFreedom + ")/" + StandardDeviationConfidenceIntervalLowerLimit + ")";
                StandardDeviationUpperLimit = StandardDeviation + "*SQRT((" + DegreesOfFreedom + ")/" + StandardDeviationConfidenceIntervalUpperLimit + ")";
            }

            // Histogram
            if (doCalculate.Histogram)
            {
                NumberOfBins = numberOfBins < 0 ? (int)function.RoundUp(Math.Sqrt(function.Count(range)), 0) : numberOfBins;
                BinRange = "ROUND((" + Range + ")/" + NumberOfBins + ",0)";
            }
        }

        /// <summary>
        /// Set the alpha value of the mean confidence interval.
        /// </summary>
        /// <param name="row">The row in which the mean confidence level is in.</param>
        /// <param name="column">The column in which the mean confidence level is in.</param>
        public void SetMeanAlpha(int row, int column)
        {
            MeanAlpha = "1 - " + AddressConverter.CellAddress(row, column);
            MeanConfidenceInterval = "CONFIDENCE.T(" + MeanAlpha + "," + StandardDeviation + "," + Count + ")";
            MeanLowerLimit = Mean + "-" + MeanConfidenceInterval;
            MeanUpperLimit = Mean + "+" + MeanConfidenceInterval;
        }

        /// <summary>
        /// Set the alpha value of the standard deviation confidence interval.
        /// </summary>
        /// <param name="row">The row in which the standard deviation confidence level is in.</param>
        /// <param name="column">The column in which the standard deviation confidence level is in.</param>
        public void SetStandardDeviationAlpha(int row, int column)
        {
            StandardDeviationAlpha = "1 - " + AddressConverter.CellAddress(row, column);
            StandardDeviationConfidenceIntervalLowerLimit = "CHISQ.INV(1-(" + StandardDeviationAlpha + ")/2," + DegreesOfFreedom + ")";
            StandardDeviationConfidenceIntervalUpperLimit = "CHISQ.INV((" + StandardDeviationAlpha + ")/2," + DegreesOfFreedom + ")";
            StandardDeviationLowerLimit = StandardDeviation + "*SQRT((" + DegreesOfFreedom + ")/" + StandardDeviationConfidenceIntervalLowerLimit + ")";
            StandardDeviationUpperLimit = StandardDeviation + "*SQRT((" + DegreesOfFreedom + ")/" + StandardDeviationConfidenceIntervalUpperLimit + ")";
        }

        #endregion

        #region Properties

        public string Name { get; }

        // Base
        public string Mean { get; }
        public string Variance { get; }
        public string StandardDeviation { get; }
        public string Minimum { get; }
        public string Quartile1 { get; }
        public string Median { get; }
        public string Quartile3 { get; }
        public string Maximum { get; }
        public string InterquartileRange { get; }
        public string Skewness { get; }
        public string Kurtosis { get; }
        public string MeanAbsoluteDeviation { get; }
        public string Mode { get; }
        public bool HasMode { get; }
        public string Range { get; }
        public string Count { get; }
        public string Sum { get; }
        public List<string> Outliers { get; }

        // Box-Whisker Plot
        public string Quartile1Median { get; }
        public string MedianQuartile3 { get; }
        public string MinusWhisker { get; }
        public string PlusWhisker { get; }

        // Confidence Interval
        public string DegreesOfFreedom { get; }
        public double MeanConfidenceLevel { get; }
        public string MeanAlpha { get; private set; }
        public string MeanConfidenceInterval { get; private set; }
        public string MeanLowerLimit { get; private set; }
        public string MeanUpperLimit { get; private set; }
        public double StandardDeviationConfidenceLevel { get; }
        public string StandardDeviationAlpha { get; private set; }
        public string StandardDeviationConfidenceIntervalLowerLimit { get; private set; }
        public string StandardDeviationConfidenceIntervalUpperLimit { get; private set; }
        public string StandardDeviationLowerLimit { get; private set; }
        public string StandardDeviationUpperLimit { get; private set; }

        // Histogram
        public int NumberOfBins { get; }
        public string BinRange { get; private set; }

        #endregion
    }
}