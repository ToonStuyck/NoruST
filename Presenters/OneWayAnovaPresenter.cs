using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using NoruST.Domain;
using NoruST.Forms;
using NoruST.Models;
using DataSet = NoruST.Domain.DataSet;

namespace NoruST.Presenters
{
    public class OneWayAnovaPresenter
    {
        private OneWayAnovaForm view;
        private OneWayAnovaModel model;
        private DataSetManagerPresenter presenter;

        public OneWayAnovaPresenter(DataSetManagerPresenter presenter)
        {
            this.presenter = presenter;
            model = new OneWayAnovaModel();
        }

        public OneWayAnovaModel getModel()
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
            return presenter.getModel().getDataSets();
        }

        public void createOneWayAnova(List<Variable> variables)
        {
            _Worksheet sheet = WorksheetHelper.NewWorksheet("One-Way ANOVA");
            sheet.Cells[1, 1] = "ANOVA Summary";
            sheet.Cells[2, 1] = "Total Sample Size";
            sheet.Cells[3, 1] = "Grand Mean";
            sheet.Cells[4, 1] = "Pooled Std Dev";
            sheet.Cells[5, 1] = "Pooled Variance";
            sheet.Cells[6, 1] = "Number of Samples";
            sheet.Cells[7, 1] = "Confidence Level";
            sheet.Cells[9, 1] = "ANOVA Sample Stats";
            sheet.Cells[10, 1] = "Sample Size";
            sheet.Cells[11, 1] = "Sample Mean";
            sheet.Cells[12, 1] = "Sample Std Dev";
            sheet.Cells[13, 1] = "Sample Variance";
            sheet.Cells[14, 1] = "Pooling Weight";
            sheet.Cells[17, 1] = "One-Way ANOVA Table";
            sheet.Cells[18, 1] = "Between Variation";
            sheet.Cells[19, 1] = "Within Variation";
            sheet.Cells[20, 1] = "Total Variation";
            sheet.Cells[23, 1] = "Confidence Interval Tests";

            sheet.Cells[16, 2] = "Sum of";
            sheet.Cells[17, 2] = "Squares";
            sheet.Cells[16, 3] = "Degrees of";
            sheet.Cells[17, 3] = "Freedom";
            sheet.Cells[16, 4] = "Mean";
            sheet.Cells[17, 4] = "Squares";
            sheet.Cells[17, 5] = "F-Ratio";
            sheet.Cells[17, 6] = "p-Value";
            sheet.Cells[22, 2] = "Difference";
            sheet.Cells[23, 2] = " of Means";

            int col = 1;
            foreach (Variable variable in variables)
            {
                col++;
                var range = variable.getRange().Address(true, true, true);
                sheet.Cells[9, col] = variable.name;
                sheet.WriteFunction(10, col, "COUNT(" + range + ")");
                sheet.WriteFunction(11, col, "AVERAGE(" + range + ")");
                sheet.WriteFunction(12, col, "STDEV.S(" + range + ")");
                sheet.WriteFunction(13, col, "VAR.S(" + range + ")");
            }

            sheet.WriteFunction(2,2,"SUM(" + AddressConverter.CellAddress(10,2,false,false) + ":" + AddressConverter.CellAddress(10,col, false, false) + ")");
            sheet.WriteFunction(3,2,"SUMPRODUCT(" + AddressConverter.CellAddress(10,2,false,false) + ":" + AddressConverter.CellAddress(10,col, false, false) + "," + AddressConverter.CellAddress(11, 2, false, false) + ":" + AddressConverter.CellAddress(11, col, false, false) + ")/" + AddressConverter.CellAddress(2,2,false,false));
            sheet.Cells[6, 2] = variables.Count;
            sheet.Cells[7, 2] = model.confidenceLevel;
            ((Range)sheet.Cells[7, 2]).NumberFormat = "0.00%";

            col = 1;
            foreach (Variable variable in variables)
            {
                col++;
                sheet.WriteFunction(14, col, "(" + AddressConverter.CellAddress(10, col, false, false) + "-1)/(B2-B6)");
            }

            sheet.WriteFunction(5, 2, "SUMPRODUCT(" + AddressConverter.CellAddress(13, 2, false, false) + ":" + AddressConverter.CellAddress(13, col, false, false) + "," + AddressConverter.CellAddress(14, 2, false, false) + ":" + AddressConverter.CellAddress(14, col, false, false) + ")");
            sheet.WriteFunction(4, 2, "SQRT(" + AddressConverter.CellAddress(5, 2, false, false) + ")");

            sheet.WriteFunction(18, 2, "SUMPRODUCT(" + AddressConverter.CellAddress(10, 2, false, false) + ":" + AddressConverter.CellAddress(10, col, false, false) + ",(" + AddressConverter.CellAddress(11, 2, false, false) + ":" + AddressConverter.CellAddress(11, col, false, false) + "-B3)^2)");
            sheet.WriteFunction(19, 2, "(B2-" + variables.Count + ")*B5");
            sheet.WriteFunction(20, 2, "B18+B19");

            sheet.Cells[18, 3] = variables.Count - 1;
            sheet.WriteFunction(19, 3, "B2-" + variables.Count);
            sheet.WriteFunction(20, 3, "C18+C19");

            sheet.WriteFunction(18, 4, "B18/C18");
            sheet.WriteFunction(19, 4, "B19/C19");
            sheet.WriteFunction(18, 5, "D18/D19");
            sheet.WriteFunction(18, 6, "F.DIST.RT(E18,C18,C19)");

            int row = 24;
            int c = 0;
            for (int i = 0; i < variables.Count; i++)
            {
                for (int j = i + 1; j < variables.Count; j++)
                {
                    c++;
                    Variable var1 = variables[i];
                    Variable var2 = variables[j];
                    sheet.Cells[row, 1] = var1.name + " - " + var2.name;
                    sheet.WriteFunction(row, 2, AddressConverter.CellAddress(11, i + 2, false, false) + "-" + AddressConverter.CellAddress(11, j + 2, false, false));
                    col = 3;
                    if (model.noCorrection)
                    {
                        sheet.WriteFunction(row, col++, AddressConverter.CellAddress(row, 2, false, false) + "-(ABS(T.INV((1-B7)/2,C19)))*SQRT(D19*(1/" + AddressConverter.CellAddress(10, i + 2, false, false) + "+1/" + AddressConverter.CellAddress(10, j + 2, false, false) + "))");
                        sheet.WriteFunction(row, col++, AddressConverter.CellAddress(row, 2, false, false) + "+(ABS(T.INV((1-B7)/2,C19)))*SQRT(D19*(1/" + AddressConverter.CellAddress(10, i + 2, false, false) + "+1/" + AddressConverter.CellAddress(10, j + 2, false, false) + "))");
                    }
                    if (model.bonferroni)
                    {
                        sheet.WriteFunction(row, col++, AddressConverter.CellAddress(row, 2, false, false) + "-(ABS(T.INV(((1-B7)/(B6*(B6-1)/2))/2,C19)))*SQRT(D19*(1/" + AddressConverter.CellAddress(10, i + 2, false, false) + "+1/" + AddressConverter.CellAddress(10, j + 2, false, false) + "))");
                        sheet.WriteFunction(row, col++, AddressConverter.CellAddress(row, 2, false, false) + "+(ABS(T.INV(((1-B7)/(B6*(B6-1)/2))/2,C19)))*SQRT(D19*(1/" + AddressConverter.CellAddress(10, i + 2, false, false) + "+1/" + AddressConverter.CellAddress(10, j + 2, false, false) + "))");
                    }
                    if (model.scheffe)
                    {
                        sheet.WriteFunction(row, col++, AddressConverter.CellAddress(row, 2, false, false) + "-SQRT((B6-1)*F.INV.RT(1-B7,B6-1,C19))*SQRT(D19*(1/" + AddressConverter.CellAddress(10, i + 2, false, false) + "+1/" + AddressConverter.CellAddress(10, j + 2, false, false) + "))");
                        sheet.WriteFunction(row, col++, AddressConverter.CellAddress(row, 2, false, false) + "+SQRT((B6-1)*F.INV.RT(1-B7,B6-1,C19))*SQRT(D19*(1/" + AddressConverter.CellAddress(10, i + 2, false, false) + "+1/" + AddressConverter.CellAddress(10, j + 2, false, false) + "))");
                    }
                    row++;
                }
            }

            col = 3;
            if (model.noCorrection)
            {
                sheet.Cells[22, col] = "No Correction";
                sheet.get_Range(AddressConverter.CellAddress(22, col, false, false), AddressConverter.CellAddress(22, col + 1, false, false)).Merge();
                sheet.Cells[23, col] = "Lower";
                sheet.Cells[23, col + 1] = "Upper";
                sheet.get_Range(AddressConverter.CellAddress(23, col, false, false), AddressConverter.CellAddress(23, col + 1, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
                sheet.get_Range(AddressConverter.CellAddress(24, col, false, false), AddressConverter.CellAddress(23 + c, col, false, false)).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlDot;
                col += 2;
            }
            if (model.bonferroni)
            {
                sheet.Cells[22, col] = "Bonferroni";
                sheet.get_Range(AddressConverter.CellAddress(22, col, false, false), AddressConverter.CellAddress(22, col + 1, false, false)).Merge();
                sheet.Cells[23, col] = "Lower";
                sheet.Cells[23, col + 1] = "Upper";
                sheet.get_Range(AddressConverter.CellAddress(23, col, false, false), AddressConverter.CellAddress(23, col + 1, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
                sheet.get_Range(AddressConverter.CellAddress(24, col, false, false), AddressConverter.CellAddress(23 + c, col, false, false)).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlDot;
                col += 2;
            }
            if (model.scheffe)
            {
                sheet.Cells[22, col] = "Scheffe";
                sheet.get_Range(AddressConverter.CellAddress(22, col, false, false), AddressConverter.CellAddress(22, col + 1, false, false)).Merge();
                sheet.Cells[23, col] = "Lower";
                sheet.Cells[23, col + 1] = "Upper";
                sheet.get_Range(AddressConverter.CellAddress(23, col, false, false), AddressConverter.CellAddress(23, col + 1, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
                sheet.get_Range(AddressConverter.CellAddress(24, col, false, false), AddressConverter.CellAddress(23 + c, col, false, false)).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlDot;
            }

            ((Range)sheet.Cells[1, 1]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 2]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 3]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 4]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 5]).EntireColumn.AutoFit();
            ((Range)sheet.Cells[1, 6]).EntireColumn.AutoFit();
            sheet.get_Range("B1", "J200").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet.get_Range("A1", "B1").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            sheet.get_Range("A9", AddressConverter.CellAddress(9, variables.Count + 1, false, false)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            sheet.get_Range("A17", "F17").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            sheet.get_Range("A23", "B17").Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            sheet.get_Range("B3", "B5").NumberFormat = "0.0000";
            sheet.get_Range("B11", AddressConverter.CellAddress(14, variables.Count + 1, false, false)).NumberFormat = "0.000";
            sheet.get_Range("B18", "B20").NumberFormat = "0.0000";
            sheet.get_Range("D18", "E19").NumberFormat = "0.0000";
            sheet.get_Range("B24", AddressConverter.CellAddress(23+c, 2, false, false)).NumberFormat = "0.0000";
            sheet.get_Range("C24", AddressConverter.CellAddress(23+c, 8, false, false)).NumberFormat = "0.000000";
            sheet.get_Range("C24", AddressConverter.CellAddress(23 + c, 8, false, false)).Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
            Globals.ExcelAddIn.Application.ActiveWindow.DisplayGridlines = false;
        }
    }
}