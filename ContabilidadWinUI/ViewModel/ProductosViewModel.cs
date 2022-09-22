using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ContabilidadWinUI.Services;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using ModelEntities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace ContabilidadWinUI.ViewModel;

public class ProductosViewModel : AbstractViewModel<Producto>
{
    public ProductosViewModel()
    {
        Repository = App.Current.Services.GetService<IProductoRepository>() ??
                     throw new ArgumentNullException($"Service {typeof(IProductsService)} is not registered");

        DialogService = new ProductoDialogService();

        GetData();
    }
}