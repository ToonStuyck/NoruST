using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoruST.Forms;
using NoruST.Models;
using NoruST.Domain;
using Microsoft.Office.Interop.Excel;
using static NoruST.Domain.RangeLayout;
using DataSet = NoruST.Domain.DataSet;

namespace NoruST.Presenters
{
    public class DataSetManagerPresenter
    {
        private DataSetManagerForm view;
        private DataSetManagerModel model;

        public DataSetManagerPresenter()
        {
            model = new DataSetManagerModel();
        }

        public DataSetManagerModel getModel()
        {
            return model;
        }

        public void openDataSetManager()
        {
            view = view.createAndOrShowForm();
            view.setPresenter(this);
            addDataSetOfCurrentSelection();
        }

        private void addDataSetOfCurrentSelection()
        {
            _Worksheet workSheet = Globals.ExcelAddIn.getActiveWorksheet();
            Range range = Globals.ExcelAddIn.getCurrentSelectionRange();
            if (model.hasIntersectionWith(range))
                if (DataSetManagerForm.ignoreIntersection(model.getFirstIntersectingDataSetWith(range)))
                    return;

            if (range.Rows.Count == 1 && range.Columns.Count == 1)
            {
                range = Globals.ExcelAddIn.getExpandedCurrentRange();
                range.Select();
            }

            bool addNewDataSet = (range.Rows.Count != 1 || range.Columns.Count != 1) && DataSetManagerForm.addNewDataSet(range);
            if (!addNewDataSet) return;
            DataSet newDataSet = DataSetFactory.create(workSheet, range, "Data Set " + (model.numberOfDataSets() + 1), COLUMNS, true);
            model.addDataSet(newDataSet);
            view.selectDataSet(newDataSet);
        }

        public void rangeSelected(string range)
        {
            view.rangeSelected(range);
        }

        public void setRangeLayoutFor(DataSet dataSet, RangeLayout rangeLayout)
        {
            if (dataSet == null) return;
            DataSet newDataSet = DataSetFactory.create(dataSet.getWorksheet(), dataSet.getRange(), dataSet.getName(), rangeLayout,
                dataSet.getVariableNamesInFirstRowOrColumn());
            model.swapDataSets(dataSet, newDataSet);
        }

        public void setVariableNamesInFirstRowOrColumn(DataSet dataSet, bool variableNamesInFirstRowOrColumn)
        {
            if (dataSet == null) return;
            DataSet newDataSet = DataSetFactory.create(dataSet.getWorksheet(), dataSet.getRange(), dataSet.getName(), dataSet.getRangeLayout(),
                variableNamesInFirstRowOrColumn);
            model.swapDataSets(dataSet, newDataSet);
        }

        public void deleteDataSet(DataSet dataSet)
        {
            model.removeDataSet(dataSet);
        }

        public void addNewDataSet()
        {
            DataSet newDataSet = DataSetFactory.create(Globals.ExcelAddIn.getActiveWorksheet(), null, "Data Set " + (model.numberOfDataSets() + 1), COLUMNS, true);
            model.addDataSet(newDataSet);
            view.selectDataSet(newDataSet);
        }
    }
}