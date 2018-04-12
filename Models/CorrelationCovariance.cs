using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

// ReSharper disable LoopCanBeConvertedToQuery

namespace NoruST.Models
{
    public class CorrelationCovariance
    {
        public List<string> Correlations { get; set; }
        public bool HasCorrelations { get; set; }
        public List<string> Covariances { get; set; }
        public bool HasCovariances { get; set; }
        public int Dimension { get; set; }
    }
}