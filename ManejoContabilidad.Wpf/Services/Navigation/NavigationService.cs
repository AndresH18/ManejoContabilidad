using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Controls;
using ManejoContabilidad.Wpf.Views.Invoice;
using ManejoContabilidad.Wpf.Views.Settings;
using Views = ManejoContabilidad.Wpf.Views;


namespace ManejoContabilidad.Wpf.Services.Navigation;

/// <summary>
/// Handles navigation to other components
/// </summary>
public class NavigationService : INavigationService
{
    private readonly IServiceProvider _services = App.Current.Services;

    private readonly IReadOnlyDictionary<string, Type> _pages;

    private Page _currentPage = null!;

    public NavigationService()
    {
        _pages = new Dictionary<string, Type>
        {
            {"invoices", typeof(InvoicesPage)},
            {"settings", typeof(SettingsPage)}
        }.ToImmutableDictionary();
    }


    public void NavigateTo(string page)
    {
        if (_pages.TryGetValue(page, out var type))
        {
            Navigate(type);
        }
    }

    private void Navigate(Type type)
    {
        if (CanNavigateTo(type))
        {
            var service = _services.GetRequiredService(type) as Page ??
                          throw new InvalidOperationException($"The service is not of type {typeof(Page)}.");

            MainWindow.Current?.NavigationFrame.Navigate(service);
            _currentPage = service;
        }
    }

    private bool CanNavigateTo(Type type)
    {
        // check if _currentPage is of the same type (or derived) as type
        if (type.IsInstanceOfType(_currentPage))
        {
            return false;
        }

        if (_currentPage is SettingsPage settingsPage)
        {
            return settingsPage.CanReturn();
        }

        return true;
    }
}