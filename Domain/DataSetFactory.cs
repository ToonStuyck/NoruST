using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using static NoruST.Domain.RangeLayout;

namespace NoruST.Domain
{
    public class DataSetFactory
    {

        public static DataSet create(_Worksheet worksheet, Range range, string name, RangeLayout rangeLayout, bool variableNamesInFirstRowOrColumn)
        {
            List<Variable> variables = createVariables(worksheet, range, rangeLayout, variableNamesInFirstRowOrColumn);
            return new DataSet(worksheet, range, name, rangeLayout, variableNamesInFirstRowOrColumn, variables);
        }

        public static List<Variable> createVariables(_Worksheet worksheet, Range range, RangeLayout rangeLayout, bool variableNamesInFirstRowOrColumn)
        {
            return rangeLayout == COLUMNS ? 
                createColumnVariables(worksheet, range, variableNamesInFirstRowOrColumn) : 
                createRowVariables(worksheet, range, variableNamesInFirstRowOrColumn);
        }

        private static List<Variable> createColumnVariables(_Worksheet worksheet, Range range, bool variableNameInFirstRow)
        {
            List<Variable> variables = new List<Variable>();
            if (range == null) return variables;
            int offset = variableNameInFirstRow ? 1 : 0;

            for (int columnIndex = 0; columnIndex < range.Columns.Count; columnIndex++)
            {
                string variableName = getColumnHeader(worksheet, range, variableNameInFirstRow, columnIndex);
                if (variableNameInFirstRow && range.Rows.Count == 1)
                {
                    variables.Add(new Variable(variableName, worksheet, null));
                }
                else
                {
                    Range upperLeftCell = worksheet.Cells[range.Row + offset, range.Column + columnIndex];
                    Range lowerRightCell = worksheet.Cells[range.Row + range.Rows.Count - 1, range.Column + columnIndex];
                    Range variableRange = worksheet.Range[upperLeftCell, lowerRightCell];
                    variables.Add(new Variable(variableName, worksheet, variableRange));
                }
            }

            return variables;
        }

        private static string getColumnHeader(_Worksheet worksheet, Range range, bool variableNamesInFirstRowOrColumn, int columnIndex)
        {
            string header = Convert.ToString(((Range) worksheet.Cells[range.Row, range.Column + columnIndex]).Value2);
            return variableNamesInFirstRowOrColumn && header != null ? header : "Var_" + (columnIndex + 1);
        }

        private static List<Variable> createRowVariables(_Worksheet worksheet, Range range, bool variableNameInFirstColumn)
        {
            List<Variable> variables = new List<Variable>();
            if (range == null) return variables;
            int offset = variableNameInFirstColumn && range.Columns.Count > 1 ? 1 : 0;

            for (int rowIndex = 0; rowIndex < range.Rows.Count; rowIndex++)
            {
                string variableName = getRowHeader(worksheet, range, variableNameInFirstColumn, rowIndex);
                Range upperLeftCell = worksheet.Cells[range.Row + rowIndex, range.Column + offset];
                Range lowerRightCell = worksheet.Cells[range.Row + rowIndex, range.Column + range.Columns.Count - 1];
                Range variableRange = worksheet.Range[upperLeftCell, lowerRightCell];

                variables.Add(new Variable(variableName, worksheet, variableRange));
            }

            return variables;
        }

        private static string getRowHeader(_Worksheet worksheet, Range range, Boolean variableNamesInFirstRowOrColumn, int rowIndex)
        {
            string header = Convert.ToString(((Range) worksheet.Cells[range.Row + rowIndex, range.Column]).Value2);
            return variableNamesInFirstRowOrColumn && header != null ? header : "Var_" + (rowIndex + 1);
        }
    }
}