// --------------------------------------------------------------------------
// <copyright file="CustomerSelectedItems.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using Market.Model;
using Market.Model.Mappers;

namespace Market.Model.Entities
{
    /// <summary>
    /// Class represents a relation Customer-SelectedItems.
    /// </summary>
    public class CustomerSelectedItems
    {
        private Guid _id;

        private Guid _cId;

        private Guid _sdmId;

        private bool _isNew;

        /// <summary>
        /// Ctor for creating new Customer-SalespersonDealerMerchandise relation.
        /// </summary>
        /// <param name="customerId">Customer's id.</param>
        /// <param name="sdmId">SDM id.</param>
        public CustomerSelectedItems(Guid customerId, Guid sdmId)
        {
            _isNew = true;
            _id = Guid.NewGuid();
            _cId = customerId;
            _sdmId = sdmId;
        }

        /// <summary>
        /// Constructor for recreating Customer-SalespersonDealerMerchandise relation from database.
        /// </summary>
        /// <param name="id">Relation id in database.</param>
        /// <param name="customerId">Customer's id.</param>
        /// <param name="sdmId">SDM id.</param>
        public CustomerSelectedItems(Guid id, Guid customerId, Guid sdmId)
        {
            _isNew = false;
            _id = id;
            _cId = customerId;
            _sdmId = sdmId;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the relation Customer-Selectedtems is new.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return _isNew;
            }

            set
            {
                _isNew = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the relation Customer-Selectedtems is submited.
        /// </summary>
        public bool IsSubmited { get; set; }

        /// <summary>
        /// Gets a customer.
        /// </summary>
        public Customer Customer { get { return CustomerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Customer", Middleware.MethodType.GetById, string.Empty, _cId)[0]); } }

        /// <summary>
        /// Gets Customer id.
        /// </summary>
        public Guid CustomerID { get { return _cId; } }

        /// <summary>
        /// Gets sets a relation Salesperson-Dealer-Merchandise.
        /// </summary>
        public SDM SDM { get { return SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", Middleware.MethodType.GetById, string.Empty, _sdmId)[0]); } }

        /// <summary>
        /// Gets SDM id.
        /// </summary>
        public Guid SDMID { get { return _sdmId; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            MarketProxy.Proxy.UpdateOne(CustomerSelectedItemsMapper.Mapper.Pack(this), Middleware.UpdateType.Save);
        }

        /// <summary>
        /// Method deletes an entity CustomerSelectedItems from database.
        /// </summary>
        public void Delete()
        { MarketProxy.Proxy.UpdateOne(CustomerSelectedItemsMapper.Mapper.Pack(this), Middleware.UpdateType.Delete); }

        /// <summary>
        /// Method compares two instance of a relation Customer-Selectedtems class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            CustomerSelectedItems csi = obj as CustomerSelectedItems;
            if (csi == null) return false;
            if (csi.ID == ID &&
                csi.CustomerID == CustomerID &&
                csi.SDMID == SDMID) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Display text representstion of a Customer class.
        /// </summary>
        /// <returns>Customer and a relation Salesperson-Dealer-Merchandise.</returns>
        public override string ToString()
        { return string.Format("{0} <::> {1}", Customer, SDM); }
    }
}