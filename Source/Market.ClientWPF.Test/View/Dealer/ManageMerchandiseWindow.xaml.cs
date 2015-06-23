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
using Market.ClientWPF.Test.ViewModel;
using Market.ViewModel.DataVM;

namespace Market.ClientWPF.Test.View.Dealer
{
    /// <summary>
    /// Interaction logic for ManageMerchandiseWindow.xaml
    /// </summary>
    public partial class ManageMerchandiseWindow : Window
    {
        public ManageMerchandiseWindow(DealerVM dealer)
        {
            InitializeComponent();
            DataContext = new MerchandiseDealerVM(dealer);
        }
    }
}
