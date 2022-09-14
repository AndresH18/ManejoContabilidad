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

public class ClientsViewModel : IBaseViewModel<Cliente>, INotifyPropertyChanged
{
    private Cliente? _model;
    private IClienteRepository _repo;
    public ObservableCollection<Cliente> Models { get; private set; }

    public Cliente? SelectedModel
    {
        get => _model;
        set
        {
            _model = value;
            NotifyPropertyChanged(nameof(SelectedModel));
        }
    }

    public IModelDialogService<Cliente> DialogService { get; }

    public ViewCommand<Cliente> ViewCommand { get; }
    public CreateCommand<Cliente> CreateCommand { get; }
    public DeleteCommand<Cliente> DeleteCommand { get; }
    public EditCommand<Cliente> EditCommand { get; }


    public ClientsViewModel()
    {
        _repo = App.Current.Services.GetService<IClienteRepository>() ??
                throw new ArgumentNullException($"Service {typeof(IClienteRepository)} is not registered");

        DialogService = new ClientDialogService();

        ViewCommand = new ViewCommand<Cliente>(this);
        CreateCommand = new CreateCommand<Cliente>(this);
        DeleteCommand = new DeleteCommand<Cliente>(this);
        EditCommand = new EditCommand<Cliente>(this);

        Models = new ObservableCollection<Cliente>(_repo.GetAll());
    }


    public async void Create()
    {
        var c = await DialogService.CreateDialog();

        if (c is null)
            return;

        try
        {
            c = _repo.Create(c);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        Models.Add(c);
    }

    public void Show(Cliente t)
    {
        DialogService.ShowDialog(t);
    }

    public async void Edit(Cliente cliente)
    {
        var c = await DialogService.UpdateDialog(cliente);
        if (c is null)
            return;

        SelectedModel = null;

        cliente.CopyFrom(c);

        try
        {
            _repo.Update(cliente);
            Models = new ObservableCollection<Cliente>(_repo.GetAll());
            NotifyPropertyChanged(nameof(Models));
            SelectedModel = cliente;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    public async void Delete(Cliente t)
    {
        var delete = await DialogService.DeleteDialog(t);

        if (!delete)
            return;

        try
        {
            SelectedModel = null;
            Models.Remove(t);
            _repo.Delete(t.Id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }


    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}