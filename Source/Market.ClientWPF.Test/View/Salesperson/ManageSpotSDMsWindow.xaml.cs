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

namespace Market.ClientWPF.Test.View.Salesperson
{
    /// <summary>
    /// Interaction logic for ManageSpotSDMsWindow.xaml
    /// </summary>
    public partial class ManageSpotSDMsWindow : Window
    {
        public ManageSpotSDMsWindow(SalespersonVM model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
