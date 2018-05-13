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
        private ChiKwadraatModel model;

        public ChiKwadraatPresenter(DataSetManagerPresenter dataSetPresenter)
        {
            this.dataSetPresenter = dataSetPresenter;
            model = new ChiKwadraatModel();
        }

        public ChiKwadraatModel getModel()
        {
            return model;
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

        public void createChiKwadraatPlot(DataSet dataSet)
        {
            string range = model.range;
            string[] splitted = range.Split(':');

            string first;
            string second;
            if (splitted[0].Length > 4)
            {
                int i = splitted[0].Length;
                first = splitted[0][1] + Convert.ToString(splitted[0][3]);
                int j = 4;
                while (j < i)
                {
                    first = first + Convert.ToString(splitted[0][j]);
                    j++;
                }
            }
            else
            {
                first = splitted[0][1] + Convert.ToString(splitted[0][3]);
            }
            if (splitted[1].Length > 4)
            {
                int i = splitted[1].Length;
                second = splitted[1][1] + Convert.ToString(splitted[1][3]);
                int j = 4;
                while (j < i)
                {
                    second = second + Convert.ToString(splitted[1][j]);
                    j++;
                }
            }
            else
            {
                second = splitted[1][1] + Convert.ToString(splitted[1][3]);
            }
            
            _Worksheet sheet = WorksheetHelper.NewWorksheet("Chi Square");
            Range from = dataSet.getWorksheet().Range[first, second];
            Range to = sheet.Range[first, second];
            from.Copy(to);

            //sheet.Cells[100, 100] = "=ROWS(" + dataSet.getWorksheet().Name + "!" + range + ")";
            //int length = Convert.ToInt32((sheet.Cells[100, 100] as Range).Value);
            //sheet.Cells[100, 100] = "";

            
            //sheet.Cells[1, 1] = "Original Counts";
            
            
            }
        }
    }

