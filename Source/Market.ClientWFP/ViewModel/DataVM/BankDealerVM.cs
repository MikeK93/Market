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
using Command.ViewModel.Base;
using Market.Model.Entities;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents relation between Bank and Dealer.
    /// </summary>
    public class BankDealerVM : BaseVM
    {
        private BankDealer _bankDealer;

        /// <summary>
        /// Constructor for creating new reation Bank-Dealer.
        /// </summary>
        /// <param name="bankVMId">ID of a bank.</param>
        /// <param name="dealerVMId">ID of a dealer.</param>
        public BankDealerVM(Guid bankVMId, Guid dealerVMId)
        {
            _bankDealer = new BankDealer(bankVMId, dealerVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of BankDealerVM by instance of BankDealer class.
        /// </summary>
        /// <param name="bankDealer">Instance of BankDealer class.</param>
        public BankDealerVM(BankDealer bankDealer)
        {
            _bankDealer = bankDealer;
        }

        /// <summary>
        /// Constructor for reading data from table.
        /// </summary>
        /// <param name="id">Existing Relation Bank-Dealer ID.</param>
        /// <param name="bankVMId">ID of a bank.</param>
        /// <param name="dealerVMId">ID of a dealer.</param>
        public BankDealerVM(Guid id, Guid bankVMId, Guid dealerVMId)
        {
            _bankDealer = new BankDealer(id, bankVMId, dealerVMId);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get { return _bankDealer.ID; }
        }

        /// <summary>
        /// Gets a bank.
        /// </summary>
        public BankVM Bank { get { return new BankVM(BankMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Bank", MethodType.GetById, string.Empty, _bankDealer.BankID)[0])); } }

        /// <summary>
        /// Gets Bank id.
        /// </summary>
        public Guid BankID { get { return _bankDealer.BankID; } }

        /// <summary>
        /// Gets a dealer.
        /// </summary>
        public DealerVM Dealer { get { return new DealerVM(DealerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Dealer", MethodType.GetById, string.Empty, _bankDealer.DealerID)[0])); } }

        /// <summary>
        /// Gets Dealer id.
        /// </summary>
        public Guid DealerID { get { return _bankDealer.DealerID; } }

        /// <summary>
        /// Gets a value indicating whether the relation Bank-Dealer is new.
        /// </summary>
        public bool IsNew
        {
            get { return _bankDealer.IsNew; }
        }

        /// <summary>
        /// Method saves relation Bank-Dealer.
        /// </summary>
        public void Save()
        {
            _bankDealer.Save();
        }

        /// <summary>
        /// Method deletes relation Bank-Dealer.
        /// </summary>
        public void Delete()
        {
            _bankDealer.Delete();
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