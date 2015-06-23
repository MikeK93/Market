// --------------------------------------------------------------------------
// <copyright file="SDM.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Class represents a relation Salesperson-Dealer-Merchandise.
    /// </summary>
    public class SDMVM : BaseVM
    {
        private SDM _sdm;

        #region ViewModel

        // merchandise

        public float MerchandiseCost { get { return Cost; } }

        public string MerchandiseTags { get { return DealerMerchandise.Merchandise.Tags; } }

        // salesperson

        public string SalespersonPhoneNumber { get { return Salesperson.PhoneNumber; } }

        public string SalespersonEmail { get { return Salesperson.Email; } }

        public string GenderIcon
        { get { return @"D:\Files\Studying\Лабораторки\EXAMPLES\EpamClasses\Market\Market\Source\Market.ClientWPF.Test\Assets\" + Salesperson.Gender.ToString().ToLowerInvariant() + ".ico"; } }

        public string SalespersonFLNames { get { return Salesperson.FirstName + " " + Salesperson.MiddleName + " " + Salesperson.LastName; } }

        // Dealer

        public string DealerInitials { get { return DealerMerchandise.Dealer.FirstName + " " + DealerMerchandise.Dealer.MiddleName + " " + DealerMerchandise.Dealer.LastName; } }

        public string DealerGenderIcon
        { get { return @"D:\Files\Studying\Лабораторки\EXAMPLES\EpamClasses\Market\Market\Source\Market.ClientWPF.Test\Assets\" + DealerMerchandise.Dealer.Gender.ToString().ToLowerInvariant() + ".ico"; } }

        public string DealerEmail { get { return DealerMerchandise.Dealer.Email; } }

        public string DealerPhoneNumber { get { return DealerMerchandise.Dealer.PhoneNumber; } }

        #endregion

        /// <summary>
        /// Constructor for recreatin Salesperson-Dealer-Merchandise relation from database.
        /// </summary>
        /// <param name="id">Id of Salesperson-Dealer-Merchandise.</param>
        /// <param name="dmId">Id of Dealer-Merchandise relation.</param>
        /// <param name="sId">Id of salesperson.</param>
        public SDMVM(Guid id, Guid dmId, Guid sId)
        {
            _sdm = new SDM(id, dmId, sId);
        }

        /// <summary>
        /// Ctor for creating new instance of SDMVM by instance of SDM.
        /// </summary>
        /// <param name="sdm">Instance of SDM.</param>
        public SDMVM(SDM sdm)
        {
            _sdm = sdm;
        }

        /// <summary>
        /// Constructor for creating new Salesperson-Dealer-Merchandise relation.
        /// </summary>
        /// <param name="sId">Id of Salesperson.</param>
        /// <param name="dmId">Id of Dealer-Merchandise relation.</param>
        /// <param name="cost">Cost by Salesperson.</param>
        public SDMVM(Guid sId, Guid dmId, float cost)
        {
            _sdm = new SDM(sId, dmId, cost);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _sdm.ID; } }

        /// <summary>
        /// Gets or sets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew
        {
            get { return _sdm.IsNew; }
            set { _sdm.IsNew = value; }
        }

        /// <summary>
        /// Gets or sets a cost by salesperson.
        /// </summary>
        public float Cost
        {
            get { return _sdm.Cost; }
            set
            {
                if (value == _sdm.Cost)
                    return;

                _sdm.Cost = value;
                OnPropertyChanged("Cost");
            }
        }

        /// <summary>
        /// Gets a relation Dealer-Merchandise.
        /// </summary>
        public DMVM DealerMerchandise
        {
            get { return new DMVM(_sdm.DealerMerchandise); } //DMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("DM", Middleware.MethodType.GetById, string.Empty, _dmId)[0]); }
        }

        /// <summary>
        /// Gets dealer merchandise id.
        /// </summary>
        public Guid DealerMerchandiseID { get { return _sdm.DealerMerchandiseID; } }

        /// <summary>
        /// Gets a salesperson.
        /// </summary>
        public SalespersonVM Salesperson
        {
            get { return new SalespersonVM(_sdm.Salesperson); }
        }

        /// <summary>
        /// Gets salesperson id.
        /// </summary>
        public Guid SalespersonID { get { return _sdm.SalespersonID; } }

        /// <summary>
        /// Gets a list of a relations Spot-SDM.
        /// </summary>
        public ObservableCollection<SpotSDMVM> SpotSDMs
        {
            get { return new ObservableCollection<SpotSDMVM>(from ssdm in _sdm.SpotSDMs select new SpotSDMVM(ssdm)); }
        }

        /// <summary>
        /// Gets a dealer from DM.
        /// </summary>
        public DealerVM Dealer { get { return DealerMerchandise.Dealer; } }

        /// <summary>
        /// Gets merchandise from DM.
        /// </summary>
        public MerchandiseVM Merchendise { get { return DealerMerchandise.Merchandise; } }

        /// <summary>
        /// Gets name of merchandise.
        /// </summary>
        public string MerchandiseName { get { return this.Merchendise.Name; } }

        /// <summary>
        /// Gets a list of spots where current merchandise is available.
        /// <remarks>Got from SpotSDMs.</remarks>
        /// </summary>
        public ObservableCollection<SpotVM> Spots
        {
            get
            {
                var res = new ObservableCollection<SpotVM>();
                foreach (SpotSDMVM ssdm in SpotSDMs)
                    res.Add(ssdm.Spot);

                return res;
            }
        }

        public static ObservableCollection<SDMVM> GetAll
        { get { return new ObservableCollection<SDMVM>(from sdm in SDM.GetAll select new SDMVM(sdm)); } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { _sdm.Save(); }

        /// <summary>
        /// Method deletes a relation Salesperson-Dealer-Merchandise.
        /// </summary>
        public void Delete()
        { _sdm.Delete(); }

        /// <summary>
        /// Method compares two instance of a SalespersonDealerMerchandise class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            SDMVM sdm = obj as SDMVM;
            if (sdm == null) return false;
            if (sdm.ID == ID &&
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

        #region ICommands

        public ICommand SaveCostCommand
        { get { return Commands.GetOrCreateCommand(() => SaveCostCommand, ExecuteSaveCostCommand, CanExecuteSaveCostCommand); } }

        public ICommand DeleteCommand
        { get { return Commands.GetOrCreateCommand(() => DeleteCommand, ExecuteDeleteCommand); } }

        // DeleteCommand
        private void ExecuteDeleteCommand()
        {
            if (MessageBox.Show("Вы уверены что хотите удалить " + MerchandiseName + " от " + DealerInitials + "?", "удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question) != MessageBoxResult.Cancel)
                this.Delete();
        }

        // SaveCostCommand
        private bool CanExecuteSaveCostCommand()
        {
            return Cost != 0;
        }

        // SaveCostCommand
        private void ExecuteSaveCostCommand()
        {
            try
            {
                _sdm.Save();
                MessageBox.Show("Успешно сохранено!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при сохранении! Ошибка: " + e.Message, "Сохранение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}