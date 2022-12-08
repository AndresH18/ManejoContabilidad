using ManejoContabilidad.Wpf.Helpers.Dialog;
using ManejoContabilidad.Wpf.Services.Client;
using ManejoContabilidad.Wpf.Services.Navigation;
using ManejoContabilidad.Wpf.ViewModels;
using ManejoContabilidad.Wpf.Views.Client;
using Microsoft.Extensions.DependencyInjection;
using Models = Shared.Models;

namespace ManejoContabilidad.Wpf.Services;

public static class ServiceConfigurationExtensions
{
    public static void RegisterViewModels(this ServiceCollection services)
    {
        services.AddTransient<ClientsViewModel>();
    }

    public static void RegisterAppServices(this IServiceCollection services)
    {
        // Singleton
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IClientService, ClientService>();

        // Transient
    }

    public static void RegisterHelpers(this IServiceCollection services)
    {
        // Singleton

        // Transient
        services.AddTransient<IDialogHelper<Models::Client>, ClientDialogHelper>();
    }

    public static void RegisterWindows(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
    }

    public static void RegisterPages(this IServiceCollection services)
    {
        services.AddTransient<ClientsPage>();
    }
}