using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoruST.Forms;
using NoruST.Models;
using NoruST.Presenters;
using NoruST.Domain;
using DataSet = NoruST.Domain.DataSet;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;


namespace NoruST.Presenters
{
	public class RegressionPresenter
	{
		private RegressionForm view;
		private RegressionModel model;
		private DataSetManagerPresenter dataSetPresenter;

		public RegressionPresenter(DataSetManagerPresenter dataSetPresenter)
		{
			this.dataSetPresenter = dataSetPresenter;
			model = new RegressionModel();
		}

		public void openView()
		{
			view = view.createAndOrShowForm();
			view.setPresenter(this);
		}

		public BindingList<DataSet> dataSets()
		{
			return dataSetPresenter.getModel().getDataSets();
		}
	}
}
