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
using ManejoContabilidad.Wpf.Services.Navigation;
using ManejoContabilidad.Wpf.Views.Client;

namespace ManejoContabilidad.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
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