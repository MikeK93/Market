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
using Market.ViewModel.DataVM;

namespace Market.ClientWPF.Test.View.Dealer
{
    /// <summary>
    /// Interaction logic for DealerMainWindow.xaml
    /// </summary>
    public partial class DealerMainWindow : Window
    {
        private DealerVM _dealerVM;

        public DealerMainWindow(UserVM user)
        {
            InitializeComponent();
            DataContext = _dealerVM = new DealerVM(user);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите выйти?", "Выход", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            _dealerVM.Save();
        }
    }
}
