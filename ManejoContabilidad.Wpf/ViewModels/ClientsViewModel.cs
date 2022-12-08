using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManejoContabilidad.Wpf.Helpers.Dialog;
using ManejoContabilidad.Wpf.Services.Client;
using Shared.Models;

namespace ManejoContabilidad.Wpf.ViewModels;

[INotifyPropertyChanged]
public partial class ClientsViewModel
{
    private readonly IDialogHelper<Client> _dialog;
    private readonly IClientService _clientService;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(EditClientCommand))]
    [NotifyCanExecuteChangedFor(nameof(DeleteClientCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowClientCommand))]
    private Client? _selectedClient;

    public ObservableCollection<Client> Clients { get; private set; } = new();

    public ClientsViewModel(IClientService clientService, IDialogHelper<Client> dialogHelper)
    {
        _clientService = clientService;
        _dialog = dialogHelper;


        GetClientsAsync();
    }

    private async void GetClientsAsync()
    {
        var list = await _clientService.GetAllAsync();
        foreach (var client in list)
        {
            Clients.Add(client);
        }
    }

    [RelayCommand]
    private async void AddClient()
    {
        var client = _dialog.Add();
        if (client is null)
            return;

        client = await _clientService.AddAsync(client);

        if (client is not null)
        {
            Clients.Add(client);
        }
        // TODO: notify error
    }

    [RelayCommand(CanExecute = nameof(IsClientSelected))]
    private async void EditClient(Client client)
    {
        var result = _dialog.Edit(client);
        if (result is null)
            return;

        result = await _clientService.EditAsync(result);

        if (result is not null)
        {
            Clients.Remove(client);
            Clients.Add(result);
        }
        // TODO: notify error
    }

    [RelayCommand(CanExecute = nameof(IsClientSelected))]
    private async void DeleteClient(Client client)
    {
        var result = _dialog.Delete(client);
        if (result)
            return;

        var deleteResult = await _clientService.DeleteAsync(client);

        if (deleteResult is not null)
        {
            Clients.Remove(deleteResult);
        }
        // TODO: delete client
    }

    [RelayCommand(CanExecute = nameof(IsClientSelected))]
    private void ShowClient(Client client)
    {
        _dialog.Show(client);
    }

    private bool IsClientSelected()
    {
        return _selectedClient is not null;
    }
}