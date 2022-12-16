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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ManejoContabilidad.Wpf.ViewModels;

namespace ManejoContabilidad.Wpf.Views.Invoice
{
    /// <summary>
    /// Interaction logic for InvoicesPage.xaml
    /// </summary>
    public partial class InvoicesPage : Page
    {
        public InvoicesPage(InvoicesViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
