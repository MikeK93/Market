// --------------------------------------------------------------------------
// <copyright file="DM.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using Command.ViewModel.Base;
using Market.Model.Entities;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a relation between Dealer and Merchandise.
    /// </summary>
    public class DMVM : BaseVM
    {
        private DM _dealerMerchandise;

        #region ViewModel

        public static ObservableCollection<DMVM> GetAllDMs
        {
            get { return new ObservableCollection<DMVM>(from dm in DM.GetAllDMs select new DMVM(dm)); }
        }

        public string DealerInitials { get { return Dealer.FirstName + " " + Dealer.MiddleName + " " + Dealer.LastName; } }

        public string DealerGenderIcon
        { get { return @"D:\Files\Studying\Лабораторки\EXAMPLES\EpamClasses\Market\Market\Source\Market.ClientWPF.Test\Assets\" + Dealer.Gender.ToString().ToLowerInvariant() + ".ico"; } }

        public string DealerEmail { get { return Dealer.Email; } }

        public string DealerPhoneNumber { get { return Dealer.PhoneNumber; } }


        #endregion

        /// <summary>
        /// Custom constructor for recreating Dealer-Merchandise relation from the database.
        /// </summary>
        /// <param name="id">Id of an entity DealerMerchandise.</param>
        /// <param name="dVMId">Id of a dealer.</param>
        /// <param name="mVMId">Id of merchandise.</param>
        public DMVM(Guid id, Guid dVMId, Guid mVMId)
        {
            _dealerMerchandise = new DM(id, dVMId, mVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of DMVM by instance of DM.
        /// </summary>
        /// <param name="dm">Instance of DM.</param>
        public DMVM(DM dm)
        {
            _dealerMerchandise = dm;
        }

        /// <summary>
        /// Custom constructor for creating new Dealer-Merchandise relation.
        /// </summary>
        /// <param name="dVMId">Id of a dealer.</param>
        /// <param name="mVMId">Id of merchandise.</param>
        public DMVM(Guid dVMId, Guid mVMId)
        {
            _dealerMerchandise = new DM(dVMId, mVMId);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get
            {
                return _dealerMerchandise.ID;
            }
        }

        /// <summary>
        /// Gets a dealer.
        /// </summary>
        public DealerVM Dealer
        {
            get { return new DealerVM(_dealerMerchandise.Dealer); }
            //DealerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Dealer", MethodType.GetById, string.Empty, _dealerId)[0]); }
        }

        /// <summary>
        /// Gets Dealer id.
        /// </summary>
        public Guid DealerID
        {
            get { return _dealerMerchandise.DealerID; }
        }

        /// <summary>
        /// Gets merchandise.
        /// </summary>
        public MerchandiseVM Merchandise
        {
            get { return new MerchandiseVM(_dealerMerchandise.Merchandise); }
            //MerchandiseMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Merchandise", Middleware.MethodType.GetById, string.Empty, _merchandiseId)[0]); }
        }

        /// <summary>
        /// Gets name of merchandise.
        /// </summary>
        public string MerchandiseName
        { get { return Merchandise.Name; } }

        /// <summary>
        /// Gets merchsndise tags.
        /// </summary>
        public string MerchandiseTags
        { get { return Merchandise.Tags; } }

        /// <summary>
        /// Gets Merchandise id.
        /// </summary>
        public Guid MerchandiseID
        {
            get { return _dealerMerchandise.MerchandiseID; }
        }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew
        {
            get { return _dealerMerchandise.IsNew; }
            set { _dealerMerchandise.IsNew = value; }
        }

        /// <summary>
        /// Gets or sets a cost for merchandise by dealer.
        /// </summary>
        [Required(ErrorMessage = "Цена не может быть пустой!")]
        public float Cost
        {
            get { return _dealerMerchandise.Cost; }
            set
            {
                if (value == _dealerMerchandise.Cost)
                    return;

                _dealerMerchandise.Cost = value;
                OnPropertyChanged("Cost");
            }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            _dealerMerchandise.Save();
        }

        /// <summary>
        /// Method deletes Dealer-Merchandise relation.
        /// </summary>
        public void Delete()
        {
            _dealerMerchandise.Delete();
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

        #region ICommands

        public ICommand SaveCostCommand
        { get { return Commands.GetOrCreateCommand(() => SaveCostCommand, ExecuteSaveCostCommand, CanExecuteSaveCostCommand); } }

        private void ExecuteSaveCostCommand()
        {
            try
            {
                _dealerMerchandise.Save();
                MessageBox.Show("Успешно сохранено!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при сохранении! Ошибка: " + e.Message, "Сохранение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanExecuteSaveCostCommand()
        {
            var hasError = this["Cost"] == string.Empty;
            return hasError;
        }

        #endregion

    }
}