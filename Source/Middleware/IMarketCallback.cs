// --------------------------------------------------------------------------
// <copyright file="IMarketCallback.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Market.Middleware
{
    ///
    /// [ServiceContract(SessionMode = SessionMode.Required)]
    ///

    /// <summary>
    /// Interface for callback.
    /// </summary>
    public interface IMarketCallback
    {
        /// <summary>
        /// Test method
        /// </summary>
        [OperationContract(IsInitiating = true, IsOneWay = true, IsTerminating = false)]
        void Enter();
    }
}