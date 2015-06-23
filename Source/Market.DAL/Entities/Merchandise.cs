// --------------------------------------------------------------------------
// <copyright file="Merchandise.cs" company="MK inc.">
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
    /// Class represents Merchandise.
    /// </summary>
    [DataContract]
    public class Merchandise
    {
        private bool _isNew = false;

        private Guid _id;

        private Guid _storageId;

        /// <summary>
        /// Ctor for creating new Merchandise.
        /// </summary>
        /// <param name="storageId">Storage Id, where a current merchandise is located.</param>
        public Merchandise(Guid storageId)
        {
            _id = Guid.NewGuid();
            _storageId = storageId;
            _isNew = true;
        }

        /// <summary>
        /// Ctor for creating new Merchandise.
        /// </summary>
        /// <param name="storageId">Storage Id, where a current merchandise is located.</param>
        public Merchandise(Guid id, Guid storageId, bool isNew) :
            this(id, storageId)
        { _isNew = isNew; }

        /// <summary>
        /// Ctor for recreating Merchandise from database.
        /// </summary>
        /// <param name="id">Id of Merchandise in database.</param>
        /// <param name="storageId">Storage Id, where a current merchandise is located.</param>
        public Merchandise(Guid id, Guid storageId)
        {
            _id = id;
            _storageId = storageId;
            _isNew = false;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _id; } }

        /// <summary>
        /// Gets id of storage.
        /// </summary>
        public Guid StorageID { get { return this._storageId; } }

        /// <summary>
        /// Gets or sets a name of merchandise.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a cost of merchandise.
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Gets all tags current merchandise is assigned to.
        /// </summary>
        public string Tags
        {
            get
            {
                var res = string.Empty;
                foreach (Category c in Categories)
                    res += " #" + c.Name;
                return res;
            }
        }

        /// <summary>
        /// Gets a list of all dealers who sells current merchandise.
        /// </summary>
        public List<Dealer> Dealers
        {
            get
            {
                var d = new List<Dealer>();

                var dIds = DMReader.Reader.GetByQuery("MerchandiseID='" + this.ID + "'");
                foreach (DM dm in dIds)
                    d.Add(dm.Dealer);

                return d;
            }
        }

        /// <summary>
        /// Gets a list og all categories current merchandise is assigned to.
        /// </summary>
        public List<Category> Categories
        {
            get
            {
                string q = "MerchandiseID='" + this.ID + "'";
                var res = from mc in MerchandiseCategoryReader.Reader.GetByQuery(q).AsEnumerable()
                          where mc.Merchandise.ID == this.ID
                          select mc.Category;
                return res.ToList();
            }
        }

        /// <summary>
        /// Gets a storage current merchandise is stored.
        /// </summary>
        public Storage Storage
        { get { return StorageReader.Reader.GetById(_storageId)[0]; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _isNew; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            MerchandiseReader.Reader.Save(this, _isNew);
            _isNew = false;
        }

        /// <summary>
        /// Method deletes current item.
        /// </summary>
        public void Delete()
        { MerchandiseReader.Reader.Delete(this); }

        /// <summary>
        /// Method compares two instance of Merchandise class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            Merchandise m = obj as Merchandise;
            if (m == null) return false;
            if (m.ID == ID && m.Name == Name && m.Cost == Cost) return true;
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
        /// <returns>Name of Merchandise.</returns>
        public override string ToString()
        { return Name; }
    }
}