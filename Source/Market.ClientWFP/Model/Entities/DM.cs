// --------------------------------------------------------------------------
// <copyright file="DM.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Market.Model;
using Market.Model.Mappers;
using Market.Middleware;

namespace Market.Model.Entities
{
    /// <summary>
    /// Class represents a relation between Dealer and Merchandise.
    /// </summary>
    public class DM
    {
        private Guid _id;

        private Guid _dealerId;

        private Guid _merchandiseId;

        private bool _isNew = false;

        /// <summary>
        /// Custom constructor for recreating Dealer-Merchandise relation from the database.
        /// </summary>
        /// <param name="id">Id of an entity DealerMerchandise.</param>
        /// <param name="dId">Id of a dealer.</param>
        /// <param name="mId">Id of merchandise.</param>
        public DM(Guid id, Guid dId, Guid mId)
        {
            _id = id;
            _dealerId = dId;
            _merchandiseId = mId;
            _isNew = false;
        }

        /// <summary>
        /// Custom constructor for creating new Dealer-Merchandise relation.
        /// </summary>
        /// <param name="dId">Id of a dealer.</param>
        /// <param name="mId">Id of merchandise.</param>
        public DM(Guid dId, Guid mId)
        {
            _id = Guid.NewGuid();
            _dealerId = dId;
            _merchandiseId = mId;
            _isNew = true;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Gets a dealer.
        /// </summary>
        public Dealer Dealer { get { return DealerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Dealer", MethodType.GetById, string.Empty, _dealerId)[0]); } }

        /// <summary>
        /// Gets Dealer id.
        /// </summary>
        public Guid DealerID { get { return _dealerId; } }

        /// <summary>
        /// Gets merchandise.
        /// </summary>
        public Merchandise Merchandise { get { return MerchandiseMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Merchandise", Middleware.MethodType.GetById, string.Empty, _merchandiseId)[0]); } }

        /// <summary>
        /// Gets Merchandise id.
        /// </summary>
        public Guid MerchandiseID { get { return _merchandiseId; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return _isNew;
            }

            set
            {
                _isNew = value;
            }
        }

        /// <summary>
        /// Gets or sets a cost for merchandise by dealer.
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            MarketProxy.Proxy.UpdateOne(DMMapper.Mapper.Pack(this), Middleware.UpdateType.Save);
            this.IsNew = false;
        }

        /// <summary>
        /// Method deletes Dealer-Merchandise relation.
        /// </summary>
        public void Delete()
        {
            MarketProxy.Proxy.UpdateOne(DMMapper.Mapper.Pack(this), Middleware.UpdateType.Delete);
        }

        /// <summary>
        /// Method compares two instance of a Dealer-Merchandise class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            DM dm = obj as DM;
            if (dm == null) return false;
            if (dm.ID == ID &&
                dm.DealerID == DealerID &&
                dm.MerchandiseID == MerchandiseID &&
                dm.Cost == Cost) return true;
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
        /// <returns>First name of a dealer, merchandise' name and cost by dealer.</returns>
        public override string ToString()
        { return string.Format("{0} ({1} ${2})", Dealer.LastName, Merchandise.Name, Cost); }
    }
}