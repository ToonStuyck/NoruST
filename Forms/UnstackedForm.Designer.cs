namespace NoruST.Forms
{
    partial class UnstackedForm
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
			this.uiComboBox_Category = new System.Windows.Forms.ComboBox();
			this.uiComboBox_Variables = new System.Windows.Forms.ComboBox();
			this.uiComboBox_DataSets = new System.Windows.Forms.ComboBox();
			this.lblDataSet = new System.Windows.Forms.Label();
			this.lblVariable = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblCategory = new System.Windows.Forms.Label();
			this.uiButton_Cancel = new System.Windows.Forms.Button();
			this.tlpForm.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpForm
			// 
			this.tlpForm.AutoSize = true;
			this.tlpForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpForm.ColumnCount = 5;
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpForm.Controls.Add(this.uiComboBox_Category, 1, 2);
			this.tlpForm.Controls.Add(this.uiComboBox_Variables, 1, 1);
			this.tlpForm.Controls.Add(this.uiComboBox_DataSets, 1, 0);
			this.tlpForm.Controls.Add(this.lblDataSet, 0, 0);
			this.tlpForm.Controls.Add(this.lblVariable, 0, 1);
			this.tlpForm.Controls.Add(this.btnOk, 3, 5);
			this.tlpForm.Controls.Add(this.lblCategory, 0, 2);
			this.tlpForm.Controls.Add(this.uiButton_Cancel, 4, 5);
			this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpForm.Location = new System.Drawing.Point(0, 0);
			this.tlpForm.Name = "tlpForm";
			this.tlpForm.RowCount = 6;
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpForm.Size = new System.Drawing.Size(334, 137);
			this.tlpForm.TabIndex = 20;
			// 
			// uiComboBox_Category
			// 
			this.tlpForm.SetColumnSpan(this.uiComboBox_Category, 4);
			this.uiComboBox_Category.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiComboBox_Category.FormattingEnabled = true;
			this.uiComboBox_Category.Location = new System.Drawing.Point(60, 57);
			this.uiComboBox_Category.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.uiComboBox_Category.Name = "uiComboBox_Category";
			this.uiComboBox_Category.Size = new System.Drawing.Size(271, 21);
			this.uiComboBox_Category.TabIndex = 26;
			// 
			// uiComboBox_Variables
			// 
			this.tlpForm.SetColumnSpan(this.uiComboBox_Variables, 4);
			this.uiComboBox_Variables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiComboBox_Variables.FormattingEnabled = true;
			this.uiComboBox_Variables.Location = new System.Drawing.Point(60, 30);
			this.uiComboBox_Variables.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.uiComboBox_Variables.Name = "uiComboBox_Variables";
			this.uiComboBox_Variables.Size = new System.Drawing.Size(271, 21);
			this.uiComboBox_Variables.TabIndex = 26;
			// 
			// uiComboBox_DataSets
			// 
			this.tlpForm.SetColumnSpan(this.uiComboBox_DataSets, 4);
			this.uiComboBox_DataSets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiComboBox_DataSets.FormattingEnabled = true;
			this.uiComboBox_DataSets.Location = new System.Drawing.Point(60, 3);
			this.uiComboBox_DataSets.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.uiComboBox_DataSets.Name = "uiComboBox_DataSets";
			this.uiComboBox_DataSets.Size = new System.Drawing.Size(271, 21);
			this.uiComboBox_DataSets.TabIndex = 25;
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
			this.lblDataSet.Size = new System.Drawing.Size(55, 27);
			this.lblDataSet.TabIndex = 21;
			this.lblDataSet.Text = "Data set";
			this.lblDataSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.lblVariable.Size = new System.Drawing.Size(55, 27);
			this.lblVariable.TabIndex = 24;
			this.lblVariable.Text = "Variable";
			this.lblVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

			// 
			// lblCategory
			// 
			this.lblCategory.AutoSize = true;
			this.lblCategory.Location = new System.Drawing.Point(3, 54);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(49, 13);
			this.lblCategory.TabIndex = 27;
			this.lblCategory.Text = "Category";

			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(174, 104);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 30);
			this.btnOk.TabIndex = 27;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.uiButton_Ok_Click);

			// 
			// uiButton_Cancel
			// 
			this.uiButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uiButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.uiButton_Cancel.Location = new System.Drawing.Point(256, 104);
			this.uiButton_Cancel.Name = "uiButton_Cancel";
			this.uiButton_Cancel.Size = new System.Drawing.Size(75, 30);
			this.uiButton_Cancel.TabIndex = 28;
			this.uiButton_Cancel.Text = "Annuleren";
			this.uiButton_Cancel.UseVisualStyleBackColor = true;
			this.uiButton_Cancel.Click += new System.EventHandler(this.uiButton_Cancel_Click);
			// 
			// UnstackedForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 137);
			this.Controls.Add(this.tlpForm);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximumSize = new System.Drawing.Size(500, 255);
			this.MinimumSize = new System.Drawing.Size(350, 155);
			this.Name = "UnstackedForm";
			this.Text = "NoruST - Unstacked";
			this.tlpForm.ResumeLayout(false);
			this.tlpForm.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tlpForm;
		private System.Windows.Forms.Label lblDataSet;
		private System.Windows.Forms.Label lblVariable;
		private System.Windows.Forms.ComboBox uiComboBox_DataSets;
		private System.Windows.Forms.ComboBox uiComboBox_Variables;
		private System.Windows.Forms.ComboBox uiComboBox_Category;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button uiButton_Cancel;
		private System.Windows.Forms.Label lblCategory;
	}
}