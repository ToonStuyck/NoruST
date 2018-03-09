using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

// ReSharper disable LoopCanBeConvertedToQuery

namespace NoruST.Models
{
    /// <summary>
    /// <para>CorrelationCovariance.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 14, 2016</para>
    /// </summary>
    public class CorrelationCovariance
    {
        #region Constructors

        /// <summary>
        /// Generate dynamic correlations and/or covariance's as <see cref="string"/>s.
        /// </summary>
        /// <param name="ranges">The <see cref="Range"/>s of the data that needs correlations and/or covariance's.</param>
        /// <param name="doCalculate">A collection of <see cref="bool"/>s that indicate which summary statistic has to be calculated.</param>
        public CorrelationCovariance(List<Range> ranges, SummaryStatisticsBool doCalculate)
        {
            // Functions to calculate the values for the correlation and/or covariance.
            Func<object, object, string> funcCorr = (name1, name2) => "CORREL(" + name1 + "," + name2 + ")";
            Func<object, object, string> funcCova = (name1, name2) => "COVARIANCE.S(" + name1 + "," + name2 + ")";

            if (doCalculate.Correlation && doCalculate.Covariance)
            {
                Correlations = Compute(funcCorr, ranges);
                Covariances = Compute(funcCova, ranges);
                HasCorrelations = true;
                HasCovariances = true;
            }
            else if (doCalculate.Correlation)
            {
                Correlations = Compute(funcCorr, ranges);
                HasCorrelations = true;
            }
            else if (doCalculate.Covariance)
            {
                Covariances = Compute(funcCova, ranges);
                HasCovariances = true;
            }

            Dimension = (int)Math.Sqrt(Correlations?.Count ?? Covariances?.Count ?? 0);
        }

        #endregion

        #region Private Methods

        private static List<string> Compute(Func<object, object, string> funcAdd, List<Range> ranges)
        {
            var values = new List<string>();

            foreach (var range2 in ranges)
                foreach (var range1 in ranges)
                    values.Add(funcAdd(((Name)range1.Name).Name, ((Name)range2.Name).Name));

            return values;
        }

        #endregion

        #region Properties

        public List<string> Correlations { get; set; }
        public bool HasCorrelations { get; set; }
        public List<string> Covariances { get; set; }
        public bool HasCovariances { get; set; }
        public int Dimension { get; set; }

        #endregion
    }
}