using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoruST.Models
{
    public class OneWayAnovaModel
    {
        public bool noCorrection { get; set; }
        public bool bonferroni { get; set; }
        public bool scheffe { get; set; }
        public double confidenceLevel { get; set; }
    }
}
