using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoruST.Domain;

namespace NoruST.Models
{
    public class InteractionModel
    {
        public Domain.DataSet dataSet { get; set; }
        public Variable variable { get; set; }
        public Variable variable2 { get; set; }
    }
}
