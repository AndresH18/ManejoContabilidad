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
using AdminAssist.wpf.Services;
using AdminAssist.wpf.Views.Invoice;

namespace AdminAssist.wpf.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly NavigationService _navigation;

    public MainWindow(NavigationService navigationService)
    {
        this._navigation = navigationService;

        InitializeComponent();
        
        Current = this;
    }

    public static MainWindow? Current { get; private set; }

    private void Frame_OnLoaded(object sender, RoutedEventArgs e)
    {
        _navigation.NavigateToPage<InvoicesPage>();
    }
}