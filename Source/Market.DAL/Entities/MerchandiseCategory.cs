// --------------------------------------------------------------------------
// <copyright file="MerchandiseCategory.cs" company="MK inc.">
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
using Market.Readers;

namespace Market.Entities
{
    /// <summary>
    /// Class represents a relation between Merchandise and Category.
    /// </summary>
    [DataContract]
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
        /// Constructor for creating new Merchandise-Category.
        /// </summary>
        /// <param name="id">ID of a relation.</param>
        /// <param name="merchandiseId">ID of merchandise.</param>
        /// <param name="categoryId">ID of a category.</param>
        /// <param name="isNew">Defines if instance new or not.</param>
        public MerchandiseCategory(Guid id, Guid merchandiseId, Guid categoryId, bool isNew)
            : this(id, merchandiseId, categoryId)
        { _isNew = isNew; }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _isNew; } }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _id; } }

        /// <summary>
        /// Gets id of merchandise.
        /// </summary>
        public Guid MerchandiseID { get { return this._mId; } }

        /// <summary>
        /// Gets id of category.
        /// </summary>
        public Guid CategoryID { get { return this._cId; } }

        /// <summary>
        /// Gets merchandise.
        /// </summary>
        public Merchandise Merchandise { get { return MerchandiseReader.Reader.GetById(_mId)[0]; } }

        /// <summary>
        /// Gets a category.
        /// </summary>
        public Category Category { get { return CategoryReader.Reader.GetById(_cId)[0]; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MerchandiseCategoryReader.Reader.Save(this, this.IsNew); }

        /// <summary>
        /// Method deletes current item.
        /// </summary>
        public void Delete()
        { MerchandiseCategoryReader.Reader.Delete(this); }

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
                mc.Merchandise == Merchandise &&
                mc.Category == Category) return true;
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