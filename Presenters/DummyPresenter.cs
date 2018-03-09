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
    public class DummyPresenter
    {
        private DummyForm view;
        private DummyModel model;
        private DataSetManagerPresenter dataSetPresenter;

        public DummyPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            this.model = new DummyModel();
        }

        public DummyModel getModel()
        {
            return model;
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

        public void createDummy()
        {
            model.dataSet.addDummy(model.variable, model.condition, model.conditionValue);
        }
    }
}
