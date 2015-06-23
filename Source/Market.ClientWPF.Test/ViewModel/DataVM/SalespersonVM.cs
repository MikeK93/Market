// --------------------------------------------------------------------------
// <copyright file="Salesperson.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Command.ViewModel.Base;
using Market.ClientWPF.Test.View.Salesperson;
using Market.Middleware;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents Salesperson.
    /// </summary>
    public class SalespersonVM : BaseVM
    {
        private Salesperson _salesperson;
        private SalespersonMainWindow _window;

        private string _newLogin;
        private string _newPWord;
        private string _newPWordComfirm;
        private DealerVM _selectedDealer;
        private SDMVM _selectedSDM;
        private DMVM _selectedDM;
        private DMVM _selectedMerchandiseDM;
        private DMVM _selectedAvailableMerchandiseDM;
        private SpotVM _selectedSpot;
        private SpotVM _selectedNewSpot;
        private CustomerVM _selectedCustomer;
        private MerchandiseVM _selectedMerchandise;
        private MerchandiseVM _selectedAvailableMerchandise;
        private CustomerSelectedItemsVM _selectedCSI;
        private List<GenderType> _genders;

        #region ViewModel
        #region Login & PWord
        [Required(ErrorMessage = "Логин не должен быть пустым!")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Логин должен иметь от 6 до 15 символов!")]
        public string NewLogin
        {
            get { return _newLogin; }
            set
            {
                _newLogin = value;
                OnPropertyChanged("NewLogin");
            }
        }

        [Required(ErrorMessage = "Пароль не должен быть пустым!")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Пароль должен иметь от 8 до 15 символов!")]
        [DataType(DataType.Password)]
        public string NewPWord
        {
            get { return _newPWord; }
            set
            {
                _newPWord = value;
                OnPropertyChanged("NewPWord");
            }
        }

        [Required(ErrorMessage = "Пароль не должен быть пустым!")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Пароль должен иметь от 8 до 15 символов!")]
        [DataType(DataType.Password)]
        public string NewPWordComfirm
        {
            get { return _newPWordComfirm; }
            set
            {
                _newPWordComfirm = value;
                OnPropertyChanged("NewPWordComfirm");
            }
        }
        #endregion
        public SalespersonMainWindow MainWindow { get { return _window; } }

        /// <summary>
        /// Gets list of genders.
        /// </summary>
        public List<GenderType> Genders
        {
            get { return _genders; }
        }

        /// <summary>
        /// Gets or sets selected dealer.
        /// </summary>
        public DealerVM SelectedDealer
        {
            get { return _selectedDealer; }
            set
            {
                if (value == null)
                    return;

                _selectedDealer = value;
                OnPropertyChanged("SelectedDealer");
                OnPropertyChanged("SelectedDealerMerchandise");
            }
        }

        /// <summary>
        /// Gets or sets selected sdm.
        /// </summary>
        public SDMVM SelectedSDM
        {
            get { return _selectedSDM; }
            set
            {
                if (value == null)
                    return;

                _selectedSDM = value;
                OnPropertyChanged("SelectedSDM");
            }
        }

        /// <summary>
        /// Gets or sets selected DM.
        /// </summary>
        public DMVM SelectedDM
        {
            get { return _selectedDM; }
            set
            {
                if (value == null)
                    return;

                _selectedDM = value;
                SelectedSDM = null;
                OnPropertyChanged("SelectedDM");
                OnPropertyChanged("DealersForSelectedMerchandise");
                OnPropertyChanged("SpotsForSelectedMerchandise");
            }
        }

        /// <summary>
        /// Gets or sets selected spot.
        /// </summary>
        public SpotVM SelectedSpot
        {
            get { return _selectedSpot; }
            set
            {
                if (value == null)
                    return;

                _selectedSpot = value;
                OnPropertyChanged("SelectedSpot");
            }
        }

        /// <summary>
        /// Gets or sets selected new spot for adding new spots.
        /// </summary>
        public SpotVM SelectedNewSpot
        {
            get { return _selectedNewSpot; }
            set
            {
                if (value == null)
                    return;

                _selectedNewSpot = value;
                OnPropertyChanged("SelectedNewSpot");
            }
        }

        /// <summary>
        /// Gets or sets selected customer
        /// </summary>
        public CustomerVM SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (value == null)
                    return;

                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
                OnPropertyChanged("CustomerSelectedItems");
            }
        }

        /// <summary>
        /// Gets or sets selected customer selected items.
        /// </summary>
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

        /// <summary>
        /// Gets dealers for selected merchandise.
        /// </summary>
        public ObservableCollection<SDMVM> DealersForSelectedMerchandise
        {
            get
            {
                if (SelectedDM == null)
                    return null;

                var res = new ObservableCollection<SDMVM>();
                foreach (SDMVM sdm in SDMs)
                    if (sdm.DealerMerchandise.MerchandiseID == SelectedDM.MerchandiseID)
                        res.Add(sdm);

                return res;
            }
        }

        /// <summary>
        /// Gets list of merchandise for selected dealer.
        /// </summary>
        public ObservableCollection<SDMVM> SelectedDealerMerchandise
        {
            get
            {
                if (SelectedDealer == null)
                    return null;

                var res = new ObservableCollection<SDMVM>();
                foreach (var sdm in SDMs)
                    if (sdm.Dealer.ID == SelectedDealer.ID)
                        res.Add(sdm);

                return res;
            }
        }

        /// <summary>
        /// Gets dm without repeats.
        /// </summary>
        public ObservableCollection<DMVM> ModifiedDMs
        {
            get
            {
                var res = new List<DMVM>();
                foreach (DMVM dm in DMs)
                    if (res.Find(_dm => _dm.MerchandiseID == dm.MerchandiseID) == null)
                        res.Add(dm);

                return new ObservableCollection<DMVM>(res);
            }
        }

        /// <summary>
        /// Gets all available DMs.
        /// </summary>
        public ObservableCollection<DMVM> GetAllDMs
        {
            get { return DMVM.GetAllDMs; }
        }

        /// <summary>
        /// Gets all available spots.
        /// </summary>
        public ObservableCollection<SpotVM> AllAvailableSpots
        {
            get { return SpotVM.GetAllAvailableSpots; }
        }

        /// <summary>
        /// Gets collection of customer.
        /// </summary>
        public ObservableCollection<CustomerVM> CustomerInitials
        {
            get
            {
                var res = new ObservableCollection<CustomerVM>();
                foreach (var csi in Clients)
                    if (res.ToList().Find(_c => _c.ID == csi.CustomerID) == null)
                        res.Add(csi.Customer);

                return res;
            }
        }

        public ObservableCollection<CustomerSelectedItemsVM> CustomerSelectedItems
        {
            get
            {
                if (SelectedCustomer == null)
                    return null;

                var res = new ObservableCollection<CustomerSelectedItemsVM>();
                foreach (var csi in Clients)
                    if (csi.CustomerID == SelectedCustomer.ID)
                        res.Add(csi);

                return res;
            }
        }

        #region For ManageSDMsWindow
        ///
        /// my DMs
        ///
        //
        /// <summary>
        /// Gets observable collection of merchandise from collectio of DMs with no repeats.
        /// </summary>
        public ObservableCollection<MerchandiseVM> DMMerchandise
        { get { return GetMerchandiseCollFromDMColl(DMs); } }

        /// <summary>
        /// Gets or sets selected Merchandise.
        /// </summary>
        public MerchandiseVM SelectedMerchandise
        {
            get { return _selectedMerchandise; }
            set
            {
                if (value == null)
                    return;

                _selectedMerchandise = value;
                OnPropertyChanged("SelectedMerchandise");
                OnPropertyChanged("MerchandiseDMs");
            }
        }

        /// <summary>
        /// Gets observable collection of DMs by selected merchandise.
        /// </summary>
        public ObservableCollection<DMVM> MerchandiseDMs
        {
            get
            {
                if (SelectedMerchandise == null)
                    return null;

                return GetMerchandiseDMsCollection(DMs, SelectedMerchandise);
            }
        }

        /// <summary>
        /// Gets or sets selected dm for selected merchadnise.
        /// </summary>
        public DMVM SelectedMerchandiseDM
        {
            get { return _selectedMerchandiseDM; }
            set
            {
                if (value == null)
                    return;

                _selectedMerchandiseDM = value;
                OnPropertyChanged("SelectedMerchandiseDM");
            }
        }

        ///
        /// available DMs
        ///
        //
        /// <summary>
        /// Gets all available merhcandise from collectio of DMs.
        /// </summary>
        public ObservableCollection<MerchandiseVM> DMMerchandiseAllAvailable
        { get { return GetMerchandiseCollFromDMColl(GetAllDMs); } }

        /// <summary>
        /// Gets or sets selected Available Merchandise.
        /// </summary>
        public MerchandiseVM SelectedAvailableMerchandise
        {
            get { return _selectedAvailableMerchandise; }
            set
            {
                if (value == null)
                    return;

                _selectedAvailableMerchandise = value;
                OnPropertyChanged("SelectedAvailableMerchandise");
                OnPropertyChanged("AvailableMerchandiseDMs");
            }
        }

        /// <summary>
        /// Gets observable collection of DMs by selected available merhcanidse.
        /// </summary>
        public ObservableCollection<DMVM> AvailableMerchandiseDMs
        {
            get
            {
                if (SelectedAvailableMerchandise == null)
                    return null;

                return GetMerchandiseDMsCollection(GetAllDMs, SelectedAvailableMerchandise);
            }
        }

        /// <summary>
        /// Gets or sets selected available dm for selected available merchadnise.
        /// </summary>
        public DMVM SelectedAvailableMerchandiseDM
        {
            get { return _selectedAvailableMerchandiseDM; }
            set
            {
                if (value == null)
                    return;

                _selectedAvailableMerchandiseDM = value;
                OnPropertyChanged("SelectedAvailableMerchandiseDM");
            }
        }

        #endregion

        #endregion

        #region Salesperson
        /// <summary>
        /// Ctor for cteatign new salesperson
        /// </summary>
        /// <param name="userId">User's id attached to current salesperson.</param>
        public SalespersonVM(Guid userVMId)
        {
            _salesperson = new Salesperson(userVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of SalespersonVM by instance of Salesperson.
        /// </summary>
        /// <param name="s">Instance of Salesperson.</param>
        public SalespersonVM(Salesperson s)
        {
            _salesperson = s;
        }

        /// <summary>
        /// Ctor for recreating salesperson from database.
        /// </summary>
        /// <param name="id">Salesperson's ID in database.</param>
        /// <param name="userVMId">User's ID attached to current salesperon.</param>
        public SalespersonVM(Guid id, Guid userVMId)
        {
            _salesperson = new Salesperson(id, userVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of SalespersonVM for data context.
        /// </summary>
        /// <param name="user">Instance of UserVM class attached to salesperson.</param>
        public SalespersonVM(UserVM user, SalespersonMainWindow window)
        {
            this._salesperson = Salesperson.GetSalespersonByUser(new User(user.ID));
            NewLogin = user.Login;
            NewPWord = NewPWordComfirm = user.Password;
            _genders = new List<GenderType>();
            _genders.Add(GenderType.Female);
            _genders.Add(GenderType.Male);
            OnPropertyChanged("Gender");
            _window = window;
        }

        /// <summary>
        /// Gets Salesperson.
        /// </summary>
        public Salesperson Salesperson { get { return _salesperson; } }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _salesperson.ID; } }

        /// <summary>
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return _salesperson.UserID; } }

        /// <summary>
        /// Gets or sets a first name of a current salesperson.
        /// </summary>
        public string FirstName
        {
            get { return _salesperson.FirstName; }
            set
            {
                if (value == _salesperson.FirstName)
                    return;

                _salesperson.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets a middle name of a current salesperson.
        /// </summary>
        public string MiddleName
        {
            get { return _salesperson.MiddleName; }
            set
            {
                if (value == _salesperson.MiddleName)
                    return;

                _salesperson.MiddleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// Gets or sets a last name of a current salesperson.
        /// </summary>
        public string LastName
        {
            get { return _salesperson.LastName; }
            set
            {
                if (value == _salesperson.LastName)
                    return;

                _salesperson.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets a phone number.
        /// </summary>
        public string PhoneNumber
        {
            get { return _salesperson.PhoneNumber; }
            set
            {
                if (value == _salesperson.PhoneNumber)
                    return;

                _salesperson.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Gets or sets an email.
        /// </summary>
        public string Email
        {
            get { return _salesperson.Email; }
            set
            {
                if (value == _salesperson.Email)
                    return;

                _salesperson.Email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets a gender of a current salesperson.
        /// </summary>
        public GenderType Gender
        {
            get { return _salesperson.Gender; }
            set
            {
                if (value == _salesperson.Gender)
                    return;

                _salesperson.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew
        { get { return _salesperson.IsNew; } }

        /// <summary>
        /// Gets User attached to current salesperson.
        /// </summary>
        public UserVM User
        {
            get { return new UserVM(_salesperson.User); }
            //UserMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("User", Middleware.MethodType.GetById, string.Empty, _userId)[0]); }
        }

        /// <summary>
        /// Gets or sets a list of Salesperson-Dealer-Merchandise.
        /// </summary>
        public ObservableCollection<SDMVM> SDMs
        {
            get { return new ObservableCollection<SDMVM>(from sdm in _salesperson.SDMs select new SDMVM(sdm)); }
        }

        /// <summary>
        /// Gets a list of all merchandise, current salesperson is selling.
        /// </summary>
        public ObservableCollection<DMVM> DMs
        {
            get { return new ObservableCollection<DMVM>(from dm in _salesperson.DMs select new DMVM(dm)); }
        }

        /// <summary>
        /// Gets a list of dealers, current salesperson is working with.
        /// </summary>
        public ObservableCollection<DealerVM> Dealers
        {
            get { return new ObservableCollection<DealerVM>(from d in _salesperson.Dealers select new DealerVM(d)); }
        }

        /// <summary>
        /// Gets a list of banks, current salesperson is using.
        /// </summary>
        public ObservableCollection<BankVM> Banks
        {
            get { return new ObservableCollection<BankVM>(from b in _salesperson.Banks select new BankVM(b)); }
        }

        /// <summary>
        /// Gets a list of spots, current salesperson is using.
        /// </summary>
        public ObservableCollection<SpotVM> Spots
        {
            get { return new ObservableCollection<SpotVM>(from s in _salesperson.Spots select new SpotVM(s)); }
        }

        /// <summary>
        /// Gets a list of clients and order details.
        /// </summary>
        public ObservableCollection<CustomerSelectedItemsVM> Clients
        {
            get { return new ObservableCollection<CustomerSelectedItemsVM>(from csi in _salesperson.Clients select new CustomerSelectedItemsVM(csi)); }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            _salesperson.Save();
        }

        /// <summary>
        /// Method updates selected daeler-merchandise list.
        /// </summary>
        public void UpdateSDMs()
        {
            var sdms = SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", MethodType.GetByQuery, "SalespersonID='" + this.ID + "'", Guid.Empty));
            this._salesperson.SDMs = new List<SDM>();
            foreach (SDM sdm in sdms)
                SDMs.Add(new SDMVM(sdm));
        }

        /// <summary>
        /// Method updates clients list.
        /// </summary>
        public void UpdateClients()
        {
            _salesperson.UpdateClients();
        }

        /// <summary>
        /// Method compares two instance of a Salesperson class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            SalespersonVM s = obj as SalespersonVM;
            if (s == null) return false;
            if (s.ID == ID) return true;
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
        /// <returns>First and Last Names of salesperson.</returns>
        public override string ToString()
        { return FirstName + " " + LastName; }
        #endregion

        #region ICommands

        public ICommand SavePersonalInformationCommand
        { get { return Commands.GetOrCreateCommand(() => SavePersonalInformationCommand, ExecuteSavePersonalInformationCommand, CanExecuteSavePersonalInformationCommand); } }

        public ICommand RemoveSDMCommand
        { get { return Commands.GetOrCreateCommand(() => RemoveSDMCommand, ExecuteRemoveSDMCommand, CanExecuteRemoveSDMCommand); } }

        public ICommand ManageSDMsCommand
        { get { return Commands.GetOrCreateCommand(() => ManageSDMsCommand, ExecuteManageSDMsCommand); } }

        public ICommand ShowDealersCommand
        { get { return Commands.GetOrCreateCommand(() => ShowDealersCommand, ExecuteShowDealersCommand); } }

        public ICommand ManageSpotSDMsCommand
        { get { return Commands.GetOrCreateCommand(() => ManageSpotSDMsCommand, ExecuteManageSpotSDMsCommand); } }

        public ICommand AddSpotToMerchandiseCommand
        { get { return Commands.GetOrCreateCommand(() => AddSpotToMerchandiseCommand, ExecuteAddSpotToMerchandiseCommand, CanExecuteAddSpotToMerchandiseCommand); } }

        public ICommand ManageSpotsCommand
        { get { return Commands.GetOrCreateCommand(() => ManageSpotsCommand, ExecuteManageSpotsCommand); } }

        public ICommand AddNewSpotCommand
        { get { return Commands.GetOrCreateCommand(() => AddNewSpotCommand, ExecuteAddNewSpotCommand, CanExecuteAddNewSpotCommand); ; } }

        public ICommand RemoveOldSpotCommand
        { get { return Commands.GetOrCreateCommand(() => RemoveOldSpotCommand, ExecuteRemoveOldSpotCommand, CanExecuteRemoveOldSpotCommand); } }

        public ICommand UpdateClientsCommand
        { get { return Commands.GetOrCreateCommand(() => UpdateClientsCommand, ExecuteUpdateClientsCommand); } }

        // UpdateClientsCommand
        private void ExecuteUpdateClientsCommand()
        {
            UpdateClients();
            MessageBox.Show("Список клиентов обновлен.", "Клиенты", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // RemoveOldSpotCommand *CAN
        private bool CanExecuteRemoveOldSpotCommand() { return SelectedSpot != null; }

        // RemoveOldSpotCommand *EXE
        private void ExecuteRemoveOldSpotCommand()
        {
            var removeSpotNumber = SelectedSpot.Number;
            if (MessageBox.Show("Вы уверены что хотите удалить место №" + removeSpotNumber + "?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                return;

            SelectedSpot.Salesperson = null;
            SelectedSpot.Save();
            OnPropertyChanged("Spots");
            MessageBox.Show("Успешно удалено место №" + removeSpotNumber + ".", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // AddNewSpotCommand *CAN
        private bool CanExecuteAddNewSpotCommand() { return SelectedNewSpot != null; }

        // AddNewSpotCommand *EXE
        private void ExecuteAddNewSpotCommand()
        {
            try
            {
                SelectedNewSpot.Salesperson = this;
                SelectedNewSpot.Save();
                OnPropertyChanged("Spots");
                MessageBox.Show("Успешно добавлено место №" + SelectedNewSpot.Number + ".", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "Ошибка при добавлении места №" + SelectedNewSpot.Number + "." + Environment.NewLine + "Сообщение ошибки: " + e.Message,
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        // ManageSpotsCommand *EXE
        private void ExecuteManageSpotsCommand()
        {
            new ManageSpotsWindow(this).ShowDialog();
            OnPropertyChanged("Spots");
        }

        // AddSpotToMerchandiseCommand *CAN
        private bool CanExecuteAddSpotToMerchandiseCommand() { return SelectedSpot != null && SelectedSDM != null; }

        // AddSpotToMerchandiseCommand *EXE
        private void ExecuteAddSpotToMerchandiseCommand()
        {
            var newSpotSDM = new SpotSDM(SelectedSpot.ID, SelectedSDM.ID);
            var canAdd = SelectedSDM.SpotSDMs.ToList().Find(_ssdm => _ssdm.SpotID == SelectedSpot.ID && _ssdm.SDMID == SelectedSDM.ID) == null;
            if (!canAdd)
            {
                MessageBox.Show("Вы уже выбрали такой елемент!", "Добавление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            newSpotSDM.Save();
            OnPropertyChanged("SelectedSDM");
            MessageBox.Show("Товар успешно добавлен!", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // ManageSpotSDMsCommand *EXE
        private void ExecuteManageSpotSDMsCommand()
        {
            new ManageSpotSDMsWindow(this).ShowDialog();
            OnPropertyChanged("Spots");
        }

        // ShowDealersCommand *EXE
        private void ExecuteShowDealersCommand() { MainWindow.subTabDealers.IsSelected = true; }

        // ManageSDMsCommand *EXE
        private void ExecuteManageSDMsCommand()
        {
            new ManageSDMsWindow(this).ShowDialog();
            OnPropertyChanged("SDMs");
        }

        // RemoveSDMCommand *CAN
        private bool CanExecuteRemoveSDMCommand() { return SelectedSDM != null; }

        // RemoveSDMCommand *EXE
        private void ExecuteRemoveSDMCommand()
        {
            SelectedSDM.Delete();
            MessageBox.Show("Успешно удалено.", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // SavePersonalInformationCommand *CAN
        private bool CanExecuteSavePersonalInformationCommand()
        {
            if (NewPWord != NewPWordComfirm)
                return false;

            if (string.IsNullOrEmpty(NewLogin) && string.IsNullOrEmpty(NewPWord) && string.IsNullOrEmpty(NewPWordComfirm) &&
                string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleName) && string.IsNullOrEmpty(LastName) &&
                string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(PhoneNumber))
                return false;

            return true;
        }

        // SavePersonalInformationCommand *EXE
        private void ExecuteSavePersonalInformationCommand()
        {
            _salesperson.User.Login = NewLogin;
            _salesperson.User.Password = NewPWord;
            _salesperson.Email = Email;
            _salesperson.PhoneNumber = PhoneNumber;
            _salesperson.FirstName = FirstName;
            _salesperson.MiddleName = MiddleName;
            _salesperson.LastName = LastName;
            _salesperson.Save();
            MessageBox.Show("Успешно сохранено!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        /// <summary>
        /// Gets observable collection of DMVM by selected merchandise.
        /// </summary>
        /// <param name="initialCollection">Collection of objects to go though.</param>
        /// <param name="selectedMerchandise">Selected merhcandise to get collection of DMs for.</param>
        /// <returns>Observable collection of DMVM.</returns>
        private ObservableCollection<DMVM> GetMerchandiseDMsCollection(ObservableCollection<DMVM> initialCollection, MerchandiseVM selectedMerchandise)
        {
            var res = new ObservableCollection<DMVM>();
            foreach (DMVM dm in initialCollection)
                if (dm.MerchandiseID == selectedMerchandise.ID)
                    res.Add(dm);

            return res;
        }

        /// <summary>
        /// Gets merchandise collectio from collection of DMs with no repeats.
        /// </summary>
        /// <param name="initialCollection">Collectio of DMs to get merchandise from.</param>
        /// <returns>Collection of MerchandiseVM.</returns>
        private ObservableCollection<MerchandiseVM> GetMerchandiseCollFromDMColl(ObservableCollection<DMVM> initialCollection)
        {
            var res = new ObservableCollection<MerchandiseVM>();
            foreach (DMVM dm in initialCollection)
                if (res.ToList().Find(_m => _m.ID == dm.MerchandiseID) == null)
                    res.Add(dm.Merchandise);

            return res;
        }
    }
}