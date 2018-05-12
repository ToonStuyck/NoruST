namespace NoruST.Forms
{
    partial class DiscriminantAnalyseForm
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
            this.uiDataGridView_Variables = new System.Windows.Forms.DataGridView();
            this.uiDataGridViewColumn_VariableCheckD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uiDataGridViewColumn_VariableCheckI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblDataSet = new System.Windows.Forms.Label();
            this.lblVariable = new System.Windows.Forms.Label();
            this.uiComboBox_DataSets = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpForm
            // 
            this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpForm.ColumnCount = 4;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 653F));
            this.tlpForm.Controls.Add(this.uiDataGridView_Variables, 1, 1);
            this.tlpForm.Controls.Add(this.lblDataSet, 0, 0);
            this.tlpForm.Controls.Add(this.lblVariable, 0, 1);
            this.tlpForm.Controls.Add(this.uiComboBox_DataSets, 1, 0);
            this.tlpForm.Controls.Add(this.btnOk, 2, 2);
            this.tlpForm.Controls.Add(this.btnCancel, 3, 2);
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 3;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(388, 349);
            this.tlpForm.TabIndex = 22;
            // 
            // uiDataGridView_Variables
            // 
            this.uiDataGridView_Variables.AllowUserToAddRows = false;
            this.uiDataGridView_Variables.AllowUserToDeleteRows = false;
            this.uiDataGridView_Variables.AllowUserToResizeColumns = true;
            this.uiDataGridView_Variables.AllowUserToResizeRows = false;
            this.uiDataGridView_Variables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridView_Variables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiDataGridView_Variables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uiDataGridViewColumn_VariableCheckD,
            this.uiDataGridViewColumn_VariableCheckI});
            this.tlpForm.SetColumnSpan(this.uiDataGridView_Variables, 3);
            this.uiDataGridView_Variables.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiDataGridView_Variables.Location = new System.Drawing.Point(63, 33);
            this.uiDataGridView_Variables.Name = "uiDataGridView_Variables";
            this.uiDataGridView_Variables.RowHeadersVisible = false;
            this.uiDataGridView_Variables.Size = new System.Drawing.Size(321, 193);
            this.uiDataGridView_Variables.TabIndex = 29;
            this.uiDataGridView_Variables.Columns[0].Width = 200;
            this.uiDataGridView_Variables.Columns[1].Width = 200;
            // 
            // uiDataGridViewColumn_VariableCheckD
            // 
            this.uiDataGridViewColumn_VariableCheckD.HeaderText = "D";
            this.uiDataGridViewColumn_VariableCheckD.Name = "uiDataGridViewColumn_VariableCheckD";
            // 
            // uiDataGridViewColumn_VariableCheckI
            // 
            this.uiDataGridViewColumn_VariableCheckI.HeaderText = "I";
            this.uiDataGridViewColumn_VariableCheckI.Name = "uiDataGridViewColumn_VariableCheckI";
            // 
            // lblDataSet
            // 
            this.lblDataSet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataSet.AutoSize = true;
            this.lblDataSet.Location = new System.Drawing.Point(6, 8);
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
            this.lblVariable.Size = new System.Drawing.Size(50, 13);
            this.lblVariable.TabIndex = 20;
            this.lblVariable.Text = "Variable";
            this.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboBox_DataSets
            // 
            this.tlpForm.SetColumnSpan(this.uiComboBox_DataSets, 3);
            this.uiComboBox_DataSets.FormattingEnabled = true;
            this.uiComboBox_DataSets.Location = new System.Drawing.Point(63, 3);
            this.uiComboBox_DataSets.Name = "uiComboBox_DataSets";
            this.uiComboBox_DataSets.Size = new System.Drawing.Size(321, 21);
            this.uiComboBox_DataSets.TabIndex = 22;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(165, 232);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 24);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.uiButton_Ok_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(267, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 24);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.ui_Button_Cancel_Click);
            // 
            // DiscriminantAnalyseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(389, 262);
            this.Controls.Add(this.tlpForm);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "DiscriminantAnalyseForm";
            this.Text = "StatEx - Discriminant Analysis";
            this.tlpForm.ResumeLayout(false);
            this.tlpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Label lblDataSet;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox uiComboBox_DataSets;
        private System.Windows.Forms.DataGridView uiDataGridView_Variables;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheckD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheckI;
    }
}