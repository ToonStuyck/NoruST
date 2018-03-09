using System;
using System.Collections;
using Microsoft.Office.Interop.Excel;

namespace NoruST.Models
{
    /// <summary>
    /// <para>StaticSummaryStatistics.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 10, 2016</para>
    /// </summary>
    public class StaticSummaryStatistics
    {
        #region Constructors

        /// <summary>
        /// Generate static summary statistics as values.
        /// </summary>
        /// <param name="array">The <see cref="Range"/> or values of the data that needs summary statistics.</param>
        public StaticSummaryStatistics(object array)
        {
            // Check if the array is either of type IEnumerable or Range. Throw an exception if this is not the case.
            if (!(array is IEnumerable) && !(array is Range))
                throw new ArgumentException("Object must be of type IEnumerable or Range.");

            // Calculate the different variables for the summary.
            var functions = Globals.ThisAddIn.Application.WorksheetFunction;
            try
            {
                Mean = functions.Average(array);
                Variance = functions.Var_S(array);
                StdDev = functions.StDev_S(array);
                Minimum = functions.Quartile_Inc(array, 0);
                Quartile1 = functions.Quartile_Inc(array, 1);
                Median = functions.Quartile_Inc(array, 2);
                Quartile3 = functions.Quartile_Inc(array, 3);
                Maximum = functions.Quartile_Inc(array, 4);
                InterquartileRange = Quartile3 - Quartile1;
                Skewness = functions.Skew(array);
                Kurtosis = functions.Kurt(array); // = sample excess kurtosis // StstTools Kurtosis = Excel Kurtosis + 3
                MeanAbsDev = functions.AveDev(array);
                try
                {
                    Mode = functions.Mode_Sngl(array);
                        // StatTools will only calculate 1 most occurring variable. If 2 values occur the same amount of time, it will only show 1. If no mode is found, it will divide the range in intervals and calculate the mode from those intervals.
                    HasMode = true;
                }
                catch
                {
                    HasMode = false;
                }
                Range = functions.Max(array) - functions.Min(array);
                Count = functions.Count(array);
                Sum = functions.Sum(array);
            }
            catch
            {
                throw new NotImplementedException("Static calculations are not yet working with string values.");
            }
        }

        #endregion

        #region Properties

        public double Mean { get; set; }
        public double Variance { get; set; }
        public double StdDev { get; set; }
        public double Minimum { get; set; }
        public double Quartile1 { get; set; }
        public double Median { get; set; }
        public double Quartile3 { get; set; }
        public double Maximum { get; set; }
        public double InterquartileRange { get; set; }
        public double Skewness { get; set; }
        public double Kurtosis { get; set; }
        public double MeanAbsDev { get; set; }
        public double Mode { get; set; }
        public bool HasMode { get; set; }
        public double Range { get; set; }
        public double Count { get; set; }
        public double Sum { get; set; }

        #endregion
    }
}