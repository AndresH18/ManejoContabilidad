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
    private readonly IClienteRepository _repo;

    private Cliente? _model;
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

        GetData();
    }

    private async void GetData()
    {
        var data = await Task.Run(() => _repo.GetAllAsync());
        Models = new ObservableCollection<Cliente>(data);

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
            Debug.WriteLine(ex);
        }
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
            var collection = await Task.Run(async () =>
            {
                await _repo.UpdateAsync(cliente);

                return await _repo.GetAllAsync();
            });

            Models = new ObservableCollection<Cliente>(collection);

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
            await Task.Run(() => _repo.DeleteAsync(t.Id));
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