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
using Exception = System.Exception;

namespace ContabilidadWinUI.ViewModel;

public class MarcasViewModel : AbstractViewModel<Marca>
{
    public MarcasViewModel()
    {
        Repository = App.Current.Services.GetService<IMarcaRepository>() ??
                     throw new ArgumentNullException($"Service {typeof(IMarcaRepository)} is not registered");

        DialogService = new MarcaDialogService();

        GetData();
    }
}