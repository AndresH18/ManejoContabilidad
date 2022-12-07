using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using static ManejoContabilidad.Wpf.Services.ServiceConfigurationExtensions;

namespace ManejoContabilidad.Wpf;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Services = ConfigureServices();

        InitializeComponent();
    }

    /// <summary>
    ///     Gets the <see cref="IServiceProvider" /> instance to resolve application services.
    /// </summary>
    public IServiceProvider Services { get; }

    /// <summary>
    ///     Gets the current <see cref="App" /> instance in use
    /// </summary>
    public new static App Current => (App) Application.Current;


    private IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.RegisterAppServices();
        services.RegisterViews();
        services.RegisterViewModels();

        return services.BuildServiceProvider();
    }
}