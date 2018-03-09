namespace NoruST
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabNoruST = this.Factory.CreateRibbonTab();
            this.grpData = this.Factory.CreateRibbonGroup();
            this.btnDataSetManager = this.Factory.CreateRibbonButton();
            this.btnDataViewer = this.Factory.CreateRibbonButton();
            this.btnDataUtilities = this.Factory.CreateRibbonMenu();
            this.btnDummy = this.Factory.CreateRibbonButton();
            this.btnLag = this.Factory.CreateRibbonButton();
            this.grpAnalysis = this.Factory.CreateRibbonGroup();
            this.menuSimpleStatistics = this.Factory.CreateRibbonMenu();
            this.btnOneVariableSummary = this.Factory.CreateRibbonButton();
            this.btnHistogram = this.Factory.CreateRibbonButton();
            this.btnScatterplot = this.Factory.CreateRibbonButton();
            this.btnBoxWhiskerPlot = this.Factory.CreateRibbonButton();
            this.btnSampleSizeEstimation = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.menuStatisticalInference = this.Factory.CreateRibbonMenu();
            this.btnAnova = this.Factory.CreateRibbonButton();
            this.btnInteractionplot = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.menuRegression = this.Factory.CreateRibbonMenu();
            this.btnCorrelationAndCovariance = this.Factory.CreateRibbonButton();
            this.btnInteraction = this.Factory.CreateRibbonButton();
            this.btnWhiteTest = this.Factory.CreateRibbonButton();
            this.btnSimpleRegression = this.Factory.CreateRibbonButton();
            this.separator6 = this.Factory.CreateRibbonSeparator();
            this.menuNormalityTests = this.Factory.CreateRibbonMenu();
            this.menuDatamining = this.Factory.CreateRibbonMenu();
            this.btnLogisticRegression = this.Factory.CreateRibbonButton();
            this.btnDiscriminantAnalysis = this.Factory.CreateRibbonButton();
            this.separator4 = this.Factory.CreateRibbonSeparator();
            this.menuTimeseries = this.Factory.CreateRibbonMenu();
            this.btnTimeSeriesGraph = this.Factory.CreateRibbonButton();
            this.btnRunsTestForRandomness = this.Factory.CreateRibbonButton();
            this.btnForecast = this.Factory.CreateRibbonButton();
            this.separator5 = this.Factory.CreateRibbonSeparator();
            this.menuStatisticalProcessControl = this.Factory.CreateRibbonMenu();
            this.btnXRChart = this.Factory.CreateRibbonButton();
            this.btnPChart = this.Factory.CreateRibbonButton();
            this.btnProcessCapability = this.Factory.CreateRibbonButton();
            this.tabNoruST.SuspendLayout();
            this.grpData.SuspendLayout();
            this.grpAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabNoruST
            // 
            this.tabNoruST.Groups.Add(this.grpData);
            this.tabNoruST.Groups.Add(this.grpAnalysis);
            this.tabNoruST.Label = "NoruST";
            this.tabNoruST.Name = "tabNoruST";
            // 
            // grpData
            // 
            this.grpData.Items.Add(this.btnDataSetManager);
            this.grpData.Items.Add(this.btnDataViewer);
            this.grpData.Items.Add(this.btnDataUtilities);
            this.grpData.Label = "Data";
            this.grpData.Name = "grpData";
            // 
            // btnDataSetManager
            // 
            this.btnDataSetManager.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDataSetManager.Image = global::NoruST.Properties.Resources.data_set_manager2_image;
            this.btnDataSetManager.Label = "Data Set Manager";
            this.btnDataSetManager.Name = "btnDataSetManager";
            this.btnDataSetManager.ShowImage = true;
            // 
            // btnDataViewer
            // 
            this.btnDataViewer.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDataViewer.Image = global::NoruST.Properties.Resources.data_viewer;
            this.btnDataViewer.Label = "Data Viewer";
            this.btnDataViewer.Name = "btnDataViewer";
            this.btnDataViewer.ShowImage = true;
            this.btnDataViewer.Visible = false;
            // 
            // btnDataUtilities
            // 
            this.btnDataUtilities.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDataUtilities.Image = global::NoruST.Properties.Resources.data_utilities2_image;
            this.btnDataUtilities.Items.Add(this.btnDummy);
            this.btnDataUtilities.Items.Add(this.btnLag);
            this.btnDataUtilities.Label = "Data Utilities";
            this.btnDataUtilities.Name = "btnDataUtilities";
            this.btnDataUtilities.ShowImage = true;
            // 
            // btnDummy
            // 
            this.btnDummy.Label = "Dummy...";
            this.btnDummy.Name = "btnDummy";
            this.btnDummy.ShowImage = true;
            // 
            // btnLag
            // 
            this.btnLag.Label = "Lag...";
            this.btnLag.Name = "btnLag";
            this.btnLag.ShowImage = true;
            // 
            // grpAnalysis
            // 
            this.grpAnalysis.Items.Add(this.menuSimpleStatistics);
            this.grpAnalysis.Items.Add(this.separator1);
            this.grpAnalysis.Items.Add(this.menuStatisticalInference);
            this.grpAnalysis.Items.Add(this.separator2);
            this.grpAnalysis.Items.Add(this.menuRegression);
            this.grpAnalysis.Items.Add(this.separator6);
            this.grpAnalysis.Items.Add(this.menuNormalityTests);
            this.grpAnalysis.Items.Add(this.menuDatamining);
            this.grpAnalysis.Items.Add(this.separator4);
            this.grpAnalysis.Items.Add(this.menuTimeseries);
            this.grpAnalysis.Items.Add(this.separator5);
            this.grpAnalysis.Items.Add(this.menuStatisticalProcessControl);
            this.grpAnalysis.Label = "Analysis";
            this.grpAnalysis.Name = "grpAnalysis";
            // 
            // menuSimpleStatistics
            // 
            this.menuSimpleStatistics.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menuSimpleStatistics.Image = global::NoruST.Properties.Resources.simple_statistics_image;
            this.menuSimpleStatistics.Items.Add(this.btnOneVariableSummary);
            this.menuSimpleStatistics.Items.Add(this.btnHistogram);
            this.menuSimpleStatistics.Items.Add(this.btnScatterplot);
            this.menuSimpleStatistics.Items.Add(this.btnBoxWhiskerPlot);
            this.menuSimpleStatistics.Items.Add(this.btnSampleSizeEstimation);
            this.menuSimpleStatistics.Label = "Simple Statistics";
            this.menuSimpleStatistics.Name = "menuSimpleStatistics";
            this.menuSimpleStatistics.ShowImage = true;
            // 
            // btnOneVariableSummary
            // 
            this.btnOneVariableSummary.Label = "One-Variable Summary";
            this.btnOneVariableSummary.Name = "btnOneVariableSummary";
            this.btnOneVariableSummary.ShowImage = true;
            // 
            // btnHistogram
            // 
            this.btnHistogram.Label = "Histogram";
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.ShowImage = true;
            // 
            // btnScatterplot
            // 
            this.btnScatterplot.Label = "Scatterplot";
            this.btnScatterplot.Name = "btnScatterplot";
            this.btnScatterplot.ShowImage = true;
            // 
            // btnBoxWhiskerPlot
            // 
            this.btnBoxWhiskerPlot.Label = "Box-Whisker Plot";
            this.btnBoxWhiskerPlot.Name = "btnBoxWhiskerPlot";
            this.btnBoxWhiskerPlot.ShowImage = true;
            // 
            // btnSampleSizeEstimation
            // 
            this.btnSampleSizeEstimation.Label = "Sample Size Estimation";
            this.btnSampleSizeEstimation.Name = "btnSampleSizeEstimation";
            this.btnSampleSizeEstimation.ShowImage = true;
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // menuStatisticalInference
            // 
            this.menuStatisticalInference.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menuStatisticalInference.Image = global::NoruST.Properties.Resources.statistical_inference_image;
            this.menuStatisticalInference.Items.Add(this.btnAnova);
            this.menuStatisticalInference.Items.Add(this.btnInteractionplot);
            this.menuStatisticalInference.Label = "Statistical Inference";
            this.menuStatisticalInference.Name = "menuStatisticalInference";
            this.menuStatisticalInference.ShowImage = true;
            // 
            // btnAnova
            // 
            this.btnAnova.Label = "Anova";
            this.btnAnova.Name = "btnAnova";
            this.btnAnova.ShowImage = true;
            // 
            // btnInteractionplot
            // 
            this.btnInteractionplot.Label = "Interactionplot";
            this.btnInteractionplot.Name = "btnInteractionplot";
            this.btnInteractionplot.ShowImage = true;
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // menuRegression
            // 
            this.menuRegression.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menuRegression.Image = global::NoruST.Properties.Resources.regression_image;
            this.menuRegression.Items.Add(this.btnCorrelationAndCovariance);
            this.menuRegression.Items.Add(this.btnInteraction);
            this.menuRegression.Items.Add(this.btnWhiteTest);
            this.menuRegression.Items.Add(this.btnSimpleRegression);
            this.menuRegression.Label = "Regression";
            this.menuRegression.Name = "menuRegression";
            this.menuRegression.ShowImage = true;
            // 
            // btnCorrelationAndCovariance
            // 
            this.btnCorrelationAndCovariance.Label = "Correlation and Covariance";
            this.btnCorrelationAndCovariance.Name = "btnCorrelationAndCovariance";
            this.btnCorrelationAndCovariance.ShowImage = true;
            // 
            // btnInteraction
            // 
            this.btnInteraction.Label = "Interaction";
            this.btnInteraction.Name = "btnInteraction";
            this.btnInteraction.ShowImage = true;
            // 
            // btnWhiteTest
            // 
            this.btnWhiteTest.Label = "White Test";
            this.btnWhiteTest.Name = "btnWhiteTest";
            this.btnWhiteTest.ShowImage = true;
            // 
            // btnSimpleRegression
            // 
            this.btnSimpleRegression.Label = "Simple Regression";
            this.btnSimpleRegression.Name = "btnSimpleRegression";
            this.btnSimpleRegression.ShowImage = true;
            // 
            // separator6
            // 
            this.separator6.Name = "separator6";
            // 
            // menuNormalityTests
            // 
            this.menuNormalityTests.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menuNormalityTests.Label = "Normality Tests";
            this.menuNormalityTests.Name = "menuNormalityTests";
            this.menuNormalityTests.ShowImage = true;
            this.menuNormalityTests.Visible = false;
            // 
            // menuDatamining
            // 
            this.menuDatamining.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menuDatamining.Image = global::NoruST.Properties.Resources.data_mining_image;
            this.menuDatamining.Items.Add(this.btnLogisticRegression);
            this.menuDatamining.Items.Add(this.btnDiscriminantAnalysis);
            this.menuDatamining.Label = "Datamining";
            this.menuDatamining.Name = "menuDatamining";
            this.menuDatamining.ShowImage = true;
            // 
            // btnLogisticRegression
            // 
            this.btnLogisticRegression.Label = "Logistic Regression";
            this.btnLogisticRegression.Name = "btnLogisticRegression";
            this.btnLogisticRegression.ShowImage = true;
            // 
            // btnDiscriminantAnalysis
            // 
            this.btnDiscriminantAnalysis.Label = "Discriminant Analysis";
            this.btnDiscriminantAnalysis.Name = "btnDiscriminantAnalysis";
            this.btnDiscriminantAnalysis.ShowImage = true;
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            // 
            // menuTimeseries
            // 
            this.menuTimeseries.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menuTimeseries.Image = global::NoruST.Properties.Resources.time_series_image;
            this.menuTimeseries.Items.Add(this.btnTimeSeriesGraph);
            this.menuTimeseries.Items.Add(this.btnRunsTestForRandomness);
            this.menuTimeseries.Items.Add(this.btnForecast);
            this.menuTimeseries.Label = "Time Series";
            this.menuTimeseries.Name = "menuTimeseries";
            this.menuTimeseries.ShowImage = true;
            // 
            // btnTimeSeriesGraph
            // 
            this.btnTimeSeriesGraph.Label = "Time Series Graph";
            this.btnTimeSeriesGraph.Name = "btnTimeSeriesGraph";
            this.btnTimeSeriesGraph.ShowImage = true;
            // 
            // btnRunsTestForRandomness
            // 
            this.btnRunsTestForRandomness.Label = "Runs Test for Randomness";
            this.btnRunsTestForRandomness.Name = "btnRunsTestForRandomness";
            this.btnRunsTestForRandomness.ShowImage = true;
            this.btnRunsTestForRandomness.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRunsTestForRandomness_Click);
            // 
            // btnForecast
            // 
            this.btnForecast.Label = "Forecast";
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.ShowImage = true;
            // 
            // separator5
            // 
            this.separator5.Name = "separator5";
            // 
            // menuStatisticalProcessControl
            // 
            this.menuStatisticalProcessControl.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menuStatisticalProcessControl.Image = global::NoruST.Properties.Resources.quality_control_image;
            this.menuStatisticalProcessControl.Items.Add(this.btnXRChart);
            this.menuStatisticalProcessControl.Items.Add(this.btnPChart);
            this.menuStatisticalProcessControl.Items.Add(this.btnProcessCapability);
            this.menuStatisticalProcessControl.Label = "Quality Control";
            this.menuStatisticalProcessControl.Name = "menuStatisticalProcessControl";
            this.menuStatisticalProcessControl.ShowImage = true;
            // 
            // btnXRChart
            // 
            this.btnXRChart.Label = "X/R Chart";
            this.btnXRChart.Name = "btnXRChart";
            this.btnXRChart.ShowImage = true;
            // 
            // btnPChart
            // 
            this.btnPChart.Label = "P Chart";
            this.btnPChart.Name = "btnPChart";
            this.btnPChart.ShowImage = true;
            // 
            // btnProcessCapability
            // 
            this.btnProcessCapability.Label = "Process Capability";
            this.btnProcessCapability.Name = "btnProcessCapability";
            this.btnProcessCapability.ShowImage = true;
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabNoruST);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tabNoruST.ResumeLayout(false);
            this.tabNoruST.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpAnalysis.ResumeLayout(false);
            this.grpAnalysis.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabNoruST;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpData;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDataSetManager;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDataViewer;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpAnalysis;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menuStatisticalInference;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menuSimpleStatistics;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOneVariableSummary;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDummy;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLag;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu btnDataUtilities;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menuRegression;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menuTimeseries;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menuDatamining;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menuStatisticalProcessControl;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnXRChart;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPChart;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnProcessCapability;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnHistogram;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnScatterplot;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnBoxWhiskerPlot;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCorrelationAndCovariance;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSampleSizeEstimation;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInteractionplot;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAnova;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInteraction;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnWhiteTest;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLogisticRegression;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDiscriminantAnalysis;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTimeSeriesGraph;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRunsTestForRandomness;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnForecast;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator4;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator5;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator6;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menuNormalityTests;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSimpleRegression;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
