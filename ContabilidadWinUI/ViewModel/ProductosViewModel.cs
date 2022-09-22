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

public class ProductosViewModel : IBaseViewModel<Producto>, INotifyPropertyChanged
{
    private readonly IProductoRepository _repo;
    private Producto? _producto;
    private Visibility _taskVisibility;
    private bool _isError;

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

    /// <summary>
    /// <p>
    /// Gets the <see cref="Visibility"/> based on the <see cref="_taskCounter"/>.
    /// </p>
    /// <p>
    /// This is used for bindings in which the user should know that there is an operation running
    /// </p>
    /// </summary>
    public Visibility TaskVisibility
    {
        get => _taskVisibility;
        private set
        {
            _taskVisibility = value;
            NotifyPropertyChanged(nameof(TaskVisibility));
        }
    }
    // public Visibility TaskVisibility => _taskCounter > 0 ? Visibility.Visible : Visibility.Collapsed;


    /// <summary>
    /// <p>
    /// Gets the error state from <see cref="_isError"/>.
    /// </p>
    /// <p>This is used for bindings in which the user should know that an operation was unsuccessful</p>
    /// </summary>
    public bool IsTaskError
    {
        get => _isError;
        private set
        {
            _isError = value;
            NotifyPropertyChanged(nameof(IsTaskError));
        }
    }

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
        TaskVisibility = Visibility.Visible;
        try
        {
            var data = await Task.Run(() => _repo.GetAllAsync());
            Models = new ObservableCollection<Producto>(data);
            NotifyPropertyChanged(nameof(Models));

            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public async void Create()
    {
        TaskVisibility = Visibility.Visible;

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
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating. {ex}");
            IsTaskError = true;
        }
    }

    public void Show(Producto t)
    {
        DialogService.ShowDialog(t);
    }


    public async void Edit(Producto producto)
    {
        TaskVisibility = Visibility.Visible;

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
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public async void Delete(Producto t)
    {
        TaskVisibility = Visibility.Visible;

        var delete = await DialogService.DeleteDialog(t);

        if (!delete)
            return;

        try
        {
            SelectedModel = null;
            Models.Remove(t);
            await Task.Run(() => _repo.DeleteAsync(t.Id));
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}