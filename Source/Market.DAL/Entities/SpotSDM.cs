// --------------------------------------------------------------------------
// <copyright file="SpotSDM.cs" company="MK inc.">
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
        /// Gets id of spot.
        /// </summary>
        public Guid SpotID { get { return this._sId; } }

        /// <summary>
        /// Gets id of a relation salesperon-dealer-merchandise.
        /// </summary>
        public Guid SDMID { get { return this._sdmId; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        /// <summary>
        /// Gets a spot.
        /// </summary>
        public Spot Spot { get { return SpotReader.Reader.GetById(_sId)[0]; } }

        /// <summary>
        /// Gets Salesperons-Dealer-Merchandise relation.
        /// </summary>
        public SDM SDM { get { return SDMReader.Reader.GetById(_sdmId)[0]; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { SpotSDMReader.Reader.Save(this, this.IsNew); }

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
                ssdm.Spot.ID == Spot.ID &&
                ssdm.SDM.ID == SDM.ID) return true;
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