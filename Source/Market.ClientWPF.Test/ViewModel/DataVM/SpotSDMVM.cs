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
using System.Windows;
using System.Windows.Input;
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
        private List<SDMVM> _currentMerchandiseAllSMDs = new List<SDMVM>();
        private SpotSDMVM _selectedSpotSDMVM;

        #region ViewModelLogic

        public static List<SpotSDMVM> GetAll
        {
            get
            {
                var res = new List<SpotSDMVM>();
                var allSpotSDMs = SpotSDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SpotSDM", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));
                foreach (SpotSDM ssdm in allSpotSDMs)
                    res.Add(new SpotSDMVM(ssdm));

                return res;
            }
        }

        public string MerchandiseName { get { return SDM.DealerMerchandise.Merchandise.Name; } }

        public string MerchandiseTags { get { return SDM.DealerMerchandise.Merchandise.Tags; } }

        public int MerchandiseSpot { get { return Spot.Number; } }

        public string SpotStartDate { get { return Spot.DateStart.ToShortDateString(); } }

        public List<SDMVM> CurrentMerchandiseAllSMDs
        {
            get { return _currentMerchandiseAllSMDs; }
            set
            {
                _currentMerchandiseAllSMDs = value;
                OnPropertyChanged("MerchandiseAllSpotSDMs");
            }
        }

        public SpotSDMVM SelectedSpotSDM
        {
            get { return _selectedSpotSDMVM; }
            set
            {
                _selectedSpotSDMVM = value;
                OnPropertyChanged("SelectedSpotSDMVM");
            }
        }

        public string SpotAddress { get { return Spot.Address; } }

        #endregion

        #region SpotSDM

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
        { _spotSDM.Save(); }

        /// <summary>
        /// Method deletes object.
        /// </summary>
        public void Delete()
        { _spotSDM.Delete(); }

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

        #endregion

        #region ICommands

        public ICommand DeleteCommand
        { get { return Commands.GetOrCreateCommand(() => DeleteCommand, ExecuteDeleteCommand); } }

        // DeleteCommand *EXE
        private void ExecuteDeleteCommand()
        {
            if (MessageBox.Show("Вы уверены что хотите удалить " + MerchandiseName + " из места №" + MerchandiseSpot + "?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question) != MessageBoxResult.Cancel)
                this.Delete();
        }

        #endregion
    }
}