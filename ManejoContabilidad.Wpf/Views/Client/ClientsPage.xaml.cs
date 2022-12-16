using System.Windows.Controls;
using ManejoContabilidad.Wpf.ViewModels;

namespace ManejoContabilidad.Wpf.Views.Client;

public partial class ClientsPage : Page
{
    public ClientsPage(ClientsViewModel viewModel)
    {
        InitializeComponent();
        
        DataContext = viewModel;
    }
}