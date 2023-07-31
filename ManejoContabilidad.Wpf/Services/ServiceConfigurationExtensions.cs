using System;
using ExcelModule;
using ManejoContabilidad.Wpf.Helpers.Dialog;
using ManejoContabilidad.Wpf.Services.AppEnvironment;
using ManejoContabilidad.Wpf.Services.Invoice;
using ManejoContabilidad.Wpf.Services.Navigation;
using ManejoContabilidad.Wpf.Services.RequestProvider;
using ManejoContabilidad.Wpf.ViewModels;
using ManejoContabilidad.Wpf.Views.Invoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ManejoContabilidad.Wpf.Services;

public static class ServiceConfigurationExtensions
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        // Singleton
        services.AddSingleton<AppEnvironmentService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IRequestProvider, RequestProvider.RequestProvider>();

        services.AddSingleton<PrintService>();

        // TODO: replace for production version of Excel Writer
        // services.AddSingleton<IExcelWriter, ExcelWriter>(x =>
        // {
        //     var environment = x.GetRequiredService<AppEnvironmentService>();
        //     return new ExcelWriter(environment.GetExcelData());
        // });
        services.AddSingleton<IExcelWriter, EmptyExcelWriter>();

        services.AddSingleton<IInvoiceService, InvoiceService>(x =>
        {
            var environment = x.GetRequiredService<AppEnvironmentService>();
            var cs = environment.GetConnectionString("sqlserver");

            return new InvoiceService(cs!);
        });
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
        services.AddTransient<InvoiceDialogHelper>();
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