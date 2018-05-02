using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoruST.Forms;
using NoruST.Models;
using NoruST.Domain;
using DataSet = NoruST.Domain.DataSet;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace NoruST.Presenters
{
    public class InteractionPresenter
    {
        private InteractionForm view;
        private InteractionModel model;
        private DataSetManagerPresenter dataSetPresenter;

        public InteractionPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new InteractionModel();
        }

        public InteractionModel getModel()
        {
            return model;
        }

        public void openView()
        {
            view = view.createAndOrShowForm();
            view.SetPresenter(this);
        }

        public BindingList<DataSet> dataSets()
        {
            return dataSetPresenter.getModel().getDataSets();
        }

        public bool checkInput(DataSet dataSet)
        {

            if (dataSet != null)
            {
                createUnstacked(dataSet);
                return true;
            }
            else
                MessageBox.Show("Please correct all fields to generate interaction", "Interaction error");
            return false;
        }

        public void createUnstacked(DataSet dataSet)
        {
            model.dataSet.Interaction(model.variable, model.variable2, dataSet);
        }
    }
}
