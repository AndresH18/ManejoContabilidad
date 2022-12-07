using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;

namespace ManejoContabilidad.Wpf.ViewModels;

[INotifyPropertyChanged]
public partial class ClientsViewModel
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(EditClientCommand))]
    [NotifyCanExecuteChangedFor(nameof(DeleteClientCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowClientCommand))]
    private Client? _selectedClient;

    public ObservableCollection<Client> Clients { get; private set; }

    public ClientsViewModel()
    {
        Clients = new ObservableCollection<Client>
        {
            new() {Name = "Andres", Document = "1", Email = "andres@email.com"},
            new() {Name = "David", Document = "2", Email = "david@email.com"}
        };
    }

    [RelayCommand]
    private void AddClient()
    {
        // TODO: add client
    }

    [RelayCommand(CanExecute = nameof(IsClientSelected))]
    private void EditClient()
    {
        // TODO: edit client
    }

    [RelayCommand(CanExecute = nameof(IsClientSelected))]
    private void DeleteClient()
    {
        // TODO: delete client
    }

    [RelayCommand(CanExecute = nameof(IsClientSelected))]
    private void ShowClient()
    {
        // TODO: show client
    }

    private bool IsClientSelected()
    {
        return _selectedClient is not null;
    }
}