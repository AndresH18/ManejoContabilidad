using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ManejoContabilidad.Services;
using ManejoContabilidad.Views.Windows;

namespace ManejoContabilidad;



/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
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
        services.RegisterViews();
        services.RegisterViewModels();

        return services.BuildServiceProvider();
    }
}