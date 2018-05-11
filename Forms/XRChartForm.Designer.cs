namespace NoruST.Forms
{
    partial class XRChartForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRChartForm));
			this.ui_Button_Cancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblStopIndex = new System.Windows.Forms.Label();
			this.lblStartIndex = new System.Windows.Forms.Label();
			this.uiTextBox_StopIndex = new System.Windows.Forms.TextBox();
			this.uiTextBox_StartIndex = new System.Windows.Forms.TextBox();
			this.rdbObservationsInRange = new System.Windows.Forms.RadioButton();
			this.rdbAllObservations = new System.Windows.Forms.RadioButton();
			this.ui_ComboBox_SelectDataSets = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.uiDataGridView_Variables = new System.Windows.Forms.DataGridView();
			this.uiDataGridViewColumn_VariableCheckX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblPlotStopIndex = new System.Windows.Forms.Label();
			this.lblPlotStartIndex = new System.Windows.Forms.Label();
			this.uiTextbox_PlotStopIndex = new System.Windows.Forms.TextBox();
			this.uiTextbox_PlotStartIndex = new System.Windows.Forms.TextBox();
			this.rdbPlotOnlyObservationsWithin = new System.Windows.Forms.RadioButton();
			this.rdbPlotAllObservations = new System.Windows.Forms.RadioButton();
			this.variableBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ui_Button_Cancel
			// 
			this.ui_Button_Cancel.Location = new System.Drawing.Point(291, 437);
			this.ui_Button_Cancel.Name = "ui_Button_Cancel";
			this.ui_Button_Cancel.Size = new System.Drawing.Size(75, 21);
			this.ui_Button_Cancel.TabIndex = 3;
			this.ui_Button_Cancel.Text = "Cancel";
			this.ui_Button_Cancel.UseVisualStyleBackColor = true;
			this.ui_Button_Cancel.Click += new System.EventHandler(this.Cancelbutton_clicked);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(209, 437);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 21);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.uiButton_Ok_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblStopIndex);
			this.groupBox2.Controls.Add(this.lblStartIndex);
			this.groupBox2.Controls.Add(this.uiTextBox_StopIndex);
			this.groupBox2.Controls.Add(this.uiTextBox_StartIndex);
			this.groupBox2.Controls.Add(this.rdbObservationsInRange);
			this.groupBox2.Controls.Add(this.rdbAllObservations);
			this.groupBox2.Location = new System.Drawing.Point(12, 359);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(373, 72);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Control limits based on";
			// 
			// lblStopIndex
			// 
			this.lblStopIndex.AutoSize = true;
			this.lblStopIndex.Location = new System.Drawing.Point(177, 45);
			this.lblStopIndex.Name = "lblStopIndex";
			this.lblStopIndex.Size = new System.Drawing.Size(58, 13);
			this.lblStopIndex.TabIndex = 6;
			this.lblStopIndex.Text = "Stop Index";
			this.lblStopIndex.Visible = false;
			// 
			// lblStartIndex
			// 
			this.lblStartIndex.AutoSize = true;
			this.lblStartIndex.Location = new System.Drawing.Point(177, 19);
			this.lblStartIndex.Name = "lblStartIndex";
			this.lblStartIndex.Size = new System.Drawing.Size(58, 13);
			this.lblStartIndex.TabIndex = 5;
			this.lblStartIndex.Text = "Start Index";
			this.lblStartIndex.Visible = false;
			// 
			// uiTextBox_StopIndex
			// 
			this.uiTextBox_StopIndex.Location = new System.Drawing.Point(262, 42);
			this.uiTextBox_StopIndex.MaxLength = 5;
			this.uiTextBox_StopIndex.Name = "uiTextBox_StopIndex";
			this.uiTextBox_StopIndex.Size = new System.Drawing.Size(91, 20);
			this.uiTextBox_StopIndex.TabIndex = 4;
			this.uiTextBox_StopIndex.Text = "0";
			this.uiTextBox_StopIndex.Visible = false;
			// 
			// uiTextBox_StartIndex
			// 
			this.uiTextBox_StartIndex.Location = new System.Drawing.Point(262, 16);
			this.uiTextBox_StartIndex.MaxLength = 5;
			this.uiTextBox_StartIndex.Name = "uiTextBox_StartIndex";
			this.uiTextBox_StartIndex.Size = new System.Drawing.Size(91, 20);
			this.uiTextBox_StartIndex.TabIndex = 3;
			this.uiTextBox_StartIndex.Text = "0";
			this.uiTextBox_StartIndex.Visible = false;
			// 
			// rdbObservationsInRange
			// 
			this.rdbObservationsInRange.AutoSize = true;
			this.rdbObservationsInRange.Location = new System.Drawing.Point(17, 43);
			this.rdbObservationsInRange.Name = "rdbObservationsInRange";
			this.rdbObservationsInRange.Size = new System.Drawing.Size(128, 17);
			this.rdbObservationsInRange.TabIndex = 1;
			this.rdbObservationsInRange.Text = "Observations in range";
			this.rdbObservationsInRange.UseVisualStyleBackColor = true;
			this.rdbObservationsInRange.CheckedChanged += new System.EventHandler(this.ObservationsInRange_CheckedChanged);
			// 
			// rdbAllObservations
			// 
			this.rdbAllObservations.AutoSize = true;
			this.rdbAllObservations.Checked = true;
			this.rdbAllObservations.Location = new System.Drawing.Point(17, 19);
			this.rdbAllObservations.Name = "rdbAllObservations";
			this.rdbAllObservations.Size = new System.Drawing.Size(101, 17);
			this.rdbAllObservations.TabIndex = 0;
			this.rdbAllObservations.TabStop = true;
			this.rdbAllObservations.Text = "All Observations";
			this.rdbAllObservations.UseVisualStyleBackColor = true;
			// 
			// ui_ComboBox_SelectDataSets
			// 
			this.ui_ComboBox_SelectDataSets.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ui_ComboBox_SelectDataSets.FormattingEnabled = true;
			this.ui_ComboBox_SelectDataSets.Location = new System.Drawing.Point(97, 23);
			this.ui_ComboBox_SelectDataSets.Name = "ui_ComboBox_SelectDataSets";
			this.ui_ComboBox_SelectDataSets.Size = new System.Drawing.Size(257, 21);
			this.ui_ComboBox_SelectDataSets.TabIndex = 7;
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
			this.groupBox3.Controls.Add(this.uiDataGridView_Variables);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.ui_ComboBox_SelectDataSets);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Location = new System.Drawing.Point(12, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(374, 259);
			this.groupBox3.TabIndex = 10;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Dataset";
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
            this.uiDataGridViewColumn_VariableCheckX});
			this.uiDataGridView_Variables.Location = new System.Drawing.Point(97, 58);
			this.uiDataGridView_Variables.Name = "uiDataGridView_Variables";
			this.uiDataGridView_Variables.RowHeadersVisible = false;
			this.uiDataGridView_Variables.Size = new System.Drawing.Size(257, 161);
			this.uiDataGridView_Variables.TabIndex = 30;
			// 
			// uiDataGridViewColumn_VariableCheckX
			// 
			this.uiDataGridViewColumn_VariableCheckX.HeaderText = "X";
			this.uiDataGridViewColumn_VariableCheckX.Name = "uiDataGridViewColumn_VariableCheckX";
			this.uiDataGridViewColumn_VariableCheckX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Select Data";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblPlotStopIndex);
			this.groupBox1.Controls.Add(this.lblPlotStartIndex);
			this.groupBox1.Controls.Add(this.uiTextbox_PlotStopIndex);
			this.groupBox1.Controls.Add(this.uiTextbox_PlotStartIndex);
			this.groupBox1.Controls.Add(this.rdbPlotOnlyObservationsWithin);
			this.groupBox1.Controls.Add(this.rdbPlotAllObservations);
			this.groupBox1.Location = new System.Drawing.Point(12, 277);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(374, 76);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Observations";
			// 
			// lblPlotStopIndex
			// 
			this.lblPlotStopIndex.AutoSize = true;
			this.lblPlotStopIndex.Location = new System.Drawing.Point(178, 46);
			this.lblPlotStopIndex.Name = "lblPlotStopIndex";
			this.lblPlotStopIndex.Size = new System.Drawing.Size(58, 13);
			this.lblPlotStopIndex.TabIndex = 5;
			this.lblPlotStopIndex.Text = "Stop Index";
			this.lblPlotStopIndex.Visible = false;
			// 
			// lblPlotStartIndex
			// 
			this.lblPlotStartIndex.AutoSize = true;
			this.lblPlotStartIndex.Location = new System.Drawing.Point(178, 18);
			this.lblPlotStartIndex.Name = "lblPlotStartIndex";
			this.lblPlotStartIndex.Size = new System.Drawing.Size(58, 13);
			this.lblPlotStartIndex.TabIndex = 4;
			this.lblPlotStartIndex.Text = "Start Index";
			this.lblPlotStartIndex.Visible = false;
			// 
			// uiTextbox_PlotStopIndex
			// 
			this.uiTextbox_PlotStopIndex.Location = new System.Drawing.Point(263, 42);
			this.uiTextbox_PlotStopIndex.Name = "uiTextbox_PlotStopIndex";
			this.uiTextbox_PlotStopIndex.Size = new System.Drawing.Size(91, 20);
			this.uiTextbox_PlotStopIndex.TabIndex = 3;
			this.uiTextbox_PlotStopIndex.Text = "0";
			this.uiTextbox_PlotStopIndex.Visible = false;
			// 
			// uiTextbox_PlotStartIndex
			// 
			this.uiTextbox_PlotStartIndex.Location = new System.Drawing.Point(263, 13);
			this.uiTextbox_PlotStartIndex.Name = "uiTextbox_PlotStartIndex";
			this.uiTextbox_PlotStartIndex.Size = new System.Drawing.Size(91, 20);
			this.uiTextbox_PlotStartIndex.TabIndex = 2;
			this.uiTextbox_PlotStartIndex.Text = "0";
			this.uiTextbox_PlotStartIndex.Visible = false;
			// 
			// rdbPlotOnlyObservationsWithin
			// 
			this.rdbPlotOnlyObservationsWithin.AutoSize = true;
			this.rdbPlotOnlyObservationsWithin.Location = new System.Drawing.Point(17, 44);
			this.rdbPlotOnlyObservationsWithin.Name = "rdbPlotOnlyObservationsWithin";
			this.rdbPlotOnlyObservationsWithin.Size = new System.Drawing.Size(149, 17);
			this.rdbPlotOnlyObservationsWithin.TabIndex = 1;
			this.rdbPlotOnlyObservationsWithin.Text = "Plot only those within limits";
			this.rdbPlotOnlyObservationsWithin.UseVisualStyleBackColor = true;
			this.rdbPlotOnlyObservationsWithin.CheckedChanged += new System.EventHandler(this.rdbPlotOnlyObservationsWithin_CheckedChanged);
			// 
			// rdbPlotAllObservations
			// 
			this.rdbPlotAllObservations.AutoSize = true;
			this.rdbPlotAllObservations.Checked = true;
			this.rdbPlotAllObservations.Location = new System.Drawing.Point(17, 19);
			this.rdbPlotAllObservations.Name = "rdbPlotAllObservations";
			this.rdbPlotAllObservations.Size = new System.Drawing.Size(119, 17);
			this.rdbPlotAllObservations.TabIndex = 0;
			this.rdbPlotAllObservations.TabStop = true;
			this.rdbPlotAllObservations.Text = "Plot all observations";
			this.rdbPlotAllObservations.UseVisualStyleBackColor = true;
			// 
			// variableBindingSource
			// 
			this.variableBindingSource.DataSource = typeof(NoruST.Domain.Variable);
			// 
			// XRChartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 470);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.ui_Button_Cancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "XRChartForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "StatEx - X/R Chart";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiDataGridView_Variables)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ui_Button_Cancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbAllObservations;
        private System.Windows.Forms.RadioButton rdbObservationsInRange;
        private System.Windows.Forms.Label lblStartIndex;
        private System.Windows.Forms.TextBox uiTextBox_StopIndex;
        private System.Windows.Forms.TextBox uiTextBox_StartIndex;
        private System.Windows.Forms.Label lblStopIndex;
        private System.Windows.Forms.ComboBox ui_ComboBox_SelectDataSets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource variableBindingSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPlotStopIndex;
        private System.Windows.Forms.Label lblPlotStartIndex;
        private System.Windows.Forms.TextBox uiTextbox_PlotStopIndex;
        private System.Windows.Forms.TextBox uiTextbox_PlotStartIndex;
        private System.Windows.Forms.RadioButton rdbPlotOnlyObservationsWithin;
        private System.Windows.Forms.RadioButton rdbPlotAllObservations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView uiDataGridView_Variables;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uiDataGridViewColumn_VariableCheckX;
    }
}