using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable LocalizableElement

namespace NoruST.Models
{
    public class CheckInput
    {
        #region Fields

        private readonly string _messageBoxCaption;

        #endregion

        #region Constructor

        /// <summary>
        /// Check the input so everything is working like intended.
        /// </summary>
        /// <param name="dataSet">The <see cref="DataSet"/> source.</param>
        /// <param name="messageBoxCaption">The caption for the <see cref="MessageBox"/>.</param>
        /// <param name="doIncludeX">A <see cref="IReadOnlyList{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Data"/> in the <see cref="DataSet.DataList"/> should be included.</param>
        /// <param name="checkX">The format the <see cref="Data"/> should be in.</param>
        /// <param name="fewestX">(Optional) The fewest amount of <see cref="Data"/> that has to be included. Default is 1.</param>
        /// <param name="doIncludeY">(Optional) A <see cref="IReadOnlyList{T}"/> of <see cref="bool"/>s that corresponds to which <see cref="Data"/> in the <see cref="DataSet.DataList"/> should be included. Default is null.</param>
        /// <param name="checkY">(Optional) The format the <see cref="Data"/> should be in. Default is <see cref="DefaultCheck.Unknown"/>.</param>
        /// <param name="fewestY">(Optional) The fewest amount of <see cref="Data"/> that has to be included. Default is 0.</param>
        /// <param name="doCalculate">(Optional) The indicator for which Summary Statistics should be calculated. Default is null.</param>
        /// <param name="dataType">(Optional) The type of the <see cref="Data"/>. Default is <see cref="DataType.Data"/>.</param>
        /// <param name="isCategory">(Optional) Will display 'category' instead of 'variable' when true. Default is false.</param>
        /// <param name="doIsNumericCheck">(Optional) Will do the numeric checks when true. Default is true.</param>
        /// <remarks>
        /// <para><see cref="doIncludeX"/> is used for single (value) column checks, X-column checks and category column checks.</para>
        /// <para><see cref="doIncludeY"/> is used for Y-column checks and value column checks if <see cref="doIncludeX"/> is used for category column checks.</para>
        /// <para>The similar is true for <see cref="checkX"/> and <see cref="checkY"/>.</para>
        /// </remarks>
        public CheckInput(DataSet dataSet, string messageBoxCaption, IReadOnlyList<bool> doIncludeX, DefaultCheck checkX, int fewestX = 1, IReadOnlyList<bool> doIncludeY = null, DefaultCheck checkY = DefaultCheck.Unknown, int fewestY = 0, SummaryStatisticsBool doCalculate = null, DataType dataType = DataType.Data, bool isCategory = false, bool doIsNumericCheck = true)
        {
            // Check if there is Data.
            if (dataSet == null)
            {
                MessageBox.Show("There is no data to work with.", "NoruST - " + messageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Successful = false;
                return;
            }

            // Check if Summary Statistics are calculated properly.
            if (doCalculate != null && !doCalculate.AtLeastOne)
            {
                MessageBox.Show("Nothing is being calculated. Select at least one.", "NoruST - " + messageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Successful = false;
                return;
            }

            // Initialize some variables.
            _messageBoxCaption = messageBoxCaption;
            if (doIncludeX != null && doIncludeY == null)
                doIncludeY = Enumerable.Repeat(false, doIncludeX.Count).ToList();

            // Create the Lists that holds the Data.
            Categories = new List<Data>();
            Values = new List<Data>();

            // Check for each Data in the DataSet if it's included.
            for (var i = 0; i < dataSet.DataList.Count; i++)
            {
                //  If it's not included, go to the next one.
                if (doIncludeY != null && doIncludeX != null && !doIncludeX[i] && !doIncludeY[i]) continue;

                // Check if the variables are in the correct format. If they aren't, warn the user.
                if (doIncludeX != null && doIsNumericCheck && doIncludeX[i])
                    switch (checkX)
                    {
                        case DefaultCheck.All:
                            break;
                        case DefaultCheck.Numeric:
                            if (!Numeric(dataSet.DataList[i])) return;
                            break;
                        case DefaultCheck.Nonnumeric:
                            if (!Nonnumeric(dataSet.DataList[i])) return;
                            break;
                        case DefaultCheck.None:
                            break;
                        case DefaultCheck.LastState:
                            break;
                        case DefaultCheck.Unknown:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(checkX), checkX, null);
                    }

                // Check if the variables are in the correct format. If they aren't, warn the user.
                if (doIncludeY != null && doIsNumericCheck && doIncludeY[i])
                    switch (checkY)
                    {
                        case DefaultCheck.All:
                            break;
                        case DefaultCheck.Numeric:
                            if (!Numeric(dataSet.DataList[i])) return;
                            break;
                        case DefaultCheck.Nonnumeric:
                            if (!Nonnumeric(dataSet.DataList[i])) return;
                            break;
                        case DefaultCheck.None:
                            break;
                        case DefaultCheck.LastState:
                            break;
                        case DefaultCheck.Unknown:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(checkX), checkX, null);
                    }

                // Add the included Data to the list.
                if (checkY != DefaultCheck.Unknown)
                {
                    if (doIncludeX != null && doIncludeX[i])
                        Categories.Add(dataSet.DataList[i]);
                    if (doIncludeY != null && doIncludeY[i])
                        Values.Add(dataSet.DataList[i]);
                }
                else
                {
                    if (doIncludeX != null && doIncludeX[i])
                        Values.Add(dataSet.DataList[i]);
                }

                // If the type of the Data is a Dummy, check for blank cells.
                if (dataType != DataType.Dummy) continue;
                foreach (var d in dataSet.DataList[i].GetValuesList())
                {
                    if (d != null) continue;

                    var result = MessageBox.Show("'" + dataSet.DataList[i].Name + $"' has blank data and will show some invalid data.{Environment.NewLine}{Environment.NewLine}Do you wish to continue anyway?", "NoruST - " + messageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes) break;

                    Successful = false;
                    return;
                }
            }

            // Check if the least amount of Data is selected.
            if (checkY != DefaultCheck.Unknown)
            {
                if ((fewestX < 0 && Categories.Count != Math.Abs(fewestX)) || Categories.Count < fewestX)
                {
                    MessageBox.Show((fewestX < 0 ? "Exactly " : Categories.Count < fewestX ? "At least " : "") + Math.Abs(fewestX) + " " + (Math.Abs(fewestX) == 1 ? isCategory ? "category" : "variable" + " has" : isCategory ? "categories" : "variables" + " have") + " to be selected.", "NoruST - " + messageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Successful = false;
                    return;
                }
                if (checkY != DefaultCheck.Unknown && ((fewestY < 0 && Values.Count != Math.Abs(fewestY)) || Values.Count < fewestY))
                {
                    MessageBox.Show((fewestY < 0 ? "Exactly " : Values.Count < fewestY ? "At least " : "") + Math.Abs(fewestY) + " " + (Math.Abs(fewestY) == 1 ? "variable has" : "variables have") + " to be selected.", "NoruST - " + messageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Successful = false;
                    return;
                }
            }
            else
            {
                if ((fewestX < 0 && Values.Count != Math.Abs(fewestX)) || Values.Count < fewestX)
                {
                    MessageBox.Show((fewestX < 0 ? "Exactly " : Values.Count < fewestX ? "At least " : "") + Math.Abs(fewestX) + " " + (Math.Abs(fewestX) == 1 ? "variable has" : "variables have") + " to be selected.", "NoruST - " + messageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Successful = false;
                    return;
                }
            }

            // If all checks succeeded, set it to true.
            Successful = true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check for <see cref="DefaultCheck.Numeric"/>.
        /// </summary>
        private bool Numeric(Data data)
        {
            if (data.IsNumeric) return true;

            var result = MessageBox.Show("'" + data.Name + $"' has non-numeric data and will show some strange or invalid data.{Environment.NewLine}{Environment.NewLine}Do you wish to continue anyway?", "NoruST - " + _messageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return Successful = false;

            return true;
        }

        /// <summary>
        /// Check for <see cref="DefaultCheck.Nonnumeric"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool Nonnumeric(Data data)
        {
            if (!data.IsNumeric) return true;

            var result = MessageBox.Show("'" + data.Name + $"' has numeric data and will show some strange or invalid data.{Environment.NewLine}{Environment.NewLine}Do you wish to continue anyway?", "NoruST - " + _messageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return Successful = false;

            return true;
        }

        #endregion

        #region Properties

        public bool Successful { get; private set; }
        public _Worksheet Sheet { get; }
        public DataSet DataSet { get; }
        public List<Data> Categories { get; }
        public List<Data> Values { get; }

        #endregion
    }
}