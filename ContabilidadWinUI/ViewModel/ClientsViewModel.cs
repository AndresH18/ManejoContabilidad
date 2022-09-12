using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public ObservableCollection<Cliente> Models { get; }

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

        // Models = new ObservableCollection<Cliente>
        // {
        //     new()
        //     {
        //         Nombre = "Imporcom", NumeroDocumento = "123-456-7890", TipoDocumento = TipoDocumento.Nit,
        //         Direccion = "Cra impor #1", Correo = "imporcom@correo.com", Telefono = "123-456-7890",
        //     },
        //     new()
        //     {
        //         Nombre = "Andres' Programmers SAS", NumeroDocumento = "111-222-33-44",
        //         TipoDocumento = TipoDocumento.Cc, Correo = "andres@correo.com", Telefono = "111-876-2394",
        //         Direccion = "Calle 123 # 445 sur",
        //     }
        // };
        Models = new ObservableCollection<Cliente>(_repo.GetAll());
    }


    public async void Create()
    {
        var c = await DialogService.CreateDialog();

        if (c is null)
            return;

        c = _repo.Create(c);

        Models.Add(c);
    }

    public void Show(Cliente t)
    {
        DialogService.ShowDialog(t);
    }

    public async void Delete(Cliente t)
    {
        // TODO: Implement Delete Client
        var r = await DialogService.DeleteDialog(t);
    }

    public async void Edit(Cliente t)
    {
        // TODO: Implement Edit Client
        var c = await DialogService.UpdateDialog(t);
        if (c is null) 
            return;

        _repo.Update(c);

        Models.Remove(SelectedModel!);
        Models.Add(c);
        SelectedModel = c;
    }


    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}