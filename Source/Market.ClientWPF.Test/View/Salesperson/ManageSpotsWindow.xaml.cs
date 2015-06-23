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

namespace Market.ClientWPF.Test.View.Salesperson
{
    /// <summary>
    /// Interaction logic for ManageSpotsWindow.xaml
    /// </summary>
    public partial class ManageSpotsWindow : Window
    {
        private SalespersonVM _model;

        public ManageSpotsWindow(SalespersonVM model)
        {
            InitializeComponent();
            DataContext = _model = model;
        }
    }
}
