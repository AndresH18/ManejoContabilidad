using ManejoContabilidad.Wpf.Helpers.Dialog;
using ManejoContabilidad.Wpf.Services.Client;
using ManejoContabilidad.Wpf.Services.Invoice;
using ManejoContabilidad.Wpf.Services.Navigation;
using ManejoContabilidad.Wpf.ViewModels;
using ManejoContabilidad.Wpf.Views.Client;
using ManejoContabilidad.Wpf.Views.Invoice;
using Microsoft.Extensions.DependencyInjection;
using Models = Shared.Models;

namespace ManejoContabilidad.Wpf.Services;

public static class ServiceConfigurationExtensions
{
    public static void RegisterViewModels(this ServiceCollection services)
    {
        // Singleton

        // Transient
        services.AddTransient<ClientsViewModel>();
        services.AddTransient<InvoicesViewModel>();
    }

    public static void RegisterAppServices(this IServiceCollection services)
    {
        // Singleton
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<IClientService, ClientServiceTest>();
        services.AddSingleton<IInvoiceService, InvoiceServiceTest>();


        // Transient
    }

    public static void RegisterHelpers(this IServiceCollection services)
    {
        // Singleton

        // Transient
        services.AddTransient<IDialogHelper<Models::Client>, ClientDialogHelper>();
        services.AddTransient<IDialogHelper<Models::Invoice>, InvoiceDialogHelper>();
    }

    public static void RegisterWindows(this IServiceCollection services)
    {
        // Singleton
        services.AddSingleton<MainWindow>();

        // Transient
    }

    public static void RegisterPages(this IServiceCollection services)
    {
        // Singleton

        // Transient
        services.AddTransient<ClientsPage>();
        services.AddTransient<InvoicesPage>();
    }
}