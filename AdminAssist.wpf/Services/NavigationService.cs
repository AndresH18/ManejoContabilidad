using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AdminAssist.wpf.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AdminAssist.wpf.Services;

public class NavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public void NavigateToPage<T>() where T : Page
    {
        var service = _serviceProvider.GetRequiredService<T>();
        MainWindow.Current?.NavigationFrame.Navigate(service);
    }

}