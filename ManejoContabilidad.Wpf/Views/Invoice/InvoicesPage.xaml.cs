using ManejoContabilidad.Wpf.ViewModels;
using System.Windows.Controls;

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
