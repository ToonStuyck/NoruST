using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NoruST.Models
{
    public class ChiKwadraatModel
    {
        public Domain.DataSet dataSet { get; set; }
        public string range { get; set; }
        public string rowTitle { get; set; }
        public string colTitle { get; set; }
        public bool hasRowTitle { get; set; }
        public bool hasColTitle { get; set; }
        public bool hasRowColHeaders { get; set; }
    }
}