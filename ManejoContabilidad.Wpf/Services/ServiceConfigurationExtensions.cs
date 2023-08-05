using System;
using Shared;
using ManejoContabilidad.Wpf.Helpers.Dialog;
using ManejoContabilidad.Wpf.Services.Invoice;
using ManejoContabilidad.Wpf.Services.Navigation;
using ManejoContabilidad.Wpf.ViewModels;
using ManejoContabilidad.Wpf.Views.Invoice;
using ManejoContabilidad.Wpf.Views.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace ManejoContabilidad.Wpf.Services;

public static class ServiceConfigurationExtensions
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        // Singleton
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<PrintService>();

        // TODO: replace for production version of Excel Writer
        services.AddSingleton<IExcelWriter, EmptyExcelWriter>();
        // services.AddSingleton<IExcelWriter, ExcelWriter>(x =>
        // {
        //     var settingManager = x.GetRequiredService<SettingsManager>();
        //     return new ExcelWriter(settingManager.ExcelConfigurationOptions);
        // });

        services.AddSingleton<IInvoiceService, InvoiceService>();

        services.AddSingleton<SettingsManager>();
    }

    public static void RegisterViewModels(this ServiceCollection services)
    {
        // Singleton

        // Transient
        services.AddTransient<InvoicesViewModel>();
    }

    public static void RegisterViews(this IServiceCollection services)
    {
        // Windows
        services.AddSingleton<MainWindow>();

        // Pages
        services.AddTransient<InvoicesPage>();
        services.AddTransient<SettingsPage>();
    }

    public static void RegisterHelpers(this IServiceCollection services)
    {
        // Singleton

        // Transient
        services.AddTransient<InvoiceDialogHelper>();
    }
}