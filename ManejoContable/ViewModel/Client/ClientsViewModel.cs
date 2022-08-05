using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ManejoContable.ViewModel.Client.Commands;
using ModelEntities;

namespace ManejoContable.ViewModel.Client;

public class ClientsViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Cliente> Clients { get; private set; }

    public ViewClientCommand ViewClientCommand { get; init; }
    public DeleteClientCommand DeleteClientCommand { get; init; }
    public EditClientCommand EditClientCommand { get; init; }
    public AddClientCommand AddClientCommand { get; init; }

    private IClientDialogService _clientDialog;

    private Cliente? _cliente;

    public Cliente? SelectedCliente
    {
        get => _cliente;
        set
        {
            _cliente = value;
            OnPropertyChanged(nameof(SelectedCliente));
        }
    }


    public ClientsViewModel()
    {
        ViewClientCommand = new ViewClientCommand(this);
        DeleteClientCommand = new DeleteClientCommand(this);
        EditClientCommand = new EditClientCommand(this);
        AddClientCommand = new AddClientCommand(this);

        _clientDialog = new ClientClientDialogService();

        Clients = new ObservableCollection<Cliente>
        {
            new()
            {
                Nombre = "Imporcom", NumeroDocumento = "123-456-7890", TipoDocumento = TipoDocumento.Nit,
                Direccion = "Cra impor #1", Correo = "imporcom@correo.com", Telefono = "123-456-7890",
            },
            new()
            {
                Nombre = "Andres' Programmers SAS", NumeroDocumento = "111-222-33-44",
                TipoDocumento = TipoDocumento.Cc, Correo = "andres@correo.com", Telefono = "111-222-3344",
                Direccion = "Calle 123 # 445 sur",
            }
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;


    public void ShowClientInformation(Cliente cliente)
    {
        Debug.WriteLine($"{nameof(ShowClientInformation)}: showing client information.");

        _clientDialog.OpenClientInformationDialog(cliente);
    }

    public void DeleteClient(Cliente cliente)
    {
        var result = _clientDialog.DeleteClientDialog(cliente);
        // TODO: use Result
        Debug.WriteLine($"{nameof(DeleteClient)}: prompt to delete client.");
    }

    public void EditClient(Cliente cliente)
    {
        var result = _clientDialog.UpdateClientDialog(cliente);
        // TODO: use Result
        Debug.WriteLine($"{nameof(EditClient)}: show edit client dialog.");
    }

    public void AddClient()
    {
        var result = _clientDialog.AddClientDialog();
        // TODO: use Result
        Debug.WriteLine($"{nameof(AddClient)}: show edit client dialog.");
    }


    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}