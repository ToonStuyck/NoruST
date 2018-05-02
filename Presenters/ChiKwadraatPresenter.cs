using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using NoruST.Domain;
using NoruST.Forms;

namespace NoruST.Presenters
{
    public class ChiKwadraatPresenter

    {
        private ChiKwadraatForm view;
        private DataSetManagerPresenter dataSetPresenter;

        public ChiKwadraatPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
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

        public void createChiKwadraatPlot(List<Variable> variables)
        {


        }
    }
}
