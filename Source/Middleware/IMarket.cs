// --------------------------------------------------------------------------
// <copyright file="IMarket.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Market.Middleware
{
    /// <summary>
    /// Enum indicates a type of method to be invoked.
    /// </summary>
    [Serializable]
    public enum MethodType
    {
        /// <summary>
        /// Get data by specified id.
        /// </summary>
        GetById,

        /// <summary>
        /// Get data by specified query.
        /// </summary>
        GetByQuery,

        /// <summary>
        /// Get all items in table.
        /// </summary>
        GetAllItems,
    }

    /// <summary>
    /// Enum indicates a way to update object.
    /// </summary>
    public enum UpdateType
    {
        /// <summary>
        /// Save object.
        /// </summary>
        Save,

        /// <summary>
        /// Delete object.
        /// </summary>
        Delete
    }

    /// <summary>
    /// Contract for market.
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IMarketCallback))]
    [ServiceKnownType(typeof(Dictionary<string, object>))]
    public interface IMarket
    {
        /// <summary>
        /// Gets data from a table by the type of an entity.
        /// </summary>
        /// <param name="dataType">Type of items to get.</param>
        /// <param name="mType">Type of a method to be executed.</param>
        /// <param name="query">Query for getting data from table, if mType = GetByQuery.</param>
        /// <param name="id">Id of an item to look up, if mType = GetById.</param>
        /// <returns>List of objects of type T</returns>
        [OperationContract(IsOneWay = false)]
        List<PackedObject> GetData(string dataType, MethodType mType, string query, Guid id);

        /// <summary>
        /// Updates a data in table by an entity.
        /// </summary>
        /// <param name="packedObject">Object to update.</param>
        /// <param name="uType">Update type.</param>
        [OperationContract(IsOneWay = true)]
        void UpdateOne(PackedObject packedObject, UpdateType uType);

        /// <summary>
        /// Updates a data in table by a list of entities.
        /// </summary>
        /// <param name="packedObjects">Objects to update.</param>
        /// <param name="uType">Update type.</param>
        /// <rereturns>Number of updated items.</rereturns>
        [OperationContract(IsOneWay = false, Name = "UpdateList")]
        int UpdateList(List<PackedObject> packedObjects, UpdateType uType);
    }
}