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
            string range = model.range.Replace("$", null);

            //string range = model.range;
            //string[] splitted = range.Split(':');

            string first = range.Split(':')[0];
            string second = range.Split(':')[1];
            /*if (splitted[0].Length > 4)
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
            }*/

            _Worksheet sheet = WorksheetHelper.NewWorksheet("Chi Square");
            Range from = dataSet.getWorksheet().Range[first, second];
            int rangeWidth = from.Columns.Count;
            int rangeHeight = from.Rows.Count;

            //original Counts

            sheet.Cells[2, 1] = "Original Counts";
            //sheet.get_Range("A2").Cells.HorizontalAlignment = XlHAlign.xlHAlignFill;
            sheet.get_Range("A2", AddressConverter.CellAddress(2, rangeWidth + 2, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

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
            sheet.Cells[2, col] = "Total";

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
            sheet.Cells[roww - 1, 1] = "Total";

            // percentage of Rows 
            sheet.Cells[rangeHeight + 6, 1] = "Percentage of Rows";
            sheet.get_Range("A2", AddressConverter.CellAddress(rangeHeight + 6, rangeWidth + 1, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
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
            sheet.get_Range("A2", AddressConverter.CellAddress(2 * rangeHeight + 9, rangeWidth + 1, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
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
            sheet.get_Range("A2", AddressConverter.CellAddress(3 * rangeHeight + 12, rangeWidth + 1, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
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
            sheet.get_Range("A2", AddressConverter.CellAddress(4 * rangeHeight + 15, rangeWidth + 1, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
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

                    sheet.Cells[rowf, colf] = Math.Round(prodf, 4);
                    colf++;
                }
                rowf++;
            }

            //chi square dings
            sheet.Cells[5 * rangeHeight + 18, 1] = "Chi-Square Statistic";
            sheet.Cells[5 * rangeHeight + 19, 1] = "CHi-Square";
            sheet.get_Range("A2", AddressConverter.CellAddress(5 * rangeHeight + 18, 2, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
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
            sheet.Cells[5 * rangeHeight + 19, 2] = som;



            //autofit
            ((Range)sheet.Cells[1, 1]).EntireColumn.AutoFit();
            //((Range)sheet.Cells[1, 2]).EntireColumn.AutoFit();
            //((Range)sheet.Cells[1, 3]).EntireColumn.AutoFit();
            //((Range)sheet.Cells[1, 4]).EntireColumn.AutoFit();
            //((Range)sheet.Cells[1, 5]).EntireColumn.AutoFit();
            //((Range)sheet.Cells[1, 6]).EntireColumn.AutoFit();
            //((Range)sheet.Cells[1, 7]).EntireColumn.AutoFit();
            //((Range)sheet.Cells[1, 8]).EntireColumn.AutoFit();
            //((Range)sheet.Cells[1, 9]).EntireColumn.AutoFit();
            //((Range)sheet.Cells[1, 10]).EntireColumn.AutoFit();

            // Merge Headers
            sheet.Range[sheet.Cells[1, 2], sheet.Cells[1, rangeWidth + 2]].Merge();
            sheet.Range[sheet.Cells[rangeHeight + 5, 2], sheet.Cells[rangeHeight + 5, rangeWidth + 1]].Merge();
            sheet.Range[sheet.Cells[2 * rangeHeight + 8, 2], sheet.Cells[2 * rangeHeight + 8, rangeWidth + 1]].Merge();
            sheet.Range[sheet.Cells[3 * rangeHeight + 11, 2], sheet.Cells[3 * rangeHeight + 11, rangeWidth + 1]].Merge();
            sheet.Range[sheet.Cells[4 * rangeHeight + 14, 2], sheet.Cells[4 * rangeHeight + 14, rangeWidth + 1]].Merge();

            // Build Headers
            var header = "";
            if (model.hasRowTitle) header += "Rows: {0}";
            if (model.hasRowTitle && model.hasColTitle) header += " / ";
            if (model.hasColTitle) header += "Columns: {1}";

            header = String.Format(header, model.rowTitle, model.colTitle);

            // Fill in Headers
            sheet.Cells[1, 2] = header;
            sheet.Cells[rangeHeight + 5, 2] = header;
            sheet.Cells[2 * rangeHeight + 8, 2] = header;
            sheet.Cells[3 * rangeHeight + 11, 2] = header;
            sheet.Cells[4 * rangeHeight + 14, 2] = header;

            // Center Headers
            sheet.Cells[1, 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet.Cells[rangeHeight + 5, 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet.Cells[2 * rangeHeight + 8, 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet.Cells[3 * rangeHeight + 11, 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet.Cells[4 * rangeHeight + 14, 2].HorizontalAlignment = XlHAlign.xlHAlignCenter;

            // Row and column titles
            if (model.hasRowColHeaders)
            {
                String[] rowTitles = new String[rangeHeight];
                String[] colTitles = new String[rangeWidth];

                for (int i = 0; i < rangeHeight; i++)
                {
                    rowTitles[i] = dataSet.getWorksheet().Range[first].Offset[i, -1].Value;
                }

                for (int i = 0; i < rangeWidth; i++)
                {
                    colTitles[i] = dataSet.getWorksheet().Range[first].Offset[-1, i].Value;
                }

                for (int i = 0; i < rangeHeight; i++)
                {
                    sheet.Cells[3 + i, 1] = rowTitles[i];
                    sheet.Cells[7 + rangeHeight + i, 1] = rowTitles[i];
                    sheet.Cells[10 + 2 * rangeHeight + i, 1] = rowTitles[i];
                    sheet.Cells[13 + 3 * rangeHeight + i, 1] = rowTitles[i];
                    sheet.Cells[16 + 4 * rangeHeight + i, 1] = rowTitles[i];

                }

                for (int i = 0; i < rangeWidth; i++)
                {
                    sheet.Cells[2, 2 + i] = colTitles[i];
                    sheet.Cells[6 + rangeHeight, 2 + i] = colTitles[i];
                    sheet.Cells[9 + 2 * rangeHeight, 2 + i] = colTitles[i];
                    sheet.Cells[12 + 3 * rangeHeight, 2 + i] = colTitles[i];
                    sheet.Cells[15 + 4 * rangeHeight, 2 + i] = colTitles[i];
                }
            }
        }
    }
}

