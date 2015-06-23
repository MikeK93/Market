// --------------------------------------------------------------------------
// <copyright file="SDM.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Market.Model;
using Market.Model.Mappers;

namespace Market.Model.Entities
{
    /// <summary>
    /// Class represents a relation Salesperson-Dealer-Merchandise.
    /// </summary>
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
        public DM DealerMerchandise { get { return DMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("DM", Middleware.MethodType.GetById, string.Empty, _dmId)[0]); } }

        /// <summary>
        /// Gets dealer merchandise id.
        /// </summary>
        public Guid DealerMerchandiseID { get { return _dmId; } }

        /// <summary>
        /// Gets a salesperson.
        /// </summary>
        public Salesperson Salesperson { get { return SalespersonMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Salesperson", Middleware.MethodType.GetById, string.Empty, _salespersonId)[0]); } }

        /// <summary>
        /// Gets salesperson id.
        /// </summary>
        public Guid SalespersonID { get { return _salespersonId; } }

        /// <summary>
        /// Gets a list of a relations Spot-SDM.
        /// </summary>
        public List<SpotSDM> SpotSDMs { get { return SpotSDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SpotSDM", Middleware.MethodType.GetByQuery, "SalespersonDealerMerchandiseID='" + ID + "'", Guid.Empty)); } }

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
        /// Gets all sdms.
        /// </summary>
        public static List<SDM> GetAll
        {
            get { return SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty)); }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(SDMMapper.Mapper.Pack(this), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method deletes a relation Salesperson-Dealer-Merchandise.
        /// </summary>
        public void Delete()
        { MarketProxy.Proxy.UpdateOne(SDMMapper.Mapper.Pack(this), Middleware.UpdateType.Delete); }

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
                sdm.DealerMerchandiseID == DealerMerchandiseID &&
                sdm.SalespersonID == SalespersonID) return true;
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