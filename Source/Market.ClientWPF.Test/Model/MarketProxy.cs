// --------------------------------------------------------------------------
// <copyright file="MarketProxy.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using Market.Model.Entities;
using Market.Middleware;
using System.Windows;

namespace Market.Model
{
    /// <summary>
    /// Class represent proxy.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [ServiceKnownType(typeof(Role))]
    [ServiceKnownType(typeof(GenderType))]
    [ServiceKnownType(typeof(Dictionary<string, object>))]
    public class MarketProxy : DuplexClientBase<IMarket>, IMarket
    {
        private static MarketProxy _obj;

        private MarketProxy(InstanceContext callbankInstance) : base(callbankInstance) { }

        /// <summary>
        /// Gets instance of a class.
        /// </summary>
        public static MarketProxy Proxy
        {
            get
            {
                if (_obj == null)
                    _obj = new MarketProxy(new InstanceContext(new ServiceListener()));
                else
                    if (_obj.State == CommunicationState.Faulted)
                        _obj = new MarketProxy(new InstanceContext(new ServiceListener()));

                return _obj;
            }
        }

        #region Contract
        /// <summary>
        /// Method retrieves data from database.
        /// </summary>
        /// <param name="dataType">Type of items to get.</param>
        /// <param name="mType">Type of method.</param>
        /// <param name="query">Query by which to look up items.</param>
        /// <param name="id">Id by which to find item(s).</param>
        /// <returns>List of pacekd objects.</returns>
        public List<PackedObject> GetData(string dataType, MethodType mType, string query, Guid id)
        {
            try
            {
                return base.Channel.GetData(dataType, mType, query, id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in type: " + GetType() + Environment.NewLine + "Error msg:" + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Updates a data in table by an entity.
        /// </summary>
        /// <param name="instanceToUpdate">Object to update.</param>
        /// <param name="uType">Update type.</param>
        public void UpdateOne(PackedObject instanceToUpdate, UpdateType uType)
        {
            try
            {
                base.Channel.UpdateOne(instanceToUpdate, uType);
            }
            catch (Exception e)
            { MessageBox.Show("Error in type: " + GetType() + Environment.NewLine + "Error msg:" + e.Message); }
        }

        /// <summary>
        /// Updates a data in table by a list of entities.
        /// </summary>
        /// <param name="packedObjects">Objects to update.</param>
        /// <param name="uType">Update type.</param>
        /// <rereturns>Number of updated items.</rereturns>
        public int UpdateList(List<PackedObject> packedObjects, UpdateType uType)
        {
            try
            {
                return base.Channel.UpdateList(packedObjects, uType);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in type: " + GetType() + Environment.NewLine + "Error msg:" + e.Message);
                return 0;
            }

        }
        #endregion
    }
}