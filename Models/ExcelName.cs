using System;
using Microsoft.Office.Interop.Excel;

namespace NoruST.Models
{
    public class ExcelName<T> : IComparable, IComparable<ExcelName<T>>, IEquatable<ExcelName<T>>
    {
        #region Functions

        public int CompareTo(object obj)
        {
            if (obj != null && !(obj is ExcelName<T>))
                throw new ArgumentException("Object must be of type ExcelName.");

            return CompareTo((ExcelName<T>)obj);
        }

        public int CompareTo(ExcelName<T> other)
        {
            return ReferenceEquals(other, null) ? 1 : string.CompareOrdinal(Name.Name, other.Name.Name);
        }

        public bool Equals(ExcelName<T> other)
        {
            return other != null && Name == other.Name;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of the <see cref="Data"/> class
        /// </summary>
        /// <param name="name">The <see cref="Microsoft.Office.Interop.Excel.Name"/>.</param>
        /// <param name="value">The actual calculated value of the <see cref="Microsoft.Office.Interop.Excel.Name"/>.</param>
        public ExcelName(Name name, T value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The <see cref="Microsoft.Office.Interop.Excel.Name"/>.
        /// </summary>
        public Name Name { get; set; }

        /// <summary>
        /// The actual calculated value of the <see cref="Microsoft.Office.Interop.Excel.Name"/>.
        /// </summary>
        public T Value { get; }

        #endregion
    }
}