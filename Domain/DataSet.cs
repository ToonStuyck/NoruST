using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using NoruST.Forms;
using static Microsoft.Office.Interop.Excel.XlInsertFormatOrigin;
using static Microsoft.Office.Interop.Excel.XlInsertShiftDirection;
using static NoruST.Domain.RangeLayout;

namespace NoruST.Domain
{
    public class DataSet : INotifyPropertyChanged
    {

        private _Worksheet worksheet;
        private RangeLayout rangeLayout;
        private bool variableNamesInFirstRowOrColumn;
        private BindingList<Variable> variables = new BindingList<Variable>();
        private string inputtedRange = null;
        private Range range;
        private string name;

        public DataSet() {}

        public DataSet(_Worksheet worksheet, Range range, string name, RangeLayout rangeLayout, bool variableNamesInFirstRowOrColumn, List<Variable> variables)
        {
            this.worksheet = worksheet;
            this.range = range;
            this.name = name;
            this.rangeLayout = rangeLayout;
            this.variableNamesInFirstRowOrColumn = variableNamesInFirstRowOrColumn;
            this.variables = new BindingList<Variable>(variables);
        }

        public _Worksheet getWorksheet()
        {
            return worksheet;
        }

        public Range getRange()
        {
            return range;
        }

        public string getName()
        {
            return name;
        }

        public bool getVariableNamesInFirstRowOrColumn()
        {
            return variableNamesInFirstRowOrColumn;
        }

        public RangeLayout getRangeLayout()
        {
            return rangeLayout;
        }

        public BindingList<Variable> getVariables()
        {
            return variables;
        }

        public int rangeSize()
        {
            return rangeLayout == COLUMNS ? variables[0].getRange().Rows.Count : variables[0].getRange().Columns.Count;
        }

        public void addLags(Variable variable, int numberOfLags)
        {
            for (int i = 1; i <= numberOfLags; i++)
            {
                Range source = rangeLayout == COLUMNS
                    ? variable.getRange().extendRangeByRows(-i)
                    : variable.getRange().extendRangeByColumns(-i);
                Range destination = rangeLayout == COLUMNS
                    ? variable.getRange()
                        .extendRangeByRows(-i, false)
                        .shiftRangeByColumns(variables.Count - variables.IndexOf(variable) + i - 1)
                    : variable.getRange()
                        .extendRangeByColumns(-i, false)
                        .shiftRangeByRows(variables.Count - variables.IndexOf(variable) + i - 1);
                source.Copy(destination);
                if (!variableNamesInFirstRowOrColumn) continue;
                source = rangeLayout == COLUMNS
                    ? variable.getRange().first().shiftRangeByRows(-1)
                    : variable.getRange().first().shiftRangeByColumns(-1);
                destination = rangeLayout == COLUMNS
                    ? variable.getRange()
                        .first()
                        .shiftRangeByRows(-1)
                        .shiftRangeByColumns(variables.Count - variables.IndexOf(variable) + i - 1)
                    : variable.getRange()
                        .first()
                        .shiftRangeByColumns(-1)
                        .shiftRangeByRows(variables.Count - variables.IndexOf(variable) + i - 1);
                destination.Value = source.Value + " Lag " + i.ToString();
            }
            Globals.ExcelAddIn.Application.CutCopyMode = XlCutCopyMode.xlCopy;

            range = rangeLayout == COLUMNS
                ? range.Resize[range.Rows.Count, range.Columns.Count + numberOfLags]
                : range.Resize[range.Rows.Count + numberOfLags, range.Columns.Count];
            recalculateVariables();
        }

        public void addDummy(Variable variable, int condition, string conditionValueString)
        {
            if (condition < 0 || condition > 4) return;
            double conditionValue;
            if (!Double.TryParse(conditionValueString, out conditionValue)) return;
            Range source = variable.getRange();
            Range destination = rangeLayout == COLUMNS
                ? variable.getRange().shiftRangeByColumns(variables.Count - variables.IndexOf(variable))
                : variable.getRange().shiftRangeByRows(variables.Count - variables.IndexOf(variable));

            for (int i = 0; i < (rangeLayout == COLUMNS ? variable.getRange().Rows.Count : variable.getRange().Columns.Count); i++)
            {
                int sourceRow = rangeLayout == COLUMNS ? source.Row + i : source.Row;
                int sourceColumn = rangeLayout == COLUMNS ? source.Column : source.Column + i;
                int destinationRow = rangeLayout == COLUMNS ? destination.Row + i : destination.Row;
                int destinationColumn = rangeLayout == COLUMNS ? destination.Column : destination.Column + i;
                double sourceValue = Double.Parse(((Range) worksheet.Cells[sourceRow, sourceColumn]).Value2.ToString());
                int res = -1;
                switch (condition)
                {
                    case 0: res = sourceValue < conditionValue ? 1 : 0; break;
                    case 1: res = sourceValue <= conditionValue ? 1 : 0; break;
                    case 2: res = sourceValue == conditionValue ? 1 : 0; break;
                    case 3: res = sourceValue >= conditionValue ? 1 : 0; break;
                    case 4: res = sourceValue > conditionValue ? 1 : 0; break;
                }
                worksheet.Cells[destinationRow, destinationColumn] = res;
            }

            if (!variableNamesInFirstRowOrColumn) return;
            Range headerLocation = rangeLayout == COLUMNS
                ? variable.getRange().first().shiftRangeByRows(-1).shiftRangeByColumns(variables.Count - variables.IndexOf(variable))
                : variable.getRange().first().shiftRangeByColumns(-1).shiftRangeByRows(variables.Count - variables.IndexOf(variable));
            string headerText = variable.name;
            switch (condition)
            {
                case 0: headerText += " < "; break;
                case 1: headerText += " <= ";break;
                case 2: headerText += " = "; break;
                case 3: headerText += " => "; break;
                case 4: headerText += " > "; break;
            }
            headerText += conditionValueString;
            headerLocation.Value = headerText;

            range = rangeLayout == COLUMNS
                ? range.Resize[range.Rows.Count, range.Columns.Count + 1]
                : range.Resize[range.Rows.Count + 1, range.Columns.Count];
            recalculateVariables();
        }

        public int amountOfVariables()
        {
            return variables.Count();
        }

        #region PropertyChangeEventHandlerStuff

        public string Range
        {
            get { return inputtedRange ?? range.Address(true, true); }
            set
            {
                try
                {
                    Range rangeFromString = worksheet.Range[value, Type.Missing];
                    inputtedRange = null;
                    SetField(ref range, rangeFromString, "Range");
                }
                catch (Exception e)
                {
                    inputtedRange = value;
                }
            }
        }

        public string Name
        {
            get { return name; }
            set { SetField(ref name, value, "Name"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            if (propertyName == "Range") recalculateVariables();
            OnPropertyChanged(propertyName);
            return true;
        }

        private void recalculateVariables()
        {
            List<Variable> newVariables = DataSetFactory.createVariables(worksheet, range, rangeLayout, variableNamesInFirstRowOrColumn);
            bool variablesAdded = newVariables.Count != variables.Count;
            bool variablesLengthened = rangeLayout == COLUMNS
                ? newVariables.First().getRange().Rows.Count != variables.First().getRange().Rows.Count
                : newVariables.First().getRange().Columns.Count != variables.First().getRange().Columns.Count;
            bool rangesHaveChanged = variablesAdded || variablesLengthened;
            
            if (rangesHaveChanged || variables.Count == 0)
            {
                variables.Clear();
                foreach (Variable newVariable in newVariables)
                    variables.Add(newVariable);
            }
        }

        #endregion
    }
}