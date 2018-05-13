using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoruST.Forms;
using NoruST.Models;
using NoruST.Presenters;
using NoruST.Domain;
using DataSet = NoruST.Domain.DataSet;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using MathNet.Numerics.LinearRegression;
using MathNet;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NoruST.Presenters
{
    public class ChiKwadraatPresenter : IRangeSelectionPresenter

    {
        private ChiKwadraatForm view;
        private DataSetManagerPresenter dataSetPresenter;

        public ChiKwadraatPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
        }

        public void openView()
        {
            view = view.createAndOrShowForm();
            view.setPresenter(this);
        }

        public BindingList<DataSet> dataSets()
        {
            return dataSetPresenter.getModel().getDataSets();
        }

        public void rangeSelected(string range)
        {
            view.selectRange(range);
        }

        public void createChiKwadraatPlot(DataSet dataSet, String range)
        {
            _Worksheet sheet = WorksheetHelper.NewWorksheet("Chi Square");
            sheet.Cells[100, 100] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + range + ")";
            int length = Convert.ToInt32((sheet.Cells[100, 100] as Range).Value);
            sheet.Cells[100, 100] = "";

            
            sheet.Cells[1, 1] = "Original Counts";
            
            
            }
        }
    }

