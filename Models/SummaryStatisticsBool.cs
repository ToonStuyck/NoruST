namespace NoruST.Models
{
    /// <summary>
    /// <para>SummaryStatisticsBool.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Apr 25, 2016</para>
    /// </summary>
    public class SummaryStatisticsBool
    {
        #region Constructors

        /// <summary>
        /// The constructor for the <see cref="SummaryStatisticsBool"/> class.
        /// </summary>
        public SummaryStatisticsBool(bool mean = false, bool variance = false, bool standardDeviation = false, bool minimum = false, bool quartile1 = false, bool median = false, bool quartile3 = false, bool maximum = false, bool interquartileRange = false, bool skewness = false, bool kurtosis = false, bool meanAbsoluteDeviation = false, bool mode = false, bool range = false, bool count = false, bool sum = false, bool outliers = false, bool correlation = false, bool covariance = false, bool boxWhiskerPlot = false, bool meanConfidenceInterval = false, bool standardDeviationConfidenceInterval = false, bool meanSampleSize = false, bool proportionSampleSize = false, bool differenceOfMeansSampleSize = false, bool differenceOfProportionsSampleSize = false, bool histogram = false, bool fittedValuesVsActualYValues = false, bool residualsVsFittedValues = false, bool residualsVsXValues = false, bool displayRegressionEquation = false, bool customCutoffValue = false, bool movingAverage = false, bool simpleExponentialSmoothing = false, bool holtsExponentialSmoothing = false, bool wintersExponentialSmoothing = false)
        {
            // Base
            Mean = mean;
            Variance = variance;
            StandardDeviation = standardDeviation;
            Minimum = minimum;
            Quartile1 = quartile1;
            Median = median;
            Quartile3 = quartile3;
            Maximum = maximum;
            InterquartileRange = interquartileRange;
            Skewness = skewness;
            Kurtosis = kurtosis;
            MeanAbsoluteDeviation = meanAbsoluteDeviation;
            Mode = mode;
            Range = range;
            Count = count;
            Sum = sum;
            Outliers = outliers;

            // Correlation and Covariance
            Correlation = correlation;
            Covariance = covariance;

            // Box-Whisker Plot
            BoxWhiskerPlot = boxWhiskerPlot;

            // Confidence Interval
            MeanConfidenceInterval = meanConfidenceInterval;
            StandardDeviationConfidenceInterval = standardDeviationConfidenceInterval;

            // Sample Size Estimation
            MeanSampleSize = meanSampleSize;
            ProportionSampleSize = proportionSampleSize;
            DifferenceOfMeansSampleSize = differenceOfMeansSampleSize;
            DifferenceOfProportionsSampleSize = differenceOfProportionsSampleSize;

            // Histogram
            Histogram = histogram;

            // Regression
            FittedValuesVsActualYValues = fittedValuesVsActualYValues;
            ResidualsVsFittedValues = residualsVsFittedValues;
            ResidualsVsXValues = residualsVsXValues;
            DisplayRegressionEquation = displayRegressionEquation;

            // Runs Test for Randomness
            CustomCutoffValue = customCutoffValue;

            // Forecast
            MovingAverage = movingAverage;
            SimpleExponentialSmoothing = simpleExponentialSmoothing;
            HoltsExponentialSmoothing = holtsExponentialSmoothing;
            WintersExponentialSmoothing = wintersExponentialSmoothing;

            // General
            if (Mean || Variance || StandardDeviation || Minimum || Quartile1 || Median || Quartile3 || Maximum || InterquartileRange || Skewness || Kurtosis || MeanAbsoluteDeviation || Mode || Range || Count || Sum || Outliers || Correlation || Covariance || BoxWhiskerPlot || MeanConfidenceInterval || StandardDeviationConfidenceInterval || MeanSampleSize || ProportionSampleSize || DifferenceOfMeansSampleSize || DifferenceOfProportionsSampleSize || Histogram || FittedValuesVsActualYValues || ResidualsVsFittedValues || ResidualsVsXValues || DisplayRegressionEquation || CustomCutoffValue || MovingAverage || SimpleExponentialSmoothing || HoltsExponentialSmoothing || WintersExponentialSmoothing)
                AtLeastOne = true;
            else
                AtLeastOne = false;
        }

        #endregion

        #region Properties

        // Base
        public bool Mean { get; }
        public bool Variance { get; }
        public bool StandardDeviation { get; }
        public bool Minimum { get; }
        public bool Quartile1 { get; }
        public bool Median { get; }
        public bool Quartile3 { get; }
        public bool Maximum { get; }
        public bool InterquartileRange { get; }
        public bool Skewness { get; }
        public bool Kurtosis { get; }
        public bool MeanAbsoluteDeviation { get; }
        public bool Mode { get; }
        public bool Range { get; }
        public bool Count { get; }
        public bool Sum { get; }
        public bool Outliers { get; }

        // Correlation and Covariance
        public bool Correlation { get; }
        public bool Covariance { get; }

        // Box-Whisker Plot
        public bool BoxWhiskerPlot { get; }

        // Confidence Interval
        public bool MeanConfidenceInterval { get; }
        public bool StandardDeviationConfidenceInterval { get; }

        // Sample Size Estimation
        public bool MeanSampleSize { get; }
        public bool ProportionSampleSize { get; }
        public bool DifferenceOfMeansSampleSize { get; }
        public bool DifferenceOfProportionsSampleSize { get; }

        // Histogram
        public bool Histogram { get; }

        // Regression
        public bool FittedValuesVsActualYValues { get; }
        public bool ResidualsVsFittedValues { get; }
        public bool ResidualsVsXValues { get; }
        public bool DisplayRegressionEquation { get; }

        // Runs Test for Randomness
        public bool CustomCutoffValue { get; }

        // Forecast
        public bool MovingAverage { get; }
        public bool SimpleExponentialSmoothing { get; }
        public bool HoltsExponentialSmoothing { get; }
        public bool WintersExponentialSmoothing { get; }

        // General
        public bool AtLeastOne { get; }

        #endregion
    }
}