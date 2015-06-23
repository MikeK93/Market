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
using Market.Model.Entities;
using Command.ViewModel.Base;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents relation between Bank and Salesperson.
    /// </summary>
    public class BankSalespersonVM : BaseVM
    {
        private BankSalesperson _bankSalesperson;

        private BankVM _bankVM;

        private SalespersonVM _salespersonVM;

        /// <summary>
        /// Constructor for creating new reation Bank-SalespersonId.
        /// </summary>
        /// <param name="bankVMId">ID of a bank.</param>
        /// <param name="salespersonVMId">ID of a salesperson.</param>
        public BankSalespersonVM(Guid bankVMId, Guid salespersonVMId)
        {
            _bankSalesperson = new BankSalesperson(bankVMId, salespersonVMId);
            _bankVM = new BankVM(_bankSalesperson.Bank);
            _salespersonVM = new SalespersonVM(_bankSalesperson.Salesperson);
        }

        /// <summary>
        /// Constructor for reading data from table.
        /// </summary>
        /// <param name="id">Existing Relation Bank-SalespersonId ID.</param>
        /// <param name="bankVMId">ID of a bank.</param>
        /// <param name="salespersonVMId">ID of a salespersonId.</param>
        public BankSalespersonVM(Guid id, Guid bankVMId, Guid salespersonVMId)
        {
            _bankSalesperson = new BankSalesperson(id, bankVMId, salespersonVMId);
            _bankVM = new BankVM(_bankSalesperson.Bank);
            _salespersonVM = new SalespersonVM(_bankSalesperson.Salesperson);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get
            {
                return _bankSalesperson.ID;
            }
        }

        /// <summary>
        /// Gets a bank.
        /// </summary>
        public BankVM Bank
        {
            get
            {
                return _bankVM;
                //new BankVM(BankMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Bank", MethodType.GetById, string.Empty, _bankSalesperson.BankID)[0]));
            }
        }

        /// <summary>
        /// Gets Bank id.
        /// </summary>
        public Guid BankID { get { return _bankSalesperson.BankID; } }

        /// <summary>
        /// Gets a salesperson.
        /// </summary>
        public SalespersonVM Salesperson
        {
            get
            {
                return _salespersonVM;
                    //new SalespersonVM(SalespersonMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Salesperson", MethodType.GetById, string.Empty, _bankSalesperson.SalespersonID)[0]));
            }
        }

        /// <summary>
        /// Gets Salesperson id.
        /// </summary>
        public Guid SalespersonID { get { return _bankSalesperson.SalespersonID; } }

        /// <summary>
        /// Gets a value indicating whether the relation Bank-Salesperson is new.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return _bankSalesperson.IsNew;
            }
        }

        /// <summary>
        /// Method saves relation Bank-Salesperson.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(BankSalespersonMapper.Mapper.Pack(this._bankSalesperson), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method deletes relation Bank-Salesperson.
        /// </summary>
        public void Delete()
        { MarketProxy.Proxy.UpdateOne(BankSalespersonMapper.Mapper.Pack(this._bankSalesperson), Middleware.UpdateType.Delete); }

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