using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ContabilidadWinUI.Services;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class ProductosViewModel : IBaseViewModel<Producto>, INotifyPropertyChanged
{
    private IProductoRepository _repo;

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

    public ObservableCollection<Producto> Models { get; }
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

        Models = new ObservableCollection<Producto>(_repo.GetAll());
    }

    public async void Create()
    {
        var c = await DialogService.CreateDialog();

        if (c is null)
            return;

        c = _repo.Create(c);
        c = _repo.GetById(c.Id);

        Models.Add(c);
    }

    public void Show(Producto t)
    {
        DialogService.ShowDialog(t);
    }


    public async void Edit(Producto t)
    {
        var c = await DialogService.UpdateDialog(t);
        if (c is null)
            return;
        try
        {
            _repo.Update(c);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        Models.Remove(SelectedModel!);
        Models.Add(c);
        SelectedModel = c;
    }

    public async void Delete(Producto t)
    {
        // var delete = await DialogService.DeleteDialog(t);
        //
        // if (!delete)
        //     return;
        //
        // SelectedModel = null;
        // Models.Remove(t);
        // _repo.Delete(t.Id);
    }

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}