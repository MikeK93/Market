// --------------------------------------------------------------------------
// <copyright file="Salesperson.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Command.ViewModel.Base;
using Market.Middleware;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents Salesperson.
    /// </summary>
    public class SalespersonVM : BaseVM
    {
        private Salesperson _salesperson;

        /// <summary>
        /// Ctor for cteatign new salesperson
        /// </summary>
        /// <param name="userId">User's id attached to current salesperson.</param>
        public SalespersonVM(Guid userVMId)
        {
            _salesperson = new Salesperson(userVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of SalespersonVM by instance of Salesperson.
        /// </summary>
        /// <param name="s">Instance of Salesperson.</param>
        public SalespersonVM(Salesperson s)
        {
            _salesperson = s;
        }

        /// <summary>
        /// Ctor for recreating salesperson from database.
        /// </summary>
        /// <param name="id">Salesperson's ID in database.</param>
        /// <param name="userVMId">User's ID attached to current salesperon.</param>
        public SalespersonVM(Guid id, Guid userVMId)
        {
            _salesperson = new Salesperson(id, userVMId);
        }

        /// <summary>
        /// Method gets salesperson by user.
        /// </summary>
        /// <param name="user">User attached to salesperson.</param>
        /// <returns>Salesperson object.</returns>
        public static SalespersonVM GetSalespersonByUser(UserVM user)
        {
            var packedObjects = MarketProxy.Proxy.GetData("Salesperson", MethodType.GetByQuery, "UserID='" + user.ID + "'", Guid.Empty);
            return new SalespersonVM(SalespersonMapper.Mapper.UnPack(packedObjects[0]));
        }

        /// <summary>
        /// Gets Salesperson.
        /// </summary>
        public Salesperson Salesperson { get { return _salesperson; } }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _salesperson.ID; } }

        /// <summary>
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return _salesperson.UserID; } }

        /// <summary>
        /// Gets or sets a first name of a current salesperson.
        /// </summary>
        public string FirstName
        {
            get { return _salesperson.FirstName; }
            set
            {
                if (value == _salesperson.FirstName)
                    return;

                _salesperson.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets a middle name of a current salesperson.
        /// </summary>
        public string MiddleName
        {
            get { return _salesperson.MiddleName; }
            set
            {
                if (value == _salesperson.MiddleName)
                    return;

                _salesperson.MiddleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// Gets or sets a last name of a current salesperson.
        /// </summary>
        public string LastName
        {
            get { return _salesperson.LastName; }
            set
            {
                if (value == _salesperson.LastName)
                    return;

                _salesperson.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets a phone number.
        /// </summary>
        public string PhoneNumber
        {
            get { return _salesperson.PhoneNumber; }
            set
            {
                if (value == _salesperson.PhoneNumber)
                    return;

                _salesperson.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Gets or sets an email.
        /// </summary>
        public string Email
        {
            get { return _salesperson.Email; }
            set
            {
                if (value == _salesperson.Email)
                    return;

                _salesperson.Email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets a gender of a current salesperson.
        /// </summary>
        public GenderType Gender
        {
            get { return _salesperson.Gender; }
            set
            {
                if (value == _salesperson.Gender)
                    return;

                _salesperson.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew
        { get { return _salesperson.IsNew; } }

        /// <summary>
        /// Gets User attached to current salesperson.
        /// </summary>
        public UserVM User
        {
            get { return new UserVM(_salesperson.User); }
            //UserMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("User", Middleware.MethodType.GetById, string.Empty, _userId)[0]); }
        }

        /// <summary>
        /// Gets or sets a list of Salesperson-Dealer-Merchandise.
        /// </summary>
        public ObservableCollection<SDMVM> SDMs
        {
            get { return (ObservableCollection<SDMVM>)(from sdm in _salesperson.SDMs select new SDMVM(sdm)); }
        }

        /// <summary>
        /// Gets a list of all merchandise, current salesperson is selling.
        /// </summary>
        public ObservableCollection<MerchandiseVM> SellingMerchandise
        {
            get
            {
                return (ObservableCollection<MerchandiseVM>)(from m in _salesperson.SellingMerchandise
                                                             select new MerchandiseVM(m));
            }
        }

        /// <summary>
        /// Gets a list of dealers, current salesperson is working with.
        /// </summary>
        public ObservableCollection<DealerVM> Dealers
        {
            get
            {
                return (ObservableCollection<DealerVM>)(from d in _salesperson.Dealers
                                                        select new DealerVM(d));
            }
        }

        /// <summary>
        /// Gets a list of banks, current salesperson is using.
        /// </summary>
        public ObservableCollection<BankVM> Banks
        {
            get
            {
                return (ObservableCollection<BankVM>)(from b in _salesperson.Banks
                                                      select new BankVM(b));
            }
        }

        /// <summary>
        /// Gets a list of spots, current salesperson is using.
        /// </summary>
        public ObservableCollection<SpotVM> Spots
        {
            get
            {
                return (ObservableCollection<SpotVM>)(from s in _salesperson.Spots
                                                      select new SpotVM(s));
            }
        }

        /// <summary>
        /// Gets a list of clients and order details.
        /// </summary>
        public ObservableCollection<CustomerSelectedItemsVM> Clients
        {
            get { return (ObservableCollection<CustomerSelectedItemsVM>)(from csi in _salesperson.Clients select new CustomerSelectedItemsVM(csi)); }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            _salesperson.Save();
        }

        /// <summary>
        /// Method updates selected daeler-merchandise list.
        /// </summary>
        public void UpdateSDMs()
        {
            var sdms = SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", MethodType.GetByQuery, "SalespersonID='" + this.ID + "'", Guid.Empty));
            this._salesperson.SDMs = new List<SDM>();
            foreach (SDM sdm in sdms)
                SDMs.Add(new SDMVM(sdm));
        }

        /// <summary>
        /// Method updates clients list.
        /// </summary>
        public void UpdateClients()
        {
            this._salesperson.Clients = new List<CustomerSelectedItems>();

            string q = string.Empty;
            foreach (var sdm in SDMs)
                q += " SalespersonDealerMerchandiseID = '" + sdm.ID + "' OR";

            q = q.Remove(q.Length - 3);
            var all = CustomerSelectedItemsMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("CustomerSelectedItems", Middleware.MethodType.GetByQuery, q, Guid.Empty));

            foreach (CustomerSelectedItems csi in all)
                if (csi.IsSubmited)
                    this._salesperson.Clients.Add(csi);
        }

        /// <summary>
        /// Method compares two instance of a Salesperson class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            SalespersonVM s = obj as SalespersonVM;
            if (s == null) return false;
            if (s.ID == ID) return true;
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
        /// Shows string representation of class.
        /// </summary>
        /// <returns>First and Last Names of salesperson.</returns>
        public override string ToString()
        { return FirstName + " " + LastName; }
    }
}