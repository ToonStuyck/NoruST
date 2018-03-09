namespace NoruST.Forms
{
    partial class DiscriminantAnalysisForm
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
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDataSet = new System.Windows.Forms.DataGridView();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkCheckAllOptions = new System.Windows.Forms.CheckBox();
            this.tlpOptions = new System.Windows.Forms.TableLayoutPanel();
            this.lblMisclassification1 = new System.Windows.Forms.Label();
            this.lblMisclassification0 = new System.Windows.Forms.Label();
            this.txtProbability = new System.Windows.Forms.TextBox();
            this.lblProbability = new System.Windows.Forms.Label();
            this.txtMisclassification0 = new System.Windows.Forms.TextBox();
            this.txtMisclassification1 = new System.Windows.Forms.TextBox();
            this.lstDataSets = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSet)).BeginInit();
            this.grpOptions.SuspendLayout();
            this.tlpOptions.SuspendLayout();
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
            this.tlpForm.Controls.Add(this.dgvDataSet, 0, 1);
            this.tlpForm.Controls.Add(this.grpOptions, 0, 2);
            this.tlpForm.Controls.Add(this.lstDataSets, 0, 0);
            this.tlpForm.Controls.Add(this.btnOk, 1, 3);
            this.tlpForm.Controls.Add(this.btnCancel, 2, 3);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 4;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(384, 361);
            this.tlpForm.TabIndex = 21;
            // 
            // dgvDataSet
            // 
            this.dgvDataSet.AllowUserToAddRows = false;
            this.dgvDataSet.AllowUserToDeleteRows = false;
            this.dgvDataSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpForm.SetColumnSpan(this.dgvDataSet, 3);
            this.dgvDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataSet.Location = new System.Drawing.Point(3, 78);
            this.dgvDataSet.MinimumSize = new System.Drawing.Size(300, 0);
            this.dgvDataSet.Name = "dgvDataSet";
            this.dgvDataSet.RowHeadersVisible = false;
            this.dgvDataSet.Size = new System.Drawing.Size(378, 141);
            this.dgvDataSet.TabIndex = 14;
            // 
            // grpOptions
            // 
            this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOptions.AutoSize = true;
            this.grpOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpForm.SetColumnSpan(this.grpOptions, 3);
            this.grpOptions.Controls.Add(this.chkCheckAllOptions);
            this.grpOptions.Controls.Add(this.tlpOptions);
            this.grpOptions.Location = new System.Drawing.Point(3, 225);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(378, 102);
            this.grpOptions.TabIndex = 18;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkCheckAllOptions
            // 
            this.chkCheckAllOptions.AutoSize = true;
            this.chkCheckAllOptions.Checked = true;
            this.chkCheckAllOptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckAllOptions.Location = new System.Drawing.Point(6, 0);
            this.chkCheckAllOptions.Name = "chkCheckAllOptions";
            this.chkCheckAllOptions.Size = new System.Drawing.Size(62, 17);
            this.chkCheckAllOptions.TabIndex = 34;
            this.chkCheckAllOptions.Text = "Options";
            this.chkCheckAllOptions.UseVisualStyleBackColor = true;
            this.chkCheckAllOptions.Visible = false;
            // 
            // tlpOptions
            // 
            this.tlpOptions.AutoSize = true;
            this.tlpOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpOptions.ColumnCount = 3;
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptions.Controls.Add(this.lblMisclassification1, 0, 2);
            this.tlpOptions.Controls.Add(this.lblMisclassification0, 0, 1);
            this.tlpOptions.Controls.Add(this.txtProbability, 1, 0);
            this.tlpOptions.Controls.Add(this.lblProbability, 0, 0);
            this.tlpOptions.Controls.Add(this.txtMisclassification0, 1, 1);
            this.tlpOptions.Controls.Add(this.txtMisclassification1, 1, 2);
            this.tlpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptions.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpOptions.Location = new System.Drawing.Point(3, 16);
            this.tlpOptions.Name = "tlpOptions";
            this.tlpOptions.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tlpOptions.RowCount = 3;
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOptions.Size = new System.Drawing.Size(372, 83);
            this.tlpOptions.TabIndex = 32;
            // 
            // lblMisclassification1
            // 
            this.lblMisclassification1.AutoSize = true;
            this.lblMisclassification1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMisclassification1.Location = new System.Drawing.Point(3, 57);
            this.lblMisclassification1.Name = "lblMisclassification1";
            this.lblMisclassification1.Size = new System.Drawing.Size(141, 26);
            this.lblMisclassification1.TabIndex = 12;
            this.lblMisclassification1.Text = "Misclassification cost: 1 as 0";
            this.lblMisclassification1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMisclassification0
            // 
            this.lblMisclassification0.AutoSize = true;
            this.lblMisclassification0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMisclassification0.Location = new System.Drawing.Point(3, 31);
            this.lblMisclassification0.Name = "lblMisclassification0";
            this.lblMisclassification0.Size = new System.Drawing.Size(141, 26);
            this.lblMisclassification0.TabIndex = 11;
            this.lblMisclassification0.Text = "Misclassification cost: 0 as 1";
            this.lblMisclassification0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProbability
            // 
            this.txtProbability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProbability.Location = new System.Drawing.Point(150, 8);
            this.txtProbability.Name = "txtProbability";
            this.txtProbability.Size = new System.Drawing.Size(50, 20);
            this.txtProbability.TabIndex = 10;
            this.txtProbability.Text = "0.5";
            // 
            // lblProbability
            // 
            this.lblProbability.AutoSize = true;
            this.lblProbability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProbability.Location = new System.Drawing.Point(3, 5);
            this.lblProbability.Name = "lblProbability";
            this.lblProbability.Size = new System.Drawing.Size(141, 26);
            this.lblProbability.TabIndex = 9;
            this.lblProbability.Text = "Prior probability of 0";
            this.lblProbability.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMisclassification0
            // 
            this.txtMisclassification0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMisclassification0.Location = new System.Drawing.Point(150, 34);
            this.txtMisclassification0.Name = "txtMisclassification0";
            this.txtMisclassification0.Size = new System.Drawing.Size(50, 20);
            this.txtMisclassification0.TabIndex = 13;
            this.txtMisclassification0.Text = "1";
            // 
            // txtMisclassification1
            // 
            this.txtMisclassification1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMisclassification1.Location = new System.Drawing.Point(150, 60);
            this.txtMisclassification1.Name = "txtMisclassification1";
            this.txtMisclassification1.Size = new System.Drawing.Size(50, 20);
            this.txtMisclassification1.TabIndex = 14;
            this.txtMisclassification1.Text = "1";
            // 
            // lstDataSets
            // 
            this.tlpForm.SetColumnSpan(this.lstDataSets, 3);
            this.lstDataSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDataSets.FormattingEnabled = true;
            this.lstDataSets.Location = new System.Drawing.Point(3, 3);
            this.lstDataSets.Name = "lstDataSets";
            this.lstDataSets.Size = new System.Drawing.Size(378, 69);
            this.lstDataSets.TabIndex = 15;
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOk.Location = new System.Drawing.Point(225, 333);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(306, 333);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DiscriminantAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.tlpForm);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "DiscriminantAnalysisForm";
            this.Text = "NoruST - Discriminant Analysis";
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSet)).EndInit();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.tlpOptions.ResumeLayout(false);
            this.tlpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.DataGridView dgvDataSet;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.TableLayoutPanel tlpOptions;
        private System.Windows.Forms.ListBox lstDataSets;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkCheckAllOptions;
        private System.Windows.Forms.Label lblMisclassification1;
        private System.Windows.Forms.Label lblMisclassification0;
        private System.Windows.Forms.TextBox txtProbability;
        private System.Windows.Forms.Label lblProbability;
        private System.Windows.Forms.TextBox txtMisclassification0;
        private System.Windows.Forms.TextBox txtMisclassification1;
    }
}