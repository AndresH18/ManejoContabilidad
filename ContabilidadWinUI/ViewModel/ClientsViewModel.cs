using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class ClientsViewModel : AbstractViewModel<Cliente>
{
    public ClientsViewModel()
    {
        Repository = App.Current.Services.GetService<IClienteRepository>() ??
                     throw new ArgumentNullException($"Service {typeof(IClienteRepository)} is not registered");

        DialogService = new ClientDialogService();

        GetData();
    }
}