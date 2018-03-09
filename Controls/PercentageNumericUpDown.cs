using System.Windows.Forms;

// ReSharper disable LocalizableElement

namespace NoruST.Controls
{
    public partial class PercentageNumericUpDown : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            base.UpdateEditText();

            ChangingText = true;
            Text += "%";
        }
    }
}