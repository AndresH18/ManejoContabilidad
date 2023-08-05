using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ManejoContabilidad.Wpf.Services.Navigation;
using Views = ManejoContabilidad.Wpf.Views;

namespace ManejoContabilidad.Wpf;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private readonly INavigationService _navigation;


    public MainWindow(INavigationService navigationService)
    {
        _navigation = navigationService;

        InitializeComponent();

        Current = this;
    }

    public static MainWindow? Current { get; private set; }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is MenuItem menuItem)
        {
            var tag = menuItem.Tag as string ?? string.Empty;
            NavigateTo(tag);
        }
    }

    private void NavigateTo(string page)
    {
        _navigation.NavigateTo(page);
    }

    private void NavigationFrame_OnLoaded(object sender, RoutedEventArgs e)
    {
        NavigateTo("invoices");
    }
}