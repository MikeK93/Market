// --------------------------------------------------------------------------
// <copyright file="Category.cs" company="MK inc.">
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
    /// Class represents a category of merchandise.
    /// </summary>
    [DataContract]
    public class Category
    {
        private Guid _id;

        private bool _isNew = false;

        /// <summary>
        /// Default constructor for creating new category.
        /// </summary>
        public Category()
        {
            _isNew = true;
            _id = Guid.NewGuid();
        }

        /// <summary>
        /// Custom constructor for recreating category from database.
        /// </summary>
        /// <param name="id">ID of a category in database.</param>
        public Category(Guid id, string name)
        {
            _isNew = false;
            Name = name;
            _id = id;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        [DataMember]
        public Guid ID
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Gets a name of the current category.
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the relation Bank-Salesperson is new.
        /// </summary>
        [DataMember]
        public bool IsNew
        {
            get
            {
                return _isNew;
            }
        }

        /// <summary>
        /// Gets all Merchandise-Category relations.
        /// </summary>
        [DataMember]
        public List<MerchandiseCategory> MCs
        {
            get
            {
                return MerchandiseCategoryReader.Reader.GetByQuery("CategoryID=" + this.ID + "'");
            }
        }

        /// <summary>
        /// Method saves Category.
        /// </summary>
        public void Save()
        { CategoryReader.Reader.Save(this, this._isNew); }

        /// <summary>
        /// Method deletes Category.
        /// </summary>
        public void Delete()
        { CategoryReader.Reader.Delete(this); }

        /// <summary>
        /// Method compares two instance of a Category class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            Category c = obj as Category;
            if (c == null) return false;
            if (c.ID == ID &&
                c.Name == Name &&
                c.MCs == MCs) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Display text representstion of a Category class.
        /// </summary>
        /// <returns>Name of a category.</returns>
        public override string ToString()
        { return Name; }
    }
}