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
        // TODO: Open the Window Dialog to show client information
        Debug.WriteLine($"{nameof(ShowClientInformation)}: showing client information.");
    }

    public void DeleteClient(Cliente cliente)
    {
        // TODO: Open the Window dialog to confirm client deletion
        Debug.WriteLine($"{nameof(DeleteClient)}: prompt to delete client.");
    }

    public void EditClient(Cliente cliente)
    {
        // TODO: open the window dialog to edit the client
        Debug.WriteLine($"{nameof(EditClient)}: show edit client dialog.");
    }


    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}