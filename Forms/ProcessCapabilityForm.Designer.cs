namespace NoruST.Forms
{
    partial class ProcessCapabilityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessCapabilityForm));
            this.ui_Button_Cancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLowerLimit = new System.Windows.Forms.Label();
            this.lblUpperLimit = new System.Windows.Forms.Label();
            this.uiTextBox_LowerLimit = new System.Windows.Forms.TextBox();
            this.uiTextBox_UpperLimit = new System.Windows.Forms.TextBox();
            this.ui_ComboBox_SelectDataSets = new System.Windows.Forms.ComboBox();
            this.variableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_Button_Cancel
            // 
            this.ui_Button_Cancel.Location = new System.Drawing.Point(353, 145);
            this.ui_Button_Cancel.Name = "ui_Button_Cancel";
            this.ui_Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.ui_Button_Cancel.TabIndex = 3;
            this.ui_Button_Cancel.Text = "Cancel";
            this.ui_Button_Cancel.UseVisualStyleBackColor = true;
            this.ui_Button_Cancel.Click += new System.EventHandler(this.Cancelbutton_clicked);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(272, 145);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.uiButton_Ok_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLowerLimit);
            this.groupBox2.Controls.Add(this.lblUpperLimit);
            this.groupBox2.Controls.Add(this.uiTextBox_LowerLimit);
            this.groupBox2.Controls.Add(this.uiTextBox_UpperLimit);
            this.groupBox2.Location = new System.Drawing.Point(13, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 62);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Specification Limits";
            // 
            // lblLowerLimit
            // 
            this.lblLowerLimit.AutoSize = true;
            this.lblLowerLimit.Location = new System.Drawing.Point(13, 27);
            this.lblLowerLimit.Name = "lblLowerLimit";
            this.lblLowerLimit.Size = new System.Drawing.Size(60, 13);
            this.lblLowerLimit.TabIndex = 3;
            this.lblLowerLimit.Text = "Lower Limit";
            // 
            // lblUpperLimit
            // 
            this.lblUpperLimit.AutoSize = true;
            this.lblUpperLimit.Location = new System.Drawing.Point(224, 30);
            this.lblUpperLimit.Name = "lblUpperLimit";
            this.lblUpperLimit.Size = new System.Drawing.Size(60, 13);
            this.lblUpperLimit.TabIndex = 5;
            this.lblUpperLimit.Text = "Upper Limit";
            // 
            // uiTextBox_LowerLimit
            // 
            this.uiTextBox_LowerLimit.Location = new System.Drawing.Point(98, 24);
            this.uiTextBox_LowerLimit.MaxLength = 8;
            this.uiTextBox_LowerLimit.Name = "uiTextBox_LowerLimit";
            this.uiTextBox_LowerLimit.Size = new System.Drawing.Size(91, 20);
            this.uiTextBox_LowerLimit.TabIndex = 4;
            this.uiTextBox_LowerLimit.Text = "0";
            // 
            // uiTextBox_UpperLimit
            // 
            this.uiTextBox_UpperLimit.Location = new System.Drawing.Point(288, 27);
            this.uiTextBox_UpperLimit.MaxLength = 8;
            this.uiTextBox_UpperLimit.Name = "uiTextBox_UpperLimit";
            this.uiTextBox_UpperLimit.Size = new System.Drawing.Size(91, 20);
            this.uiTextBox_UpperLimit.TabIndex = 6;
            this.uiTextBox_UpperLimit.Text = "0";
            // 
            // ui_ComboBox_SelectDataSets
            // 
            this.ui_ComboBox_SelectDataSets.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ui_ComboBox_SelectDataSets.FormattingEnabled = true;
            this.ui_ComboBox_SelectDataSets.Location = new System.Drawing.Point(116, 23);
            this.ui_ComboBox_SelectDataSets.Name = "ui_ComboBox_SelectDataSets";
            this.ui_ComboBox_SelectDataSets.Size = new System.Drawing.Size(300, 21);
            this.ui_ComboBox_SelectDataSets.TabIndex = 7;
            // 
            // variableBindingSource
            // 
            this.variableBindingSource.DataSource = typeof(NoruST.Domain.Variable);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Dataset";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ui_ComboBox_SelectDataSets);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 59);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dataset";
            // 
            // ProcessCapabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 180);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ui_Button_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessCapabilityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Capability";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ui_Button_Cancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblUpperLimit;
        private System.Windows.Forms.TextBox uiTextBox_LowerLimit;
        private System.Windows.Forms.TextBox uiTextBox_UpperLimit;
        private System.Windows.Forms.Label lblLowerLimit;
        private System.Windows.Forms.ComboBox ui_ComboBox_SelectDataSets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource variableBindingSource;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}