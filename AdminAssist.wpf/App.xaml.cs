using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AdminAssist.wpf.Services;
using AdminAssist.wpf.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AdminAssist.wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Services = RegisterServices();
        Application.Current.MainWindow = Services.GetRequiredService<MainWindow>();
        Application.Current.MainWindow.Show();
    }

    /// <summary>
    /// Gets the current <see cref="App"/> instance in use.
    /// </summary>
    public new static App Current => (App)Application.Current;

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
    /// </summary>
    private IServiceProvider Services { get; }

    private static IServiceProvider RegisterServices()
    {
        var services = new ServiceCollection();

        services.RegisterViews();

        return services.BuildServiceProvider();
    }
}