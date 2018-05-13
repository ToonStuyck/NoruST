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
			System.Windows.Forms.Application.EnableVisualStyles();
			this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
			this.uiDataGridView_Variables = new System.Windows.Forms.DataGridView();
			this.uiDataGridViewColumn_VariableCheckD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uiDataGridViewColumn_VariableCheckI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblDataSet = new System.Windows.Forms.Label();
			this.lblVariable = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.uiComboBox_DataSets = new System.Windows.Forms.ComboBox();
			this.grpOptions = new System.Windows.Forms.GroupBox();
			this.chkCheckAllOptions = new System.Windows.Forms.CheckBox();
			this.tlpOptions = new System.Windows.Forms.TableLayoutPanel();
			this.chkResidualsVsXValues = new System.Windows.Forms.CheckBox();
			this.chkFittedValuesVsActualYValues = new System.Windows.Forms.CheckBox();
			this.chkResidualsVsFittedValues = new System.Windows.Forms.CheckBox();
			this.chkDisplayRegressionEquation = new System.Windows.Forms.CheckBox();
			this.lblConfidenceLevel = new System.Windows.Forms.Label();
			this.nudConfidenceLevel = new NoruST.Controls.PercentageNumericUpDown();
			this.tlpForm.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).BeginInit();
			this.grpOptions.SuspendLayout();
			this.tlpOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudConfidenceLevel)).BeginInit();
			this.SuspendLayout();
			// 
			// tlpForm
			// 
			this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpForm.ColumnCount = 4;
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 654F));
			this.tlpForm.Controls.Add(this.uiDataGridView_Variables, 1, 1);
			this.tlpForm.Controls.Add(this.btnOk, 2, 3);
			this.tlpForm.Controls.Add(this.lblVariable, 0, 1);
			this.tlpForm.Controls.Add(this.btnCancel, 3, 3);
			this.tlpForm.Controls.Add(this.uiComboBox_DataSets, 1, 0);
			this.tlpForm.Controls.Add(this.grpOptions, 0, 2);
			this.tlpForm.Controls.Add(this.lblDataSet, 0, 0);
			this.tlpForm.Location = new System.Drawing.Point(0, 0);
			this.tlpForm.Name = "tlpForm";
			this.tlpForm.RowCount = 4;
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpForm.Size = new System.Drawing.Size(388, 390);
			this.tlpForm.TabIndex = 22;
			// 
			// uiDataGridView_Variables
			// 
			this.uiDataGridView_Variables.AllowUserToAddRows = false;
			this.uiDataGridView_Variables.AllowUserToDeleteRows = false;
			this.uiDataGridView_Variables.AllowUserToResizeColumns = false;
			this.uiDataGridView_Variables.AllowUserToResizeRows = false;
			this.uiDataGridView_Variables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.uiDataGridView_Variables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uiDataGridView_Variables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uiDataGridViewColumn_VariableCheckD,
            this.uiDataGridViewColumn_VariableCheckI});
			this.tlpForm.SetColumnSpan(this.uiDataGridView_Variables, 3);
			this.uiDataGridView_Variables.Dock = System.Windows.Forms.DockStyle.Left;
			this.uiDataGridView_Variables.Location = new System.Drawing.Point(66, 33);
			this.uiDataGridView_Variables.Name = "uiDataGridView_Variables";
			this.uiDataGridView_Variables.RowHeadersVisible = false;
			this.uiDataGridView_Variables.Size = new System.Drawing.Size(321, 204);
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
			// btnOk
			// 
			this.btnOk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnOk.Location = new System.Drawing.Point(165, 363);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(95, 24);
			this.btnOk.TabIndex = 17;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.uiButton_Ok_Click);
			// 
			// lblDataSet
			// 
			this.lblDataSet.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblDataSet.AutoSize = true;
			this.lblDataSet.Location = new System.Drawing.Point(8, 8);
			this.lblDataSet.Name = "lblDataSet";
			this.lblDataSet.Size = new System.Drawing.Size(47, 13);
			this.lblDataSet.TabIndex = 19;
			this.lblDataSet.Text = "Data set";
			this.lblDataSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblVariable
			// 
			this.lblVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblVariable.AutoSize = true;
			this.lblVariable.Location = new System.Drawing.Point(5, 35);
			this.lblVariable.Margin = new System.Windows.Forms.Padding(5);
			this.lblVariable.Name = "lblVariable";
			this.lblVariable.Size = new System.Drawing.Size(53, 13);
			this.lblVariable.TabIndex = 20;
			this.lblVariable.Text = "Variables";
			this.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnCancel.Location = new System.Drawing.Point(266, 363);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(118, 24);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.ui_Button_Cancel_Click);
			// 
			// uiComboBox_DataSets
			// 
			this.tlpForm.SetColumnSpan(this.uiComboBox_DataSets, 3);
			this.uiComboBox_DataSets.FormattingEnabled = true;
			this.uiComboBox_DataSets.Location = new System.Drawing.Point(66, 3);
			this.uiComboBox_DataSets.Name = "uiComboBox_DataSets";
			this.uiComboBox_DataSets.Size = new System.Drawing.Size(321, 21);
			this.uiComboBox_DataSets.TabIndex = 22;
			// 
			// grpOptions
			// 
			this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpOptions.AutoSize = true;
			this.grpOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpForm.SetColumnSpan(this.grpOptions, 4);
			this.grpOptions.Controls.Add(this.chkCheckAllOptions);
			this.grpOptions.Controls.Add(this.tlpOptions);
			this.grpOptions.Location = new System.Drawing.Point(3, 261);
			this.grpOptions.Name = "grpOptions";
			this.grpOptions.Size = new System.Drawing.Size(911, 96);
			this.grpOptions.TabIndex = 18;
			this.grpOptions.TabStop = false;
			// 
			// chkCheckAllOptions
			// 
			this.chkCheckAllOptions.AutoSize = true;
			this.chkCheckAllOptions.Location = new System.Drawing.Point(6, 0);
			this.chkCheckAllOptions.Name = "chkCheckAllOptions";
			this.chkCheckAllOptions.Size = new System.Drawing.Size(62, 17);
			this.chkCheckAllOptions.TabIndex = 34;
			this.chkCheckAllOptions.Text = "Options";
			this.chkCheckAllOptions.ThreeState = true;
			this.chkCheckAllOptions.UseVisualStyleBackColor = true;
			// 
			// tlpOptions
			// 
			this.tlpOptions.AutoSize = true;
			this.tlpOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpOptions.ColumnCount = 3;
			this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpOptions.Controls.Add(this.chkResidualsVsXValues, 1, 0);
			this.tlpOptions.Controls.Add(this.chkFittedValuesVsActualYValues, 0, 0);
			this.tlpOptions.Controls.Add(this.chkResidualsVsFittedValues, 0, 1);
			this.tlpOptions.Controls.Add(this.chkDisplayRegressionEquation, 1, 1);
			this.tlpOptions.Controls.Add(this.lblConfidenceLevel, 0, 2);
			this.tlpOptions.Controls.Add(this.nudConfidenceLevel, 1, 2);
			this.tlpOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlpOptions.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tlpOptions.Location = new System.Drawing.Point(3, 16);
			this.tlpOptions.Name = "tlpOptions";
			this.tlpOptions.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.tlpOptions.RowCount = 3;
			this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpOptions.Size = new System.Drawing.Size(905, 77);
			this.tlpOptions.TabIndex = 32;
			// 
			// chkResidualsVsXValues
			// 
			this.chkResidualsVsXValues.AutoSize = true;
			this.tlpOptions.SetColumnSpan(this.chkResidualsVsXValues, 2);
			this.chkResidualsVsXValues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkResidualsVsXValues.Location = new System.Drawing.Point(188, 8);
			this.chkResidualsVsXValues.Name = "chkResidualsVsXValues";
			this.chkResidualsVsXValues.Size = new System.Drawing.Size(714, 17);
			this.chkResidualsVsXValues.TabIndex = 16;
			this.chkResidualsVsXValues.Text = "Residuals vs X-Values";
			this.chkResidualsVsXValues.UseVisualStyleBackColor = true;
			// 
			// chkFittedValuesVsActualYValues
			// 
			this.chkFittedValuesVsActualYValues.AutoSize = true;
			this.chkFittedValuesVsActualYValues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkFittedValuesVsActualYValues.Location = new System.Drawing.Point(3, 8);
			this.chkFittedValuesVsActualYValues.Name = "chkFittedValuesVsActualYValues";
			this.chkFittedValuesVsActualYValues.Size = new System.Drawing.Size(179, 17);
			this.chkFittedValuesVsActualYValues.TabIndex = 15;
			this.chkFittedValuesVsActualYValues.Text = "Fitted Values vs Actual Y-Values";
			this.chkFittedValuesVsActualYValues.UseVisualStyleBackColor = true;
			// 
			// chkResidualsVsFittedValues
			// 
			this.chkResidualsVsFittedValues.AutoSize = true;
			this.chkResidualsVsFittedValues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkResidualsVsFittedValues.Location = new System.Drawing.Point(3, 31);
			this.chkResidualsVsFittedValues.Name = "chkResidualsVsFittedValues";
			this.chkResidualsVsFittedValues.Size = new System.Drawing.Size(179, 17);
			this.chkResidualsVsFittedValues.TabIndex = 17;
			this.chkResidualsVsFittedValues.Text = "Residuals vs Fitted Values";
			this.chkResidualsVsFittedValues.UseVisualStyleBackColor = true;
			// 
			// chkDisplayRegressionEquation
			// 
			this.chkDisplayRegressionEquation.AutoSize = true;
			this.tlpOptions.SetColumnSpan(this.chkDisplayRegressionEquation, 2);
			this.chkDisplayRegressionEquation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkDisplayRegressionEquation.Location = new System.Drawing.Point(188, 31);
			this.chkDisplayRegressionEquation.Name = "chkDisplayRegressionEquation";
			this.chkDisplayRegressionEquation.Size = new System.Drawing.Size(714, 17);
			this.chkDisplayRegressionEquation.TabIndex = 18;
			this.chkDisplayRegressionEquation.Text = "Display Regression Equation";
			this.chkDisplayRegressionEquation.UseVisualStyleBackColor = true;
			// 
			// lblConfidenceLevel
			// 
			this.lblConfidenceLevel.AutoSize = true;
			this.lblConfidenceLevel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblConfidenceLevel.Location = new System.Drawing.Point(3, 51);
			this.lblConfidenceLevel.Name = "lblConfidenceLevel";
			this.lblConfidenceLevel.Size = new System.Drawing.Size(179, 26);
			this.lblConfidenceLevel.TabIndex = 20;
			this.lblConfidenceLevel.Text = "Confidence level (%)";
			this.lblConfidenceLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nudConfidenceLevel
			// 
			this.nudConfidenceLevel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nudConfidenceLevel.Location = new System.Drawing.Point(188, 54);
			this.nudConfidenceLevel.Name = "nudConfidenceLevel";
			this.nudConfidenceLevel.Size = new System.Drawing.Size(50, 20);
			this.nudConfidenceLevel.TabIndex = 21;
			this.nudConfidenceLevel.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
			// 
			// RegressionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(389, 392);
			this.Controls.Add(this.tlpForm);
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "RegressionForm";
			this.Text = "StatEx - Regression";
			this.tlpForm.ResumeLayout(false);
			this.tlpForm.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).EndInit();
			this.grpOptions.ResumeLayout(false);
			this.grpOptions.PerformLayout();
			this.tlpOptions.ResumeLayout(false);
			this.tlpOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudConfidenceLevel)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpForm;
		private System.Windows.Forms.Label lblDataSet;
		private System.Windows.Forms.Label lblVariable;
		private System.Windows.Forms.GroupBox grpOptions;
		private System.Windows.Forms.CheckBox chkCheckAllOptions;
		private System.Windows.Forms.TableLayoutPanel tlpOptions;
		private System.Windows.Forms.CheckBox chkResidualsVsXValues;
		private System.Windows.Forms.CheckBox chkFittedValuesVsActualYValues;
		private System.Windows.Forms.CheckBox chkResidualsVsFittedValues;
		private System.Windows.Forms.CheckBox chkDisplayRegressionEquation;
		private System.Windows.Forms.Label lblConfidenceLevel;
		private Controls.PercentageNumericUpDown nudConfidenceLevel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox uiComboBox_DataSets;
		private System.Windows.Forms.DataGridView uiDataGridView_Variables;
		private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheckD;
		private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheckI;
	}
}