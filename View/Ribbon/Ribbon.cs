using Microsoft.Office.Tools.Ribbon;
using NoruST.Forms;
using NoruST.Presenters;

namespace NoruST
{
    public partial class Ribbon
    {

        private DataSetManagerPresenter dataSetManagerPresenter;
        private LagPresenter lagPresenter;
        private XRChartPresenter xrChartPresenter;
        private PChartPresenter pChartPresenter;
        private DummyPresenter dummyPresenter;
        private ProcessCapabilityPresenter processCapabilityPresenter;
        private TimeSeriesGraphPresenter timeSeriesGraphPresenter;
        private OneVariableSummaryPresenter oneVariableSummaryPresenter;
        private RunsTestForRandomnessPresenter runsTestForRandomnessPresenter;
        private ForecastPresenter forecastPresenter;
        private CorrelationCovariancePresenter correlationcovariancePresenter;
        private HistogramPresenter histogramPresenter;
        private ScatterPlotPresenter scatterPlotPresenter;
        private BoxWhiskerPlotPresenter boxWhiskerPlotPresenter;
        private SampleSizeEstimationPresenter sampleSizeEstimationPresenter;
        private OneWayAnovaPresenter oneWayAnovaPresenter;
        private TimeSeriesGraphForm timeSeriesGraphForm;
        private RunsTestForRandomnessForm runsTestForRandomnessForm;
        private ForecastForm forecastForm;
        private RegressionForm regressionForm;
        private LogisticRegressionForm logisticRegressionForm;
        private UnstackedPresenter unstackedPresenter;
        private ConfidencePresenter1 confidencePresenter1;
        private ConfidencePresenter2 confidencePresenter2;
        private HypothesePresenter1 hypothesePresenter1;
        private HypothesePresenter2 hypothesePresenter2;
        private AutoCorrPresenter autoCorrPresenter;
        private InteractionPresenter interactionPresenter;
        private ChiKwadraatPresenter chiKwadraatPresenter;
        private RegressionPresenter regressionPresenter;
        private DiscriminantAnalysePresenter discriminantAnalysePresenter;

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            // Initialize the required classes to work.
            dataSetManagerPresenter = new DataSetManagerPresenter();
            lagPresenter = new LagPresenter(dataSetManagerPresenter);
            xrChartPresenter = new XRChartPresenter(dataSetManagerPresenter);
            pChartPresenter = new PChartPresenter(dataSetManagerPresenter);
            dummyPresenter = new DummyPresenter(dataSetManagerPresenter);
            correlationcovariancePresenter = new CorrelationCovariancePresenter(dataSetManagerPresenter);
            unstackedPresenter = new UnstackedPresenter(dataSetManagerPresenter);
            processCapabilityPresenter = new ProcessCapabilityPresenter(dataSetManagerPresenter);
            timeSeriesGraphPresenter = new TimeSeriesGraphPresenter(dataSetManagerPresenter);
            oneVariableSummaryPresenter = new OneVariableSummaryPresenter(dataSetManagerPresenter);
            histogramPresenter = new HistogramPresenter(dataSetManagerPresenter);
            scatterPlotPresenter = new ScatterPlotPresenter(dataSetManagerPresenter);
            boxWhiskerPlotPresenter = new BoxWhiskerPlotPresenter(dataSetManagerPresenter);
            sampleSizeEstimationPresenter = new SampleSizeEstimationPresenter(dataSetManagerPresenter);
            oneWayAnovaPresenter = new OneWayAnovaPresenter(dataSetManagerPresenter);
            runsTestForRandomnessPresenter = new RunsTestForRandomnessPresenter(dataSetManagerPresenter);
            forecastPresenter = new ForecastPresenter(dataSetManagerPresenter);
            confidencePresenter1 = new ConfidencePresenter1(dataSetManagerPresenter);
            confidencePresenter2 = new ConfidencePresenter2(dataSetManagerPresenter);
            hypothesePresenter1 = new HypothesePresenter1(dataSetManagerPresenter);
            hypothesePresenter2 = new HypothesePresenter2(dataSetManagerPresenter);
            autoCorrPresenter = new AutoCorrPresenter(dataSetManagerPresenter);
            interactionPresenter = new InteractionPresenter(dataSetManagerPresenter);
            chiKwadraatPresenter = new ChiKwadraatPresenter(dataSetManagerPresenter);
            regressionPresenter = new RegressionPresenter(dataSetManagerPresenter);
            discriminantAnalysePresenter = new DiscriminantAnalysePresenter(dataSetManagerPresenter);


            // Add Event Handlers for the click events of the buttons.
            btnDataSetManager.Click += delegate { dataSetManagerPresenter.openDataSetManager(); };
            btnLag.Click += delegate { lagPresenter.openView(); };
            btnDummy.Click += delegate { dummyPresenter.openView(); };
            btnOneVariableSummary.Click += delegate { oneVariableSummaryPresenter.openView(); };
            btnCorrelationAndCovariance.Click += delegate { correlationcovariancePresenter.openView(); };
            btnHistogram.Click += delegate { histogramPresenter.openView(); };
            btnScatterplot.Click += delegate { scatterPlotPresenter.openView(); };
            btnBoxWhiskerPlot.Click += delegate { boxWhiskerPlotPresenter.openView(); };
            btnSampleSize.Click += delegate { sampleSizeEstimationPresenter.openView(); };
            btnAnova.Click += delegate { oneWayAnovaPresenter.openView(); };
            btnRunsTestForRandomness.Click += delegate { runsTestForRandomnessPresenter.openView(); };
            btnForecast.Click += delegate { forecastPresenter.openView(); };
            btnLogisticRegression.Click += delegate { logisticRegressionForm = logisticRegressionForm.createAndOrShowForm(); };
            btnXRChart.Click += delegate { xrChartPresenter.openView(); };
            btnPChart.Click += delegate { pChartPresenter.openView(); };
            btnProcessCapability.Click += delegate { processCapabilityPresenter.openView(); };
            btnTimeSeriesGraph.Click += delegate { timeSeriesGraphPresenter.openView(); };
            btnSimpleRegression.Click += delegate { regressionPresenter.openView(); };
            btnUnstacked.Click += delegate { unstackedPresenter.openView(); };
            btnMeanConf.Click += delegate { confidencePresenter1.openView(); };
            btnProportionConf.Click += delegate { confidencePresenter2.openView(); };
            btnHypoMean.Click += delegate { hypothesePresenter1.openView(); };
            btnHypoProp.Click += delegate { hypothesePresenter2.openView(); };
            button4.Click += delegate { autoCorrPresenter.openView(); };
            btnInteraction.Click += delegate { interactionPresenter.openView(); };
            button3.Click += delegate { chiKwadraatPresenter.openView(); };
            btnDiscriminantAnalysis.Click += delegate { discriminantAnalysePresenter.openView(); };
        }

        private void btnRunsTestForRandomness_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}