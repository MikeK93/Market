// --------------------------------------------------------------------------
// <copyright file="BankDealer.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Market.Model;
using Market.Model.Mappers;
using Market.Middleware;

namespace Market.Model.Entities
{
    /// <summary>
    /// Class represents relation between Bank and Dealer.
    /// </summary>
    public class BankDealer
    {
        private Guid _id;

        private Guid _bankId;

        private Guid _dealerId;

        private bool _isNew = false;

        /// <summary>
        /// Constructor for creating new reation Bank-Dealer.
        /// </summary>
        /// <param name="bankId">ID of a bank.</param>
        /// <param name="dealerId">ID of a dealer.</param>
        public BankDealer(Guid bankId, Guid dealerId)
        {
            _id = Guid.NewGuid();
            _bankId = bankId;
            _dealerId = dealerId;
            _isNew = true;
        }

        /// <summary>
        /// Constructor for reading data from table.
        /// </summary>
        /// <param name="id">Existing Relation Bank-Dealer ID.</param>
        /// <param name="bankId">ID of a bank.</param>
        /// <param name="dealerId">ID of a dealer.</param>
        public BankDealer(Guid id, Guid bankId, Guid dealerId)
        {
            _id = id;
            _bankId = bankId;
            _dealerId = dealerId;
            _isNew = false;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get { return _id; }
        }

        /// <summary>
        /// Gets a bank.
        /// </summary>
        public Bank Bank { get { return BankMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Bank", MethodType.GetById, string.Empty, _bankId)[0]); } }

        /// <summary>
        /// Gets Bank id.
        /// </summary>
        public Guid BankID { get { return _bankId; } }

        /// <summary>
        /// Gets a dealer.
        /// </summary>
        public Dealer Dealer { get { return DealerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Dealer", MethodType.GetById, string.Empty, _dealerId)[0]); } }

        /// <summary>
        /// Gets Dealer id.
        /// </summary>
        public Guid DealerID { get { return _dealerId; } }

        /// <summary>
        /// Gets a value indicating whether the relation Bank-Dealer is new.
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
        }

        /// <summary>
        /// Method saves relation Bank-Dealer.
        /// </summary>
        public void Save()
        {
            MarketProxy.Proxy.UpdateOne(BankDealerMapper.Mapper.Pack(this), Middleware.UpdateType.Save);
        }

        /// <summary>
        /// Method deletes relation Bank-Dealer.
        /// </summary>
        public void Delete()
        {
            MarketProxy.Proxy.UpdateOne(BankDealerMapper.Mapper.Pack(this), Middleware.UpdateType.Delete);
        }

        /// <summary>
        /// Method compares two instance of a BankDealer class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            BankDealer bd = obj as BankDealer;
            if (bd == null) return false;
            if (bd.ID == ID &&
                bd.BankID == BankID &&
                bd.DealerID == DealerID) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}