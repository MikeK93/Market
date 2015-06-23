// --------------------------------------------------------------------------
// <copyright file="Category.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Command.ViewModel.Base;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a category of merchandise.
    /// </summary>
    public class CategoryVM : BaseVM
    {
        private Category _category;

        /// <summary>
        /// Default constructor for creating new category.
        /// </summary>
        public CategoryVM()
        {
            _category = new Category();
        }

        /// <summary>
        /// Ctor for creating new instance of CategoryVM by instance of Category.
        /// </summary>
        /// <param name="c">Instance of Category.</param>
        public CategoryVM(Category c)
        {
            _category = c;
        }

        /// <summary>
        /// Custom constructor for recreating category from database.
        /// </summary>
        /// <param name="id">ID of a category in database.</param>
        public CategoryVM(Guid id, string name)
        {
            _category = new Category(id, name);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get
            {
                return _category.ID;
            }
        }

        /// <summary>
        /// Gets a name of the current category.
        /// </summary>
        public string Name { get { return _category.Name; } }

        /// <summary>
        /// Gets a value indicating whether the relation Bank-Salesperson is new.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return _category.IsNew;
            }
        }

        /// <summary>
        /// Gets all Merchandise-Category relations.
        /// </summary>
        public ObservableCollection<MerchandiseCategoryVM> MCs
        {
            get
            {
                return (ObservableCollection<MerchandiseCategoryVM>)(from mc in MerchandiseCategoryMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("MerchandiseCategory", Middleware.MethodType.GetByQuery, "CategoryID=" + this.ID + "'", Guid.Empty)).AsEnumerable()
                                                                     select new MerchandiseCategoryVM(mc));
            }
        }

        /// <summary>
        /// Method saves Category.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(CategoryMapper.Mapper.Pack(this._category), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method deletes Category.
        /// </summary>
        public void Delete()
        { MarketProxy.Proxy.UpdateOne(CategoryMapper.Mapper.Pack(this._category), Middleware.UpdateType.Delete); }

        /// <summary>
        /// Method compares two instance of a Category class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            CategoryVM c = obj as CategoryVM;
            if (c == null)
                return false;

            if (c.ID == ID)
                return true;

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