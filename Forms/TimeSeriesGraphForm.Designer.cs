namespace NoruST.Forms
{
    partial class TimeSeriesGraphForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSeriesGraphForm));
            this.ui_Button_Cancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.variableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ui_ComboBox_SelectDataSets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiDataGridView_Variables = new System.Windows.Forms.DataGridView();
            this.uiDataGridViewColumn_VariableCheckX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uiDataGridViewColumn_VariableCheckY = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_Button_Cancel
            // 
            this.ui_Button_Cancel.Location = new System.Drawing.Point(331, 238);
            this.ui_Button_Cancel.Name = "ui_Button_Cancel";
            this.ui_Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.ui_Button_Cancel.TabIndex = 3;
            this.ui_Button_Cancel.Text = "Cancel";
            this.ui_Button_Cancel.UseVisualStyleBackColor = true;
            this.ui_Button_Cancel.Click += new System.EventHandler(this.Cancelbutton_clicked);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(250, 238);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.uiButton_Ok_Click);
            // 
            // variableBindingSource
            // 
            this.variableBindingSource.DataSource = typeof(NoruST.Domain.Variable);
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
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Select Dataset";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Select Data";
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
            this.uiDataGridViewColumn_VariableCheckX,
            this.uiDataGridViewColumn_VariableCheckY});
            this.uiDataGridView_Variables.Location = new System.Drawing.Point(98, 41);
            this.uiDataGridView_Variables.Name = "uiDataGridView_Variables";
            this.uiDataGridView_Variables.RowHeadersVisible = false;
            this.uiDataGridView_Variables.Size = new System.Drawing.Size(308, 185);
            this.uiDataGridView_Variables.TabIndex = 29;
            // 
            // uiDataGridViewColumn_VariableCheckX
            // 
            this.uiDataGridViewColumn_VariableCheckX.HeaderText = "X";
            this.uiDataGridViewColumn_VariableCheckX.Name = "uiDataGridViewColumn_VariableCheckX";
            this.uiDataGridViewColumn_VariableCheckX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // uiDataGridViewColumn_VariableCheckY
            // 
            this.uiDataGridViewColumn_VariableCheckY.HeaderText = "Y";
            this.uiDataGridViewColumn_VariableCheckY.Name = "uiDataGridViewColumn_VariableCheckY";
            this.uiDataGridViewColumn_VariableCheckY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridViewColumn_VariableCheckY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TimeSeriesGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(422, 274);
            this.Controls.Add(this.uiDataGridView_Variables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ui_ComboBox_SelectDataSets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ui_Button_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeSeriesGraphForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Series Graph";
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).EndInit();
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
        private System.Windows.Forms.DataGridView uiDataGridView_Variables;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheckX;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheckY;
    }
}