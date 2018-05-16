using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using NoruST.Domain;

namespace NoruST.Models
{
	public class RegressionModel
	{
        public Domain.DataSet dataSet { get; set; }
        public bool doPrediction { get; set; }
        public double confidenceLevel { get; set; }
        public double predictionLevel { get; set; }

    }
}
