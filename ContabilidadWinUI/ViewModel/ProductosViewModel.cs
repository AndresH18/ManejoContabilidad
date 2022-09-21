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

namespace ContabilidadWinUI.ViewModel;

public class ProductosViewModel : IBaseViewModel<Producto>, INotifyPropertyChanged
{
    private readonly IProductoRepository _repo;
    private Producto? _producto;

    public Producto? SelectedModel
    {
        get => _producto;
        set
        {
            _producto = value;
            NotifyPropertyChanged(nameof(SelectedModel));
        }
    }


    public ObservableCollection<Producto> Models { get; private set; } = new();
    public IModelDialogService<Producto> DialogService { get; }
    public ViewCommand<Producto> ViewCommand { get; }
    public CreateCommand<Producto> CreateCommand { get; }
    public DeleteCommand<Producto> DeleteCommand { get; }
    public EditCommand<Producto> EditCommand { get; }

    public ProductosViewModel()
    {
        _repo = App.Current.Services.GetService<IProductoRepository>() ??
                throw new ArgumentNullException($"Service {typeof(IProductsService)} is not registered");

        DialogService = new ProductoDialogService();

        ViewCommand = new ViewCommand<Producto>(this);
        CreateCommand = new CreateCommand<Producto>(this);
        DeleteCommand = new DeleteCommand<Producto>(this);
        EditCommand = new EditCommand<Producto>(this);

        // Models = new ObservableCollection<Producto>(_repo.GetAll());
        GetData();
    }

    private async void GetData()
    {
        var data = await Task.Run(() =>  _repo.GetAllAsync());
        Models = new ObservableCollection<Producto>(data);
        NotifyPropertyChanged(nameof(Models));
    }

    public async void Create()
    {
        var c = await DialogService.CreateDialog();

        if (c is null)
            return;
        try
        {
            c = await Task.Run(async () =>
            {
                var ac = await _repo.CreateAsync(c);
                ac = await _repo.GetByIdAsync(ac.Id);
                return ac;
            });

            Models.Add(c!);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating. {ex}");
        }
    }

    public void Show(Producto t)
    {
        try
        {
            DialogService.ShowDialog(t);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }


    public async void Edit(Producto producto)
    {
        var p = await DialogService.UpdateDialog(producto);
        if (p is null)
            return;

        SelectedModel = null;

        producto.CopyFrom(p);

        try
        {
            var collection = await Task.Run(async () =>
            {
                await _repo.UpdateAsync(producto);

                return await _repo.GetAllAsync();
            });

            Models = new ObservableCollection<Producto>(collection);

            NotifyPropertyChanged(nameof(Models));

            SelectedModel = producto;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    public async void Delete(Producto t)
    {
        var delete = await DialogService.DeleteDialog(t);

        if (!delete)
            return;

        try
        {
            SelectedModel = null;
            Models.Remove(t);
            await Task.Run(() => _repo.DeleteAsync(t.Id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}