using Microsoft.Office.Interop.Excel;

namespace NoruST
{
    /// <summary>
    /// <para>AddSeriesCollection.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Mar 19, 2016</para>
    /// </summary>
    public static class AddSeriesCollection
    {
        /// <summary>
        /// Add a new series to the <see cref="SeriesCollection"/> without having to provide a <see cref="Range"/>.
        /// </summary>
        /// <returns>The new series.</returns>
        /// <remarks>This method replaces the <see cref="SeriesCollection.NewSeries"/> method because that one isn't working like intended.</remarks>
        public static Series Add(this SeriesCollection seriesCollection)
        {
            // Add the series to the provided collection of series with a temp range and clear the name.
            var sheet = (Worksheet) Globals.ExcelAddIn.Application.ActiveSheet;
            var series = seriesCollection.Add(sheet.Range["A1:A2"]);
            series.Name = "";

            // Return the newly added series.
            return series;
        }
    }
}