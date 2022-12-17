using ManejoContabilidad.Wpf.Helpers.Dialog;
using ManejoContabilidad.Wpf.Services.AppEnvironment;
using ManejoContabilidad.Wpf.Services.Invoice;
using ManejoContabilidad.Wpf.Services.Navigation;
using ManejoContabilidad.Wpf.Services.RequestProvider;
using ManejoContabilidad.Wpf.ViewModels;
using ManejoContabilidad.Wpf.Views.Invoice;
using Microsoft.Extensions.DependencyInjection;
using Models = Shared.Models;

namespace ManejoContabilidad.Wpf.Services;

public static class ServiceConfigurationExtensions
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        // Singleton
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IInvoiceService, InvoiceServiceTest>();
        services.AddSingleton<IRequestProvider, RequestProvider.RequestProvider>();
        services.AddSingleton<AppEnvironmentService>();
    }

    public static void RegisterViewModels(this ServiceCollection services)
    {
        // Singleton

        // Transient
        services.AddTransient<InvoicesViewModel>();
    }

    public static void RegisterHelpers(this IServiceCollection services)
    {
        // Singleton

        // Transient
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
        services.AddTransient<InvoicesPage>();
    }
}