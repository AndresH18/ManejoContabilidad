using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminAssist.wpf.Views;
using AdminAssist.wpf.Views.Invoice;
using AdminAssist.wpf.Views.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminAssist.wpf.Services;

internal static class ServiceConfigurationExtensions
{
    /// <summary>
    /// Registers the app services into the <paramref name="services"/> instance.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> in which to register the app services.</param>
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddSingleton<NavigationService>();
    }

    /// <summary>
    /// Register the app views into the <paramref name="services"/> instance. Includes: <see cref="System.Windows.Window"/>,  <see cref="System.Windows.Controls.Page"/>, and other UI elements.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> in which to register the app views</param>
    public static void RegisterViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<InvoicesPage>();
    }

    /// <summary>
    /// Registers the app viewModels into the <paramref name="services"/> instance.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> in which to register the app viewModels.</param>
    public static void RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<InvoicesViewModel>();
    }
}