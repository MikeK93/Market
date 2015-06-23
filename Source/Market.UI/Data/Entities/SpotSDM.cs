// --------------------------------------------------------------------------
// <copyright file="SpotSDM.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Market.Data;
using Market.Data.Mappers;

namespace Market.Data.Entities
{
    /// <summary>
    /// Class represents a relation between Spot and Salesperson-Dealer-Merchandise.
    /// </summary>
    [DataContract]
    public class SpotSDM
    {
        private Guid _id;

        private Guid _sId;

        private Guid _sdmId;

        private bool _isNew;

        /// <summary>
        /// Ctor for creating new Spot-SalespersonDealerMerchandise relation.
        /// </summary>
        /// <param name="spotId">Spot Id.</param>
        /// <param name="sdmId">SalespersonDealerMerchandise Id.</param>
        public SpotSDM(Guid spotId, Guid sdmId)
        {
            _isNew = true;
            _id = Guid.NewGuid();
            _sId = spotId;
            _sdmId = sdmId;
        }

        /// <summary>
        /// Ctor for recreating Spot-SalespersonDealerMerchandise relation from database.
        /// </summary>
        /// <param name="id">Id of SpotSDM in database.</param>
        /// <param name="spotId">Spot Id.</param>
        /// <param name="sdmId">SalespersonDealerMerchandise Id.</param>
        public SpotSDM(Guid id, Guid spotId, Guid sdmId)
        {
            _isNew = false;
            _id = id;
            _sId = spotId;
            _sdmId = sdmId;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _id; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _isNew; } }

        /// <summary>
        /// Gets a spot.
        /// </summary>
        public Spot Spot { get { return SpotMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Spot", Middleware.MethodType.GetById, string.Empty, _sId)[0]); } }

        /// <summary>
        /// Gets spot id.
        /// </summary>
        public Guid SpotID { get { return _sId; } }

        /// <summary>
        /// Gets Salesperons-Dealer-Merchandise relation.
        /// </summary>
        public SDM SDM { get { return SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", Middleware.MethodType.GetById, string.Empty, _sdmId)[0]); } }

        /// <summary>
        /// Gets Salesperons-Dealer-Merchandise relation id.
        /// </summary>
        public Guid SDMID { get { return _sdmId; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(SpotSDMMapper.Mapper.Pack(this), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of a SpotSDM class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            SpotSDM ssdm = obj as SpotSDM;
            if (ssdm == null) return false;
            if (ssdm.ID == ID &&
                ssdm.SpotID == SpotID &&
                ssdm.SDMID == SDMID) return true;
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
        /// <returns>Spot Number, Salesperson, Dealer and Merchandise.</returns>
        public override string ToString()
        { return "[" + Spot.Number + "] " + SDM.Salesperson + "," + SDM.DealerMerchandise; }
    }
}