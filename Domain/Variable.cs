using System;
using Microsoft.Office.Interop.Excel;

namespace NoruST.Domain
{
    public class Variable
    {

        private _Worksheet worksheet;
        public string name { get; set; }
        private Range range;
        public string Range => range.Address(true, true);

        public Variable(string name, _Worksheet worksheet, Range range)
        {
            this.name = name;
            this.worksheet = worksheet;
            this.range = range;
        }

        public Range getRange()
        {
            return range;
        }
    }
}