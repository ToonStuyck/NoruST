namespace NoruST.Forms
{
    partial class RegressionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
			this.uiDataGridView_Variables = new System.Windows.Forms.DataGridView();
			this.uiDataGridViewColumn_VariableCheckD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uiDataGridViewColumn_VariableCheckI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uiComboBox_DataSets = new System.Windows.Forms.ComboBox();
			this.lblDataSet = new System.Windows.Forms.Label();
			this.grpBoxGraphs = new System.Windows.Forms.GroupBox();
			this.tlpGraph = new System.Windows.Forms.TableLayoutPanel();
			this.chkCheckAllOptions = new System.Windows.Forms.CheckBox();
			this.chkFittedValuesVsActualYValues = new System.Windows.Forms.CheckBox();
			this.chkResidualsVsFittedValues = new System.Windows.Forms.CheckBox();
			this.chkResidualsVsXValues = new System.Windows.Forms.CheckBox();
			this.chkActualVsX = new System.Windows.Forms.CheckBox();
			this.chkFittedVsX = new System.Windows.Forms.CheckBox();
			this.lblVariable = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.grpBoxOptions = new System.Windows.Forms.GroupBox();
			this.tlpOptions = new System.Windows.Forms.TableLayoutPanel();
			this.chckBoxPrediction = new System.Windows.Forms.CheckBox();
			this.lblConfidenceLevel = new System.Windows.Forms.Label();
			this.lblPredLevel = new System.Windows.Forms.Label();
			this.nudPredictionLevel = new NoruST.Controls.PercentageNumericUpDown();
			this.lblPredData = new System.Windows.Forms.Label();
			this.nudConfidenceLevel = new NoruST.Controls.PercentageNumericUpDown();
			this.comboBoxPredData = new System.Windows.Forms.ComboBox();
			this.tlpForm.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).BeginInit();
			this.grpBoxGraphs.SuspendLayout();
			this.tlpGraph.SuspendLayout();
			this.grpBoxOptions.SuspendLayout();
			this.tlpOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPredictionLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudConfidenceLevel)).BeginInit();
			this.SuspendLayout();
			// 
			// tlpForm
			// 
			this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpForm.ColumnCount = 4;
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 547F));
			this.tlpForm.Controls.Add(this.uiDataGridView_Variables, 1, 1);
			this.tlpForm.Controls.Add(this.uiComboBox_DataSets, 1, 0);
			this.tlpForm.Controls.Add(this.lblDataSet, 0, 0);
			this.tlpForm.Controls.Add(this.grpBoxGraphs, 0, 2);
			this.tlpForm.Controls.Add(this.lblVariable, 0, 1);
			this.tlpForm.Controls.Add(this.btnCancel, 3, 4);
			this.tlpForm.Controls.Add(this.btnOk, 2, 4);
			this.tlpForm.Controls.Add(this.grpBoxOptions, 0, 3);
			this.tlpForm.Location = new System.Drawing.Point(0, 0);
			this.tlpForm.Name = "tlpForm";
			this.tlpForm.RowCount = 5;
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 129F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpForm.Size = new System.Drawing.Size(465, 471);
			this.tlpForm.TabIndex = 22;
			// 
			// uiDataGridView_Variables
			// 
			this.uiDataGridView_Variables.AllowUserToAddRows = false;
			this.uiDataGridView_Variables.AllowUserToDeleteRows = false;
			this.uiDataGridView_Variables.AllowUserToResizeColumns = false;
			this.uiDataGridView_Variables.AllowUserToResizeRows = false;
			this.uiDataGridView_Variables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.uiDataGridView_Variables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.uiDataGridView_Variables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uiDataGridView_Variables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uiDataGridViewColumn_VariableCheckD,
            this.uiDataGridViewColumn_VariableCheckI});
			this.tlpForm.SetColumnSpan(this.uiDataGridView_Variables, 3);
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.uiDataGridView_Variables.DefaultCellStyle = dataGridViewCellStyle5;
			this.uiDataGridView_Variables.Dock = System.Windows.Forms.DockStyle.Left;
			this.uiDataGridView_Variables.Location = new System.Drawing.Point(118, 33);
			this.uiDataGridView_Variables.Name = "uiDataGridView_Variables";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.uiDataGridView_Variables.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.uiDataGridView_Variables.RowHeadersVisible = false;
			this.uiDataGridView_Variables.Size = new System.Drawing.Size(344, 146);
			this.uiDataGridView_Variables.TabIndex = 29;
			// 
			// uiDataGridViewColumn_VariableCheckD
			// 
			this.uiDataGridViewColumn_VariableCheckD.HeaderText = "D";
			this.uiDataGridViewColumn_VariableCheckD.Name = "uiDataGridViewColumn_VariableCheckD";
			this.uiDataGridViewColumn_VariableCheckD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// uiDataGridViewColumn_VariableCheckI
			// 
			this.uiDataGridViewColumn_VariableCheckI.HeaderText = "I";
			this.uiDataGridViewColumn_VariableCheckI.Name = "uiDataGridViewColumn_VariableCheckI";
			this.uiDataGridViewColumn_VariableCheckI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uiDataGridViewColumn_VariableCheckI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// uiComboBox_DataSets
			// 
			this.tlpForm.SetColumnSpan(this.uiComboBox_DataSets, 3);
			this.uiComboBox_DataSets.FormattingEnabled = true;
			this.uiComboBox_DataSets.Location = new System.Drawing.Point(118, 3);
			this.uiComboBox_DataSets.Name = "uiComboBox_DataSets";
			this.uiComboBox_DataSets.Size = new System.Drawing.Size(344, 21);
			this.uiComboBox_DataSets.TabIndex = 22;
			// 
			// lblDataSet
			// 
			this.lblDataSet.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblDataSet.AutoSize = true;
			this.lblDataSet.Location = new System.Drawing.Point(34, 8);
			this.lblDataSet.Name = "lblDataSet";
			this.lblDataSet.Size = new System.Drawing.Size(47, 13);
			this.lblDataSet.TabIndex = 19;
			this.lblDataSet.Text = "Data set";
			this.lblDataSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpBoxGraphs
			// 
			this.grpBoxGraphs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.grpBoxGraphs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpForm.SetColumnSpan(this.grpBoxGraphs, 4);
			this.grpBoxGraphs.Controls.Add(this.tlpGraph);
			this.grpBoxGraphs.Location = new System.Drawing.Point(3, 185);
			this.grpBoxGraphs.Name = "grpBoxGraphs";
			this.grpBoxGraphs.Size = new System.Drawing.Size(462, 124);
			this.grpBoxGraphs.TabIndex = 18;
			this.grpBoxGraphs.TabStop = false;
			this.grpBoxGraphs.Text = "Graphs";
			// 
			// tlpGraph
			// 
			this.tlpGraph.AutoSize = true;
			this.tlpGraph.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpGraph.ColumnCount = 2;
			this.tlpGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpGraph.Controls.Add(this.chkCheckAllOptions, 0, 0);
			this.tlpGraph.Controls.Add(this.chkFittedValuesVsActualYValues, 0, 1);
			this.tlpGraph.Controls.Add(this.chkResidualsVsFittedValues, 0, 2);
			this.tlpGraph.Controls.Add(this.chkResidualsVsXValues, 1, 0);
			this.tlpGraph.Controls.Add(this.chkActualVsX, 1, 1);
			this.tlpGraph.Controls.Add(this.chkFittedVsX, 1, 2);
			this.tlpGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpGraph.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tlpGraph.Location = new System.Drawing.Point(3, 16);
			this.tlpGraph.Name = "tlpGraph";
			this.tlpGraph.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.tlpGraph.RowCount = 3;
			this.tlpGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tlpGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpGraph.Size = new System.Drawing.Size(456, 105);
			this.tlpGraph.TabIndex = 32;
			// 
			// chkCheckAllOptions
			// 
			this.chkCheckAllOptions.AutoSize = true;
			this.chkCheckAllOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkCheckAllOptions.Location = new System.Drawing.Point(3, 8);
			this.chkCheckAllOptions.Name = "chkCheckAllOptions";
			this.chkCheckAllOptions.Size = new System.Drawing.Size(222, 34);
			this.chkCheckAllOptions.TabIndex = 34;
			this.chkCheckAllOptions.Text = "Select all graphs";
			this.chkCheckAllOptions.UseVisualStyleBackColor = true;
			this.chkCheckAllOptions.CheckedChanged += new System.EventHandler(this.chkCheckAllOptions_CheckedChanged);
			// 
			// chkFittedValuesVsActualYValues
			// 
			this.chkFittedValuesVsActualYValues.AutoSize = true;
			this.chkFittedValuesVsActualYValues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkFittedValuesVsActualYValues.Location = new System.Drawing.Point(3, 48);
			this.chkFittedValuesVsActualYValues.Name = "chkFittedValuesVsActualYValues";
			this.chkFittedValuesVsActualYValues.Size = new System.Drawing.Size(222, 24);
			this.chkFittedValuesVsActualYValues.TabIndex = 15;
			this.chkFittedValuesVsActualYValues.Text = "Fitted Values vs Actual Y-Values";
			this.chkFittedValuesVsActualYValues.UseVisualStyleBackColor = true;
			// 
			// chkResidualsVsFittedValues
			// 
			this.chkResidualsVsFittedValues.AutoSize = true;
			this.chkResidualsVsFittedValues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkResidualsVsFittedValues.Location = new System.Drawing.Point(3, 78);
			this.chkResidualsVsFittedValues.Name = "chkResidualsVsFittedValues";
			this.chkResidualsVsFittedValues.Size = new System.Drawing.Size(222, 24);
			this.chkResidualsVsFittedValues.TabIndex = 17;
			this.chkResidualsVsFittedValues.Text = "Residuals vs Fitted Values";
			this.chkResidualsVsFittedValues.UseVisualStyleBackColor = true;
			// 
			// chkResidualsVsXValues
			// 
			this.chkResidualsVsXValues.AutoSize = true;
			this.chkResidualsVsXValues.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.chkResidualsVsXValues.Location = new System.Drawing.Point(231, 25);
			this.chkResidualsVsXValues.Name = "chkResidualsVsXValues";
			this.chkResidualsVsXValues.Size = new System.Drawing.Size(222, 17);
			this.chkResidualsVsXValues.TabIndex = 16;
			this.chkResidualsVsXValues.Text = "Residuals vs X-Values";
			this.chkResidualsVsXValues.UseVisualStyleBackColor = true;
			// 
			// chkActualVsX
			// 
			this.chkActualVsX.AutoSize = true;
			this.chkActualVsX.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkActualVsX.Location = new System.Drawing.Point(231, 48);
			this.chkActualVsX.Name = "chkActualVsX";
			this.chkActualVsX.Size = new System.Drawing.Size(222, 24);
			this.chkActualVsX.TabIndex = 18;
			this.chkActualVsX.Text = "Actual Y-values vs X-Values";
			this.chkActualVsX.UseVisualStyleBackColor = true;
			// 
			// chkFittedVsX
			// 
			this.chkFittedVsX.AutoSize = true;
			this.chkFittedVsX.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkFittedVsX.Location = new System.Drawing.Point(231, 78);
			this.chkFittedVsX.Name = "chkFittedVsX";
			this.chkFittedVsX.Size = new System.Drawing.Size(222, 24);
			this.chkFittedVsX.TabIndex = 21;
			this.chkFittedVsX.Text = "Fitted Values vs X-values";
			this.chkFittedVsX.UseVisualStyleBackColor = true;
			// 
			// lblVariable
			// 
			this.lblVariable.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblVariable.AutoSize = true;
			this.lblVariable.Location = new System.Drawing.Point(32, 35);
			this.lblVariable.Margin = new System.Windows.Forms.Padding(5);
			this.lblVariable.Name = "lblVariable";
			this.lblVariable.Size = new System.Drawing.Size(50, 13);
			this.lblVariable.TabIndex = 20;
			this.lblVariable.Text = "Variables";
			this.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnCancel.Location = new System.Drawing.Point(373, 445);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(89, 21);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.ui_Button_Cancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(280, 444);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(87, 21);
			this.btnOk.TabIndex = 17;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.uiButton_Ok_Click);
			// 
			// grpBoxOptions
			// 
			this.tlpForm.SetColumnSpan(this.grpBoxOptions, 4);
			this.grpBoxOptions.Controls.Add(this.tlpOptions);
			this.grpBoxOptions.Location = new System.Drawing.Point(3, 315);
			this.grpBoxOptions.Name = "grpBoxOptions";
			this.grpBoxOptions.Size = new System.Drawing.Size(459, 123);
			this.grpBoxOptions.TabIndex = 30;
			this.grpBoxOptions.TabStop = false;
			this.grpBoxOptions.Text = "Options";
			// 
			// tlpOptions
			// 
			this.tlpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpOptions.ColumnCount = 5;
			this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.76892F));
			this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.23108F));
			this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
			this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
			this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
			this.tlpOptions.Controls.Add(this.chckBoxPrediction, 0, 2);
			this.tlpOptions.Controls.Add(this.lblConfidenceLevel, 1, 0);
			this.tlpOptions.Controls.Add(this.lblPredData, 1, 3);
			this.tlpOptions.Controls.Add(this.comboBoxPredData, 2, 3);
			this.tlpOptions.Controls.Add(this.nudPredictionLevel, 3, 2);
			this.tlpOptions.Controls.Add(this.lblPredLevel, 1, 2);
			this.tlpOptions.Controls.Add(this.nudConfidenceLevel, 3, 0);
			this.tlpOptions.Location = new System.Drawing.Point(3, 19);
			this.tlpOptions.Name = "tlpOptions";
			this.tlpOptions.RowCount = 4;
			this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
			this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
			this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
			this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
			this.tlpOptions.Size = new System.Drawing.Size(456, 98);
			this.tlpOptions.TabIndex = 0;
			// 
			// chckBoxPrediction
			// 
			this.chckBoxPrediction.AutoSize = true;
			this.chckBoxPrediction.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chckBoxPrediction.Location = new System.Drawing.Point(3, 45);
			this.chckBoxPrediction.Name = "chckBoxPrediction";
			this.chckBoxPrediction.Size = new System.Drawing.Size(158, 21);
			this.chckBoxPrediction.TabIndex = 0;
			this.chckBoxPrediction.Text = "Prediction";
			this.chckBoxPrediction.UseVisualStyleBackColor = true;
			// 
			// lblConfidenceLevel
			// 
			this.lblConfidenceLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblConfidenceLevel.AutoSize = true;
			this.lblConfidenceLevel.Location = new System.Drawing.Point(167, 7);
			this.lblConfidenceLevel.Name = "lblConfidenceLevel";
			this.lblConfidenceLevel.Size = new System.Drawing.Size(103, 13);
			this.lblConfidenceLevel.TabIndex = 20;
			this.lblConfidenceLevel.Text = "Confidence level (%)";
			this.lblConfidenceLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPredLevel
			// 
			this.lblPredLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblPredLevel.AutoSize = true;
			this.lblPredLevel.Location = new System.Drawing.Point(167, 49);
			this.lblPredLevel.Name = "lblPredLevel";
			this.lblPredLevel.Size = new System.Drawing.Size(96, 13);
			this.lblPredLevel.TabIndex = 21;
			this.lblPredLevel.Text = "Prediction level (%)";
			this.lblPredLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudPredictionLevel
			// 
			this.nudPredictionLevel.Location = new System.Drawing.Point(340, 45);
			this.nudPredictionLevel.Name = "nudPredictionLevel";
			this.nudPredictionLevel.Size = new System.Drawing.Size(53, 20);
			this.nudPredictionLevel.TabIndex = 22;
			this.nudPredictionLevel.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
			// 
			// lblPredData
			// 
			this.lblPredData.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblPredData.AutoSize = true;
			this.lblPredData.Location = new System.Drawing.Point(167, 77);
			this.lblPredData.Name = "lblPredData";
			this.lblPredData.Size = new System.Drawing.Size(80, 13);
			this.lblPredData.TabIndex = 23;
			this.lblPredData.Text = "Prediction Data";
			this.lblPredData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudConfidenceLevel
			// 
			this.nudConfidenceLevel.Location = new System.Drawing.Point(340, 3);
			this.nudConfidenceLevel.Name = "nudConfidenceLevel";
			this.nudConfidenceLevel.Size = new System.Drawing.Size(53, 20);
			this.nudConfidenceLevel.TabIndex = 21;
			this.nudConfidenceLevel.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
			// 
			// comboBoxPredData
			// 
			this.tlpOptions.SetColumnSpan(this.comboBoxPredData, 2);
			this.comboBoxPredData.FormattingEnabled = true;
			this.comboBoxPredData.Location = new System.Drawing.Point(286, 72);
			this.comboBoxPredData.Name = "comboBoxPredData";
			this.comboBoxPredData.Size = new System.Drawing.Size(107, 21);
			this.comboBoxPredData.TabIndex = 24;
			// 
			// RegressionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(467, 468);
			this.Controls.Add(this.tlpForm);
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "RegressionForm";
			this.Text = "StatEx - Regression";
			this.tlpForm.ResumeLayout(false);
			this.tlpForm.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).EndInit();
			this.grpBoxGraphs.ResumeLayout(false);
			this.grpBoxGraphs.PerformLayout();
			this.tlpGraph.ResumeLayout(false);
			this.tlpGraph.PerformLayout();
			this.grpBoxOptions.ResumeLayout(false);
			this.tlpOptions.ResumeLayout(false);
			this.tlpOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPredictionLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudConfidenceLevel)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpForm;
		private System.Windows.Forms.Label lblDataSet;
		private System.Windows.Forms.Label lblVariable;
		private System.Windows.Forms.GroupBox grpBoxGraphs;
		private System.Windows.Forms.CheckBox chkCheckAllOptions;
		private System.Windows.Forms.TableLayoutPanel tlpGraph;
		private System.Windows.Forms.CheckBox chkResidualsVsXValues;
		private System.Windows.Forms.CheckBox chkFittedValuesVsActualYValues;
		private System.Windows.Forms.CheckBox chkResidualsVsFittedValues;
		private System.Windows.Forms.CheckBox chkActualVsX;
		private System.Windows.Forms.Label lblConfidenceLevel;
		private Controls.PercentageNumericUpDown nudConfidenceLevel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox uiComboBox_DataSets;
		private System.Windows.Forms.DataGridView uiDataGridView_Variables;
		private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheckD;
		private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheckI;
		private System.Windows.Forms.CheckBox chkFittedVsX;
		private System.Windows.Forms.GroupBox grpBoxOptions;
		private System.Windows.Forms.TableLayoutPanel tlpOptions;
		private System.Windows.Forms.Label lblPredLevel;
		private System.Windows.Forms.CheckBox chckBoxPrediction;
		private Controls.PercentageNumericUpDown nudPredictionLevel;
		private System.Windows.Forms.Label lblPredData;
		private System.Windows.Forms.ComboBox comboBoxPredData;
	}
}