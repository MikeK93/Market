// --------------------------------------------------------------------------
// <copyright file="MerchandiseCategory.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Linq;
using Command.ViewModel.Base;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a relation between Merchandise and Category.
    /// </summary>
    public class MerchandiseCategoryVM : BaseVM
    {
        private MerchandiseCategory _merchandiseCategory;

        /// <summary>
        /// Custom constructor for creating new Merchandise-Category relation.
        /// </summary>
        /// <param name="merchandiseVMId">Merchandise ID.</param>
        /// <param name="categoryVMId">Category ID.</param>
        public MerchandiseCategoryVM(Guid merchandiseVMId, Guid categoryVMId)
        {
            _merchandiseCategory = new MerchandiseCategory(merchandiseVMId, categoryVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of MerchandiseCategoryVM by instance of MerchandiseCategory.
        /// </summary>
        /// <param name="mc">Instance of MerchandiseCategory.</param>
        public MerchandiseCategoryVM(MerchandiseCategory mc)
        {
            _merchandiseCategory = mc;
        }

        /// <summary>
        /// Custom constructor for recreating Merchandise-Category from database.
        /// </summary>
        /// <param name="id">ID of a relation.</param>
        /// <param name="merchandiseVMId">ID of merchandise.</param>
        /// <param name="categoryVMId">ID of a category.</param>
        public MerchandiseCategoryVM(Guid id, Guid merchandiseVMId, Guid categoryVMId)
        {
            _merchandiseCategory = new MerchandiseCategory(id, merchandiseVMId, categoryVMId);
        }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _merchandiseCategory.IsNew; } }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _merchandiseCategory.ID; } }

        /// <summary>
        /// Gets merchandise.
        /// </summary>
        public MerchandiseVM Merchandise
        {
            get { return new MerchandiseVM(_merchandiseCategory.Merchandise); }
            //MerchandiseMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Merchandise", Middleware.MethodType.GetById, string.Empty, _mId)[0]); }
        }

        /// <summary>
        /// Gets Merchandise id.
        /// </summary>
        public Guid MerchandiseID { get { return _merchandiseCategory.MerchandiseID; } }

        /// <summary>
        /// Gets a category.
        /// </summary>
        public CategoryVM Category
        {
            get { return new CategoryVM(_merchandiseCategory.Category); }
            //CategoryMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Category", Middleware.MethodType.GetById, string.Empty, _cId)[0]); }
        }

        /// <summary>
        /// Gets Category id.
        /// </summary>
        public Guid CategoryID { get { return _merchandiseCategory.CategoryID; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(MerchandiseCategoryMapper.Mapper.Pack(this._merchandiseCategory), Middleware.UpdateType.Save); }

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