// --------------------------------------------------------------------------
// <copyright file="Spot.cs" company="MK inc.">
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
    /// Enum represents a month name.
    /// </summary>
    public enum MonthName
    {
        /// <summary>
        /// Represents January.
        /// </summary>
        January = 1,

        /// <summary>
        /// Represents February.
        /// </summary>
        February = 2,

        /// <summary>
        /// Represents March.
        /// </summary>
        March = 3,

        /// <summary>
        /// Represents April.
        /// </summary>
        April = 4,

        /// <summary>
        /// Represents May.
        /// </summary>
        May = 5,

        /// <summary>
        /// Represents June.
        /// </summary>
        June = 6,

        /// <summary>
        /// Represents July.
        /// </summary>
        July = 7,

        /// <summary>
        /// Represents August.
        /// </summary>
        August = 8,

        /// <summary>
        /// Represents September.
        /// </summary>
        September = 9,

        /// <summary>
        /// Represents October.
        /// </summary>
        October = 10,

        /// <summary>
        /// Represents November.
        /// </summary>
        November = 11,

        /// <summary>
        /// Represents December.
        /// </summary>
        December = 12
    }

    /// <summary>
    /// Class represents a Spot.
    /// </summary>
    public class Spot
    {
        private Guid _id;

        private Guid _stId;

        private Guid _mcId;

        private Guid _sId;

        private bool _isNew;

        /// <summary>
        /// Constructor for creating new Spot.
        /// </summary>
        /// <param name="makerCompanyId">MakerCompany id.</param>
        /// <param name="securityTypeId">Security type id.</param>
        /// <param name="salespersonId">Salesperson id. If no salespersons attached yet set value to Guid.Empty.</param>
        public Spot(Guid makerCompanyId, Guid securityTypeId, Guid salespersonId)
        {
            _id = Guid.NewGuid();
            _mcId = makerCompanyId;
            _stId = securityTypeId;
            _sId = salespersonId;
            _isNew = true;
        }

        /// <summary>
        /// Constructor for recreating Spot from database.
        /// </summary>
        /// <param name="id">Id of a Spot in database.</param>
        /// <param name="started">Date when spot started working.</param>
        /// <param name="makerCompanyId">MakerCompany id.</param>
        /// <param name="securityTypeId">Security type id.</param>
        /// <param name="salespersonId">Salesperson id. If no salespersons attached yet set value to Guid.Empty.</param>
        public Spot(Guid id, DateTime started, Guid makerCompanyId, Guid securityTypeId, Guid salespersonId)
        {
            _id = id;
            _mcId = makerCompanyId;
            _stId = securityTypeId;
            _sId = salespersonId;
            DateStart = started;
            _isNew = false;

            SpotSDMs = SpotSDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SpotSDM", Middleware.MethodType.GetByQuery, "SpotID='" + ID + "'", Guid.Empty));
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
        /// Gets or sets a number of a current spot.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets address of a spot.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets a date when the current spot started working.
        /// </summary>
        public DateTime DateStart { get; private set; }

        /// <summary>
        /// Gets a makar company.
        /// </summary>
        public MakerCompany MakerCompany { get { return MakerCompanyMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("MakerCompany", Middleware.MethodType.GetById, string.Empty, _mcId)[0]); } }

        /// <summary>
        /// Gets maker company id.
        /// </summary>
        public Guid MakerCompanyID { get { return _mcId; } }

        /// <summary>
        /// Gets a security type.
        /// </summary>
        public SecurityType SecurityType { get { return SecurityTypeMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SecurityType", Middleware.MethodType.GetById, string.Empty, _stId)[0]); } }

        /// <summary>
        /// Gets security type id.
        /// </summary>
        public Guid SecurityTypeID { get { return _stId; } }

        /// <summary>
        /// Gets or sets a salesperson.
        /// </summary>
        public Salesperson Salesperson
        {
            get { return _sId == Guid.Empty ? null : SalespersonMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Salesperson", Middleware.MethodType.GetById, string.Empty, _sId)[0]); }
            set { _sId = value == null ? Guid.Empty : value.ID; }
        }

        /// <summary>
        /// Gets salesperson id.
        /// </summary>
        public Guid SalespersonID { get { return _sId; } }

        /// <summary>
        /// Gets or sets a list of relations Spot-SDM.
        /// </summary>
        public List<SpotSDM> SpotSDMs { get; set; }

        /// <summary>
        /// Gets a list of relations Salesperson-Dealer-Merchandise.
        /// </summary>
        public List<SDM> SDMs
        {
            get
            {
                var res = new List<SDM>();
                if (SpotSDMs != null)
                    foreach (SpotSDM ssdm in SpotSDMs)
                        res.Add(ssdm.SDM);

                return res;
            }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(SpotMapper.Mapper.Pack(this), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of a Spot class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            Spot s = obj as Spot;
            if (s == null) return false;
            if (s.ID == ID &&
                s.DateStart == DateStart &&
                s.Number == Number &&
                s.MakerCompanyID == MakerCompanyID &&
                s.SecurityTypeID == SecurityTypeID &&
                s.SalespersonID == SalespersonID) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Shows string representation of class.
        /// </summary>
        /// <returns>Number and start date.</returns>
        public override string ToString()
        {
            return "#" + Number + " (" + DateStart.Day + "th of " + ((MonthName)DateStart.Month).ToString() + " " + DateStart.Year + ")";
        }
    }
}