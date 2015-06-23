// --------------------------------------------------------------------------
// <copyright file="Dealer.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Input;
using Command.ViewModel.Base;
using Market.ClientWPF.Test.View.Dealer;
using Market.Middleware;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a dealer.
    /// </summary>
    public class DealerVM : BaseVM
    {
        private Dealer _dealer;

        private string _newLogin;
        private string _newPWord;
        private string _newPWordComfirm;
        private DMVM _selectedDM;
        private SDMVM _selectedClient;
        private List<GenderType> _genders;
        private ObservableCollection<SDMVM> _allSDMs;

        #region ViewModel

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

        public DMVM SelectedDM
        {
            get { return _selectedDM; }
            set
            {
                if (value == null)
                    return;

                _selectedDM = value;
                OnPropertyChanged("SelectedDM");
            }
        }

        public List<GenderType> Genders
        {
            get { return _genders; }
        }

        public SDMVM SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                if (value == null)
                    return;

                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
                OnPropertyChanged("SelectedClientMerchandise");
            }
        }

        public string DealerInitials { get { return FirstName + " " + MiddleName + " " + LastName; } }

        public string GenderIcon
        {
            get
            {
                return @"D:\Files\Studying\Лабораторки\EXAMPLES\EpamClasses\Market\Market\Source\Market.ClientWPF.Test\Assets\" + Gender.ToString().ToLowerInvariant() + ".ico";
            }
        }

        #endregion

        #region Dealer

        /// <summary>
        /// Custom constructor for recreating dealer from database.
        /// </summary>
        /// <param name="id">ID of a dealer in database.</param>
        /// <param name="userVMId">ID of a user attached to this dealer.</param>
        public DealerVM(Guid id, Guid userVMId)
        {
            _dealer = new Dealer(id, userVMId);
        }

        /// <summary>
        /// Ctor for creating new instance of DealerVM by instance of Dealer class.
        /// </summary>
        /// <param name="dealer">Instance of Dealer class.</param>
        public DealerVM(Dealer dealer)
        {
            _dealer = dealer;
        }

        /// <summary>
        /// Custom constructor for creating new dealer.
        /// </summary>
        /// <param name="userVMId">User profile attached to a dealer.</param>
        public DealerVM(Guid userVMId)
        {
            _dealer = new Dealer(userVMId);
        }

        /// <summary>
        /// Ctor for creating data contex.
        /// </summary>
        /// <param name="user">User attaced to the dealer.</param>
        public DealerVM(UserVM user)
        {
            this._dealer = Dealer.GetDealerByUser(new User(user.ID));
            NewLogin = user.Login;
            NewPWord = NewPWordComfirm = user.Password;
            _genders = new List<GenderType>();
            _genders.Add(GenderType.Female);
            _genders.Add(GenderType.Male);
            _allSDMs = SDMVM.GetAll;
            OnPropertyChanged("Gender");
        }

        /// <summary>
        /// Method gets dealer by user.
        /// </summary>
        /// <param name="user">User attached to dealer.</param>
        /// <returns>Dealer object.</returns>
        public static DealerVM GetDealerByUser(UserVM user)
        {
            var packedObjects = MarketProxy.Proxy.GetData("Dealer", MethodType.GetByQuery, "UserID='" + user.ID + "'", Guid.Empty);
            return new DealerVM(DealerMapper.Mapper.UnPack(packedObjects[0]));
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _dealer.ID; } }

        /// <summary>
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return _dealer.UserID; } }

        /// <summary>
        /// Gets or sets a first name of a current dealer.
        /// </summary>
        public string FirstName
        {
            get { return _dealer.FirstName; }
            set
            {
                if (_dealer.FirstName == value)
                    return;

                _dealer.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets a middle name of a current dealer.
        /// </summary>
        public string MiddleName
        {
            get { return _dealer.MiddleName; }
            set
            {
                if (_dealer.MiddleName == value)
                    return;

                _dealer.MiddleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// Gets or sets a last name of a current dealer.
        /// </summary>
        public string LastName
        {
            get { return _dealer.LastName; }
            set
            {
                if (_dealer.LastName == value)
                    return;

                _dealer.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets a Gender of a current dealer.
        /// </summary>
        public GenderType Gender
        {
            get { return _dealer.Gender; }
            set
            {
                if (_dealer.Gender == value)
                    return;

                _dealer.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// Gets or sets a phone number of a current dealer.
        /// </summary>
        public string PhoneNumber
        {
            get { return _dealer.PhoneNumber; }
            set
            {
                if (_dealer.PhoneNumber == value)
                    return;

                _dealer.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Gets or sets an email.
        /// </summary>
        public string Email
        {
            get { return _dealer.Email; }
            set
            {
                if (_dealer.Email == value)
                    return;

                _dealer.Email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Dealer is new.
        /// </summary>
        public bool IsNew
        { get { return _dealer.IsNew; } }

        /// <summary>
        /// Gets User attached to current dealer.
        /// </summary>
        public UserVM User
        {
            get
            { return new UserVM(_dealer.User); }
        }

        /// <summary>
        /// Gets merchandise that available for clients.
        /// </summary>
        public ObservableCollection<MerchandiseVM> AllMerchandise
        {
            get { return new ObservableCollection<MerchandiseVM>(from dm in this.DMs.AsEnumerable() select dm.Merchandise); }
        }

        /// <summary>
        /// Gets all banks current dealer is using.
        /// </summary>
        public ObservableCollection<BankVM> Banks
        {
            get { return new ObservableCollection<BankVM>(from b in _dealer.Banks select new BankVM(b)); }
        }

        /// <summary>
        /// Gets all Dealer-Merchandise relations.
        /// </summary>
        public ObservableCollection<DMVM> DMs
        {
            get { return new ObservableCollection<DMVM>(from dm in _dealer.DMs select new DMVM(dm)); }
        }

        /// <summary>
        /// Gets list of clients.
        /// </summary>
        public ObservableCollection<SDMVM> Clients
        {
            get
            {
                var res = new List<SDMVM>();
                foreach (DMVM dm in DMs)
                {
                    var sdm = _allSDMs.ToList().Find(_sdm => _sdm.DealerMerchandiseID == dm.ID);
                    if (sdm != null)
                        if (res.Find(_sdm => _sdm.SalespersonID == sdm.SalespersonID) == null)
                            res.Add(sdm);
                }

                return new ObservableCollection<SDMVM>(res.Distinct());
            }
        }

        public ObservableCollection<SDMVM> SelectedClientMerchandise
        {
            get
            {
                if (SelectedClient == null)
                    return null;

                var res = new List<SDMVM>();
                foreach (var sdm in _allSDMs)
                {
                    if (sdm.SalespersonID == SelectedClient.SalespersonID)
                        res.Add(sdm);
                }

                return new ObservableCollection<SDMVM>(res);
            }
        }

        /// <summary>
        /// Saves changes.
        /// </summary>
        public void Save()
        {
            this._dealer.Save();
        }

        /// <summary>
        /// Method compares two instance of a Dealer class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            Dealer d = obj as Dealer;
            if (d == null) return false;
            if (d.ID == ID) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Shows string representation of dealer.
        /// </summary>
        /// <returns>First and last names.</returns>
        public override string ToString()
        { return FirstName + " " + LastName; }
        #endregion

        #region ICommand

        public ICommand SavePersonalInformationCommand
        { get { return Commands.GetOrCreateCommand(() => SavePersonalInformationCommand, ExecuteSavePersonalInformationCommand, CanExecuteSavePersonalInformationCommand); } }

        public ICommand DeleteCommand
        { get { return Commands.GetOrCreateCommand(() => DeleteCommand, ExecuteDeleteCommand, CanExecuteDeleteCommand); } }

        public ICommand ManageCommand
        { get { return Commands.GetOrCreateCommand(() => ManageCommand, ExecuteManageCommand); } }

        // ManageComman
        private void ExecuteManageCommand()
        {
            new ManageMerchandiseWindow(this).ShowDialog();
            OnPropertyChanged("DMs");
        }

        // DeleteCommand
        private void ExecuteDeleteCommand()
        {
            if (MessageBox.Show("Вы уверены что хотите удалить \"" + SelectedDM.MerchandiseName + "\"?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question)
                != MessageBoxResult.Cancel)
            {
                SelectedDM.Delete();
                OnPropertyChanged("DMs");
            }
        }

        // DeleteCommand
        private bool CanExecuteDeleteCommand()
        {
            return SelectedDM != null;
        }

        // SavePersonalInformationCommand
        private void ExecuteSavePersonalInformationCommand()
        {
            _dealer.User.Login = NewLogin;
            _dealer.User.Password = NewPWord;
            _dealer.Email = Email;
            _dealer.PhoneNumber = PhoneNumber;
            _dealer.FirstName = FirstName;
            _dealer.MiddleName = MiddleName;
            _dealer.LastName = LastName;
            _dealer.Save();
            MessageBox.Show("Успешно сохранено!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // SavePersonalInformationCommand
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

        #endregion
    }
}