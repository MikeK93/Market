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
using System.Text;
using System.Threading.Tasks;
using Market.Core;
using Market.Readers;

namespace Market.Entities
{
    /// <summary>
    /// Class represents a Customer.
    /// </summary>
    [DataContract]
    public class Customer
    {
        private Guid _id;

        private Guid _uId;

        private bool _isNew;

        /// <summary>
        /// Ctor for creating new customer.
        /// </summary>
        /// <param name="userId">User's id attached to current customer.</param>
        public Customer(Guid userId)
        {
            _isNew = true;
            _id = Guid.NewGuid();
            _uId = userId;
        }

        /// <summary>
        /// Ctor for recreating customer from database.
        /// </summary>
        /// <param name="id">Id of current customer in database.</param>
        /// <param name="userId">User's id attached to current customer.</param>
        public Customer(Guid id, Guid userId)
        {
            _isNew = false;
            _id = id;
            _uId = userId;
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
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return this._uId; } }

        /// <summary>
        /// Gets or sets a first name of a current customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a middle name of a current customer.
        /// </summary>
        public string MiddaleName { get; set; }

        /// <summary>
        /// Gets or sets a last name of a current customer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets an email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets gender of a current customer.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Gets or sets age of a current customer.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets a value indicating whether the Customer is new.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return _isNew;
            }
            set { _isNew = value; }
        }

        /// <summary>
        /// Gets or sets a user profile attached to current customer.
        /// </summary>
        public User User
        {
            get
            {
                return (_uId == Guid.Empty) ? null : UserReader.Reader.GetById(_uId)[0];
            }

            set
            {
                _uId = (value == null) ? Guid.Empty : value.ID;
            }
        }

        /// <summary>
        /// Gets a list of selected merchandise to buy.
        /// </summary>
        public List<Merchandise> SelectedMerchandise
        {
            get
            {
                var res = new List<Merchandise>();
                foreach (CustomerSelectedItems si in CSIs)
                    res.Add(si.SDM.Merchendise);
                return res.Distinct().ToList();
            }
        }

        /// <summary>
        /// Gets or sets a list of CustomerSelectedItems where all information about merchandise and salesperson is stored.
        /// </summary>
        public List<CustomerSelectedItems> CSIs { get; set; }

        /// <summary>
        /// Method saves Customer.
        /// </summary>
        public void Save()
        {
            CustomerReader.Reader.Save(this, this.IsNew);
            if (CSIs != null)
            {
                foreach (CustomerSelectedItems csi in CSIs)
                {
                    CustomerSelectedItemsReader.Reader.Save(csi, csi.IsNew);
                    csi.IsNew = false;
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
            Customer c = obj as Customer;
            if (c == null) return false;
            if (c.ID == ID &&
                c.FirstName == FirstName &&
                c.MiddaleName == MiddaleName &&
                c.LastName == LastName &&
                c.Age == Age &&
                c.Gender == Gender &&
                c.User == User) return true;
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