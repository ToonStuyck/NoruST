using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using NoruST.Domain;

namespace NoruST.Models
{
    public class DataSetManagerModel
    {
        private BindingList<Domain.DataSet> dataSets;

        public DataSetManagerModel()
        {
            this.dataSets = new BindingList<Domain.DataSet>();
        }

        public void addDataSet(Domain.DataSet dataSet)
        {
            dataSets.Add(dataSet);
        }

        public void removeDataSet(Domain.DataSet dataSet)
        {
            dataSets.Remove(dataSet);
        }

        public bool hasIntersectionWith(Range range)
        {
            return getFirstIntersectingDataSetWith(range) != null;
        }

        public Domain.DataSet getFirstIntersectingDataSetWith(Range range)
        {
            foreach (Domain.DataSet dataSet in dataSets)
                if (Globals.ExcelAddIn.getActiveWorksheet() == dataSet.getWorksheet() &&
                    Globals.ExcelAddIn.doRangesIntersect(range, dataSet.getRange()))
                    return dataSet;
            return null;
        }

        public int numberOfDataSets()
        {
            return dataSets.Count;
        }

        public BindingList<Domain.DataSet> getDataSets()
        {
            return dataSets;
        }

        public void swapDataSets(Domain.DataSet oldDataSet, Domain.DataSet newDataSet)
        {
            int index = dataSets.IndexOf(oldDataSet);
            if (index != -1)
                dataSets[index] = newDataSet;
        }
    }
}