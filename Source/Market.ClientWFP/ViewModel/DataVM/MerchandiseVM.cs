// --------------------------------------------------------------------------
// <copyright file="Merchandise.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Linq;
using Command.ViewModel.Base;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents Merchandise.
    /// </summary>
    public class MerchandiseVM : BaseVM
    {
        private Merchandise _merchandise;

        /// <summary>
        /// Ctor for creating new Merchandise.
        /// </summary>
        /// <param name="storageVMId">Storage Id, where a current merchandise is located.</param>
        public MerchandiseVM(Guid storageVMId)
        {
            _merchandise = new Merchandise(storageVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of MerchandiseVM by instance of Merchandise.
        /// </summary>
        /// <param name="m">Instance of Merchandise.</param>
        public MerchandiseVM(Merchandise m)
        {
            _merchandise = m;
        }

        /// <summary>
        /// Ctor for recreating Merchandise from database.
        /// </summary>
        /// <param name="id">Id of Merchandise in database.</param>
        /// <param name="storageVMId">Storage Id, where a current merchandise is located.</param>
        public MerchandiseVM(Guid id, Guid storageVMId)
        {
            _merchandise = new Merchandise(id, storageVMId);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _merchandise.ID; } }

        /// <summary>
        /// Gets or sets a name of merchandise.
        /// </summary>
        public string Name
        {
            get { return _merchandise.Name; }
            set
            {
                if (value == _merchandise.Name)
                    return;

                _merchandise.Name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets a cost of merchandise.
        /// </summary>
        public float Cost
        {
            get { return _merchandise.Cost; }
            set
            {
                if (value == _merchandise.Cost)
                    return;

                _merchandise.Cost = value;
                OnPropertyChanged("Cost");
            }
        }

        /// <summary>
        /// Gets all tags current merchandise is assigned to.
        /// </summary>
        public string Tags
        {
            get
            {
                var res = string.Empty;
                foreach (CategoryVM c in Categories)
                    res += " #" + c.Name;
                return res;
            }
        }

        /// <summary>
        /// Gets a storage current merchandise is stored.
        /// </summary>
        public StorageVM Storage
        {
            get { return new StorageVM(_merchandise.Storage); }
            //StorageMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Storage", Middleware.MethodType.GetById, string.Empty, _storageId)[0]); }
        }

        /// <summary>
        /// Gets storage id.
        /// </summary>
        public Guid StorageID { get { return _merchandise.StorageID; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _merchandise.IsNew; } }

        /// <summary>
        /// Gets a list of all dealers who sells current merchandise.
        /// </summary>
        public ObservableCollection<DealerVM> Dealers
        {
            get
            {
                var dms = DMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("DM", Middleware.MethodType.GetByQuery, "MerchandiseID='" + this.ID + "'", Guid.Empty));
                return (ObservableCollection<DealerVM>)(from dm in dms.AsEnumerable()
                                                        select new DealerVM(dm.Dealer));
            }
        }

        /// <summary>
        /// Gets a list og all categories current merchandise is assigned to.
        /// </summary>
        public ObservableCollection<CategoryVM> Categories
        {
            get
            {
                var mcs = MerchandiseCategoryMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("MerchandiseCategory", Middleware.MethodType.GetByQuery, "MerchandiseID='" + this.ID + "'", Guid.Empty));
                return (ObservableCollection<CategoryVM>)(from mc in mcs.AsEnumerable()
                                                          where mc.Merchandise.ID == this.ID
                                                          select new CategoryVM(mc.Category));
            }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(MerchandiseMapper.Mapper.Pack(this._merchandise), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of Merchandise class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            Merchandise m = obj as Merchandise;
            if (m == null) return false;
            if (m.ID == ID) return true;
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