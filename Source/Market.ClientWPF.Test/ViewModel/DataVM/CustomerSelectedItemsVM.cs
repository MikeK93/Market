// --------------------------------------------------------------------------
// <copyright file="CustomerSelectedItems.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Input;
using Command.ViewModel.Base;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a relation Customer-SelectedItems.
    /// </summary>
    public class CustomerSelectedItemsVM : BaseVM
    {
        private CustomerSelectedItems _customerSelectedItems;

        #region ViewModel

        // merchandise
        public string MerchandiseName { get { return SDM.MerchandiseName; } }

        public string MerchandiseTags { get { return SDM.Merchendise.Tags; } }

        public float MerchandiseCost { get { return SDM.Cost; } }

        // salesperson
        public string SalespersonGenderIcon { get { return SDM.GenderIcon; } }

        public string SalespersonFMLNames { get { return SDM.SalespersonFLNames; } }

        public string SalespersonEmail { get { return SDM.Salesperson.Email; } }

        public string SalespersonPhoneNumber { get { return SDM.Salesperson.PhoneNumber; } }

        // customer

        public string CustomerInitials { get { return Customer.FirstName + " " + Customer.MiddleName + " " + Customer.LastName; } }

        public string CustomerGenderIcon
        { get { return @"D:\Files\Studying\Лабораторки\EXAMPLES\EpamClasses\Market\Market\Source\Market.ClientWPF.Test\Assets\" + Customer.Gender.ToString().ToLowerInvariant() + ".ico"; } }

        // CSI
        /// <summary>
        /// Gets text if selected item is selected or not for button.
        /// </summary>
        public string IsSubmitedString { get { return IsSubmited == true ? "Отказаться" : "Подтвердить"; } }

        /// <summary>
        /// Gets text if selected item submited or not.
        /// </summary>
        public string SubmitText { get { return IsSubmited == true ? "Товар подтвержден." : "Товар не подтвержден."; } }

        /// <summary>
        /// Gets foreground for submit text.
        /// </summary>
        public string SubmitColor { get { return IsSubmited == true ? "#FF05B215" : "#FFD81E1E"; } }

        /// <summary>
        /// Gets foreground for submit button.
        /// </summary>
        public string SubmitButtonColor { get { return IsSubmited == true ? "#FFD81E1E" : "#FF05B215"; } }

        #endregion

        #region CSI

        /// <summary>
        /// Ctor for creating new Customer-SalespersonDealerMerchandise relation.
        /// </summary>
        /// <param name="customerVMId">Customer's id.</param>
        /// <param name="sdmVMId">SDM id.</param>
        public CustomerSelectedItemsVM(Guid customerVMId, Guid sdmVMId)
        {
            _customerSelectedItems = new CustomerSelectedItems(customerVMId, sdmVMId);
        }

        public CustomerSelectedItemsVM(CustomerSelectedItems csi)
        {
            _customerSelectedItems = csi;
        }

        /// <summary>
        /// Constructor for recreating Customer-SalespersonDealerMerchandise relation from database.
        /// </summary>
        /// <param name="id">Relation id in database.</param>
        /// <param name="customerVMId">Customer's id.</param>
        /// <param name="sdmVMId">SDM id.</param>
        public CustomerSelectedItemsVM(Guid id, Guid customerVMId, Guid sdmVMId)
        {
            _customerSelectedItems = new CustomerSelectedItems(id, customerVMId, sdmVMId);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID
        {
            get { return _customerSelectedItems.ID; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the relation Customer-Selectedtems is new.
        /// </summary>
        public bool IsNew
        {
            get { return _customerSelectedItems.IsNew; }
            set { _customerSelectedItems.IsNew = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the relation Customer-Selectedtems is submited.
        /// </summary>
        public bool IsSubmited
        {
            get { return _customerSelectedItems.IsSubmited; }
            set { _customerSelectedItems.IsSubmited = value; }
        }

        /// <summary>
        /// Gets a customer.
        /// </summary>
        public CustomerVM Customer
        {
            get { return new CustomerVM(_customerSelectedItems.Customer); }
            //CustomerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Customer", Middleware.MethodType.GetById, string.Empty, _cId)[0]); }
        }

        /// <summary>
        /// Gets Customer id.
        /// </summary>
        public Guid CustomerID { get { return _customerSelectedItems.CustomerID; } }

        /// <summary>
        /// Gets sets a relation Salesperson-Dealer-Merchandise.
        /// </summary>
        public SDMVM SDM
        {
            get { return new SDMVM(_customerSelectedItems.SDM); }
            //SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", Middleware.MethodType.GetById, string.Empty, _sdmId)[0]); }
        }

        /// <summary>
        /// Gets SDM id.
        /// </summary>
        public Guid SDMID { get { return _customerSelectedItems.SDMID; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            this._customerSelectedItems.Save();
        }

        /// <summary>
        /// Method deletes an entity CustomerSelectedItems from database.
        /// </summary>
        public void Delete()
        {
            this._customerSelectedItems.Delete();
        }

        /// <summary>
        /// Method compares two instance of a relation Customer-Selectedtems class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            CustomerSelectedItemsVM csi = obj as CustomerSelectedItemsVM;
            if (csi == null) return false;
            if (csi.ID == ID &&
                csi.CustomerID == CustomerID &&
                csi.SDMID == SDMID) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }
        #endregion

        #region ICommand

        public ICommand SubmitCommand
        { get { return Commands.GetOrCreateCommand(() => SubmitCommand, ExecuteSubmitCommand); } }

        public ICommand DeleteCommand
        { get { return Commands.GetOrCreateCommand(() => DeleteCommand, ExecuteDeleteCommand); } }

        public ICommand ConfirmCommand
        { get { return Commands.GetOrCreateCommand(() => ConfirmCommand, ExecuteConfirmCommand); } }

        // ConfirmCommand
        private void ExecuteConfirmCommand()
        {
            ExecuteDeleteCommand();
        }

        // DeleteCommand
        private void ExecuteDeleteCommand()
        {
            if (MessageBox.Show("Вы уверены что хотите удалить даный товар?", "Удалить", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                return;

            this.Delete();
        }

        // SubmitCommand
        private void ExecuteSubmitCommand()
        {
            if (IsSubmited)
                IsSubmited = false;
            else
                IsSubmited = true;

            OnPropertyChanged("IsSubmitedString");
            OnPropertyChanged("SubmitText");
            OnPropertyChanged("SubmitColor");
            OnPropertyChanged("SubmitButtonColor");

            this.Save();
            MessageBox.Show("Данные обновлены успешно.", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
        #endregion
    }
}