using System;
using System.Windows.Forms;

namespace NoruST
{
    /// <summary>
    /// <para>Window Implementation.</para>
    /// <para>Version: 1.0</para>
    /// <para>&#160;</para>
    /// <para>Author: Frederik Van de Velde</para>
    /// <para>&#160;</para>
    /// <para>Last Updated: Mar 16, 2016</para>
    /// </summary>
    internal class WindowImplementation : IWin32Window
    {
        #region Constructors

        public WindowImplementation(IntPtr handle)
        {
            Handle = handle;
        }

        #endregion

        #region Properties

        public IntPtr Handle { get; }

        #endregion
    }
}