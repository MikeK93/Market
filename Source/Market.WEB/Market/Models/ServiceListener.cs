// --------------------------------------------------------------------------
// <copyright file="ServiceListener.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Market.Middleware;

namespace Market.Model
{
    /// <summary>
    /// Class represents service listener for callback.
    /// </summary>
    public class ServiceListener : IMarketCallback
    {
        /// <summary>
        /// Test method.
        /// </summary>
        public void Enter()
        {
            //MessageBox.Show("Test");
        }
    }
}