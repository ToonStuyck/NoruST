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
            int rangeWidth = from.Columns.Count;
            int rangeHeight = from.Rows.Count;

            sheet.Cells[2, 1] = "Original Counts";

            Range to = sheet.Range[sheet.Cells[3, 2], sheet.Cells[3, 2].offset(rangeHeight, rangeWidth)];
            from.Copy(to);

            int col = 2;
            while (col < rangeWidth + 2)
            {
                int row = 3;
                double sum = 0;
                while (row < rangeHeight + 3)
                {
                    sum += Convert.ToDouble((sheet.Cells[row, col] as Range).Value);
                    row++;
                }
                sheet.Cells[3 + rangeHeight, col] = sum;
                col++;
            }

            int roww = 3;
            while (roww < rangeHeight + 4)
            {
                int coll = 2;
                double summ = 0;
                while (coll < rangeWidth + 2)
                {
                    summ += Convert.ToDouble((sheet.Cells[roww, coll] as Range).Value);
                    coll++;
                }
                sheet.Cells[roww, 2 + rangeWidth] = summ;
                roww++;
            }

            // percentage of Rows 
            sheet.Cells[rangeHeight + 6, 1] = "Percentage of Rows";
            int rowb = rangeHeight + 7;
            while (rowb < rangeHeight + rangeHeight + 7)
            {
                int cola = 2;
                while (cola < rangeWidth + 2)
                {
                    double proda = 0;
                    proda = Convert.ToDouble((sheet.Cells[rowb - rangeHeight - 4, cola] as Range).Value) / Convert.ToDouble((sheet.Cells[rowb - rangeHeight - 4, rangeWidth + 2] as Range).Value);
                    sheet.Cells[rowb, cola] = Math.Round(proda * 100, 2);
                    //sheet.Range[rowb, cola].NumberFormat = "0.00%";

                    cola++;
                }
                rowb++;
            }

            //Percentage of Colums
            sheet.Cells[rangeHeight + rangeHeight + 9, 1] = "Percentage of Colums";
            int rowd = rangeHeight + rangeHeight + 10;
            while (rowd < rangeHeight + rangeHeight + rangeHeight + 10)
            {
                int colc = 2;
                while (colc < rangeWidth + 2)
                {
                    double prodc = 0;
                    prodc = Convert.ToDouble((sheet.Cells[rowd - rangeHeight - rangeHeight - 7, colc] as Range).Value) / Convert.ToDouble((sheet.Cells[3 + rangeHeight, colc] as Range).Value);
                    sheet.Cells[rowd, colc] = Math.Round(prodc * 100, 2);
                    //sheet.Range[rowd, colc].NumberFormat = "0.00%";

                    colc++;
                }
                rowd++;
            }

            // Expected Counts
            sheet.Cells[3 * (rangeHeight) + 12, 1] = "Expected Counts";
            int rowe = 3 * rangeHeight + 13;
            while (rowe < 4 * (rangeHeight) + 13)
            {
                int cole = 2;
                while (cole < rangeWidth + 2)
                {
                    double prode = 0;
                    prode = Convert.ToDouble((sheet.Cells[rangeHeight + 3, cole] as Range).Value)
                                * Convert.ToDouble((sheet.Cells[rowe - 3 * (rangeHeight) - 10, rangeWidth + 2] as Range).Value)
                                / Convert.ToDouble((sheet.Cells[rangeHeight + 3, rangeWidth + 2] as Range).Value);
                    sheet.Cells[rowe, cole] = prode;
                    cole++;
                }
                rowe++;
            }

            //distance ftom expected
            sheet.Cells[4 * rangeHeight + 15, 1] = "Distance from Expected";
            int rowf = 4 * rangeHeight + 16;
            while (rowf < 5 * rangeHeight + 16)
            {
                int colf = 2;
                while (colf < rangeWidth + 2)
                {
                    double prodf = 0;
                    double tussenprod = Convert.ToDouble((sheet.Cells[rowf - 4 * rangeHeight - 13, colf] as Range).Value)
                        - Convert.ToDouble((sheet.Cells[rowf - rangeHeight - 3, colf] as Range).Value);
                    prodf = Math.Pow(tussenprod, 2)
                        / Convert.ToDouble((sheet.Cells[rowf - rangeHeight - 3, colf] as Range).Value);

                    sheet.Cells[rowf, colf] = Math.Round(prodf,4);
                    colf++;
                }
                rowf++;
            }

            //chi square dings
            sheet.Cells[5 * rangeHeight + 18, 1] = "Chi-Square Statistic";
            int rowg = 4 * rangeHeight + 16;
            double som = 0;
            while (rowg < 5 * rangeHeight + 16)
            {
                int colg = 2;
                while (colg < rangeWidth + 2)
                {
                    som += Convert.ToDouble((sheet.Cells[rowg, colg] as Range).Value);
                    
                    colg++;
                }
                rowg++;
            }
            sheet.Cells[5 * rangeHeight + 18, 2] = som;
        }
    }
}

