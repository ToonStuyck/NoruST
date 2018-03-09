using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NoruST.Models
{
    public class OneVariableSummaryModel
    {
        public bool mean { get; set; }
        public bool variance { get; set; }
        public bool standardDeviation { get; set; }
        public bool skewness { get; set; }
        public bool kurtosis { get; set; }
        public bool median { get; set; }
        public bool meanAbsDeviation { get; set; }
        public bool mode { get; set; }
        public bool minimum { get; set; }
        public bool maximum { get; set; }
        public bool range { get; set; }
        public bool count { get; set; }
        public bool sum { get; set; }
        public bool firstQuartile { get; set; }
        public bool thirdQuartile { get; set; }
        public bool interquartileRange { get; set; }
    }
}
