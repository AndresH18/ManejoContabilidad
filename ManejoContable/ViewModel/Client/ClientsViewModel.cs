using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ManejoContable.ViewModel.Commands;
using ModelEntities;

namespace ManejoContable.ViewModel.Client;

public class ClientsViewModel : IBaseViewModel<Cliente>, INotifyPropertyChanged
{
    public ObservableCollection<Cliente> Models { get; }

    public ViewCommand<Cliente> ViewCommand { get; init; }
    public DeleteCommand<Cliente> DeleteCommand { get; init; }
    public EditCommand<Cliente> EditCommand { get; init; }
    public CreateCommand<Cliente> CreateCommand { get; init; }

    private IDialogService<Cliente> _dialog;

    private Cliente? _model;

    public Cliente? SelectedModel
    {
        get => _model;
        set
        {
            _model = value;
            NotifyPropertyChanged(nameof(SelectedModel));
        }
    }


    public ClientsViewModel()
    {
        ViewCommand = new ViewCommand<Cliente>(this);
        DeleteCommand = new DeleteCommand<Cliente>(this);
        EditCommand = new EditCommand<Cliente>(this);
        CreateCommand = new CreateCommand<Cliente>(this);

        _dialog = new ClientDialogService();

        Models = new ObservableCollection<Cliente>
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
            Models.Remove(cliente);
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


    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}