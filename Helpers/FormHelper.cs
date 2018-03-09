using System;
using System.Windows.Forms;

namespace NoruST
{
    internal static class FormHelper
    {
        public static T createAndOrShowForm<T>(this T form) where T : Form, new()
        {
            if (form == null || form.IsDisposed)
                form = new T();

            if (form.Visible == false)
                form.Show(new WindowImplementation(new IntPtr(Globals.ExcelAddIn.Application.Windows[1].Hwnd)));
            else
                form.Refresh();

            form.BringToFront();

            return form;
        }
    }
}