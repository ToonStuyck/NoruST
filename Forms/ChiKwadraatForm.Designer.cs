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
            this.groupBox2.Location = new System.Drawing.Point(33, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(652, 119);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Row and Culumn Headers and Titles";
            // 
            // RowsIncluded
            // 
            this.RowsIncluded.AutoSize = true;
            this.RowsIncluded.Location = new System.Drawing.Point(15, 84);
            this.RowsIncluded.Name = "RowsIncluded";
            this.RowsIncluded.Size = new System.Drawing.Size(95, 21);
            this.RowsIncluded.TabIndex = 2;
            this.RowsIncluded.Text = "Rows Title";
            this.RowsIncluded.UseVisualStyleBackColor = true;
            // 
            // ColumsIncluded
            // 
            this.ColumsIncluded.AutoSize = true;
            this.ColumsIncluded.Location = new System.Drawing.Point(15, 57);
            this.ColumsIncluded.Name = "ColumsIncluded";
            this.ColumsIncluded.Size = new System.Drawing.Size(115, 21);
            this.ColumsIncluded.TabIndex = 1;
            this.ColumsIncluded.Text = "Columns Title";
            this.ColumsIncluded.UseVisualStyleBackColor = true;
            // 
            // RowsAndColumsIncluded
            // 
            this.RowsAndColumsIncluded.AutoSize = true;
            this.RowsAndColumsIncluded.Location = new System.Drawing.Point(15, 30);
            this.RowsAndColumsIncluded.Name = "RowsAndColumsIncluded";
            this.RowsAndColumsIncluded.Size = new System.Drawing.Size(290, 21);
            this.RowsAndColumsIncluded.TabIndex = 0;
            this.RowsAndColumsIncluded.Text = "Table includes Row and Column Headers";
            this.RowsAndColumsIncluded.UseVisualStyleBackColor = true;
            // 
            // ChiSquareOk
            // 
            this.ChiSquareOk.Location = new System.Drawing.Point(487, 201);
            this.ChiSquareOk.Name = "ChiSquareOk";
            this.ChiSquareOk.Size = new System.Drawing.Size(91, 36);
            this.ChiSquareOk.TabIndex = 2;
            this.ChiSquareOk.Text = "OK";
            this.ChiSquareOk.UseVisualStyleBackColor = true;
            // 
            // ChiSquareCancel
            // 
            this.ChiSquareCancel.Location = new System.Drawing.Point(594, 201);
            this.ChiSquareCancel.Name = "ChiSquareCancel";
            this.ChiSquareCancel.Size = new System.Drawing.Size(91, 36);
            this.ChiSquareCancel.TabIndex = 3;
            this.ChiSquareCancel.Text = "Cancel";
            this.ChiSquareCancel.UseVisualStyleBackColor = true;
            
            // 
            // uiButton_Range
            // 
            this.uiButton_Range.Image = global::NoruST.Properties.Resources.range_image;
            this.uiButton_Range.Location = new System.Drawing.Point(653, 22);
            this.uiButton_Range.Margin = new System.Windows.Forms.Padding(4);
            this.uiButton_Range.Name = "uiButton_Range";
            this.uiButton_Range.Size = new System.Drawing.Size(32, 28);
            this.uiButton_Range.TabIndex = 9;
            this.uiButton_Range.UseVisualStyleBackColor = true;
            // 
            // uiTextBox_DataSetRange
            // 
            this.uiTextBox_DataSetRange.Location = new System.Drawing.Point(293, 25);
            this.uiTextBox_DataSetRange.Name = "uiTextBox_DataSetRange";
            this.uiTextBox_DataSetRange.Size = new System.Drawing.Size(353, 22);
            this.uiTextBox_DataSetRange.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Contingency Table Range";
            // 
            // ChiKwadraatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 243);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiTextBox_DataSetRange);
            this.Controls.Add(this.uiButton_Range);
            this.Controls.Add(this.ChiSquareCancel);
            this.Controls.Add(this.ChiSquareOk);
            this.Controls.Add(this.groupBox2);
            this.Name = "ChiKwadraatForm";
            this.Text = "Chi-Square Independence Test";
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