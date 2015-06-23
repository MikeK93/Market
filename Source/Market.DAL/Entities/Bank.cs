// --------------------------------------------------------------------------
// <copyright file="Bank.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

namespace Market.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class represents a bank.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// The field indicates ID of a bank.
        /// </summary>
        private Guid _id;

        /// <summary>
        /// The field indicates whether current bank is new.
        /// </summary>
        private bool _isNew = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class.
        /// </summary>
        /// <param name="id">ID of a bank in database.</param>
        public Bank(Guid id)
        {
            _id = id;
            _isNew = false;
        }

        /// <summary>
        /// Gets ID of a bank.
        /// </summary>
        public Guid ID
        {
            get { return this._id; }
        }

        /// <summary>
        /// Gets or sets a bank's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a bank's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets a value indicating whether current bank is new.
        /// </summary>
        public bool IsNew
        {
            get { return this._isNew; }
        }

        /// <summary>
        /// Gets or sets a list of all dealers using current bank.
        /// </summary>
        public List<Dealer> Dealers { get; set; }

        /// <summary>
        /// Gets or sets a list of all salespersons using current bank.
        /// </summary>
        public List<Salesperson> Salespersons { get; set; }

        /// <summary>
        /// Method saves a relation between current bank and salesperson.
        /// </summary>
        /// <param name="salesperson">Salesperson to relate to current bank.</param>
        public void Save(Salesperson salesperson)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method deletes a relation between current bank and salesperson.
        /// </summary>
        /// <param name="salesperson">Salesperson to delete.</param>
        public void Delete(Salesperson salesperson)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method saves a relation between current bank and dealer.
        /// </summary>
        /// <param name="dealer">Dealer to relate to current bank.</param>
        public void Save(Dealer dealer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method deletes a relation between current bank and dealer.
        /// </summary>
        /// <param name="dealer">Dealer to delete.</param>
        public void Delete(Dealer dealer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method equals two instance of a bank class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current bank object.</returns>
        public override bool Equals(object obj)
        {
            Bank b = obj as Bank;
            if (b == null)
            {
                return false;
            }

            if (b.ID == ID && b.Name == Name && b.Address == Address)
            {
                return true;
            }

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