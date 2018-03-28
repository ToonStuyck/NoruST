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
    public class UnstackedPresenter
    {
        private UnstackedForm view;
        private UnstackedModel model;
        private DataSetManagerPresenter dataSetPresenter;

        public UnstackedPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new UnstackedModel();
        }

        public UnstackedModel getModel()
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

		public bool checkInput(List<Variable> variablesX, List<Variable> variablesY, DataSet dataSet)
		{

			if (dataSet != null)
			{
				createUnstacked(dataSet);
				return true;
			}
			else
				MessageBox.Show("Please correct all fields to generate Time Series Graph", "Time Series Graph error");
			return false;
		}

		public void createUnstacked(DataSet dataSet)
        {
			//model.dataSet.addUnstacked(model.variable, dataSet);
        }
    }
}
