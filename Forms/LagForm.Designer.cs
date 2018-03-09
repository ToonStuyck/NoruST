namespace NoruST.Forms
{
    partial class LagForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LagForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.uiButton_Cancel = new System.Windows.Forms.Button();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.uiComboBox_Variables = new System.Windows.Forms.ComboBox();
            this.lblVariable = new System.Windows.Forms.Label();
            this.uiComboBox_DataSets = new System.Windows.Forms.ComboBox();
            this.lblDataSet = new System.Windows.Forms.Label();
            this.lblNbOfLags = new System.Windows.Forms.Label();
            this.uiNumericUpDown_Lag = new System.Windows.Forms.NumericUpDown();
            this.tlpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNumericUpDown_Lag)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(150, 88);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.uiButton_Ok_Click);
            // 
            // uiButton_Cancel
            // 
            this.uiButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButton_Cancel.Location = new System.Drawing.Point(231, 88);
            this.uiButton_Cancel.Name = "uiButton_Cancel";
            this.uiButton_Cancel.Size = new System.Drawing.Size(75, 25);
            this.uiButton_Cancel.TabIndex = 16;
            this.uiButton_Cancel.Text = "Annuleren";
            this.uiButton_Cancel.UseVisualStyleBackColor = true;
            this.uiButton_Cancel.Click += new System.EventHandler(this.uiButton_Cancel_Click);
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
            this.tlpForm.Controls.Add(this.uiComboBox_Variables, 1, 1);
            this.tlpForm.Controls.Add(this.lblVariable, 0, 1);
            this.tlpForm.Controls.Add(this.uiComboBox_DataSets, 1, 0);
            this.tlpForm.Controls.Add(this.lblDataSet, 0, 0);
            this.tlpForm.Controls.Add(this.lblNbOfLags, 0, 2);
            this.tlpForm.Controls.Add(this.uiNumericUpDown_Lag, 1, 2);
            this.tlpForm.Controls.Add(this.btnOk, 2, 3);
            this.tlpForm.Controls.Add(this.uiButton_Cancel, 3, 3);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 4;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.Size = new System.Drawing.Size(309, 116);
            this.tlpForm.TabIndex = 20;
            // 
            // uiComboBox_Variables
            // 
            this.tlpForm.SetColumnSpan(this.uiComboBox_Variables, 3);
            this.uiComboBox_Variables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiComboBox_Variables.FormattingEnabled = true;
            this.uiComboBox_Variables.Location = new System.Drawing.Point(87, 30);
            this.uiComboBox_Variables.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.uiComboBox_Variables.Name = "uiComboBox_Variables";
            this.uiComboBox_Variables.Size = new System.Drawing.Size(219, 21);
            this.uiComboBox_Variables.TabIndex = 24;
            // 
            // lblVariable
            // 
            this.lblVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVariable.AutoSize = true;
            this.lblVariable.Location = new System.Drawing.Point(0, 27);
            this.lblVariable.Margin = new System.Windows.Forms.Padding(0);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(82, 27);
            this.lblVariable.TabIndex = 23;
            this.lblVariable.Text = "Variable";
            this.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboBox_DataSets
            // 
            this.tlpForm.SetColumnSpan(this.uiComboBox_DataSets, 3);
            this.uiComboBox_DataSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiComboBox_DataSets.FormattingEnabled = true;
            this.uiComboBox_DataSets.Location = new System.Drawing.Point(87, 3);
            this.uiComboBox_DataSets.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.uiComboBox_DataSets.Name = "uiComboBox_DataSets";
            this.uiComboBox_DataSets.Size = new System.Drawing.Size(219, 21);
            this.uiComboBox_DataSets.TabIndex = 19;
            // 
            // lblDataSet
            // 
            this.lblDataSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataSet.AutoSize = true;
            this.lblDataSet.Location = new System.Drawing.Point(0, 0);
            this.lblDataSet.Margin = new System.Windows.Forms.Padding(0);
            this.lblDataSet.Name = "lblDataSet";
            this.lblDataSet.Size = new System.Drawing.Size(82, 27);
            this.lblDataSet.TabIndex = 20;
            this.lblDataSet.Text = "Data set";
            this.lblDataSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNbOfLags
            // 
            this.lblNbOfLags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNbOfLags.AutoSize = true;
            this.lblNbOfLags.Location = new System.Drawing.Point(0, 54);
            this.lblNbOfLags.Margin = new System.Windows.Forms.Padding(0);
            this.lblNbOfLags.Name = "lblNbOfLags";
            this.lblNbOfLags.Size = new System.Drawing.Size(82, 30);
            this.lblNbOfLags.TabIndex = 21;
            this.lblNbOfLags.Text = "Number of Lags";
            this.lblNbOfLags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiNumericUpDown_Lag
            // 
            this.uiNumericUpDown_Lag.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiNumericUpDown_Lag.Location = new System.Drawing.Point(87, 59);
            this.uiNumericUpDown_Lag.Margin = new System.Windows.Forms.Padding(5);
            this.uiNumericUpDown_Lag.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uiNumericUpDown_Lag.Name = "uiNumericUpDown_Lag";
            this.uiNumericUpDown_Lag.Size = new System.Drawing.Size(50, 20);
            this.uiNumericUpDown_Lag.TabIndex = 22;
            this.uiNumericUpDown_Lag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uiNumericUpDown_Lag.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uiButton_Cancel;
            this.ClientSize = new System.Drawing.Size(309, 116);
            this.Controls.Add(this.tlpForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 155);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(325, 155);
            this.Name = "LagForm";
            this.Text = "NoruST - Lag";
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNumericUpDown_Lag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button uiButton_Cancel;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Label lblDataSet;
        private System.Windows.Forms.Label lblNbOfLags;
        private System.Windows.Forms.NumericUpDown uiNumericUpDown_Lag;
        private System.Windows.Forms.ComboBox uiComboBox_Variables;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.ComboBox uiComboBox_DataSets;
    }
}