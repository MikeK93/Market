// --------------------------------------------------------------------------
// <copyright file="Customer.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Market.Model;
using Market.Model.Mappers;
using Market.Middleware;
using Market.Model.Entities;
using Command.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Market.ViewModel.DataVM;
using System.ComponentModel;
using Market.ClientWPF.View.User;
using Market.ClientWPF.View.Customer;
using System.Windows;

namespace Market.ViewModel.DataVM
{
    public enum MarketViews
    {
        [Description("Карта маркета.")]
        MarketView,
        [Description("Список товаров.")]
        ListOfMerchandise
    }

    public enum SortType
    {
        ByDescending = 0,
        ByScending = 1,
        Alphabetic = 2
    }

    /// <summary>
    /// Class represents a Customer.
    /// </summary>
    public class CustomerVM : BaseVM
    {
        private Customer _customer;

        private CustomerMainWindow _customerMainWindow;
        private string _email;
        private string _salesperson;
        private string _tags;
        private float _cost;
        private string _newLogin;
        private string _newPWord;
        private string _newPWordComfirm;
        private string _selectedSpotSalespersonGenderIcon;
        private MarketViews _selectedView;
        private SpotVM _selectedSpotVM;
        private SDMVM _selectedSDMVM;
        private SpotSDMVM _selectedSpotSDMVM;
        private CustomerSelectedItemsVM _selectedCSI;
        private GenderType _selectedGender;
        private CategoryVM _selectedTag;
        private SortType _selectedSortType;
        private List<MarketViews> _marketViews;
        private List<SpotVM> _allSpotVMs;
        private List<SpotSDMVM> _allSpotSDMVM;
        private List<SpotSDMVM> _filteredSpotSDMVM;
        private List<CategoryVM> _allTags;
        private List<SortType> _sortTypes;
        private List<GenderType> _genders;
        private List<SDMVM> _sdms;

        #region ViewModelLogin
        public CustomerMainWindow CustomerMainWindow { get { return _customerMainWindow; } }

        public List<MarketViews> Views { get { return _marketViews; } }

        public List<SpotVM> AllSpots { get { return _allSpotVMs; } }

        public List<SpotSDMVM> AllSpotSDM
        {
            get { return _allSpotSDMVM; }
            set
            {
                _allSpotSDMVM = value;
                OnPropertyChanged("AllSpotSDM");
            }
        }

        public List<SpotSDMVM> FilteredSpotSDM
        {
            get { return _filteredSpotSDMVM; }
            set
            {
                _filteredSpotSDMVM = value;
                OnPropertyChanged("FilteredSpotSDM");
            }
        }

        public SpotSDMVM SelectedSpotSDM
        {
            get { return _selectedSpotSDMVM; }
            set
            {
                _selectedSpotSDMVM = value;
                OnPropertyChanged("SelectedSpotSDM");
            }
        }

        public List<SDMVM> SpotSDM
        {
            get { return _sdms; }
            set
            {
                _sdms = value;
                OnPropertyChanged("SpotSDM");
            }
        }

        public List<CategoryVM> AllTags { get { return _allTags; } }

        public List<SortType> SortTypes { get { return _sortTypes; } }

        public List<GenderType> Genders { get { return _genders; } }

        public GenderType SelectedGender
        {
            get { return _selectedGender; }
            set
            {
                _selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }

        public MarketViews SelectedView
        {
            get { return _selectedView; }
            set
            {
                _selectedView = value;
                OnPropertyChanged("SelectedView");
            }
        }

        public SpotVM SelectedSpot
        {
            get { return _selectedSpotVM; }
            set
            {
                if (value == null)
                    return;

                _selectedSpotVM = value;
                SpotSDM = value.SDMs.ToList();
                SelectedMerchandiseSalesperson = value.Salesperson.FirstName + " " + value.Salesperson.LastName;
                SelectedMerchandiseSalespersonEmail = value.Salesperson.Email;
                SelectedSpotSalespersonGenderIcon = @"D:\Files\Studying\Лабораторки\EXAMPLES\EpamClasses\Market\Market\Source\Market.ClientWPF.Test\Assets\" + value.Salesperson.Gender.ToString().ToLowerInvariant() + ".ico";
                OnPropertyChanged("SelectedSpot");
            }
        }

        public SDMVM SelectedSDM
        {
            get { return _selectedSDMVM; }
            set
            {
                if (value == null)
                    return;

                _selectedSDMVM = value;
                SelectedMerchandiseCost = value.Cost;
                SelectedMerchandiseTags = value.Merchendise.Tags;
                OnPropertyChanged("SelectedMerchandise");
                OnPropertyChanged("SelectedSDM");
            }
        }

        public CategoryVM SelectedTag
        {
            get { return _selectedTag; }
            set
            {
                _selectedTag = value;
                OnPropertyChanged("SelectedTag");
            }
        }

        public SortType SelectedSortType
        {
            get { return _selectedSortType; }
            set
            {
                _selectedSortType = value;
                OnPropertyChanged("SelectedSortType");
            }
        }

        public CustomerSelectedItemsVM SelectedCSI
        {
            get { return _selectedCSI; }
            set
            {
                if (value == null)
                    return;

                _selectedCSI = value;
                OnPropertyChanged("SelectedCSI");
            }
        }

        public string SelectedSpotSalespersonGenderIcon
        {
            get { return _selectedSpotSalespersonGenderIcon; }
            set
            {
                _selectedSpotSalespersonGenderIcon = value;
                OnPropertyChanged("SelectedSpotSalespersonGenderIcon");
            }
        }

        public float SelectedMerchandiseCost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged("SelectedMerchandiseCost");
            }
        }

        public string SelectedMerchandiseTags
        {
            get { return _tags; }
            set
            {
                _tags = value;
                OnPropertyChanged("SelectedMerchandiseTags");
            }
        }

        public string SelectedMerchandiseSalesperson
        {
            get { return _salesperson; }
            set
            {
                _salesperson = value;
                OnPropertyChanged("SelectedMerchandiseSalesperson");
            }
        }

        public string SelectedMerchandiseSalespersonEmail
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("SelectedMerchandiseSalespersonEmail");
            }
        }

        public string NewLogin
        {
            get { return _newLogin; }
            set
            {
                _newLogin = value;
                OnPropertyChanged("NewLogin");
            }
        }

        public string NewPWord
        {
            get { return _newPWord; }
            set
            {
                _newPWord = value;
                OnPropertyChanged("NewPWord");
            }
        }

        public string NewPWordComfirm
        {
            get { return _newPWordComfirm; }
            set
            {
                _newPWordComfirm = value;
                OnPropertyChanged("NewPWordComfirm");
            }
        }

        public string GenderIcon
        { get { return @"D:\Files\Studying\Лабораторки\EXAMPLES\EpamClasses\Market\Market\Source\Market.ClientWPF.Test\Assets\" + Gender.ToString().ToLowerInvariant() + ".ico"; } }

        public string Initials
        { get { return FirstName + " " + MiddleName + " " + LastName; } }

        #endregion

        #region Customer

        /// <summary>
        /// Ctor for data context.
        /// </summary>
        public CustomerVM(CustomerMainWindow window, UserVM user)
        {
            _customer = Customer.GetCustomerByUser(new Model.Entities.User(user.ID));
            _marketViews = new List<MarketViews>();
            _marketViews.Add(MarketViews.ListOfMerchandise);
            _marketViews.Add(MarketViews.MarketView);
            _allSpotVMs = SpotVM.GetAll.ToList();
            _allSpotSDMVM = SpotSDMVM.GetAll;
            _allTags = CategoryVM.GetAll;
            _sortTypes = new List<SortType>();
            _sortTypes.Add(SortType.ByDescending);
            _sortTypes.Add(SortType.ByScending);
            _sortTypes.Add(SortType.Alphabetic);
            _genders = new List<GenderType>();
            _genders.Add(GenderType.Female);
            _genders.Add(GenderType.Male);
            SelectedGender = _customer.Gender;
            OnPropertyChanged("AllSpots");
            OnPropertyChanged("AllSpotSDM");
            OnPropertyChanged("AllTags");
            OnPropertyChanged("SortTypes");
            OnPropertyChanged("SelectedGender");
            NewLogin = User.Login;
            NewPWord = NewPWordComfirm = User.Password;
            _customerMainWindow = window;
        }

        /// <summary>
        /// Ctor for creating new customer.
        /// </summary>
        /// <param name="userId">User's id attached to current customer.</param>
        public CustomerVM(Guid userVMId)
        {
            _customer = new Customer(userVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of a CustomerVM class by Customer class instanse.
        /// </summary>
        public CustomerVM(Customer customer)
        { _customer = customer; }

        /// <summary>
        /// Ctor for recreating customer from database.
        /// </summary>
        /// <param name="id">Id of current customer in database.</param>
        /// <param name="userId">User's id attached to current customer.</param>
        public CustomerVM(Guid id, Guid userVMId)
        {
            _customer = new Customer(id, userVMId);
            UpdateCSI();
        }

        /// <summary>
        /// Method gets customer by user.
        /// </summary>
        /// <param name="user">User attacehd to customer.</param>
        /// <returns>Customer object.</returns>
        public static CustomerVM GetCustomerByUser(UserVM user)
        {
            var packedObjects = MarketProxy.Proxy.GetData("Customer", Middleware.MethodType.GetByQuery, "UserID='" + user.ID + "'", Guid.Empty);
            return new CustomerVM(CustomerMapper.Mapper.UnPack(packedObjects[0]));
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _customer.ID; } }

        /// <summary>
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return _customer.UserID; } }

        /// <summary>
        /// Gets or sets a first name of a current customer.
        /// </summary>
        public string FirstName
        {
            get { return _customer.FirstName; }
            set
            {
                if (value == _customer.FirstName)
                    return;

                _customer.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets a middle name of a current customer.
        /// </summary>
        public string MiddleName
        {
            get { return _customer.MiddaleName; }
            set
            {
                if (value == _customer.MiddaleName)
                    return;

                _customer.MiddaleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// Gets or sets a last name of a current customer.
        /// </summary>
        public string LastName
        {
            get { return _customer.LastName; }
            set
            {
                if (value == _customer.LastName)
                    return;

                _customer.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets a phone number.
        /// </summary>
        public string PhoneNumber
        {
            get { return _customer.PhoneNumber; }
            set
            {
                if (value == _customer.PhoneNumber)
                    return;

                _customer.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Gets or sets an email.
        /// </summary>
        public string Email
        {
            get { return _customer.Email; }
            set
            {
                if (value == _customer.Email)
                    return;

                _customer.Email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets gender of a current customer.
        /// </summary>
        public GenderType Gender
        {
            get { return _customer.Gender; }
            set
            {
                if (value == _customer.Gender)
                    return;

                _customer.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// Gets or sets age of a current customer.
        /// </summary>
        public int Age
        {
            get { return _customer.Age; }
            set
            {
                if (value == _customer.Age)
                    return;

                _customer.Age = value;
                OnPropertyChanged("Age");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Customer is new.
        /// </summary>
        public bool IsNew { get { return _customer.IsNew; } }

        /// <summary>
        /// Gets sets a user profile attached to current customer.
        /// </summary>
        public UserVM User
        {
            get { return new UserVM(_customer.User); }
        }

        /// <summary>
        /// Gets a list of selected merchandise to buy.
        /// </summary>
        public ObservableCollection<MerchandiseVM> SelectedMerchandise
        {
            get
            {
                var res = new ObservableCollection<MerchandiseVM>();
                foreach (CustomerSelectedItemsVM si in CSIs)
                    res.Add(si.SDM.Merchendise);
                return (ObservableCollection<MerchandiseVM>)res.Distinct();
            }
        }

        /// <summary>
        /// Gets or sets a list of CustomerSelectedItems where all information about merchandise and salesperson is stored.
        /// </summary>
        public List<CustomerSelectedItemsVM> CSIs
        {
            get
            {
                return _customer.CSIs == null ?
                    null : (from csi in _customer.CSIs select new CustomerSelectedItemsVM(csi)).ToList();
            }
            set
            {
                _customer.CSIs = ToList(value);
                OnPropertyChanged("CSIs");
            }
        }

        /// <summary>
        /// Method updates list of customer selected items.
        /// </summary>
        public void UpdateCSI()
        {
            _customer.CSIs = new List<CustomerSelectedItems>();
            _customer.CSIs = CustomerSelectedItemsMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("CustomerSelectedItems", MethodType.GetByQuery, "CustomerID='" + this.ID + "'", Guid.Empty));
        }

        /// <summary>
        /// Method saves Customer.
        /// </summary>
        public void Save()
        {
            this._customer.Save();
            if (CSIs != null)
            {
                // here we need access to csi through csiVM to save a list at once, insted foreach and one by one.
                foreach (CustomerSelectedItemsVM csi in CSIs)
                {
                    csi.IsNew = false;
                    csi.Save();
                }
            }
        }

        /// <summary>
        /// Method compares two instance of a Customer class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            CustomerVM c = obj as CustomerVM;
            if (c == null) return false;
            if (c.ID == ID &&
                c.UserID == UserID) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Display text representstion of a Customer class.
        /// </summary>
        /// <returns>First and Last Names of a Customer.</returns>
        public override string ToString()
        { return FirstName + " " + LastName; }
        #endregion

        #region ICommands

        public ICommand SavePersonalInformationCommand
        { get { return Commands.GetOrCreateCommand(() => SavePersonalInformationCommand, ExecuteSavePersonalInformationCommand, CanExecuteSavePersonalInformationCommand); } }

        public ICommand AcceptViewCommand
        { get { return Commands.GetOrCreateCommand(() => AcceptViewCommand, ExecuteAcceptViewCommand); } }

        public ICommand AddMerchandiseCommand
        { get { return Commands.GetOrCreateCommand(() => AddMerchandiseCommand, ExecuteAddMerchandiseCommand); } }

        public ICommand ManageSelecectionsCommand
        { get { return Commands.GetOrCreateCommand(() => ManageSelecectionsCommand, ExecuteManageSelecectionsCommand); } }

        public ICommand FilterSpotSDMCommand
        { get { return Commands.GetOrCreateCommand(() => FilterSpotSDMCommand, ExecuteFilterSpotSDMCommand, CanExecuteFilterSpotSDMCommand); } }

        public ICommand SortSelectedItemsCommand
        { get { return Commands.GetOrCreateCommand(() => SortSelectedItemsCommand, ExecuteSortSelectedItemsCommand, CanExecuteSortSelectedItemsCommand); } }

        private void ExecuteSortSelectedItemsCommand()
        {
            switch (SelectedSortType)
            {
                case SortType.ByDescending:
                    this.CSIs = this.CSIs.OrderByDescending(csi => csi.SDM.Cost).ToList();
                    break;
                case SortType.ByScending:
                    this.CSIs = this.CSIs.OrderBy(csi => csi.SDM.Cost).ToList();
                    break;
                case SortType.Alphabetic:
                    this.CSIs = this.CSIs.OrderBy(csi => csi.SDM.MerchandiseName).ToList();
                    break;
            }
        }

        private void ExecuteFilterSpotSDMCommand()
        {
            var res = new List<SpotSDMVM>();
            var merchandiseAdded = new List<string>();
            string merchandiseName = string.Empty;
            switch (SelectedSortType)
            {
                case SortType.ByDescending:
                    AllSpotSDM = AllSpotSDM.OrderByDescending(_ssdm => _ssdm.SDM.Cost).ToList();
                    break;
                case SortType.ByScending:
                    AllSpotSDM = AllSpotSDM.OrderBy(_ssdm => _ssdm.SDM.Cost).ToList();
                    break;
                case SortType.Alphabetic:
                    AllSpotSDM = AllSpotSDM.OrderBy(_ssdm => _ssdm.SDM.MerchandiseName).ToList();
                    break;
            }

            foreach (SpotSDMVM ssdmVM in AllSpotSDM)
                if (ssdmVM.SDM.Merchendise.Tags.ToLower().Contains(SelectedTag.Name.ToLower()))
                {
                    merchandiseName = ssdmVM.MerchandiseName;
                    if (!merchandiseAdded.Contains(merchandiseName))
                    {
                        ssdmVM.CurrentMerchandiseAllSMDs = new List<SDMVM>();
                        ssdmVM.CurrentMerchandiseAllSMDs.Add(ssdmVM.SDM);
                        res.Add(ssdmVM);
                        merchandiseAdded.Add(merchandiseName);
                    }
                    else
                    {
                        var ssdmToExtend = res.Find(_ssdmVM => _ssdmVM.MerchandiseName == merchandiseName);
                        ssdmToExtend.CurrentMerchandiseAllSMDs.Add(ssdmVM.SDM);
                    }
                }
            FilteredSpotSDM = res;
        }

        private void ExecuteManageSelecectionsCommand()
        {
            CustomerMainWindow.SelectedItems.IsSelected = true;
        }

        private void ExecuteAddMerchandiseCommand()
        {
            try
            {
                var newCSIVM = new CustomerSelectedItemsVM(_customer.ID, SelectedSDM.ID);
                if (this.CSIs.ToList().Find(_csiVM => _csiVM.CustomerID == newCSIVM.CustomerID && _csiVM.SDMID == newCSIVM.SDMID) == null)
                {
                    _customer.CSIs.Add(new CustomerSelectedItems(ID, newCSIVM.SDMID));
                    OnPropertyChanged("CSIs");
                    MessageBox.Show("Товар успешно добавлен в корзину.", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Вы уже выбрили такой товар.", "Добавление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            { MessageBox.Show("Error! " + e.Message, "Добавление", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void ExecuteAcceptViewCommand()
        {
            switch (_selectedView)
            {
                case MarketViews.MarketView:
                    CustomerMainWindow.grdVirtualMapView.Visibility = System.Windows.Visibility.Visible;
                    CustomerMainWindow.grdListAllView.Visibility = System.Windows.Visibility.Hidden;
                    CustomerMainWindow.grdVirtualMapView.BringIntoView();
                    break;
                case MarketViews.ListOfMerchandise:
                    CustomerMainWindow.grdListAllView.Visibility = System.Windows.Visibility.Visible;
                    CustomerMainWindow.grdVirtualMapView.Visibility = System.Windows.Visibility.Hidden;
                    CustomerMainWindow.grdListAllView.BringIntoView();
                    break;
            }
        }

        private void ExecuteSavePersonalInformationCommand()
        {
            _customer.User.Login = NewLogin;
            _customer.User.Password = NewPWord;
            _customer.Save();
        }

        private bool CanExecuteSortSelectedItemsCommand()
        {
            return SelectedSortType != null;
        }

        private bool CanExecuteFilterSpotSDMCommand()
        {
            return SelectedTag != null;
        }

        private bool CanExecuteSavePersonalInformationCommand()
        {
            if (NewPWord != NewPWordComfirm)
                return false;

            if (string.IsNullOrEmpty(NewLogin) && string.IsNullOrEmpty(NewPWord) && string.IsNullOrEmpty(NewPWordComfirm) &&
                string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleName) && string.IsNullOrEmpty(LastName) &&
                Age <= 0 && string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(PhoneNumber))
                return false;

            return true;
        }

        #endregion

        private List<CustomerSelectedItems> ToList(List<CustomerSelectedItemsVM> list)
        {
            var res = new List<CustomerSelectedItems>();
            foreach (CustomerSelectedItemsVM vm in list)
                res.Add(new CustomerSelectedItems(vm.ID, vm.CustomerID, vm.SDMID));

            return res;
        }

        private ObservableCollection<CustomerSelectedItemsVM> ToObservableCollection(List<CustomerSelectedItems> list)
        {
            var res = new ObservableCollection<CustomerSelectedItemsVM>();
            foreach (CustomerSelectedItems vm in list)
                res.Add(new CustomerSelectedItemsVM(vm.ID, vm.CustomerID, vm.SDMID));

            return res;
        }
    }
}