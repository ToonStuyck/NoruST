namespace NoruST.Forms
{
    partial class SelectRangeForm
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.uiTextBox_Range = new System.Windows.Forms.TextBox();
            this.uiButton_Ok = new System.Windows.Forms.Button();
            this.uiButton_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(106, 13);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Selecteer een range:";
            // 
            // uiTextBox_Range
            // 
            this.uiTextBox_Range.Location = new System.Drawing.Point(15, 25);
            this.uiTextBox_Range.Name = "uiTextBox_Range";
            this.uiTextBox_Range.Size = new System.Drawing.Size(257, 20);
            this.uiTextBox_Range.TabIndex = 1;
            // 
            // uiButton_Ok
            // 
            this.uiButton_Ok.Location = new System.Drawing.Point(116, 51);
            this.uiButton_Ok.Name = "uiButton_Ok";
            this.uiButton_Ok.Size = new System.Drawing.Size(75, 23);
            this.uiButton_Ok.TabIndex = 2;
            this.uiButton_Ok.Text = "Ok";
            this.uiButton_Ok.UseVisualStyleBackColor = true;
            this.uiButton_Ok.Click += new System.EventHandler(this.uiButton_Ok_Click);
            // 
            // uiButton_Cancel
            // 
            this.uiButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButton_Cancel.Location = new System.Drawing.Point(197, 51);
            this.uiButton_Cancel.Name = "uiButton_Cancel";
            this.uiButton_Cancel.Size = new System.Drawing.Size(75, 23);
            this.uiButton_Cancel.TabIndex = 3;
            this.uiButton_Cancel.Text = "Annuleren";
            this.uiButton_Cancel.UseVisualStyleBackColor = true;
            this.uiButton_Cancel.Click += new System.EventHandler(this.uiButton_Cancel_Click);
            // 
            // SelectRangeForm
            // 
            this.AcceptButton = this.uiButton_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uiButton_Cancel;
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this.uiButton_Cancel);
            this.Controls.Add(this.uiButton_Ok);
            this.Controls.Add(this.uiTextBox_Range);
            this.Controls.Add(this.lblInfo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 120);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 120);
            this.Name = "SelectRangeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NoruST - Data Set Manager";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox uiTextBox_Range;
        private System.Windows.Forms.Button uiButton_Ok;
        private System.Windows.Forms.Button uiButton_Cancel;
    }
}