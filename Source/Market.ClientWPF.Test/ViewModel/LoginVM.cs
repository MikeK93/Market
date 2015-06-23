using System;
using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using Command.ViewModel.Base;
using Market.ClientWPF.View.Customer;
using Market.ClientWPF.View.User;
using Market.Model.Entities;
using Market.ViewModel.DataVM;
using Market.ClientWPF.Test.View.Dealer;
using Market.ClientWPF.Test.View.Salesperson;
using System.Windows;

namespace Market.ClientWPF.ViewModel
{
    public class LoginVM : BaseVM
    {
        private static LoginVM _instance;

        private string _login;
        private string _loginError;
        private string _pwd;
        private string _pwdError;

        public static LoginVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoginVM();

                return _instance;
            }
        }

        private LoginVM()
        {
            OnPropertyChanged("Login");
            OnPropertyChanged("PWord");
        }

        [Required(ErrorMessage = "Логин не должен быть пустым!")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Логин должен иметь от 4 до 15 символов!")]
        public string Login
        {
            get { return _login; }
            set
            {
                if (value == _login)
                    return;

                _login = value;
                OnPropertyChanged("Login");
                LoginError = this["Login"].ToString();
            }
        }

        [Required(ErrorMessage = "Пароль не должен быть пустым!")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Пароль должен иметь от 4 до 15 символов!")]
        [DataType(DataType.Password)]
        public string PWord
        {
            get { return _pwd; }
            set
            {
                if (value == _pwd)
                    return;

                _pwd = value;
                OnPropertyChanged("PWord");
                PWordError = this["PWord"].ToString();
            }
        }

        public string LoginError
        {
            get { return _loginError; }
            set
            {
                _loginError = value;
                OnPropertyChanged("LoginError");
            }
        }

        public string PWordError
        {
            get { return _pwdError; }
            set
            {
                _pwdError = value;
                OnPropertyChanged("PWordError");
            }
        }
        #region ICommand

        public ICommand LoginCommand
        {
            get { return Commands.GetOrCreateCommand(() => LoginCommand, ExecuteLoginCommand, CanExecuteLoginCommand); }
        }

        public ICommand RegisterCommand
        {
            get { return Commands.GetOrCreateCommand(() => RegisterCommand, ExecuteRegisterCommand); }
        }

        private void ExecuteRegisterCommand()
        {
            new Register().ShowDialog();
        }

        private bool CanExecuteLoginCommand()
        {
            return /*!string.IsNullOrEmpty(PWord) && */!string.IsNullOrEmpty(Login);
        }

        private void ExecuteLoginCommand()
        {
            UserVM user = UserVM.GetByLoginPassword(Login, PWord);
            if (user != null)
            {
                switch (user.Role)
                {
                    case Role.Customer:
                        {
                            new CustomerMainWindow(user).ShowDialog();
                            break;
                        }

                    case Role.Salesperson:
                        {
                            new SalespersonMainWindow(user).ShowDialog();
                            break;
                        }

                    case Role.Dealer:
                        {
                            new DealerMainWindow(user).ShowDialog();
                            break;
                        }
                }
            }
            else
                MessageBox.Show("Ошибка при входе", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion
    }
}