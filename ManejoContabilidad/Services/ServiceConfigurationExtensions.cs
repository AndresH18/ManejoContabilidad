using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManejoContabilidad.Views.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace ManejoContabilidad.Services;

internal static class ServiceConfigurationExtensions
{
    /// <summary>
    /// Registers app services to the <paramref name="services"/> instance
    /// </summary>
    /// <param name="services">Service collection for Dependency Injection</param>
    public static void RegisterAppServices(this IServiceCollection services)
    {
    }

    public static void RegisterViewModels(this IServiceCollection services)
    {
    }

    public static void RegisterViews(this IServiceCollection services)
    {
        // Windows
        services.AddSingleton<MainWindow>();

        // Pages
    }

    public static void RegisterHelpers(this IServiceCollection services)
    {
    }
}