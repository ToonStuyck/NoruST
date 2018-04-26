namespace NoruST.Forms
{
    partial class RunsTestForRandomnessForm
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
            this.uiDataGridView_Variables = new System.Windows.Forms.DataGridView();
            this.uiDataGridViewColumn_VariableCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblVariable = new System.Windows.Forms.Label();
            this.uiComboBox_DataSets = new System.Windows.Forms.ComboBox();
            this.lblDataSet = new System.Windows.Forms.Label();
            this.rdbMedian = new System.Windows.Forms.RadioButton();
            this.rdbMean = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.ui_Button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.uiDataGridView_Variables.Location = new System.Drawing.Point(65, 37);
            this.uiDataGridView_Variables.Name = "uiDataGridView_Variables";
            this.uiDataGridView_Variables.RowHeadersVisible = false;
            this.uiDataGridView_Variables.Size = new System.Drawing.Size(275, 132);
            this.uiDataGridView_Variables.TabIndex = 32;
            // 
            // uiDataGridViewColumn_VariableCheck
            // 
            this.uiDataGridViewColumn_VariableCheck.FillWeight = 30F;
            this.uiDataGridViewColumn_VariableCheck.HeaderText = "";
            this.uiDataGridViewColumn_VariableCheck.Name = "uiDataGridViewColumn_VariableCheck";
            this.uiDataGridViewColumn_VariableCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // lblVariable
            // 
            this.lblVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVariable.AutoSize = true;
            this.lblVariable.Location = new System.Drawing.Point(5, 38);
            this.lblVariable.Margin = new System.Windows.Forms.Padding(5);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(30, 13);
            this.lblVariable.TabIndex = 31;
            this.lblVariable.Text = "Data";
            this.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboBox_DataSets
            // 
            this.uiComboBox_DataSets.FormattingEnabled = true;
            this.uiComboBox_DataSets.Location = new System.Drawing.Point(65, 3);
            this.uiComboBox_DataSets.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.uiComboBox_DataSets.Name = "uiComboBox_DataSets";
            this.uiComboBox_DataSets.Size = new System.Drawing.Size(275, 21);
            this.uiComboBox_DataSets.TabIndex = 30;
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
            this.lblDataSet.Size = new System.Drawing.Size(47, 13);
            this.lblDataSet.TabIndex = 29;
            this.lblDataSet.Text = "Data set";
            this.lblDataSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbMedian
            // 
            this.rdbMedian.AutoSize = true;
            this.rdbMedian.Location = new System.Drawing.Point(6, 45);
            this.rdbMedian.Name = "rdbMedian";
            this.rdbMedian.Size = new System.Drawing.Size(60, 17);
            this.rdbMedian.TabIndex = 34;
            this.rdbMedian.Text = "Median";
            this.rdbMedian.UseVisualStyleBackColor = true;
            // 
            // rdbMean
            // 
            this.rdbMean.AutoSize = true;
            this.rdbMean.Checked = true;
            this.rdbMean.Location = new System.Drawing.Point(6, 21);
            this.rdbMean.Name = "rdbMean";
            this.rdbMean.Size = new System.Drawing.Size(52, 17);
            this.rdbMean.TabIndex = 33;
            this.rdbMean.TabStop = true;
            this.rdbMean.Text = "Mean";
            this.rdbMean.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbMean);
            this.groupBox2.Controls.Add(this.rdbMedian);
            this.groupBox2.Location = new System.Drawing.Point(12, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 91);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cutoff Value";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(183, 272);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 21);
            this.btnOk.TabIndex = 39;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ui_Button_Cancel
            // 
            this.ui_Button_Cancel.Location = new System.Drawing.Point(264, 272);
            this.ui_Button_Cancel.Name = "ui_Button_Cancel";
            this.ui_Button_Cancel.Size = new System.Drawing.Size(75, 21);
            this.ui_Button_Cancel.TabIndex = 38;
            this.ui_Button_Cancel.Text = "Cancel";
            this.ui_Button_Cancel.UseVisualStyleBackColor = true;
            this.ui_Button_Cancel.Click += new System.EventHandler(this.ui_Button_Cancel_Click);
            // 
            // RunsTestForRandomnessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 302);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ui_Button_Cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.uiDataGridView_Variables);
            this.Controls.Add(this.lblVariable);
            this.Controls.Add(this.uiComboBox_DataSets);
            this.Controls.Add(this.lblDataSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(370, 340);
            this.Name = "RunsTestForRandomnessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Runs Test for Randomness";
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView uiDataGridView_Variables;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.ComboBox uiComboBox_DataSets;
        private System.Windows.Forms.Label lblDataSet;
        private System.Windows.Forms.RadioButton rdbMedian;
        private System.Windows.Forms.RadioButton rdbMean;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button ui_Button_Cancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheck;
    }
}