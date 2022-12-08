using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManejoContabilidad.Wpf.Helpers.Dialog;
using Shared.Models;

namespace ManejoContabilidad.Wpf.ViewModels;

[INotifyPropertyChanged]
public partial class ClientsViewModel
{
    private readonly IDialogHelper<Client> _dialog;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(EditClientCommand))]
    [NotifyCanExecuteChangedFor(nameof(DeleteClientCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowClientCommand))]
    private Client? _selectedClient;

    public ObservableCollection<Client> Clients { get; private set; }

    public ClientsViewModel(IDialogHelper<Client> dialogHelper)
    {
        _dialog = dialogHelper;

        Clients = new ObservableCollection<Client>
        {
            new() {Name = "Andres", Document = "1", Email = "andres@email.com"},
            new() {Name = "David", Document = "2", Email = "david@email.com"}
        };
    }

    [RelayCommand]
    private void AddClient()
    {
        var result = _dialog.Add();
        // TODO: add client
    }

    [RelayCommand(CanExecute = nameof(IsClientSelected))]
    private void EditClient(Client client)
    {
        var result = _dialog.Edit(client);
        // TODO: edit client
    }

    [RelayCommand(CanExecute = nameof(IsClientSelected))]
    private void DeleteClient(Client client)
    {
        var result = _dialog.Delete(client);
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