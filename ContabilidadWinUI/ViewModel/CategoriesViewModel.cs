using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class CategoriesViewModel : AbstractViewModel<Categoria>
{
    public CategoriesViewModel()
    {
        Repository = App.Current.Services.GetService<ICategoriaRepository>() ??
                     throw new ArgumentNullException($"Service {typeof(ICategoriaRepository)} is not registered");

        DialogService = new CategoriaDialogService();

        GetData();
    }
}