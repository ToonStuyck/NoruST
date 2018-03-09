using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoruST.Models
{
    public class SampleSizeEstimationModel
    {
        public bool mean { get; set; }
        public bool proportion { get; set; }
        public bool diffMean { get; set; }
        public bool diffProportion { get; set; }
        public int confidenceLevel { get; set; }
        public string marginOfError { get; set; }
        public string estimation1 { get; set; }
        public string estimation2 { get; set; }
    }
}
