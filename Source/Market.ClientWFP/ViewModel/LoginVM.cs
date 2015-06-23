using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Command.ViewModel.Base;
using Market.Model.Entities;
using Market.ViewModel.DataVM;

namespace Market.ClientWPF.ViewModel
{
    public class LoginVM : BaseVM
    {
        private string _login;
        private string _pwd;

        public string Login
        {
            get { return _login; }
            set
            {
                if (value == _login)
                    return;

                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public string PWord
        {
            get { return _pwd; }
            set
            {
                if (value == _pwd)
                    return;

                _pwd = value;
                OnPropertyChanged("PWord");
            }
        }

        #region ICommand

        public ICommand LoginCommand
        {
            get { return Commands.GetOrCreateCommand(() => LoginCommand, ExecuteLoginCommand, CanExecuteLoginCommand); }
        }

        private bool CanExecuteLoginCommand()
        {
            return !string.IsNullOrEmpty(PWord) || !string.IsNullOrEmpty(Login);
        }

        private void ExecuteLoginCommand()
        {
            UserVM user = UserVM.GetByLoginPassword(Login, PWord);
            if (user != null)
            {
                SalespersonVM salesperson = null;
                DealerVM dealer = null;
                CustomerVM customer = null;
                switch (user.Role)
                {
                    case Role.Customer:
                        {
                            customer = CustomerVM.GetCustomerByUser(user);
                            //new CustomerForms.Main(customer, _winWait).ShowDialog();
                            break;
                        }

                    case Role.Salesperson:
                        {
                            //_winWait = new WaitWindow();
                            //_winWait.Show();
                            //salesperson = Salesperson.GetSalespersonByUser(user);
                            //Hide();
                            //new SalespersonForms.Main(salesperson, _winWait).ShowDialog();
                            //Show();
                            break;
                        }

                    case Role.Dealer:
                        {
                            //_winWait = new WaitWindow();
                            //_winWait.Show();
                            //dealer = Dealer.GetDealerByUser(user);
                            //Hide();
                            //new DealerForms.Main(dealer, _winWait).ShowDialog();
                            //Show();
                            break;
                        }
                }
            }
        }

        #endregion
    }
}