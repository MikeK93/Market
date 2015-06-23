// --------------------------------------------------------------------------
// <copyright file="Bank.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Market.Model.Mappers;
using Market.Middleware;
using System.Linq;
using Market.Model.Entities;
using Command.ViewModel.Base;
using Market.Model;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a bank.
    /// </summary>
    public class BankVM : BaseVM
    {
        private Bank _bank;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class.
        /// </summary>
        /// <param name="id">ID of a bank in database.</param>
        public BankVM(Guid id)
        {
            _bank = new Bank(id);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class.
        /// </summary>
        /// <param name="bank">ID of a bank in database.</param>
        public BankVM(Bank bank)
        {
            _bank = bank;
        }

        /// <summary>
        /// Gets ID of a bank.
        /// </summary>
        public Guid ID
        {
            get { return _bank.ID; }
        }

        /// <summary>
        /// Gets or sets a bank's name.
        /// </summary>
        public string Name
        {
            get { return _bank.Name; }
            set
            {
                if (_bank.Name == value)
                    return;

                _bank.Name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets a bank's address.
        /// </summary>
        public string Address
        {
            get { return _bank.Address; }
            set
            {
                if (_bank.Address == value)
                    return;

                _bank.Address = value;
                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets a value indicating whether current bank is new.
        /// </summary>
        public bool IsNew
        {
            get { return _bank.IsNew; }
        }

        /// <summary>
        /// Gets a list of all dealers using current bank.
        /// </summary>
        public List<DealerVM> Dealers
        {
            get
            {
                var bankDealers = BankDealerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("BankDealer", MethodType.GetByQuery, "BankID='" + this.ID + "'", Guid.Empty));
                return (from d in bankDealers.AsEnumerable() select new DealerVM(d.Dealer)).ToList();
            }
        }

        /// <summary>
        /// Gets a list of all salespersons using current bank.
        /// </summary>
        public List<SalespersonVM> Salespersons
        {
            get
            {
                var bankSalesperson = BankSalespersonMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("BankSalesperson", MethodType.GetByQuery, "BankID='" + this.ID + "'", Guid.Empty));
                return (from s in bankSalesperson.AsEnumerable() select new SalespersonVM(s.Salesperson)).ToList();
            }
        }

        /// <summary>
        /// Method equals two instance of a bank class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current bank object.</returns>
        public override bool Equals(object obj)
        {
            BankVM b = obj as BankVM;
            if (b == null)
                return false;

            if (b.ID == ID)
                return true;

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

        /// <summary>
        /// Shows text representation of a class.
        /// </summary>
        /// <returns>Name of a current bank.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}