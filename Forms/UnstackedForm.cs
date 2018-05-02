using System;
using System.Windows.Forms;
using NoruST.Domain;
using NoruST.Presenters;
using System.Collections.Generic;
using System.ComponentModel;

namespace NoruST.Forms
{
    public partial class UnstackedForm : Form
    {
        private UnstackedPresenter presenter;

        public UnstackedForm()
        {
            InitializeComponent();
        }

        public void SetPresenter(UnstackedPresenter unstackedPresenter)
        {
            this.presenter = unstackedPresenter;
            bindModelToView();
            selectDataSet(selectedDataSet());
        }

        private void bindModelToView()
        {
            ui_ComboBox_SelectDataSets.DataSource = presenter.dataSets();
            ui_ComboBox_SelectDataSets.DisplayMember = "name";
            ui_ComboBox_SelectDataSets.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedDataSet() == null) return;
               

                ui_ComboBox_cat.DataSource = selectedDataSet().getVariables();
                ui_ComboBox_cat.DisplayMember = "name";

                var variableList = new BindingList<Variable>();
                
                foreach (Variable v in selectedDataSet().getVariables()) 
                {
                    variableList.Add(v);
                } 
               
                ui_ComboBox_var.DataSource = variableList;
                ui_ComboBox_var.DisplayMember = "name";

                presenter.getModel().dataSet = selectedDataSet();
            };

            ui_ComboBox_var.SelectedIndexChanged += (obj, eventArgs) =>
            {
                presenter.getModel().variable = selectedVariable();
            };

            ui_ComboBox_cat.SelectedIndexChanged += (obj, eventArgs) =>
            {
                if (selectedCategory() == null) return;
                presenter.getModel().category = selectedCategory();
            };
        }

        private DataSet selectedDataSet()
        {
            return (DataSet)ui_ComboBox_SelectDataSets.SelectedItem;
        }

        private Variable selectedCategory()
        {
            return (Variable)ui_ComboBox_cat.SelectedItem;
        }

        private Variable selectedVariable()
        {
            return (Variable)ui_ComboBox_var.SelectedItem;
        }

        public void selectDataSet(DataSet dataSet)
        {
            ui_ComboBox_SelectDataSets.SelectedItem = null;
            ui_ComboBox_SelectDataSets.SelectedItem = dataSet;
        }

        private void Cancelbutton_clicked(object sender, EventArgs e)
        {
            Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiButton_Ok_Click(object sender, EventArgs e)
        {
            Variable variableX = selectedCategory();
            Variable variableY = selectedVariable();

            bool inputOk = presenter.checkInput(selectedDataSet());
            if (inputOk)
            {
                Close();
            }
        }

    }
}

