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
using Market.Model;
using Market.Model.Mappers;

namespace Market.Model.Entities
{
    /// <summary>
    /// Class represents Merchandise.
    /// </summary>
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
        /// Ctor for creating new merhcandise.
        /// </summary>
        public Merchandise()
        {
            _id = Guid.NewGuid();
            _storageId = Guid.Parse("e229e836-3b70-4afc-81ed-d24e89a380f7");
            _isNew = true;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _id; } }

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
                var dms = DMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("DM", Middleware.MethodType.GetByQuery, "MerchandiseID='" + this.ID + "'", Guid.Empty));
                return (from dm in dms.AsEnumerable() select dm.Dealer).ToList();
            }
        }

        /// <summary>
        /// Gets a list og all categories current merchandise is assigned to.
        /// </summary>
        public List<Category> Categories
        {
            get
            {
                var mcs = MerchandiseCategoryMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("MerchandiseCategory", Middleware.MethodType.GetByQuery, "MerchandiseID='" + this.ID + "'", Guid.Empty));
                return (from mc in mcs.AsEnumerable() select mc.Category).ToList();
            }
        }

        /// <summary>
        /// Gets a storage current merchandise is stored.
        /// </summary>
        public Storage Storage { get { return StorageMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Storage", Middleware.MethodType.GetById, string.Empty, _storageId)[0]); } }

        /// <summary>
        /// Gets storage id.
        /// </summary>
        public Guid StorageID { get { return _storageId; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _isNew; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            MarketProxy.Proxy.UpdateOne(MerchandiseMapper.Mapper.Pack(this), Middleware.UpdateType.Save);
            _isNew = false;
        }

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