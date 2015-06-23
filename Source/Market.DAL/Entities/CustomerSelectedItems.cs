// --------------------------------------------------------------------------
// <copyright file="CustomerSelectedItems.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Market.Readers;

namespace Market.Entities
{
    /// <summary>
    /// Class represents a relation Customer-SelectedItems.
    /// </summary>
    [DataContract]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
        public bool IsSubmited { get; set; }

        /// <summary>
        /// Gets or sets a customer.
        /// </summary>
        public Customer Customer
        {
            get
            {
                return (_cId == Guid.Empty) ? null : CustomerReader.Reader.GetById(_cId).FirstOrDefault();
            }

            set
            {
                _cId = (value == null) ? Guid.Empty : value.ID;
            }
        }

        /// <summary>
        /// Gets id of customer.
        /// </summary>
        public Guid CustomerID { get { return this._cId; } }

        /// <summary>
        /// Gets or sets a relation Salesperson-Dealer-Merchandise.
        /// </summary>
        public SDM SDM
        {
            get
            {
                return (_sdmId == Guid.Empty) ? null : SDMReader.Reader.GetById(_sdmId).FirstOrDefault();
            }

            set
            {
                _sdmId = (value == null) ? Guid.Empty : value.ID;
            }
        }

        /// <summary>
        /// Gets sdm id.
        /// </summary>
        public Guid SDMID { get { return _sdmId;} }

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
                csi.Customer.ID == Customer.ID &&
                csi.SDM.ID == SDM.ID) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            CustomerSelectedItemsReader.Reader.Save(this, this.IsNew);
        }

        /// <summary>
        /// Method deletes an entity CustomerSelectedItems from database.
        /// </summary>
        public void Delete()
        { CustomerSelectedItemsReader.Reader.Delete(this); }

        /// <summary>
        /// Display text representstion of a Customer class.
        /// </summary>
        /// <returns>Customer and a relation Salesperson-Dealer-Merchandise.</returns>
        public override string ToString()
        { return string.Format("{0} <::> {1}", Customer, SDM); }
    }
}