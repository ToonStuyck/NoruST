namespace NoruST.Forms
{
    partial class OneVariableSummaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneVariableSummaryForm));
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.uiButton_Cancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblOptions = new System.Windows.Forms.Label();
            this.uiComboBox_DataSets = new System.Windows.Forms.ComboBox();
            this.lblVariable = new System.Windows.Forms.Label();
            this.lblDataSet = new System.Windows.Forms.Label();
            this.uiDataGridView_Variables = new System.Windows.Forms.DataGridView();
            this.uiDataGridViewColumn_VariableCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkInterquartileRange = new System.Windows.Forms.CheckBox();
            this.chkMode = new System.Windows.Forms.CheckBox();
            this.chkThirdQuartile = new System.Windows.Forms.CheckBox();
            this.chkMeanAbsDev = new System.Windows.Forms.CheckBox();
            this.chkFirstQuartile = new System.Windows.Forms.CheckBox();
            this.chkMedian = new System.Windows.Forms.CheckBox();
            this.chkSum = new System.Windows.Forms.CheckBox();
            this.chkKurtosis = new System.Windows.Forms.CheckBox();
            this.chkCount = new System.Windows.Forms.CheckBox();
            this.chkSkewness = new System.Windows.Forms.CheckBox();
            this.chkRange = new System.Windows.Forms.CheckBox();
            this.chkStandardDev = new System.Windows.Forms.CheckBox();
            this.chkMaximum = new System.Windows.Forms.CheckBox();
            this.chkVariance = new System.Windows.Forms.CheckBox();
            this.chkMinimum = new System.Windows.Forms.CheckBox();
            this.chkMean = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.tlpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpForm
            // 
            this.tlpForm.AutoSize = true;
            this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpForm.ColumnCount = 4;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.Controls.Add(this.uiButton_Cancel, 3, 3);
            this.tlpForm.Controls.Add(this.btnOk, 2, 3);
            this.tlpForm.Controls.Add(this.lblOptions, 0, 2);
            this.tlpForm.Controls.Add(this.uiComboBox_DataSets, 1, 0);
            this.tlpForm.Controls.Add(this.lblVariable, 0, 1);
            this.tlpForm.Controls.Add(this.lblDataSet, 0, 0);
            this.tlpForm.Controls.Add(this.uiDataGridView_Variables, 1, 1);
            this.tlpForm.Controls.Add(this.tableLayoutPanel1, 1, 2);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 4;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.Size = new System.Drawing.Size(584, 336);
            this.tlpForm.TabIndex = 20;
            // 
            // uiButton_Cancel
            // 
            this.uiButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButton_Cancel.Location = new System.Drawing.Point(506, 308);
            this.uiButton_Cancel.Name = "uiButton_Cancel";
            this.uiButton_Cancel.Size = new System.Drawing.Size(75, 25);
            this.uiButton_Cancel.TabIndex = 29;
            this.uiButton_Cancel.Text = "Annuleren";
            this.uiButton_Cancel.UseVisualStyleBackColor = true;
            this.uiButton_Cancel.Click += new System.EventHandler(this.uiButton_Cancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(425, 308);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblOptions
            // 
            this.lblOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOptions.AutoSize = true;
            this.lblOptions.Location = new System.Drawing.Point(5, 174);
            this.lblOptions.Margin = new System.Windows.Forms.Padding(5);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(50, 13);
            this.lblOptions.TabIndex = 27;
            this.lblOptions.Text = "Options";
            this.lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboBox_DataSets
            // 
            this.tlpForm.SetColumnSpan(this.uiComboBox_DataSets, 3);
            this.uiComboBox_DataSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiComboBox_DataSets.FormattingEnabled = true;
            this.uiComboBox_DataSets.Location = new System.Drawing.Point(65, 3);
            this.uiComboBox_DataSets.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.uiComboBox_DataSets.Name = "uiComboBox_DataSets";
            this.uiComboBox_DataSets.Size = new System.Drawing.Size(516, 21);
            this.uiComboBox_DataSets.TabIndex = 25;
            // 
            // lblVariable
            // 
            this.lblVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVariable.AutoSize = true;
            this.lblVariable.Location = new System.Drawing.Point(5, 32);
            this.lblVariable.Margin = new System.Windows.Forms.Padding(5);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(50, 13);
            this.lblVariable.TabIndex = 24;
            this.lblVariable.Text = "Variables";
            this.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDataSet
            // 
            this.lblDataSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataSet.AutoSize = true;
            this.lblDataSet.Location = new System.Drawing.Point(5, 5);
            this.lblDataSet.Margin = new System.Windows.Forms.Padding(5);
            this.lblDataSet.Name = "lblDataSet";
            this.lblDataSet.Size = new System.Drawing.Size(50, 17);
            this.lblDataSet.TabIndex = 21;
            this.lblDataSet.Text = "Data set";
            this.lblDataSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.uiDataGridViewColumn_VariableCheck});
            this.tlpForm.SetColumnSpan(this.uiDataGridView_Variables, 3);
            this.uiDataGridView_Variables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView_Variables.Location = new System.Drawing.Point(63, 30);
            this.uiDataGridView_Variables.Name = "uiDataGridView_Variables";
            this.uiDataGridView_Variables.RowHeadersVisible = false;
            this.uiDataGridView_Variables.Size = new System.Drawing.Size(518, 136);
            this.uiDataGridView_Variables.TabIndex = 26;
            // 
            // uiDataGridViewColumn_VariableCheck
            // 
            this.uiDataGridViewColumn_VariableCheck.HeaderText = "";
            this.uiDataGridViewColumn_VariableCheck.Name = "uiDataGridViewColumn_VariableCheck";
            this.uiDataGridViewColumn_VariableCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tlpForm.SetColumnSpan(this.tableLayoutPanel1, 3);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.chkSum, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkKurtosis, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkMaximum, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkVariance, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkMinimum, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkMean, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkStandardDev, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkRange, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkSkewness, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkCount, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkMedian, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkMeanAbsDev, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkFirstQuartile, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkThirdQuartile, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkInterquartileRange, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkMode, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(63, 172);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(518, 130);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // chkInterquartileRange
            // 
            this.chkInterquartileRange.AutoSize = true;
            this.chkInterquartileRange.Location = new System.Drawing.Point(132, 95);
            this.chkInterquartileRange.Name = "chkInterquartileRange";
            this.chkInterquartileRange.Size = new System.Drawing.Size(116, 17);
            this.chkInterquartileRange.TabIndex = 16;
            this.chkInterquartileRange.Text = "Interquartile Range";
            this.chkInterquartileRange.UseVisualStyleBackColor = true;
            // 
            // chkMode
            // 
            this.chkMode.AutoSize = true;
            this.chkMode.Location = new System.Drawing.Point(390, 95);
            this.chkMode.Name = "chkMode";
            this.chkMode.Size = new System.Drawing.Size(53, 17);
            this.chkMode.TabIndex = 15;
            this.chkMode.Text = "Mode";
            this.chkMode.UseVisualStyleBackColor = true;
            // 
            // chkThirdQuartile
            // 
            this.chkThirdQuartile.AutoSize = true;
            this.chkThirdQuartile.Location = new System.Drawing.Point(261, 95);
            this.chkThirdQuartile.Name = "chkThirdQuartile";
            this.chkThirdQuartile.Size = new System.Drawing.Size(89, 17);
            this.chkThirdQuartile.TabIndex = 14;
            this.chkThirdQuartile.Text = "Third Quartile";
            this.chkThirdQuartile.UseVisualStyleBackColor = true;
            // 
            // chkMeanAbsDev
            // 
            this.chkMeanAbsDev.AutoSize = true;
            this.chkMeanAbsDev.Location = new System.Drawing.Point(390, 72);
            this.chkMeanAbsDev.Name = "chkMeanAbsDev";
            this.chkMeanAbsDev.Size = new System.Drawing.Size(125, 17);
            this.chkMeanAbsDev.TabIndex = 13;
            this.chkMeanAbsDev.Text = "Mean Abs. Deviation";
            this.chkMeanAbsDev.UseVisualStyleBackColor = true;
            // 
            // chkFirstQuartile
            // 
            this.chkFirstQuartile.AutoSize = true;
            this.chkFirstQuartile.Location = new System.Drawing.Point(3, 95);
            this.chkFirstQuartile.Name = "chkFirstQuartile";
            this.chkFirstQuartile.Size = new System.Drawing.Size(84, 17);
            this.chkFirstQuartile.TabIndex = 12;
            this.chkFirstQuartile.Text = "First Quartile";
            this.chkFirstQuartile.UseVisualStyleBackColor = true;
            // 
            // chkMedian
            // 
            this.chkMedian.AutoSize = true;
            this.chkMedian.Location = new System.Drawing.Point(261, 72);
            this.chkMedian.Name = "chkMedian";
            this.chkMedian.Size = new System.Drawing.Size(61, 17);
            this.chkMedian.TabIndex = 11;
            this.chkMedian.Text = "Median";
            this.chkMedian.UseVisualStyleBackColor = true;
            // 
            // chkSum
            // 
            this.chkSum.AutoSize = true;
            this.chkSum.Location = new System.Drawing.Point(132, 72);
            this.chkSum.Name = "chkSum";
            this.chkSum.Size = new System.Drawing.Size(47, 17);
            this.chkSum.TabIndex = 10;
            this.chkSum.Text = "Sum";
            this.chkSum.UseVisualStyleBackColor = true;
            // 
            // chkKurtosis
            // 
            this.chkKurtosis.AutoSize = true;
            this.chkKurtosis.Location = new System.Drawing.Point(3, 72);
            this.chkKurtosis.Name = "chkKurtosis";
            this.chkKurtosis.Size = new System.Drawing.Size(63, 17);
            this.chkKurtosis.TabIndex = 9;
            this.chkKurtosis.Text = "Kurtosis";
            this.chkKurtosis.UseVisualStyleBackColor = true;
            // 
            // chkCount
            // 
            this.chkCount.AutoSize = true;
            this.chkCount.Location = new System.Drawing.Point(390, 49);
            this.chkCount.Name = "chkCount";
            this.chkCount.Size = new System.Drawing.Size(54, 17);
            this.chkCount.TabIndex = 8;
            this.chkCount.Text = "Count";
            this.chkCount.UseVisualStyleBackColor = true;
            // 
            // chkSkewness
            // 
            this.chkSkewness.AutoSize = true;
            this.chkSkewness.Location = new System.Drawing.Point(261, 49);
            this.chkSkewness.Name = "chkSkewness";
            this.chkSkewness.Size = new System.Drawing.Size(75, 17);
            this.chkSkewness.TabIndex = 7;
            this.chkSkewness.Text = "Skewness";
            this.chkSkewness.UseVisualStyleBackColor = true;
            // 
            // chkRange
            // 
            this.chkRange.AutoSize = true;
            this.chkRange.Location = new System.Drawing.Point(390, 26);
            this.chkRange.Name = "chkRange";
            this.chkRange.Size = new System.Drawing.Size(58, 17);
            this.chkRange.TabIndex = 6;
            this.chkRange.Text = "Range";
            this.chkRange.UseVisualStyleBackColor = true;
            // 
            // chkStandardDev
            // 
            this.chkStandardDev.AutoSize = true;
            this.chkStandardDev.Location = new System.Drawing.Point(261, 26);
            this.chkStandardDev.Name = "chkStandardDev";
            this.chkStandardDev.Size = new System.Drawing.Size(117, 17);
            this.chkStandardDev.TabIndex = 5;
            this.chkStandardDev.Text = "Standard Deviation";
            this.chkStandardDev.UseVisualStyleBackColor = true;
            // 
            // chkMaximum
            // 
            this.chkMaximum.AutoSize = true;
            this.chkMaximum.Location = new System.Drawing.Point(132, 49);
            this.chkMaximum.Name = "chkMaximum";
            this.chkMaximum.Size = new System.Drawing.Size(70, 17);
            this.chkMaximum.TabIndex = 4;
            this.chkMaximum.Text = "Maximum";
            this.chkMaximum.UseVisualStyleBackColor = true;
            // 
            // chkVariance
            // 
            this.chkVariance.AutoSize = true;
            this.chkVariance.Location = new System.Drawing.Point(3, 49);
            this.chkVariance.Name = "chkVariance";
            this.chkVariance.Size = new System.Drawing.Size(68, 17);
            this.chkVariance.TabIndex = 3;
            this.chkVariance.Text = "Variance";
            this.chkVariance.UseVisualStyleBackColor = true;
            // 
            // chkMinimum
            // 
            this.chkMinimum.AutoSize = true;
            this.chkMinimum.Location = new System.Drawing.Point(132, 26);
            this.chkMinimum.Name = "chkMinimum";
            this.chkMinimum.Size = new System.Drawing.Size(67, 17);
            this.chkMinimum.TabIndex = 2;
            this.chkMinimum.Text = "Minimum";
            this.chkMinimum.UseVisualStyleBackColor = true;
            // 
            // chkMean
            // 
            this.chkMean.AutoSize = true;
            this.chkMean.Location = new System.Drawing.Point(3, 26);
            this.chkMean.Name = "chkMean";
            this.chkMean.Size = new System.Drawing.Size(53, 17);
            this.chkMean.TabIndex = 1;
            this.chkMean.Text = "Mean";
            this.chkMean.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(3, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(87, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "(De)select all";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // OneVariableSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 336);
            this.Controls.Add(this.tlpForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 375);
            this.Name = "OneVariableSummaryForm";
            this.Text = "NoruST - One-Variable Summary";
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Label lblDataSet;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.ComboBox uiComboBox_DataSets;
        private System.Windows.Forms.DataGridView uiDataGridView_Variables;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button uiButton_Cancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkInterquartileRange;
        private System.Windows.Forms.CheckBox chkMode;
        private System.Windows.Forms.CheckBox chkThirdQuartile;
        private System.Windows.Forms.CheckBox chkMeanAbsDev;
        private System.Windows.Forms.CheckBox chkFirstQuartile;
        private System.Windows.Forms.CheckBox chkMedian;
        private System.Windows.Forms.CheckBox chkSum;
        private System.Windows.Forms.CheckBox chkKurtosis;
        private System.Windows.Forms.CheckBox chkCount;
        private System.Windows.Forms.CheckBox chkSkewness;
        private System.Windows.Forms.CheckBox chkRange;
        private System.Windows.Forms.CheckBox chkStandardDev;
        private System.Windows.Forms.CheckBox chkMaximum;
        private System.Windows.Forms.CheckBox chkVariance;
        private System.Windows.Forms.CheckBox chkMinimum;
        private System.Windows.Forms.CheckBox chkMean;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheck;
    }
}