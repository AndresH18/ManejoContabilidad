using ManejoContabilidad.Wpf.Services.Navigation;
using ManejoContabilidad.Wpf.Views.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ManejoContabilidad.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private readonly INavigationService _navigation;

    // private readonly List<(string Tag, Type Page)> _pages = new()
    // {
    //     ("invoices", typeof(InvoicesPage))
    // };

    public static MainWindow? Current { get; private set; }

    public MainWindow(INavigationService navigationService)
    {
        _navigation = navigationService;

        InitializeComponent();

        Current = this;
    }

    // private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    // {
    //     if (sender is MenuItem menuItem)
    //     {
    //         var tag = menuItem.Tag as string ?? string.Empty;
    //         Navigate(tag);
    //     }
    // }
    //
    // private void Navigate(string tag)
    // {
    //     var tuple = _pages.FirstOrDefault(t => t.Tag == tag);
    //     var page = tuple.Page;
    //     if (page != null)
    //     {
    //         _navigation.NavigateTo(page);
    //     }
    // }

    private void NavigationFrame_OnLoaded(object sender, RoutedEventArgs e)
    {
        _navigation.Init();
    }
}