using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ManejoContable.ViewModel.Commands;
using ModelEntities;

namespace ManejoContable.ViewModel.Client;

public class ClientsViewModel : IBaseViewModel<Cliente>,INotifyPropertyChanged
{
    public ObservableCollection<Cliente> Clients { get; private set; }

    public ViewCommand<Cliente> ViewClientCommand { get; init; }
    public DeleteCommand<Cliente> DeleteClientCommand { get; init; }
    public EditCommand<Cliente> EditClientCommand { get; init; }
    public CreateCommand<Cliente> CreateClientCommand { get; init; }

    private IDialogService<Cliente> _dialog;

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
        ViewClientCommand = new ViewCommand<Cliente>(this);
        DeleteClientCommand = new DeleteCommand<Cliente>(this);
        EditClientCommand = new EditCommand<Cliente>(this);
        CreateClientCommand = new CreateCommand<Cliente>(this);

        _dialog = new ClientDialogService();

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


    public void Show(Cliente cliente)
    {
        Debug.WriteLine($"{nameof(Show)}: showing client information.");

        _dialog.OpenInformationDialog(cliente);
    }

    public void Delete(Cliente cliente)
    {
        var result = _dialog.DeleteDialog(cliente);
        // TODO: use Result
        // TODO: delete test
        #region Test

        if (result)
        {
            Clients.Remove(cliente);
        }

        #endregion

        Debug.WriteLine($"{nameof(Delete)}: prompt to delete client.");
    }

    public void Edit(Cliente cliente)
    {
        var result = _dialog.UpdateDialog(cliente);
        // TODO: use Result
        Debug.WriteLine($"{nameof(Edit)}: show edit client dialog.");
    }

    public void Create()
    {
        var result = _dialog.AddDialog();
        // TODO: use Result
        Debug.WriteLine($"{nameof(Create)}: show edit client dialog.");
    }


    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}