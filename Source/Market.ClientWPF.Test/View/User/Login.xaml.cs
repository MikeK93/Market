using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Market.ClientWPF.ViewModel;

namespace Market.ClientWPF.View.User
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private static Login _instance;

        private bool _canLogin;

        public static Login Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Login();

                return _instance;
            }
        }

        public Login()
        {
            InitializeComponent();
            DataContext = LoginVM.Instance;
        }

        public bool CanLogin
        {
            get
            { return !string.IsNullOrEmpty(pwdBox.Password) && !string.IsNullOrEmpty(txtLogin.Text); }
        }

        private void btnLogin_OnClick(object sender, EventArgs e)
        {
            if (CanLogin)
            {
                LoginVM.Instance.PWord = pwdBox.Password;
                LoginVM.Instance.LoginCommand.Execute(null);
            }
            else
                MessageBox.Show("Проверте правильность введеных данных. Введите и повторите попытку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
