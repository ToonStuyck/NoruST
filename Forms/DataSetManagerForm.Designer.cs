using System;

namespace NoruST.Forms
{
    partial class DataSetManagerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSetManagerForm));
            this.gbxDataSet = new System.Windows.Forms.GroupBox();
            this.tlpDataSet = new System.Windows.Forms.TableLayoutPanel();
            this.uiDataGridView_Variables = new System.Windows.Forms.DataGridView();
            this.uiDataGridViewColumn_VariableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiDataGridViewColumn_VariableRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblName = new System.Windows.Forms.Label();
            this.uiTextBox_DataSetName = new System.Windows.Forms.TextBox();
            this.lblDataIn = new System.Windows.Forms.Label();
            this.rdbColumns = new System.Windows.Forms.RadioButton();
            this.rdbRows = new System.Windows.Forms.RadioButton();
            this.chkHasHeaders = new System.Windows.Forms.CheckBox();
            this.lblRange = new System.Windows.Forms.Label();
            this.uiButton_Range = new System.Windows.Forms.Button();
            this.uiTextBox_DataSetRange = new System.Windows.Forms.TextBox();
            this.uiButton_Close = new System.Windows.Forms.Button();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.uiListBox_DataSets = new System.Windows.Forms.ListBox();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.uiButton_Delete = new System.Windows.Forms.Button();
            this.uiButton_New = new System.Windows.Forms.Button();
            this.variableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbxDataSet.SuspendLayout();
            this.tlpDataSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).BeginInit();
            this.tlpForm.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxDataSet
            // 
            this.gbxDataSet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpForm.SetColumnSpan(this.gbxDataSet, 3);
            this.gbxDataSet.Controls.Add(this.tlpDataSet);
            this.gbxDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDataSet.Location = new System.Drawing.Point(3, 78);
            this.gbxDataSet.Name = "gbxDataSet";
            this.gbxDataSet.Size = new System.Drawing.Size(378, 250);
            this.gbxDataSet.TabIndex = 1;
            this.gbxDataSet.TabStop = false;
            this.gbxDataSet.Text = "Data Set";
            // 
            // tlpDataSet
            // 
            this.tlpDataSet.AutoSize = true;
            this.tlpDataSet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpDataSet.ColumnCount = 6;
            this.tlpDataSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDataSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDataSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDataSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tlpDataSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDataSet.Controls.Add(this.uiDataGridView_Variables, 0, 3);
            this.tlpDataSet.Controls.Add(this.lblName, 0, 0);
            this.tlpDataSet.Controls.Add(this.uiTextBox_DataSetName, 1, 0);
            this.tlpDataSet.Controls.Add(this.lblDataIn, 0, 2);
            this.tlpDataSet.Controls.Add(this.rdbColumns, 1, 2);
            this.tlpDataSet.Controls.Add(this.rdbRows, 2, 2);
            this.tlpDataSet.Controls.Add(this.chkHasHeaders, 4, 2);
            this.tlpDataSet.Controls.Add(this.lblRange, 0, 1);
            this.tlpDataSet.Controls.Add(this.uiButton_Range, 5, 1);
            this.tlpDataSet.Controls.Add(this.uiTextBox_DataSetRange, 1, 1);
            this.tlpDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataSet.Location = new System.Drawing.Point(3, 16);
            this.tlpDataSet.Name = "tlpDataSet";
            this.tlpDataSet.RowCount = 4;
            this.tlpDataSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDataSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDataSet.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDataSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataSet.Size = new System.Drawing.Size(372, 231);
            this.tlpDataSet.TabIndex = 7;
            // 
            // uiDataGridView_Variables
            // 
            this.uiDataGridView_Variables.AllowUserToAddRows = false;
            this.uiDataGridView_Variables.AllowUserToDeleteRows = false;
            this.uiDataGridView_Variables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridView_Variables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiDataGridView_Variables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uiDataGridViewColumn_VariableName,
            this.uiDataGridViewColumn_VariableRange});
            this.tlpDataSet.SetColumnSpan(this.uiDataGridView_Variables, 6);
            this.uiDataGridView_Variables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView_Variables.Location = new System.Drawing.Point(3, 81);
            this.uiDataGridView_Variables.Name = "uiDataGridView_Variables";
            this.uiDataGridView_Variables.RowHeadersVisible = false;
            this.uiDataGridView_Variables.Size = new System.Drawing.Size(366, 147);
            this.uiDataGridView_Variables.TabIndex = 0;
            // 
            // uiDataGridViewColumn_VariableName
            // 
            this.uiDataGridViewColumn_VariableName.HeaderText = "Naam";
            this.uiDataGridViewColumn_VariableName.Name = "uiDataGridViewColumn_VariableName";
            // 
            // uiDataGridViewColumn_VariableRange
            // 
            this.uiDataGridViewColumn_VariableRange.HeaderText = "Range";
            this.uiDataGridViewColumn_VariableRange.Name = "uiDataGridViewColumn_VariableRange";
            this.uiDataGridViewColumn_VariableRange.ReadOnly = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 3);
            this.lblName.Margin = new System.Windows.Forms.Padding(3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox_DataSetName
            // 
            this.tlpDataSet.SetColumnSpan(this.uiTextBox_DataSetName, 5);
            this.uiTextBox_DataSetName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBox_DataSetName.Location = new System.Drawing.Point(60, 3);
            this.uiTextBox_DataSetName.Name = "uiTextBox_DataSetName";
            this.uiTextBox_DataSetName.Size = new System.Drawing.Size(309, 20);
            this.uiTextBox_DataSetName.TabIndex = 6;
            // 
            // lblDataIn
            // 
            this.lblDataIn.AutoSize = true;
            this.lblDataIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataIn.Location = new System.Drawing.Point(3, 58);
            this.lblDataIn.Margin = new System.Windows.Forms.Padding(3);
            this.lblDataIn.Name = "lblDataIn";
            this.lblDataIn.Size = new System.Drawing.Size(51, 17);
            this.lblDataIn.TabIndex = 2;
            this.lblDataIn.Text = "Data are:";
            this.lblDataIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbColumns
            // 
            this.rdbColumns.AutoSize = true;
            this.rdbColumns.Checked = true;
            this.rdbColumns.Location = new System.Drawing.Point(60, 58);
            this.rdbColumns.Name = "rdbColumns";
            this.rdbColumns.Size = new System.Drawing.Size(65, 17);
            this.rdbColumns.TabIndex = 2;
            this.rdbColumns.TabStop = true;
            this.rdbColumns.Text = "Columns";
            this.rdbColumns.UseVisualStyleBackColor = true;
            this.rdbColumns.CheckedChanged += new System.EventHandler(this.uiRadioButton_Columns_Rows_CheckedChanged);
            // 
            // rdbRows
            // 
            this.rdbRows.AutoSize = true;
            this.rdbRows.Location = new System.Drawing.Point(131, 58);
            this.rdbRows.Name = "rdbRows";
            this.rdbRows.Size = new System.Drawing.Size(52, 17);
            this.rdbRows.TabIndex = 3;
            this.rdbRows.Text = "Rows";
            this.rdbRows.UseVisualStyleBackColor = true;
            this.rdbRows.CheckedChanged += new System.EventHandler(this.uiRadioButton_Columns_Rows_CheckedChanged);
            // 
            // chkHasHeaders
            // 
            this.chkHasHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHasHeaders.AutoSize = true;
            this.chkHasHeaders.Checked = true;
            this.chkHasHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tlpDataSet.SetColumnSpan(this.chkHasHeaders, 2);
            this.chkHasHeaders.Location = new System.Drawing.Point(250, 58);
            this.chkHasHeaders.Name = "chkHasHeaders";
            this.chkHasHeaders.Size = new System.Drawing.Size(119, 17);
            this.chkHasHeaders.TabIndex = 4;
            this.chkHasHeaders.TabStop = false;
            this.chkHasHeaders.Text = "Range has headers";
            this.chkHasHeaders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHasHeaders.UseVisualStyleBackColor = true;
            this.chkHasHeaders.CheckedChanged += new System.EventHandler(this.uiCheckBox_HasHeaders_CheckedChanged);
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRange.Location = new System.Drawing.Point(3, 29);
            this.lblRange.Margin = new System.Windows.Forms.Padding(3);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(51, 23);
            this.lblRange.TabIndex = 7;
            this.lblRange.Text = "Range: ";
            this.lblRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton_Range
            // 
            this.uiButton_Range.Image = global::NoruST.Properties.Resources.range_image;
            this.uiButton_Range.Location = new System.Drawing.Point(345, 29);
            this.uiButton_Range.Name = "uiButton_Range";
            this.uiButton_Range.Size = new System.Drawing.Size(24, 23);
            this.uiButton_Range.TabIndex = 8;
            this.uiButton_Range.UseVisualStyleBackColor = true;
            this.uiButton_Range.Click += new System.EventHandler(this.uiButton_Range_Click);
            // 
            // uiTextBox_DataSetRange
            // 
            this.tlpDataSet.SetColumnSpan(this.uiTextBox_DataSetRange, 4);
            this.uiTextBox_DataSetRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBox_DataSetRange.Location = new System.Drawing.Point(60, 29);
            this.uiTextBox_DataSetRange.Name = "uiTextBox_DataSetRange";
            this.uiTextBox_DataSetRange.Size = new System.Drawing.Size(279, 20);
            this.uiTextBox_DataSetRange.TabIndex = 9;
            // 
            // uiButton_Close
            // 
            this.uiButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButton_Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButton_Close.Location = new System.Drawing.Point(300, 334);
            this.uiButton_Close.Name = "uiButton_Close";
            this.uiButton_Close.Size = new System.Drawing.Size(81, 25);
            this.uiButton_Close.TabIndex = 5;
            this.uiButton_Close.Text = "Close";
            this.uiButton_Close.UseVisualStyleBackColor = true;
            this.uiButton_Close.Click += new System.EventHandler(this.uiButton_Close_Click);
            // 
            // tlpForm
            // 
            this.tlpForm.AutoSize = true;
            this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpForm.ColumnCount = 3;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpForm.Controls.Add(this.gbxDataSet, 0, 1);
            this.tlpForm.Controls.Add(this.uiButton_Close, 2, 2);
            this.tlpForm.Controls.Add(this.uiListBox_DataSets, 0, 0);
            this.tlpForm.Controls.Add(this.tlpButtons, 2, 0);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 3;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpForm.Size = new System.Drawing.Size(384, 362);
            this.tlpForm.TabIndex = 8;
            // 
            // uiListBox_DataSets
            // 
            this.tlpForm.SetColumnSpan(this.uiListBox_DataSets, 2);
            this.uiListBox_DataSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiListBox_DataSets.FormattingEnabled = true;
            this.uiListBox_DataSets.Location = new System.Drawing.Point(3, 3);
            this.uiListBox_DataSets.Name = "uiListBox_DataSets";
            this.uiListBox_DataSets.Size = new System.Drawing.Size(291, 69);
            this.uiListBox_DataSets.TabIndex = 1;
            // 
            // tlpButtons
            // 
            this.tlpButtons.AutoSize = true;
            this.tlpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpButtons.ColumnCount = 1;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtons.Controls.Add(this.uiButton_Delete, 0, 1);
            this.tlpButtons.Controls.Add(this.uiButton_New, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(300, 3);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 2;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Size = new System.Drawing.Size(81, 69);
            this.tlpButtons.TabIndex = 10;
            // 
            // uiButton_Delete
            // 
            this.uiButton_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButton_Delete.Location = new System.Drawing.Point(3, 37);
            this.uiButton_Delete.Name = "uiButton_Delete";
            this.uiButton_Delete.Size = new System.Drawing.Size(75, 29);
            this.uiButton_Delete.TabIndex = 9;
            this.uiButton_Delete.Text = "Remove";
            this.uiButton_Delete.UseVisualStyleBackColor = true;
            this.uiButton_Delete.Click += new System.EventHandler(this.uiButton_Delete_Click);
            // 
            // uiButton_New
            // 
            this.uiButton_New.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButton_New.Location = new System.Drawing.Point(3, 3);
            this.uiButton_New.Name = "uiButton_New";
            this.uiButton_New.Size = new System.Drawing.Size(75, 28);
            this.uiButton_New.TabIndex = 10;
            this.uiButton_New.Text = "New";
            this.uiButton_New.UseVisualStyleBackColor = true;
            this.uiButton_New.Click += new System.EventHandler(this.uiButton_New_Click);
            // 
            // variableBindingSource
            // 
            this.variableBindingSource.DataSource = typeof(NoruST.Domain.Variable);
            // 
            // DataSetManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uiButton_Close;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.tlpForm);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "DataSetManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NoruST - Data Set Manager";
            this.gbxDataSet.ResumeLayout(false);
            this.gbxDataSet.PerformLayout();
            this.tlpDataSet.ResumeLayout(false);
            this.tlpDataSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).EndInit();
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbxDataSet;
        private System.Windows.Forms.DataGridView uiDataGridView_Variables;
        private System.Windows.Forms.CheckBox chkHasHeaders;
        private System.Windows.Forms.RadioButton rdbRows;
        private System.Windows.Forms.RadioButton rdbColumns;
        private System.Windows.Forms.Label lblDataIn;
        private System.Windows.Forms.TextBox uiTextBox_DataSetName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button uiButton_Close;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.TableLayoutPanel tlpDataSet;
        private System.Windows.Forms.ListBox uiListBox_DataSets;
        private System.Windows.Forms.Button uiButton_Delete;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button uiButton_New;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiDataGridViewColumn_VariableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiDataGridViewColumn_VariableRange;
        private System.Windows.Forms.BindingSource variableBindingSource;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Button uiButton_Range;
        private System.Windows.Forms.TextBox uiTextBox_DataSetRange;
    }
}