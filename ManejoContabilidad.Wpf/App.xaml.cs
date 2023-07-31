using Microsoft.Extensions.DependencyInjection;
using Shared;
using System;
using System.Windows;
using static ManejoContabilidad.Wpf.Services.ServiceConfigurationExtensions;

namespace ManejoContabilidad.Wpf;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App
{
    /// <summary>
    ///     Gets the current <see cref="App" /> instance in use
    /// </summary>
    public new static App Current => (App)Application.Current;

    /// <summary>
    ///     Gets the <see cref="IServiceProvider" /> instance to resolve application services.
    /// </summary>
    public IServiceProvider Services { get; }

    public App()
    {
        Services = ConfigureServices();

        Application.Current.MainWindow = Services.GetRequiredService<MainWindow>();
        Application.Current.MainWindow.Show();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.RegisterAppServices();
        services.RegisterHelpers();
        services.RegisterWindows();
        services.RegisterPages();
        services.RegisterViewModels();

        return services.BuildServiceProvider();
    }
}