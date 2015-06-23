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
using Market.Mappers;
using Market.Readers;

namespace Market.Entities
{
    /// <summary>
    /// Class represents a dealer.
    /// </summary>
    [DataContract]
    public class Dealer
    {
        private Guid _userId;

        private bool _isNew = false;

        /// <summary>
        /// Custom constructor for recreating dealer from database.
        /// </summary>
        /// <param name="id">ID of a dealer in database.</param>
        /// <param name="userId">ID of a user attached to this dealer.</param>
        public Dealer(Guid id, Guid userId)
        {
            ID = id;
            _userId = userId;
            _isNew = false;
        }

        /// <summary>
        /// Custom constructor for creating new dealer.
        /// </summary>
        /// <param name="userId">User profile attached to a dealer.</param>
        public Dealer(Guid userId)
        {
            this.ID = Guid.NewGuid();
            _userId = userId;
            _isNew = true;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return this._userId; } }

        /// <summary>
        /// Gets or sets a first name of a current dealer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a middle name of a current dealer.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets a last name of a current dealer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a Gender of a current dealer.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Gets or sets a phone number of a current dealer.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets an email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets a value indicating whether the Dealer is new.
        /// </summary>
        public bool IsNew
        { get { return _isNew; } }

        /// <summary>
        /// Gets User attached to current dealer.
        /// </summary>
        public User User
        {
            get
            {
                return UserReader.Reader.GetById(_userId)[0];
            }
        }

        /// <summary>
        /// Gets or sets all merchandise that available for clients.
        /// </summary>
        public List<Merchandise> AllMerchandise { get; set; }

        /// <summary>
        /// Gets all banks current dealer is using.
        /// </summary>
        public List<Bank> Banks
        {
            get
            {
                var res = (from b in BankDealerReader.Reader.GetByQuery("DealerID='" + ID + "'").AsEnumerable()
                           select b.Bank).ToList();
                return res;
            }
        }

        /// <summary>
        /// Gets all Dealer-Merchandise relations.
        /// </summary>
        public List<DM> DMs
        { get { return DMReader.Reader.GetByQuery("DealerID='" + this.ID + "'"); } }

        /// <summary>
        /// Saves changes.
        /// </summary>
        public void Save()
        {
            DealerReader.Reader.Save(this, _isNew);
            if (DMs.Count > 0)
            {
                foreach (DM dm in DMs)
                    dm.Save();
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
            if (d.ID == ID && d.FirstName == FirstName && d.LastName == LastName && d.MiddleName == MiddleName && d.PhoneNumber == PhoneNumber) return true;
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