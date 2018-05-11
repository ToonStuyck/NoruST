namespace NoruST.Forms
{
    partial class ChiKwadraatForm
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.RowsIncluded = new System.Windows.Forms.CheckBox();
			this.ColumsIncluded = new System.Windows.Forms.CheckBox();
			this.RowsAndColumsIncluded = new System.Windows.Forms.CheckBox();
			this.ChiSquareOk = new System.Windows.Forms.Button();
			this.ChiSquareCancel = new System.Windows.Forms.Button();
			this.uiButton_Range = new System.Windows.Forms.Button();
			this.uiTextBox_DataSetRange = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.RowsIncluded);
			this.groupBox2.Controls.Add(this.ColumsIncluded);
			this.groupBox2.Controls.Add(this.RowsAndColumsIncluded);
			this.groupBox2.Location = new System.Drawing.Point(25, 62);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.groupBox2.Size = new System.Drawing.Size(489, 97);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Row and Culumn Headers and Titles";
			// 
			// RowsIncluded
			// 
			this.RowsIncluded.AutoSize = true;
			this.RowsIncluded.Location = new System.Drawing.Point(11, 68);
			this.RowsIncluded.Margin = new System.Windows.Forms.Padding(2);
			this.RowsIncluded.Name = "RowsIncluded";
			this.RowsIncluded.Size = new System.Drawing.Size(76, 17);
			this.RowsIncluded.TabIndex = 2;
			this.RowsIncluded.Text = "Rows Title";
			this.RowsIncluded.UseVisualStyleBackColor = true;
			this.RowsIncluded.CheckedChanged += new System.EventHandler(this.ChiSquare_Rows);
			// 
			// ColumsIncluded
			// 
			this.ColumsIncluded.AutoSize = true;
			this.ColumsIncluded.Location = new System.Drawing.Point(11, 46);
			this.ColumsIncluded.Margin = new System.Windows.Forms.Padding(2);
			this.ColumsIncluded.Name = "ColumsIncluded";
			this.ColumsIncluded.Size = new System.Drawing.Size(89, 17);
			this.ColumsIncluded.TabIndex = 1;
			this.ColumsIncluded.Text = "Columns Title";
			this.ColumsIncluded.UseVisualStyleBackColor = true;
			this.ColumsIncluded.CheckedChanged += new System.EventHandler(this.ChiSquare_Colums);
			// 
			// RowsAndColumsIncluded
			// 
			this.RowsAndColumsIncluded.AutoSize = true;
			this.RowsAndColumsIncluded.Location = new System.Drawing.Point(11, 24);
			this.RowsAndColumsIncluded.Margin = new System.Windows.Forms.Padding(2);
			this.RowsAndColumsIncluded.Name = "RowsAndColumsIncluded";
			this.RowsAndColumsIncluded.Size = new System.Drawing.Size(222, 17);
			this.RowsAndColumsIncluded.TabIndex = 0;
			this.RowsAndColumsIncluded.Text = "Table includes Row and Column Headers";
			this.RowsAndColumsIncluded.UseVisualStyleBackColor = true;
			this.RowsAndColumsIncluded.CheckedChanged += new System.EventHandler(this.ChiSquare_both);
			// 
			// ChiSquareOk
			// 
			this.ChiSquareOk.Location = new System.Drawing.Point(365, 163);
			this.ChiSquareOk.Margin = new System.Windows.Forms.Padding(2);
			this.ChiSquareOk.Name = "ChiSquareOk";
			this.ChiSquareOk.Size = new System.Drawing.Size(68, 29);
			this.ChiSquareOk.TabIndex = 2;
			this.ChiSquareOk.Text = "Ok";
			this.ChiSquareOk.UseVisualStyleBackColor = true;
			this.ChiSquareOk.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChiSquare_OK);
			// 
			// ChiSquareCancel
			// 
			this.ChiSquareCancel.Location = new System.Drawing.Point(446, 163);
			this.ChiSquareCancel.Margin = new System.Windows.Forms.Padding(2);
			this.ChiSquareCancel.Name = "ChiSquareCancel";
			this.ChiSquareCancel.Size = new System.Drawing.Size(68, 29);
			this.ChiSquareCancel.TabIndex = 3;
			this.ChiSquareCancel.Text = "Cancel";
			this.ChiSquareCancel.UseVisualStyleBackColor = true;
			this.ChiSquareCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChiSquare_Cancel);
			// 
			// uiButton_Range
			// 
			this.uiButton_Range.Image = global::NoruST.Properties.Resources.range_image;
			this.uiButton_Range.Location = new System.Drawing.Point(490, 18);
			this.uiButton_Range.Name = "uiButton_Range";
			this.uiButton_Range.Size = new System.Drawing.Size(24, 23);
			this.uiButton_Range.TabIndex = 9;
			this.uiButton_Range.UseVisualStyleBackColor = true;
			this.uiButton_Range.Click += new System.EventHandler(this.uiButton_Range_Click);
			// 
			// uiTextBox_DataSetRange
			// 
			this.uiTextBox_DataSetRange.Location = new System.Drawing.Point(220, 20);
			this.uiTextBox_DataSetRange.Margin = new System.Windows.Forms.Padding(2);
			this.uiTextBox_DataSetRange.Name = "uiTextBox_DataSetRange";
			this.uiTextBox_DataSetRange.Size = new System.Drawing.Size(266, 20);
			this.uiTextBox_DataSetRange.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 23);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Contingency Table Range";
			// 
			// ChiKwadraatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 197);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.uiTextBox_DataSetRange);
			this.Controls.Add(this.uiButton_Range);
			this.Controls.Add(this.ChiSquareCancel);
			this.Controls.Add(this.ChiSquareOk);
			this.Controls.Add(this.groupBox2);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ChiKwadraatForm";
			this.Text = "StatEx - Chi-Square Independence Test";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox RowsIncluded;
        private System.Windows.Forms.CheckBox ColumsIncluded;
        private System.Windows.Forms.CheckBox RowsAndColumsIncluded;
        private System.Windows.Forms.Button ChiSquareOk;
        private System.Windows.Forms.Button ChiSquareCancel;
        private System.Windows.Forms.Button uiButton_Range;
        private System.Windows.Forms.TextBox uiTextBox_DataSetRange;
        private System.Windows.Forms.Label label1;
    }
}