// --------------------------------------------------------------------------
// <copyright file="Storage.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using Command.ViewModel.Base;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a Storage.
    /// </summary>
    public class StorageVM : BaseVM
    {
        private Storage _storage;

        /// <summary>
        /// Ctor for creating a new Storage.
        /// </summary>
        public StorageVM()
        {
            _storage = new Storage();
        }

        /// <summary>
        /// Ctor for creating new instance of StorageVM by instance of Storage.
        /// </summary>
        /// <param name="storage">Instance of Storage.</param>
        public StorageVM(Storage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Ctor for recreating a Storage from database.
        /// </summary>
        /// <param name="id">Id of a storage in database.</param>
        public StorageVM(Guid id)
        {
            _storage = new Storage(id);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _storage.ID; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _storage.IsNew; } }

        /// <summary>
        /// Gets or sets an address of storage.
        /// </summary>
        public string Address
        {
            get { return _storage.Address; }
            set
            {
                if (value == _storage.Address)
                    return;

                _storage.Address = value;
                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets a list of all merchandise stored at current storage.
        /// </summary>
        public ObservableCollection<MerchandiseVM> AllMerchandise
        {
            get { return (ObservableCollection<MerchandiseVM>)(from m in _storage.AllMerchandise select new MerchandiseVM(m)); }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(StorageMapper.Mapper.Pack(this._storage), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of a Storage class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            StorageVM s = obj as StorageVM;
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