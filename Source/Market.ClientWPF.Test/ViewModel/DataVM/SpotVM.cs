// --------------------------------------------------------------------------
// <copyright file="SpotVM.cs" company="MK inc.">
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
    public class SpotVM : BaseVM
    {
        private Spot _spot;

        private static List<Spot> _allSpots
        {
            get { return SpotMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Spot", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty)); }
        }

        #region ViewModelLogin
        /// <summary>
        /// Gets all spots where there is at least one merhandise.
        /// </summary>
        public static ObservableCollection<SpotVM> GetAll
        {
            get
            {
                var res = new ObservableCollection<SpotVM>();
                foreach (Spot s in _allSpots)
                    if (s.SDMs != null && s.SDMs.Count > 0)
                        res.Add(new SpotVM(s));

                return res;
            }
        }

        /// <summary>
        /// Gets all available spots.
        /// </summary>
        public static ObservableCollection<SpotVM> GetAllAvailableSpots
        {
            get
            {
                var res = new ObservableCollection<SpotVM>();
                foreach (Spot s in _allSpots)
                    if (s.Salesperson == null)
                        res.Add(new SpotVM(s));

                return res;
            }
        }

        public string SDMsCountString
        {
            get
            {
                var res = string.Empty;
                if (SDMs.Count == 0)
                    return string.Empty;

                res = string.Format("Товаров на месте: {0}.", SDMs.Count);
                return res;
            }
        }

        /// <summary>
        /// Gets short start date. (day/month/year)
        /// </summary>
        public string ShortDateString { get { return DateStart.ToShortDateString(); } }
        #endregion

        /// <summary>
        /// Constructor for creating new Spot.
        /// </summary>
        /// <param name="makerCompanyId">MakerCompany id.</param>
        /// <param name="securityTypeId">Security type id.</param>
        /// <param name="salespersonId">Salesperson id. If no salespersons attached yet set value to Guid.Empty.</param>
        public SpotVM(Guid makerCompanyId, Guid securityTypeId, Guid salespersonId)
        {
            _spot = new Spot(makerCompanyId, securityTypeId, salespersonId);
        }

        /// <summary>
        /// Ctor for creating new instance of SpotVM by instance of Spot.
        /// </summary>
        /// <param name="sdm">Instance of Spot.</param>
        public SpotVM(Spot spot)
        {
            _spot = spot;
        }

        /// <summary>
        /// Constructor for recreating Spot from database.
        /// </summary>
        /// <param name="id">Id of a Spot in database.</param>
        /// <param name="started">Date when spot started working.</param>
        /// <param name="makerCompanyId">MakerCompany id.</param>
        /// <param name="securityTypeId">Security type id.</param>
        /// <param name="salespersonId">Salesperson id. If no salespersons attached yet set value to Guid.Empty.</param>
        public SpotVM(Guid id, DateTime started, Guid makerCompanyId, Guid securityTypeId, Guid salespersonId)
        {
            _spot = new Spot(id, started, makerCompanyId, securityTypeId, salespersonId);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _spot.ID; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _spot.IsNew; } }

        /// <summary>
        /// Gets or sets a number of a current spot.
        /// </summary>
        public int Number
        {
            get { return _spot.Number; }
            set { _spot.Number = value; }
        }

        /// <summary>
        /// Gets or sets address of a spot.
        /// </summary>
        public string Address
        {
            get { return _spot.Address; }
            set { _spot.Address = value; }
        }

        /// <summary>
        /// Gets a date when the current spot started working.
        /// </summary>
        public DateTime DateStart { get { return _spot.DateStart; } }

        /// <summary>
        /// Gets a makar company.
        /// </summary>
        public MakerCompanyVM MakerCompany { get { return new MakerCompanyVM(_spot.MakerCompany); } }

        /// <summary>
        /// Gets maker company id.
        /// </summary>
        public Guid MakerCompanyID { get { return _spot.MakerCompanyID; } }

        /// <summary>
        /// Gets a security type.
        /// </summary>
        public SecurityTypeVM SecurityType { get { return new SecurityTypeVM(_spot.SecurityType); } }

        /// <summary>
        /// Gets security type id.
        /// </summary>
        public Guid SecurityTypeID { get { return _spot.SecurityTypeID; } }

        /// <summary>
        /// Gets or sets a salesperson.
        /// </summary>
        public SalespersonVM Salesperson
        {
            get { return new SalespersonVM(_spot.Salesperson); }
            set
            {
                if (value == null)
                {
                    _spot.Salesperson = null;
                    return;
                }

                _spot.Salesperson = value.Salesperson;
            }
        }

        /// <summary>
        /// Gets salesperson id.
        /// </summary>
        public Guid SalespersonID { get { return _spot.SalespersonID; } }

        /// <summary>
        /// Gets or sets a list of relations Spot-SDM.
        /// </summary>
        public ObservableCollection<SpotSDMVM> SpotSDMs
        {
            get { return new ObservableCollection<SpotSDMVM>(from ssdm in _spot.SpotSDMs select new SpotSDMVM(ssdm)); }
        }

        /// <summary>
        /// Gets a list of relations Salesperson-Dealer-Merchandise.
        /// </summary>
        public ObservableCollection<SDMVM> SDMs
        {
            get
            {
                if (SpotSDMs == null)
                    return new ObservableCollection<SDMVM>();

                return new ObservableCollection<SDMVM>(from sdm in _spot.SpotSDMs select new SDMVM(sdm.SDM));
            }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { _spot.Save(); }

        /// <summary>
        /// Method compares two instance of a Spot class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            SpotVM s = obj as SpotVM;
            if (s == null) return false;
            if (s.ID == ID &&
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