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
			this.components = new System.ComponentModel.Container();
			this.ui_Button_Cancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.ui_ComboBox_SelectDataSets = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ui_ComboBox_cat = new System.Windows.Forms.ComboBox();
			this.ui_ComboBox_var = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.variableBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ui_Button_Cancel
			// 
			this.ui_Button_Cancel.Location = new System.Drawing.Point(331, 100);
			this.ui_Button_Cancel.Name = "ui_Button_Cancel";
			this.ui_Button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.ui_Button_Cancel.TabIndex = 3;
			this.ui_Button_Cancel.Text = "Cancel";
			this.ui_Button_Cancel.UseVisualStyleBackColor = true;
			this.ui_Button_Cancel.Click += new System.EventHandler(this.Cancelbutton_clicked);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(250, 100);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.uiButton_Ok_Click);
			// 
			// ui_ComboBox_SelectDataSets
			// 
			this.ui_ComboBox_SelectDataSets.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ui_ComboBox_SelectDataSets.FormattingEnabled = true;
			this.ui_ComboBox_SelectDataSets.Location = new System.Drawing.Point(98, 14);
			this.ui_ComboBox_SelectDataSets.Name = "ui_ComboBox_SelectDataSets";
			this.ui_ComboBox_SelectDataSets.Size = new System.Drawing.Size(309, 21);
			this.ui_ComboBox_SelectDataSets.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Select Dataset";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Select Category";
			// 
			// ui_ComboBox_cat
			// 
			this.ui_ComboBox_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ui_ComboBox_cat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ui_ComboBox_cat.FormattingEnabled = true;
			this.ui_ComboBox_cat.Location = new System.Drawing.Point(98, 41);
			this.ui_ComboBox_cat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.ui_ComboBox_cat.Name = "ui_ComboBox_cat";
			this.ui_ComboBox_cat.Size = new System.Drawing.Size(308, 21);
			this.ui_ComboBox_cat.TabIndex = 30;
			// 
			// ui_ComboBox_var
			// 
			this.ui_ComboBox_var.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ui_ComboBox_var.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ui_ComboBox_var.FormattingEnabled = true;
			this.ui_ComboBox_var.Location = new System.Drawing.Point(98, 67);
			this.ui_ComboBox_var.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.ui_ComboBox_var.Name = "ui_ComboBox_var";
			this.ui_ComboBox_var.Size = new System.Drawing.Size(308, 21);
			this.ui_ComboBox_var.TabIndex = 32;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 31;
			this.label3.Text = "Select Variable";
			// 
			// variableBindingSource
			// 
			this.variableBindingSource.DataSource = typeof(NoruST.Domain.Variable);
			// 
			// UnstackedForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(422, 133);
			this.Controls.Add(this.ui_ComboBox_var);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ui_ComboBox_cat);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ui_ComboBox_SelectDataSets);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.ui_Button_Cancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UnstackedForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "StatEx - Unstack";
			((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button ui_Button_Cancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.BindingSource variableBindingSource;
		private System.Windows.Forms.ComboBox ui_ComboBox_SelectDataSets;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ui_ComboBox_cat;
        private System.Windows.Forms.ComboBox ui_ComboBox_var;
        private System.Windows.Forms.Label label3;
    }
}