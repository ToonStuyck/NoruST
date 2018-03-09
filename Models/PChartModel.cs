using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using NoruST.Domain;

namespace NoruST.Models
{
    class PChartModel
    {
        public BindingList<float> averages = new BindingList<float>();
        public BindingList<Variable> variables = new BindingList<Variable>();
        public Domain.DataSet dataSet { get; set; }
        private int size;
    }
}
