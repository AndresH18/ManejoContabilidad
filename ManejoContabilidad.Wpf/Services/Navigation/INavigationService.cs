using System;
using System.Collections.Generic;

namespace ManejoContabilidad.Wpf.Services.Navigation;

public interface INavigationService
{
    public void NavigateTo<T>() where T : class;
    public void NavigateTo<T>(IDictionary<string, object>? dictionary) where T : class;
}