// --------------------------------------------------------------------------
// <copyright file="SpotSDM.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Linq;
using System.Runtime.Serialization;
using Command.ViewModel.Base;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a relation between Spot and Salesperson-Dealer-Merchandise.
    /// </summary>
    public class SpotSDMVM : BaseVM
    {
        private SpotSDM _spotSDM;

        /// <summary>
        /// Ctor for creating new Spot-SalespersonDealerMerchandise relation.
        /// </summary>
        /// <param name="spotId">Spot Id.</param>
        /// <param name="sdmId">SalespersonDealerMerchandise Id.</param>
        public SpotSDMVM(Guid spotId, Guid sdmId)
        {
            _spotSDM = new SpotSDM(spotId, sdmId);
        }

        /// <summary>
        /// Ctor for creating new instance of SpotSDMVM by instance of SpotSDM.
        /// </summary>
        /// <param name="spotSDM">Instance of SpotSDM.</param>
        public SpotSDMVM(SpotSDM spotSDM)
        {
            _spotSDM = spotSDM;
        }

        /// <summary>
        /// Ctor for recreating Spot-SalespersonDealerMerchandise relation from database.
        /// </summary>
        /// <param name="id">Id of SpotSDM in database.</param>
        /// <param name="spotId">Spot Id.</param>
        /// <param name="sdmId">SalespersonDealerMerchandise Id.</param>
        public SpotSDMVM(Guid id, Guid spotId, Guid sdmId)
        {
            _spotSDM = new SpotSDM(id, spotId, sdmId);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _spotSDM.ID; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _spotSDM.IsNew; } }

        /// <summary>
        /// Gets a spot.
        /// </summary>
        public SpotVM Spot
        {
            get { return new SpotVM(_spotSDM.Spot); }
        }

        /// <summary>
        /// Gets spot id.
        /// </summary>
        public Guid SpotID { get { return _spotSDM.SpotID; } }

        /// <summary>
        /// Gets Salesperons-Dealer-Merchandise relation.
        /// </summary>
        public SDMVM SDM
        {
            get { return new SDMVM(_spotSDM.SDM); }
        }

        /// <summary>
        /// Gets Salesperons-Dealer-Merchandise relation id.
        /// </summary>
        public Guid SDMID { get { return _spotSDM.SDMID; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(SpotSDMMapper.Mapper.Pack(this._spotSDM), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of a SpotSDM class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            SpotSDMVM ssdm = obj as SpotSDMVM;
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