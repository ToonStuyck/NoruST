﻿namespace NoruST.Forms
{
    partial class Confidence2
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
			this.uiButton_Cancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.uiDataGridView_Variables = new System.Windows.Forms.DataGridView();
			this.uiDataGridViewColumn_VariableCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.lblVariable = new System.Windows.Forms.Label();
			this.uiComboBox_DataSets = new System.Windows.Forms.ComboBox();
			this.lblDataSet = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.tlpForm.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
			this.tlpForm.Controls.Add(this.uiDataGridView_Variables, 1, 1);
			this.tlpForm.Controls.Add(this.lblVariable, 0, 1);
			this.tlpForm.Controls.Add(this.uiComboBox_DataSets, 1, 0);
			this.tlpForm.Controls.Add(this.lblDataSet, 0, 0);
			this.tlpForm.Controls.Add(this.checkBox1, 0, 2);
			this.tlpForm.Controls.Add(this.numericUpDown1, 1, 2);
			this.tlpForm.Controls.Add(this.label1, 2, 2);
			this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpForm.Location = new System.Drawing.Point(0, 0);
			this.tlpForm.Name = "tlpForm";
			this.tlpForm.RowCount = 4;
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpForm.Size = new System.Drawing.Size(334, 227);
			this.tlpForm.TabIndex = 21;
			// 
			// uiButton_Cancel
			// 
			this.uiButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uiButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.uiButton_Cancel.Location = new System.Drawing.Point(256, 199);
			this.uiButton_Cancel.Name = "uiButton_Cancel";
			this.uiButton_Cancel.Size = new System.Drawing.Size(75, 25);
			this.uiButton_Cancel.TabIndex = 32;
			this.uiButton_Cancel.Text = "Cancel";
			this.uiButton_Cancel.UseVisualStyleBackColor = true;
			this.uiButton_Cancel.Click += new System.EventHandler(this.uiButton_Cancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(175, 199);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 25);
			this.btnOk.TabIndex = 31;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
			this.uiDataGridView_Variables.Location = new System.Drawing.Point(122, 30);
			this.uiDataGridView_Variables.Name = "uiDataGridView_Variables";
			this.uiDataGridView_Variables.RowHeadersVisible = false;
			this.uiDataGridView_Variables.Size = new System.Drawing.Size(209, 132);
			this.uiDataGridView_Variables.TabIndex = 28;
			// 
			// uiDataGridViewColumn_VariableCheck
			// 
			this.uiDataGridViewColumn_VariableCheck.HeaderText = "";
			this.uiDataGridViewColumn_VariableCheck.Name = "uiDataGridViewColumn_VariableCheck";
			this.uiDataGridViewColumn_VariableCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// lblVariable
			// 
			this.lblVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblVariable.AutoSize = true;
			this.lblVariable.Location = new System.Drawing.Point(5, 32);
			this.lblVariable.Margin = new System.Windows.Forms.Padding(5);
			this.lblVariable.Name = "lblVariable";
			this.lblVariable.Size = new System.Drawing.Size(109, 13);
			this.lblVariable.TabIndex = 27;
			this.lblVariable.Text = "Variables";
			this.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// uiComboBox_DataSets
			// 
			this.tlpForm.SetColumnSpan(this.uiComboBox_DataSets, 3);
			this.uiComboBox_DataSets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiComboBox_DataSets.FormattingEnabled = true;
			this.uiComboBox_DataSets.Location = new System.Drawing.Point(124, 3);
			this.uiComboBox_DataSets.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.uiComboBox_DataSets.Name = "uiComboBox_DataSets";
			this.uiComboBox_DataSets.Size = new System.Drawing.Size(207, 21);
			this.uiComboBox_DataSets.TabIndex = 26;
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
			this.lblDataSet.Size = new System.Drawing.Size(109, 17);
			this.lblDataSet.TabIndex = 22;
			this.lblDataSet.Text = "Data set";
			this.lblDataSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(5, 170);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(5);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(109, 17);
			this.checkBox1.TabIndex = 33;
			this.checkBox1.Text = "Confidence Level";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.numericUpDown1.Location = new System.Drawing.Point(122, 168);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
			this.numericUpDown1.TabIndex = 30;
			this.numericUpDown1.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(175, 170);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 17);
			this.label1.TabIndex = 34;
			this.label1.Text = "%";
			// 
			// Confidence2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 227);
			this.Controls.Add(this.tlpForm);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(350, 265);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(350, 265);
			this.Name = "Confidence2";
			this.Text = "StatEx - Confidence Proportion";
			this.tlpForm.ResumeLayout(false);
			this.tlpForm.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Label lblDataSet;
        private System.Windows.Forms.ComboBox uiComboBox_DataSets;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.DataGridView uiDataGridView_Variables;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheck;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button uiButton_Cancel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
    }
}