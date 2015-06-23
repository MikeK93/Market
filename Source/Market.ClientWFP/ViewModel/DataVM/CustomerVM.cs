// --------------------------------------------------------------------------
// <copyright file="Customer.cs" company="MK inc.">
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
    /// Class represents a Customer.
    /// </summary>
    public class CustomerVM : BaseVM
    {
        private Customer _customer;

        /// <summary>
        /// Ctor for creating new customer.
        /// </summary>
        /// <param name="userId">User's id attached to current customer.</param>
        public CustomerVM(Guid userVMId)
        {
            _customer = new Customer(userVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of a CustomerVM class by Customer class instanse.
        /// </summary>
        public CustomerVM(Customer customer)
        { _customer = customer; }

        /// <summary>
        /// Ctor for recreating customer from database.
        /// </summary>
        /// <param name="id">Id of current customer in database.</param>
        /// <param name="userId">User's id attached to current customer.</param>
        public CustomerVM(Guid id, Guid userVMId)
        {
            _customer = new Customer(id, userVMId);
            UpdateCSI();
        }

        /// <summary>
        /// Method gets customer by user.
        /// </summary>
        /// <param name="user">User attacehd to customer.</param>
        /// <returns>Customer object.</returns>
        public static CustomerVM GetCustomerByUser(UserVM user)
        {
            var packedObjects = MarketProxy.Proxy.GetData("Customer", Middleware.MethodType.GetByQuery, "UserID='" + user.ID + "'", Guid.Empty);
            return new CustomerVM(CustomerMapper.Mapper.UnPack(packedObjects[0]));
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get
            {
                return _customer.ID;
            }
        }

        /// <summary>
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return _customer.UserID; } }

        /// <summary>
        /// Gets or sets a first name of a current customer.
        /// </summary>
        public string FirstName
        {
            get { return _customer.FirstName; }
            set
            {
                if (value == _customer.FirstName)
                    return;

                _customer.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets a middle name of a current customer.
        /// </summary>
        public string MiddleName
        {
            get { return _customer.MiddaleName; }
            set
            {
                if (value == _customer.MiddaleName)
                    return;

                _customer.MiddaleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// Gets or sets a last name of a current customer.
        /// </summary>
        public string LastName
        {
            get { return _customer.LastName; }
            set
            {
                if (value == _customer.LastName)
                    return;

                _customer.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets a phone number.
        /// </summary>
        public string PhoneNumber
        {
            get { return _customer.PhoneNumber; }
            set
            {
                if (value == _customer.PhoneNumber)
                    return;

                _customer.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Gets or sets an email.
        /// </summary>
        public string Email
        {
            get { return _customer.Email; }
            set
            {
                if (value == _customer.Email)
                    return;

                _customer.Email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets gender of a current customer.
        /// </summary>
        public GenderType Gender
        {
            get { return _customer.Gender; }
            set
            {
                if (value == _customer.Gender)
                    return;

                _customer.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// Gets or sets age of a current customer.
        /// </summary>
        public int Age
        {
            get { return _customer.Age; }
            set
            {
                if (value == _customer.Age)
                    return;

                _customer.Age = value;
                OnPropertyChanged("Age");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Customer is new.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return _customer.IsNew;
            }
        }

        /// <summary>
        /// Gets sets a user profile attached to current customer.
        /// </summary>
        public UserVM User
        {
            get { return new UserVM(_customer.User); }
        }

        /// <summary>
        /// Gets a list of selected merchandise to buy.
        /// </summary>
        public ObservableCollection<MerchandiseVM> SelectedMerchandise
        {
            get
            {
                var res = new ObservableCollection<MerchandiseVM>();
                foreach (CustomerSelectedItemsVM si in CSIs)
                    res.Add(si.SDM.Merchendise);
                return (ObservableCollection<MerchandiseVM>)res.Distinct();
            }
        }

        /// <summary>
        /// Gets or sets a list of CustomerSelectedItems where all information about merchandise and salesperson is stored.
        /// </summary>
        public ObservableCollection<CustomerSelectedItemsVM> CSIs
        {
            get { return (ObservableCollection<CustomerSelectedItemsVM>)(from csi in _customer.CSIs select new CustomerSelectedItemsVM(csi)); }
            //set { _customer.CSIs = }
        }

        /// <summary>
        /// Method updates list of customer selected items.
        /// </summary>
        public void UpdateCSI()
        {
            _customer.CSIs = new List<CustomerSelectedItems>();
            _customer.CSIs = CustomerSelectedItemsMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("CustomerSelectedItems", MethodType.GetByQuery, "CustomerID='" + this.ID + "'", Guid.Empty));
        }

        /// <summary>
        /// Method saves Customer.
        /// </summary>
        public void Save()
        {
            MarketProxy.Proxy.UpdateOne(CustomerMapper.Mapper.Pack(this._customer), Middleware.UpdateType.Save);
            if (CSIs != null)
            {
                // here we need access to csi through csiVM to save a list at once, insted foreach and one by one.
                foreach (CustomerSelectedItemsVM csi in CSIs)
                {
                    csi.IsNew = false;
                    csi.Save();
                }
            }
        }

        /// <summary>
        /// Method compares two instance of a Customer class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            CustomerVM c = obj as CustomerVM;
            if (c == null) return false;
            if (c.ID == ID &&
                c.UserID == UserID) return true;
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
        /// <returns>First and Last Names of a Customer.</returns>
        public override string ToString()
        { return FirstName + " " + LastName; }

    }
}