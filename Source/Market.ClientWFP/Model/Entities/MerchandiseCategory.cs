// --------------------------------------------------------------------------
// <copyright file="MerchandiseCategory.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using Market.Model;
using Market.Model.Mappers;

namespace Market.Model.Entities
{
    /// <summary>
    /// Class represents a relation between Merchandise and Category.
    /// </summary>
    public class MerchandiseCategory
    {
        private bool _isNew = false;

        private Guid _id;

        private Guid _mId;

        private Guid _cId;

        /// <summary>
        /// Custom constructor for creating new Merchandise-Category relation.
        /// </summary>
        /// <param name="merchandiseId">Merchandise ID.</param>
        /// <param name="categoryId">Category ID.</param>
        public MerchandiseCategory(Guid merchandiseId, Guid categoryId)
        {
            _isNew = true;
            _id = Guid.NewGuid();
            _mId = merchandiseId;
            _cId = categoryId;
        }

        /// <summary>
        /// Custom constructor for recreating Merchandise-Category from database.
        /// </summary>
        /// <param name="id">ID of a relation.</param>
        /// <param name="merchandiseId">ID of merchandise.</param>
        /// <param name="categoryId">ID of a category.</param>
        public MerchandiseCategory(Guid id, Guid merchandiseId, Guid categoryId)
        {
            _isNew = false;
            _id = id;
            _mId = merchandiseId;
            _cId = categoryId;
        }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _isNew; } }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _id; } }

        /// <summary>
        /// Gets merchandise.
        /// </summary>
        public Merchandise Merchandise { get { return MerchandiseMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Merchandise", Middleware.MethodType.GetById, string.Empty, _mId)[0]); } }

        /// <summary>
        /// Gets Merchandise id.
        /// </summary>
        public Guid MerchandiseID { get { return _mId; } }

        /// <summary>
        /// Gets a category.
        /// </summary>
        public Category Category { get { return CategoryMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Category", Middleware.MethodType.GetById, string.Empty, _cId)[0]); } }

        /// <summary>
        /// Gets Category id.
        /// </summary>
        public Guid CategoryID { get { return _cId; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(MerchandiseCategoryMapper.Mapper.Pack(this), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of a MerchandiseCategory class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            MerchandiseCategory mc = obj as MerchandiseCategory;
            if (mc == null) return false;
            if (mc.ID == ID &&
                mc.MerchandiseID == MerchandiseID &&
                mc.CategoryID == CategoryID) return true;
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
        /// <returns>Name of Merchandise and its Cost.</returns>
        public override string ToString()
        { return Merchandise.Name + " is " + Category.Name; }
    }
}