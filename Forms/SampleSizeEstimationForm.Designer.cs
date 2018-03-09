namespace NoruST.Forms
{
    partial class SampleSizeEstimationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleSizeEstimationForm));
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tlpGroupBoxes = new System.Windows.Forms.TableLayoutPanel();
            this.grpEstimate = new System.Windows.Forms.GroupBox();
            this.tlpEstimate = new System.Windows.Forms.TableLayoutPanel();
            this.rdbMean = new System.Windows.Forms.RadioButton();
            this.rdbProportion = new System.Windows.Forms.RadioButton();
            this.rdbDifferenceOfMeans = new System.Windows.Forms.RadioButton();
            this.rdbDifferenceOfProportions = new System.Windows.Forms.RadioButton();
            this.grpSecifications = new System.Windows.Forms.GroupBox();
            this.tlpSpecifications = new System.Windows.Forms.TableLayoutPanel();
            this.lblConfidenceLevel = new System.Windows.Forms.Label();
            this.lblMarginOfError = new System.Windows.Forms.Label();
            this.lblEstimate1 = new System.Windows.Forms.Label();
            this.nudConfidenceLevel = new NoruST.Controls.PercentageNumericUpDown();
            this.txtEstimate1 = new System.Windows.Forms.TextBox();
            this.txtMarginOfError = new System.Windows.Forms.TextBox();
            this.lblEstimate2 = new System.Windows.Forms.Label();
            this.txtEstimate2 = new System.Windows.Forms.TextBox();
            this.tlpForm.SuspendLayout();
            this.tlpGroupBoxes.SuspendLayout();
            this.grpEstimate.SuspendLayout();
            this.tlpEstimate.SuspendLayout();
            this.grpSecifications.SuspendLayout();
            this.tlpSpecifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConfidenceLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpForm
            // 
            this.tlpForm.AutoSize = true;
            this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpForm.ColumnCount = 3;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.Controls.Add(this.btnCancel, 2, 1);
            this.tlpForm.Controls.Add(this.btnOk, 1, 1);
            this.tlpForm.Controls.Add(this.tlpGroupBoxes, 0, 0);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 2;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.Size = new System.Drawing.Size(434, 181);
            this.tlpForm.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(356, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOk.Location = new System.Drawing.Point(275, 153);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tlpGroupBoxes
            // 
            this.tlpGroupBoxes.AutoSize = true;
            this.tlpGroupBoxes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpGroupBoxes.ColumnCount = 2;
            this.tlpForm.SetColumnSpan(this.tlpGroupBoxes, 3);
            this.tlpGroupBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpGroupBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGroupBoxes.Controls.Add(this.grpEstimate, 0, 0);
            this.tlpGroupBoxes.Controls.Add(this.grpSecifications, 1, 0);
            this.tlpGroupBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGroupBoxes.Location = new System.Drawing.Point(3, 3);
            this.tlpGroupBoxes.Name = "tlpGroupBoxes";
            this.tlpGroupBoxes.RowCount = 1;
            this.tlpGroupBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGroupBoxes.Size = new System.Drawing.Size(428, 144);
            this.tlpGroupBoxes.TabIndex = 20;
            // 
            // grpEstimate
            // 
            this.grpEstimate.AutoSize = true;
            this.grpEstimate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpEstimate.Controls.Add(this.tlpEstimate);
            this.grpEstimate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEstimate.Location = new System.Drawing.Point(3, 3);
            this.grpEstimate.Name = "grpEstimate";
            this.grpEstimate.Size = new System.Drawing.Size(154, 138);
            this.grpEstimate.TabIndex = 0;
            this.grpEstimate.TabStop = false;
            this.grpEstimate.Text = "Estimate";
            // 
            // tlpEstimate
            // 
            this.tlpEstimate.AutoSize = true;
            this.tlpEstimate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpEstimate.ColumnCount = 1;
            this.tlpEstimate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEstimate.Controls.Add(this.rdbMean, 0, 0);
            this.tlpEstimate.Controls.Add(this.rdbProportion, 0, 1);
            this.tlpEstimate.Controls.Add(this.rdbDifferenceOfMeans, 0, 2);
            this.tlpEstimate.Controls.Add(this.rdbDifferenceOfProportions, 0, 3);
            this.tlpEstimate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEstimate.Location = new System.Drawing.Point(3, 16);
            this.tlpEstimate.Name = "tlpEstimate";
            this.tlpEstimate.RowCount = 5;
            this.tlpEstimate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEstimate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEstimate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEstimate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEstimate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEstimate.Size = new System.Drawing.Size(148, 119);
            this.tlpEstimate.TabIndex = 1;
            // 
            // rdbMean
            // 
            this.rdbMean.AutoSize = true;
            this.rdbMean.Checked = true;
            this.rdbMean.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbMean.Location = new System.Drawing.Point(3, 3);
            this.rdbMean.Name = "rdbMean";
            this.rdbMean.Size = new System.Drawing.Size(142, 17);
            this.rdbMean.TabIndex = 0;
            this.rdbMean.TabStop = true;
            this.rdbMean.Text = "Mean";
            this.rdbMean.UseVisualStyleBackColor = true;
            this.rdbMean.CheckedChanged += new System.EventHandler(this.estimateCheckedChanged);
            // 
            // rdbProportion
            // 
            this.rdbProportion.AutoSize = true;
            this.rdbProportion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbProportion.Location = new System.Drawing.Point(3, 26);
            this.rdbProportion.Name = "rdbProportion";
            this.rdbProportion.Size = new System.Drawing.Size(142, 17);
            this.rdbProportion.TabIndex = 1;
            this.rdbProportion.TabStop = true;
            this.rdbProportion.Text = "Proportion";
            this.rdbProportion.UseVisualStyleBackColor = true;
            this.rdbProportion.CheckedChanged += new System.EventHandler(this.estimateCheckedChanged);
            // 
            // rdbDifferenceOfMeans
            // 
            this.rdbDifferenceOfMeans.AutoSize = true;
            this.rdbDifferenceOfMeans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbDifferenceOfMeans.Location = new System.Drawing.Point(3, 49);
            this.rdbDifferenceOfMeans.Name = "rdbDifferenceOfMeans";
            this.rdbDifferenceOfMeans.Size = new System.Drawing.Size(142, 17);
            this.rdbDifferenceOfMeans.TabIndex = 2;
            this.rdbDifferenceOfMeans.TabStop = true;
            this.rdbDifferenceOfMeans.Text = "Difference of Means";
            this.rdbDifferenceOfMeans.UseVisualStyleBackColor = true;
            this.rdbDifferenceOfMeans.CheckedChanged += new System.EventHandler(this.estimateCheckedChanged);
            // 
            // rdbDifferenceOfProportions
            // 
            this.rdbDifferenceOfProportions.AutoSize = true;
            this.rdbDifferenceOfProportions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbDifferenceOfProportions.Location = new System.Drawing.Point(3, 72);
            this.rdbDifferenceOfProportions.Name = "rdbDifferenceOfProportions";
            this.rdbDifferenceOfProportions.Size = new System.Drawing.Size(142, 17);
            this.rdbDifferenceOfProportions.TabIndex = 3;
            this.rdbDifferenceOfProportions.TabStop = true;
            this.rdbDifferenceOfProportions.Text = "Difference of Proportions";
            this.rdbDifferenceOfProportions.UseVisualStyleBackColor = true;
            this.rdbDifferenceOfProportions.CheckedChanged += new System.EventHandler(this.estimateCheckedChanged);
            // 
            // grpSecifications
            // 
            this.grpSecifications.AutoSize = true;
            this.grpSecifications.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpSecifications.Controls.Add(this.tlpSpecifications);
            this.grpSecifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSecifications.Location = new System.Drawing.Point(163, 3);
            this.grpSecifications.Name = "grpSecifications";
            this.grpSecifications.Size = new System.Drawing.Size(262, 138);
            this.grpSecifications.TabIndex = 1;
            this.grpSecifications.TabStop = false;
            this.grpSecifications.Text = "Specifications";
            // 
            // tlpSpecifications
            // 
            this.tlpSpecifications.AutoSize = true;
            this.tlpSpecifications.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpSpecifications.ColumnCount = 2;
            this.tlpSpecifications.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSpecifications.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSpecifications.Controls.Add(this.lblConfidenceLevel, 0, 0);
            this.tlpSpecifications.Controls.Add(this.lblMarginOfError, 0, 1);
            this.tlpSpecifications.Controls.Add(this.lblEstimate1, 0, 2);
            this.tlpSpecifications.Controls.Add(this.nudConfidenceLevel, 1, 0);
            this.tlpSpecifications.Controls.Add(this.txtEstimate1, 1, 2);
            this.tlpSpecifications.Controls.Add(this.txtMarginOfError, 1, 1);
            this.tlpSpecifications.Controls.Add(this.lblEstimate2, 0, 3);
            this.tlpSpecifications.Controls.Add(this.txtEstimate2, 1, 3);
            this.tlpSpecifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSpecifications.Location = new System.Drawing.Point(3, 16);
            this.tlpSpecifications.Name = "tlpSpecifications";
            this.tlpSpecifications.RowCount = 5;
            this.tlpSpecifications.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSpecifications.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSpecifications.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSpecifications.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSpecifications.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSpecifications.Size = new System.Drawing.Size(256, 119);
            this.tlpSpecifications.TabIndex = 0;
            // 
            // lblConfidenceLevel
            // 
            this.lblConfidenceLevel.AutoSize = true;
            this.lblConfidenceLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfidenceLevel.Location = new System.Drawing.Point(3, 0);
            this.lblConfidenceLevel.Name = "lblConfidenceLevel";
            this.lblConfidenceLevel.Size = new System.Drawing.Size(194, 26);
            this.lblConfidenceLevel.TabIndex = 0;
            this.lblConfidenceLevel.Text = "Confidence Level";
            this.lblConfidenceLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMarginOfError
            // 
            this.lblMarginOfError.AutoSize = true;
            this.lblMarginOfError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarginOfError.Location = new System.Drawing.Point(3, 26);
            this.lblMarginOfError.Name = "lblMarginOfError";
            this.lblMarginOfError.Size = new System.Drawing.Size(194, 26);
            this.lblMarginOfError.TabIndex = 1;
            this.lblMarginOfError.Text = "Margin of Error";
            this.lblMarginOfError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEstimate1
            // 
            this.lblEstimate1.AutoSize = true;
            this.lblEstimate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstimate1.Location = new System.Drawing.Point(3, 52);
            this.lblEstimate1.Name = "lblEstimate1";
            this.lblEstimate1.Size = new System.Drawing.Size(194, 26);
            this.lblEstimate1.TabIndex = 2;
            this.lblEstimate1.Text = "Estimated Standard Deviation";
            this.lblEstimate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudConfidenceLevel
            // 
            this.nudConfidenceLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudConfidenceLevel.Location = new System.Drawing.Point(203, 3);
            this.nudConfidenceLevel.Name = "nudConfidenceLevel";
            this.nudConfidenceLevel.Size = new System.Drawing.Size(50, 20);
            this.nudConfidenceLevel.TabIndex = 3;
            this.nudConfidenceLevel.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            // 
            // txtEstimate1
            // 
            this.txtEstimate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstimate1.Location = new System.Drawing.Point(203, 55);
            this.txtEstimate1.Name = "txtEstimate1";
            this.txtEstimate1.Size = new System.Drawing.Size(50, 20);
            this.txtEstimate1.TabIndex = 4;
            this.txtEstimate1.Text = "1";
            // 
            // txtMarginOfError
            // 
            this.txtMarginOfError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMarginOfError.Location = new System.Drawing.Point(203, 29);
            this.txtMarginOfError.Name = "txtMarginOfError";
            this.txtMarginOfError.Size = new System.Drawing.Size(50, 20);
            this.txtMarginOfError.TabIndex = 5;
            this.txtMarginOfError.Text = "0.1";
            // 
            // lblEstimate2
            // 
            this.lblEstimate2.AutoSize = true;
            this.lblEstimate2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstimate2.Location = new System.Drawing.Point(3, 78);
            this.lblEstimate2.Name = "lblEstimate2";
            this.lblEstimate2.Size = new System.Drawing.Size(194, 26);
            this.lblEstimate2.TabIndex = 6;
            this.lblEstimate2.Text = "Estimated Proportion 2";
            this.lblEstimate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEstimate2.Visible = false;
            // 
            // txtEstimate2
            // 
            this.txtEstimate2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstimate2.Location = new System.Drawing.Point(203, 81);
            this.txtEstimate2.Name = "txtEstimate2";
            this.txtEstimate2.Size = new System.Drawing.Size(50, 20);
            this.txtEstimate2.TabIndex = 7;
            this.txtEstimate2.Text = "0.1";
            this.txtEstimate2.Visible = false;
            // 
            // SampleSizeEstimationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 181);
            this.Controls.Add(this.tlpForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 220);
            this.Name = "SampleSizeEstimationForm";
            this.Text = "NoruST - Sample Size Estimation";
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            this.tlpGroupBoxes.ResumeLayout(false);
            this.tlpGroupBoxes.PerformLayout();
            this.grpEstimate.ResumeLayout(false);
            this.grpEstimate.PerformLayout();
            this.tlpEstimate.ResumeLayout(false);
            this.tlpEstimate.PerformLayout();
            this.grpSecifications.ResumeLayout(false);
            this.grpSecifications.PerformLayout();
            this.tlpSpecifications.ResumeLayout(false);
            this.tlpSpecifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConfidenceLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpGroupBoxes;
        private System.Windows.Forms.GroupBox grpEstimate;
        private System.Windows.Forms.GroupBox grpSecifications;
        private System.Windows.Forms.TableLayoutPanel tlpEstimate;
        private System.Windows.Forms.RadioButton rdbMean;
        private System.Windows.Forms.TableLayoutPanel tlpSpecifications;
        private System.Windows.Forms.Label lblConfidenceLevel;
        private System.Windows.Forms.Label lblMarginOfError;
        private System.Windows.Forms.Label lblEstimate1;
        private Controls.PercentageNumericUpDown nudConfidenceLevel;
        private System.Windows.Forms.TextBox txtEstimate1;
        private System.Windows.Forms.TextBox txtMarginOfError;
        private System.Windows.Forms.RadioButton rdbProportion;
        private System.Windows.Forms.Label lblEstimate2;
        private System.Windows.Forms.TextBox txtEstimate2;
        private System.Windows.Forms.RadioButton rdbDifferenceOfMeans;
        private System.Windows.Forms.RadioButton rdbDifferenceOfProportions;
    }
}