using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace ManejoContabilidad.Wpf.Services.Navigation;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _services = App.Current.Services;


    public void NavigateTo<T>() where T : class
    {
        var service = _services.GetRequiredService<T>();
        MainWindow.Current?.NavigationFrame.Navigate(service);
    }

    public void NavigateTo<T>(IDictionary<string, object>? dictionary) where T : class
    {
        var service = _services.GetRequiredService<T>();
        MainWindow.Current?.NavigationFrame.Navigate(service);
    }

    public void NavigateTo(Type type)
    {
        var service = _services.GetRequiredService(type);
        MainWindow.Current?.NavigationFrame.Navigate(service);
    }

    public void NavigateTo(Type type, IDictionary<string, object>? dictionary)
    {
        var service = _services.GetRequiredService(type);
        MainWindow.Current?.NavigationFrame.Navigate(service);
    }
}