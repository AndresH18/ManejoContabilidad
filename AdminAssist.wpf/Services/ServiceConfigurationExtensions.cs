using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminAssist.wpf.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AdminAssist.wpf.Services;

static class ServiceConfigurationExtensions
{
    /// <summary>
    /// Registers the app services into the <paramref name="services"/> instance.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> in which to register the app services.</param>
    public static void RegisterAppServices(this IServiceCollection services)
    {
    }

    /// <summary>
    /// Register the app views into the <paramref name="services"/> instance. Includes: <see cref="System.Windows.Window"/>,  <see cref="System.Windows.Controls.Page"/>, and other UI elements.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> in which to register the app views</param>
    public static void RegisterViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
    }

    /// <summary>
    /// Registers the app viewModels into the <paramref name="services"/> instance.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> in which to register the app viewModels.</param>
    public static void RegisterViewModels(this IServiceCollection services)
    {
    }
}