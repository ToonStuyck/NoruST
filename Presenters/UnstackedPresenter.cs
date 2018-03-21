using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoruST.Forms;
using NoruST.Models;
using DataSet = NoruST.Domain.DataSet;

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

        public UnstackedModel GetModel()
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

        public void createDummy(DataSet dataSet)
        {
            model.dataSet.addunstacked(model.variable, dataSet);
        }
    }
}
