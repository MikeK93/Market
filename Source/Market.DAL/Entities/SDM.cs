// --------------------------------------------------------------------------
// <copyright file="SDM.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Market.Mappers;
using Market.Readers;

namespace Market.Entities
{
    /// <summary>
    /// Class represents a relation Salesperson-Dealer-Merchandise.
    /// </summary>
    [DataContract]
    public class SDM
    {
        private Guid _id;

        private Guid _dmId;

        private Guid _salespersonId;

        private bool _isNew = false;

        /// <summary>
        /// Constructor for recreatin Salesperson-Dealer-Merchandise relation from database.
        /// </summary>
        /// <param name="id">Id of Salesperson-Dealer-Merchandise.</param>
        /// <param name="dmId">Id of Dealer-Merchandise relation.</param>
        /// <param name="sId">Id of salesperson.</param>
        public SDM(Guid id, Guid dmId, Guid sId)
        {
            _isNew = false;
            _id = id;
            _dmId = dmId;
            _salespersonId = sId;
        }

        /// <summary>
        /// Constructor for creating new Salesperson-Dealer-Merchandise relation.
        /// </summary>
        /// <param name="sId">Id of Salesperson.</param>
        /// <param name="dmId">Id of Dealer-Merchandise relation.</param>
        /// <param name="cost">Cost by Salesperson.</param>
        public SDM(Guid sId, Guid dmId, float cost)
        {
            _isNew = true;
            _id = Guid.NewGuid();
            _dmId = dmId;
            _salespersonId = sId;
            Cost = cost;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _id; } }

        /// <summary>
        /// Gets id of salesperson.
        /// </summary>
        public Guid SalespersonID { get { return this._salespersonId; } }

        /// <summary>
        /// Gets id of a relation dealer-merchandise.
        /// </summary>
        public Guid DealerMerchandiseID { get { return this._dmId; } }

        /// <summary>
        /// Gets or sets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        /// <summary>
        /// Gets or sets a cost by salesperson.
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Gets a relation Dealer-Merchandise.
        /// </summary>
        public DM DealerMerchandise { get { return DMReader.Reader.GetById(_dmId)[0]; } }

        /// <summary>
        /// Gets a salesperson.
        /// </summary>
        public Salesperson Salesperson { get { return SalespersonReader.Reader.GetById(_salespersonId)[0]; } }

        /// <summary>
        /// Gets a list of a relations Spot-SDM.
        /// </summary>
        public List<SpotSDM> SpotSDMs { get { return SpotSDMReader.Reader.GetByQuery("SalespersonDealerMerchandiseID='" + ID + "'"); } }

        /// <summary>
        /// Gets a dealer from DM.
        /// </summary>
        public Dealer Dealer { get { return DealerMerchandise.Dealer; } }

        /// <summary>
        /// Gets merchandise from DM.
        /// </summary>
        public Merchandise Merchendise { get { return DealerMerchandise.Merchandise; } }

        /// <summary>
        /// Gets a list of spots where current merchandise is available.
        /// <remarks>Got from SpotSDMs.</remarks>
        /// </summary>
        public List<Spot> Spots
        {
            get
            {
                var res = new List<Spot>();
                foreach (SpotSDM ssdm in SpotSDMs)
                    res.Add(ssdm.Spot);

                return res;
            }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { SDMReader.Reader.Save(this, _isNew); }

        /// <summary>
        /// Method deletes a relation Salesperson-Dealer-Merchandise.
        /// </summary>
        public void Delete()
        { SDMReader.Reader.Delete(this); }

        /// <summary>
        /// Method compares two instance of a SalespersonDealerMerchandise class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            SDM sdm = obj as SDM;
            if (sdm == null) return false;
            if (sdm.ID == ID &&
                sdm.Cost == Cost &&
                sdm.DealerMerchandise.ID == DealerMerchandise.ID &&
                sdm.Salesperson.ID == Salesperson.ID) return true;
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
        /// <returns>Dealer and merchanidse' name and its cost.</returns>
        public override string ToString()
        { return string.Format("{0}: {1} ${2}", Dealer, Merchendise.Name, Cost); }
    }
}