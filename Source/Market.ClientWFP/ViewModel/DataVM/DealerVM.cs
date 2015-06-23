// --------------------------------------------------------------------------
// <copyright file="Dealer.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Market.Model;
using Market.Model.Mappers;
using Market.Middleware;
using Market.Model.Entities;
using Command.ViewModel.Base;
using System.Collections.ObjectModel;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a dealer.
    /// </summary>
    public class DealerVM : BaseVM
    {
        private Dealer _dealer;

        /// <summary>
        /// Custom constructor for recreating dealer from database.
        /// </summary>
        /// <param name="id">ID of a dealer in database.</param>
        /// <param name="userVMId">ID of a user attached to this dealer.</param>
        public DealerVM(Guid id, Guid userVMId)
        {
            _dealer = new Dealer(id, userVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of DealerVM by instance of Dealer class.
        /// </summary>
        /// <param name="dealer">Instance of Dealer class.</param>
        public DealerVM(Dealer dealer)
        {
            _dealer = dealer;
        }

        /// <summary>
        /// Custom constructor for creating new dealer.
        /// </summary>
        /// <param name="userVMId">User profile attached to a dealer.</param>
        public DealerVM(Guid userVMId)
        {
            _dealer = new Dealer(userVMId);
        }

        /// <summary>
        /// Method gets dealer by user.
        /// </summary>
        /// <param name="user">User attached to dealer.</param>
        /// <returns>Dealer object.</returns>
        public static DealerVM GetDealerByUser(UserVM user)
        {
            var packedObjects = MarketProxy.Proxy.GetData("Dealer", MethodType.GetByQuery, "UserID='" + user.ID + "'", Guid.Empty);
            return new DealerVM(DealerMapper.Mapper.UnPack(packedObjects[0]));
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _dealer.ID; } }

        /// <summary>
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return _dealer.UserID; } }

        /// <summary>
        /// Gets or sets a first name of a current dealer.
        /// </summary>
        public string FirstName
        {
            get { return _dealer.FirstName; }
            set
            {
                if (_dealer.FirstName == value)
                    return;

                _dealer.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets a middle name of a current dealer.
        /// </summary>
        public string MiddleName
        {
            get { return _dealer.MiddleName; }
            set
            {
                if (_dealer.MiddleName == value)
                    return;

                _dealer.MiddleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// Gets or sets a last name of a current dealer.
        /// </summary>
        public string LastName
        {
            get { return _dealer.LastName; }
            set
            {
                if (_dealer.LastName == value)
                    return;

                _dealer.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets a Gender of a current dealer.
        /// </summary>
        public GenderType Gender
        {
            get { return _dealer.Gender; }
            set
            {
                if (_dealer.Gender == value)
                    return;

                _dealer.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// Gets or sets a phone number of a current dealer.
        /// </summary>
        public string PhoneNumber
        {
            get { return _dealer.PhoneNumber; }
            set
            {
                if (_dealer.PhoneNumber == value)
                    return;

                _dealer.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Gets or sets an email.
        /// </summary>
        public string Email
        {
            get { return _dealer.Email; }
            set
            {
                if (_dealer.Email == value)
                    return;

                _dealer.Email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Dealer is new.
        /// </summary>
        public bool IsNew
        { get { return _dealer.IsNew; } }

        /// <summary>
        /// Gets User attached to current dealer.
        /// </summary>
        public UserVM User
        {
            get
            { return new UserVM(_dealer.User); }
        }

        /// <summary>
        /// Gets merchandise that available for clients.
        /// </summary>
        public ObservableCollection<MerchandiseVM> AllMerchandise
        {
            get { return (ObservableCollection<MerchandiseVM>)(from dm in this.DMs.AsEnumerable() select dm.Merchandise); }
        }

        /// <summary>
        /// Gets all banks current dealer is using.
        /// </summary>
        public ObservableCollection<BankVM> Banks
        {
            get { return (ObservableCollection<BankVM>)(from b in _dealer.Banks select new BankVM(b)); }
        }

        /// <summary>
        /// Gets all Dealer-Merchandise relations.
        /// </summary>
        public ObservableCollection<DMVM> DMs
        {
            get { return (ObservableCollection<DMVM>)(from dm in _dealer.DMs select new DMVM(dm)); }
        }

        /// <summary>
        /// Saves changes.
        /// </summary>
        public void Save()
        {
            MarketProxy.Proxy.UpdateOne(DealerMapper.Mapper.Pack(this._dealer), Middleware.UpdateType.Save);
            if (DMs != null && DMs.Count > 0)
            {
                foreach (DMVM dm in DMs)
                {
                    dm.Save();
                    dm.IsNew = false;
                }
            }
        }

        /// <summary>
        /// Method compares two instance of a Dealer class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            Dealer d = obj as Dealer;
            if (d == null) return false;
            if (d.ID == ID) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Shows string representation of dealer.
        /// </summary>
        /// <returns>First and last names.</returns>
        public override string ToString()
        { return FirstName + " " + LastName; }
    }
}