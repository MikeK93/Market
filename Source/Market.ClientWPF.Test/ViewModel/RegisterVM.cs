using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Command.ViewModel.Base;
using Market.ClientWPF.Test.Attribute;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;
using Market.ViewModel.DataVM;

namespace Market.ClientWPF.Test.ViewModel
{
    public class RegisterVM : BaseVM
    {
        private List<GenderType> _genderTypes;
        private List<Role> _roles;
        private GenderType _selectedGender;
        private Role _selectedRole;
        private string _login;
        private string _pword;
        private string _fName;
        private string _mName;
        private string _lName;
        private string _email;

        public List<GenderType> Gender
        {
            get { return _genderTypes; }
        }

        public List<Role> Roles
        {
            get { return _roles; }
        }

        public Role SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                _selectedRole = value;
                OnPropertyChanged("SelectedRole");
            }
        }

        public GenderType SelectedGender
        {
            get { return _selectedGender; }
            set
            {
                _selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }

        [Required(ErrorMessage = "Логин не может быть пустым!")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Логин должен иметь от 6 до 15 символов!")]
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        [Required(ErrorMessage = "Пароль не может быть пустым!")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Пароль должен иметь от 8 до 15 символов!")]
        [DataType(DataType.Password)]
        public string PWord
        {
            get { return _pword; }
            set
            {
                _pword = value;
                OnPropertyChanged("PWord");
            }
        }

        [Required(ErrorMessage = "Имя не может быть пустым!")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Имя должнo иметь от 2 до 15 символов!")]
        [ExcludeChar("/.,!?`@#$%~^&*()_-+=\"'<>{}[]\\|", ErrorMessage = "Имя имеет неправильный формат!")]
        public string FName
        {
            get { return _fName; }
            set
            {
                _fName = value;
                OnPropertyChanged("FName");
            }
        }

        public string MName
        {
            get { return _mName; }
            set
            {
                _mName = value;
                OnPropertyChanged("MName");
            }
        }

        [Required(ErrorMessage = "Фамилия не может быть пустым!")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Фамилия должнa иметь от 2 до 15 символов!")]
        [ExcludeChar("/.,!?`@#$%~^&*()_-+=\"'<>{}[]\\|", ErrorMessage = "Фамилия имеет неправильный формат!")]
        public string LName
        {
            get { return _lName; }
            set
            {
                _lName = value;
                OnPropertyChanged("LName");
            }
        }

        [Required(ErrorMessage = "Email адресс не может быть пустым!")]
        [EmailAddress(ErrorMessage = "Email адресс не правельный!")]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public RegisterVM()
        {
            _genderTypes = new List<GenderType>();
            _genderTypes.Add(GenderType.Female);
            _genderTypes.Add(GenderType.Male);
            _roles = new List<Role>();
            _roles.Add(Role.Customer);
            _roles.Add(Role.Dealer);
            _roles.Add(Role.Salesperson);
            OnPropertyChanged("Login");
            OnPropertyChanged("PWord");
            OnPropertyChanged("FName");
            OnPropertyChanged("LName");
            OnPropertyChanged("Email");
        }

        #region ICommands

        #region RegisterCommand

        public ICommand RegisterCommand
        {
            get { return Commands.GetOrCreateCommand(() => RegisterCommand, ExecuteRegisterCommand, CanExecuteRegisterCommand); }
        }

        private void ExecuteRegisterCommand()
        {
            UserVM newUser = new UserVM();
            newUser.Login = Login;
            newUser.Password = PWord;
            newUser.Role = SelectedRole;

            bool isNewUser = UserVM.GetByLoginPassword(Login, PWord) == null;
            if (isNewUser)
            {
                newUser.Save();
                switch (newUser.Role)
                {
                    case Role.Customer:
                        {
                            var c = new CustomerVM(newUser.ID);
                            c.FirstName = FName;
                            c.MiddleName = MName;
                            c.LastName = LName;
                            c.Gender = SelectedGender;
                            c.PhoneNumber = string.Empty;
                            c.Email = Email;
                            c.Save();
                            break;
                        }

                    case Role.Salesperson:
                        {
                            var s = new SalespersonVM(newUser.ID);
                            s.FirstName = FName;
                            s.MiddleName = MName;
                            s.LastName = LName;
                            s.PhoneNumber = string.Empty;
                            s.Gender = SelectedGender;
                            s.Email = Email;
                            s.Save();
                            break;
                        }

                    case Role.Dealer:
                        {
                            var d = new DealerVM(newUser.ID);
                            d.FirstName = FName;
                            d.MiddleName = MName;
                            d.LastName = LName;
                            d.PhoneNumber = string.Empty;
                            d.Gender = SelectedGender;
                            d.Email = Email;
                            d.Save();
                            break;
                        }
                }
                MessageBox.Show("Вы успешно зарегестрированы.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            MessageBox.Show("Ошибка! 1)Проверте правильность введенного вами логина и пароля. " + Environment.NewLine + "2)Возможно Вы не зарегистрированы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private bool CanExecuteRegisterCommand()
        {
            if (string.IsNullOrEmpty(_fName) && string.IsNullOrEmpty(_mName)
                && string.IsNullOrEmpty(_lName) && string.IsNullOrEmpty(_email)
                && string.IsNullOrEmpty(_login) && string.IsNullOrEmpty(_pword))
                return false;

            return true;
        }

        #endregion

        #endregion
    }
}