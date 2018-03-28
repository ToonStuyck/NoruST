using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using NoruST.Forms;
using System.Windows.Forms;
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

        public DataSet() { }

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

        public static int ColumnLetterToColumnIndex(string columnLetter)
        {
            columnLetter = columnLetter.ToUpper();
            int sum = 0;

            for (int i = 0; i < columnLetter.Length; i++)
            {
                sum *= 26;
                sum += (columnLetter[i] - 'A' + 1);
            }
            return sum;
        }

        static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }

        public void addDummy(Variable variable, DataSet dataSet)
        {
            string ran = variable.Range.ToString();
            String colLetter2 = variable.Range[1].ToString();
            int columnIndex2 = ColumnLetterToColumnIndex(colLetter2)-1;
            String colLetter = dataSet.getVariables()[dataSet.getVariables().Count - 1].Range[1].ToString();
            int columnIndex = ColumnLetterToColumnIndex(colLetter)+1;
            Array dist = dataSet.getWorksheet().Range[ran].Value;
			int count = 0;
            foreach (var item in dist)
            {
                if (item.GetType().ToString() == "System.String")
                {
                    count = 1;
                } else
                {
                    count = 2;
                }
                break;
            }
            if (count == 1)
            {
                List<String> values = dist.OfType<String>().ToList();
                dist = values.Distinct<String>().ToArray();
                int row = 1;
                int column = columnIndex;
                foreach (var item in dist)
                {
                    worksheet.Cells[row, column] = dataSet.getVariables()[columnIndex2].name + "=" + item.ToString();
                    column = column + 1;
                }
                row = 0;
                while (row < values.Count)
                {
                    String temp = values[row];
                    column = columnIndex;
                    foreach (var item in dist)
                    {
                        if (temp.Equals(item.ToString()))
                        {
                            worksheet.Cells[row + 2, column] = "1";
                        }
                        else
                        {
                            worksheet.Cells[row + 2, column] = "0";
                        }
                        column = column + 1;
                    }
                    row = row + 1;
                }
            } else
            {
                List<Double> values = dist.OfType<Double>().ToList();
                List<Double> value = dist.OfType<Double>().ToList();
                values.Sort();
                dist = values.Distinct<Double>().ToArray();
                int row = 1;
                int column = columnIndex;
                foreach (var item in dist)
                {
                    worksheet.Cells[row, column] = dataSet.getVariables()[columnIndex2].name + "=" + item.ToString();
                    column = column + 1;
                }
                row = 0;
                while (row < values.Count)
                {
                    double temp = value[row];
                    column = columnIndex;
                    foreach (var item in dist)
                    {
                        if(temp==Convert.ToInt16(item))
                        {
                            worksheet.Cells[row+2, column] = "1";
                        } else
                        {
                            worksheet.Cells[row+2, column] = "0";
                        }
                        column = column + 1;
                    }
                    row = row + 1;
                }
            }
		}

		public void addUnstacked(Variable category, Variable variable, DataSet dataSet) //cat = gender var = salary
		{
            string ran2 = category.Range.ToString();
            String colLetterCat = category.Range[1].ToString();
            int columnIndexCat = ColumnLetterToColumnIndex(colLetterCat) - 1;
            Array distCat = dataSet.getWorksheet().Range[ran2].Value;
            Array cat = dataSet.getWorksheet().Range[ran2].Value;

            string ran = variable.Range.ToString();
            String colLetterVar = variable.Range[1].ToString();
            int columnIndexVar = ColumnLetterToColumnIndex(colLetterVar) - 1;
            Array dist = dataSet.getWorksheet().Range[ran].Value;
            int count = 0;

            Worksheet newworksheet;
            try
            {
                newworksheet = dataSet.getWorksheet().Application.Worksheets.Add();
                newworksheet.Name = "Unstack" + dataSet.getVariables()[columnIndexVar].name + "-" + dataSet.getVariables()[columnIndexCat].name;
            }
            catch (SystemException e)
            {
                MessageBox.Show("Unstacked data already exists, change name of existing worksheet and try again.");
                return;
            }


            foreach (var item in distCat)
            {
                if (item.GetType().ToString() == "System.String")
                {
                    count = 1;
                }
                else
                {
                    count = 2;
                }
                break;
            }
            if (count == 1)
            {
                List<String> valuesCat = distCat.OfType<String>().ToList();
                List<Double> valuesVar = dist.OfType<Double>().ToList();
                distCat = valuesCat.Distinct<String>().ToArray();
                int row = 1;
                int column = 1;
                foreach (var item in distCat)
                {
                    newworksheet.Cells[row, column] = dataSet.getVariables()[columnIndexVar].name + "(" + item.ToString() + ")";
                    column = column + 1;
                }
                column = 1;
                foreach (var item in distCat)
                {
                    row = 0;
                    int counter = row;
                    while (row < valuesVar.Count)
                    {
                        String temp = valuesCat[row];
                        if (temp.Equals(item.ToString()))
                        {
                            newworksheet.Cells[counter + 2, column] = valuesVar[row];
                            counter = counter + 1;
                        }
                        row = row + 1;
                    }
                    column = column + 1;
                }
            }
            else
            {
                List<Double> valueSortCat = distCat.OfType<Double>().ToList(); // één lijst gaat gesorteerd worden en de andere niet
                List<Double> valueCat = distCat.OfType<Double>().ToList();
                List<Double> valuesVar = dist.OfType<Double>().ToList();
                valueSortCat.Sort();
                distCat = valueSortCat.Distinct<Double>().ToArray();
                int row = 1;
                int column = 1;
                foreach (var item in distCat)
                {
                    newworksheet.Cells[row, column] = dataSet.getVariables()[columnIndexVar].name + "(" + item.ToString() + ")";
                    column = column + 1;
                }
                column = 1;
                foreach (var item in distCat)
                {
                    row = 0;
                    int counter = row;
                    while (row < valuesVar.Count)
                    {
                        double temp = valueCat[row];
                        if (temp == Convert.ToDouble(item.ToString()))
                        {
                            newworksheet.Cells[counter + 2, column] = valuesVar[row];
                            counter = counter + 1;
                        }
                        row = row + 1;
                    }
                    column = column + 1;
                }
            }
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