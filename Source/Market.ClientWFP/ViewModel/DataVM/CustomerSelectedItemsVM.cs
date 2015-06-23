// --------------------------------------------------------------------------
// <copyright file="CustomerSelectedItems.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using Command.ViewModel.Base;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a relation Customer-SelectedItems.
    /// </summary>
    public class CustomerSelectedItemsVM : BaseVM
    {
        private CustomerSelectedItems _customerSelectedItems;

        /// <summary>
        /// Ctor for creating new Customer-SalespersonDealerMerchandise relation.
        /// </summary>
        /// <param name="customerVMId">Customer's id.</param>
        /// <param name="sdmVMId">SDM id.</param>
        public CustomerSelectedItemsVM(Guid customerVMId, Guid sdmVMId)
        {
            _customerSelectedItems = new CustomerSelectedItems(customerVMId, sdmVMId);
        }

        public CustomerSelectedItemsVM(CustomerSelectedItems csi)
        {

        }

        /// <summary>
        /// Constructor for recreating Customer-SalespersonDealerMerchandise relation from database.
        /// </summary>
        /// <param name="id">Relation id in database.</param>
        /// <param name="customerVMId">Customer's id.</param>
        /// <param name="sdmVMId">SDM id.</param>
        public CustomerSelectedItemsVM(Guid id, Guid customerVMId, Guid sdmVMId)
        {
            _customerSelectedItems = new CustomerSelectedItems(id, customerVMId, sdmVMId);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get { return _customerSelectedItems.ID; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the relation Customer-Selectedtems is new.
        /// </summary>
        public bool IsNew
        {
            get { return _customerSelectedItems.IsNew; }
            set { _customerSelectedItems.IsNew = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the relation Customer-Selectedtems is submited.
        /// </summary>
        public bool IsSubmited
        {
            get { return _customerSelectedItems.IsSubmited; }
            set { _customerSelectedItems.IsSubmited = value; }
        }

        /// <summary>
        /// Gets a customer.
        /// </summary>
        public CustomerVM Customer
        {
            get { return new CustomerVM(_customerSelectedItems.Customer); }
            //CustomerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Customer", Middleware.MethodType.GetById, string.Empty, _cId)[0]); }
        }

        /// <summary>
        /// Gets Customer id.
        /// </summary>
        public Guid CustomerID { get { return _customerSelectedItems.CustomerID; } }

        /// <summary>
        /// Gets sets a relation Salesperson-Dealer-Merchandise.
        /// </summary>
        public SDMVM SDM
        {
            get { return new SDMVM(_customerSelectedItems.SDM); }
            //SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", Middleware.MethodType.GetById, string.Empty, _sdmId)[0]); }
        }

        /// <summary>
        /// Gets SDM id.
        /// </summary>
        public Guid SDMID { get { return _customerSelectedItems.SDMID; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            MarketProxy.Proxy.UpdateOne(CustomerSelectedItemsMapper.Mapper.Pack(this._customerSelectedItems), Middleware.UpdateType.Save);
        }

        /// <summary>
        /// Method deletes an entity CustomerSelectedItems from database.
        /// </summary>
        public void Delete()
        { MarketProxy.Proxy.UpdateOne(CustomerSelectedItemsMapper.Mapper.Pack(this._customerSelectedItems), Middleware.UpdateType.Delete); }

        /// <summary>
        /// Method compares two instance of a relation Customer-Selectedtems class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            CustomerSelectedItemsVM csi = obj as CustomerSelectedItemsVM;
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
    }
}