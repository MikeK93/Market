// --------------------------------------------------------------------------
// <copyright file="WaitWindow.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace Market.ClientUI
{
    /// <summary>
    /// Class represents a wait window.
    /// </summary>
    public partial class WaitWindow : Form
    {
        /// <summary>
        /// Ctor for creating new instance of WaitWindow.
        /// </summary>
        public WaitWindow()
        { InitializeComponent(); }

        private void WaitWindow_Load(object sender, EventArgs e) { }
    }
}