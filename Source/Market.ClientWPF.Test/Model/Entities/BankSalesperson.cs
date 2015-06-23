// --------------------------------------------------------------------------
// <copyright file="BankSalesperson.cs" company="MK inc.">
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
    /// Class represents relation between Bank and Salesperson.
    /// </summary>
    public class BankSalesperson
    {
        private Guid _id;

        private Guid _bankId;

        private Guid _salespersonId;

        private bool _isNew = false;

        /// <summary>
        /// Constructor for creating new reation Bank-SalespersonId.
        /// </summary>
        /// <param name="bankId">ID of a bank.</param>
        /// <param name="salespersonId">ID of a salesperson.</param>
        public BankSalesperson(Guid bankId, Guid salespersonId)
        {
            _id = Guid.NewGuid();
            _bankId = bankId;
            _salespersonId = salespersonId;
            _isNew = true;
        }

        /// <summary>
        /// Constructor for reading data from table.
        /// </summary>
        /// <param name="id">Existing Relation Bank-SalespersonId ID.</param>
        /// <param name="bankId">ID of a bank.</param>
        /// <param name="salespersonId">ID of a salespersonId.</param>
        public BankSalesperson(Guid id, Guid bankId, Guid salespersonId)
        {
            _id = id;
            _bankId = bankId;
            _salespersonId = salespersonId;
            _isNew = false;
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
        /// Gets a bank.
        /// </summary>
        public Bank Bank { get { return BankMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Bank", MethodType.GetById, string.Empty, _bankId)[0]); } }

        /// <summary>
        /// Gets Bank id.
        /// </summary>
        public Guid BankID { get { return _bankId; } }

        /// <summary>
        /// Gets a salesperson.
        /// </summary>
        public Salesperson Salesperson { get { return SalespersonMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Salesperson", MethodType.GetById, string.Empty, _salespersonId)[0]); } }

        /// <summary>
        /// Gets Salesperson id.
        /// </summary>
        public Guid SalespersonID { get { return _salespersonId; } }

        /// <summary>
        /// Gets a value indicating whether the relation Bank-Salesperson is new.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return _isNew;
            }
        }

        /// <summary>
        /// Method saves relation Bank-Salesperson.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(BankSalespersonMapper.Mapper.Pack(this), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method deletes relation Bank-Salesperson.
        /// </summary>
        public void Delete()
        { MarketProxy.Proxy.UpdateOne(BankSalespersonMapper.Mapper.Pack(this), Middleware.UpdateType.Delete); }

        /// <summary>
        /// Method compares two instance of a BankSalesperson class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            BankSalesperson bs = obj as BankSalesperson;
            if (bs == null) return false;
            if (bs.ID == ID &&
                bs.BankID == BankID &&
                bs.SalespersonID == SalespersonID) return true;
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