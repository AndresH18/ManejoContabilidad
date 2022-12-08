using System.Windows;
using ManejoContabilidad.Wpf.Services.Navigation;
using ManejoContabilidad.Wpf.Views.Client;

namespace ManejoContabilidad.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public static MainWindow? Current { get; private set; }
    private readonly INavigationService _navigation;

    public MainWindow(INavigationService navigationService)
    {
        _navigation = navigationService;

        InitializeComponent();

        Current = this;
    }

    private void ClientsMenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        _navigation.NavigateTo<ClientsPage>();
    }
}