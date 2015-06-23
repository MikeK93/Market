// --------------------------------------------------------------------------
// <copyright file="Storage.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Market.Readers;

namespace Market.Entities
{
    /// <summary>
    /// Class represents a Storage.
    /// </summary>
    [DataContract]
    public class Storage
    {
        private bool _isNew = false;

        /// <summary>
        /// Ctor for creating a new Storage.
        /// </summary>
        public Storage()
        {
            _isNew = true;
            ID = Guid.NewGuid();
        }

        /// <summary>
        /// Ctor for recreating a Storage from database.
        /// </summary>
        /// <param name="id">Id of a storage in database.</param>
        public Storage(Guid id)
        {
            _isNew = false;
            ID = id;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        [DataMember]
        public Guid ID { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        [DataMember]
        public bool IsNew { get { return _isNew; } }

        /// <summary>
        /// Gets or sets an address of storage.
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Gets a list of all merchandise stored at current storage.
        /// </summary>
        [DataMember]
        public List<Merchandise> Merchandise
        {
            get
            {
                var res = (from m in MerchandiseReader.Reader.GetByQuery("StorageID='" + ID + "'").AsEnumerable()
                           select m).ToList();
                return res;
            }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { StorageReader.Reader.Save(this, this._isNew); }

        /// <summary>
        /// Method compares two instance of a Storage class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            Storage s = obj as Storage;
            if (s == null) return false;
            if (s.ID == ID && s.Address == Address) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Shows string representation of class.
        /// </summary>
        /// <returns>Address of a storage.</returns>
        public override string ToString()
        { return Address; }
    }
}