using System.Collections.ObjectModel;
using System.ComponentModel;
using ContabilidadWinUI.ViewModel.Commands;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class ClientsViewModel : IBaseViewModel<Cliente>, INotifyPropertyChanged
{
    private Cliente? _model;

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

    public ViewCommand<Cliente> ViewCommand { get; }
    public CreateCommand<Cliente> CreateCommand { get; }
    public DeleteCommand<Cliente> DeleteCommand { get; }
    public EditCommand<Cliente> EditCommand { get; }


    public ClientsViewModel()
    {
        ViewCommand = new ViewCommand<Cliente>(this);
        CreateCommand = new CreateCommand<Cliente>(this);
        DeleteCommand = new DeleteCommand<Cliente>(this);
        EditCommand = new EditCommand<Cliente>(this);

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

    public void Create()
    {
        // TODO: Implement create client
        throw new System.NotImplementedException($"Implement {typeof(ClientsViewModel)}:{nameof(Create)}");
    }

    public void Show(Cliente t)
    {
        // TODO: Implement show client
        throw new System.NotImplementedException($"Implement {typeof(ClientsViewModel)}:{nameof(Show)}");
    }

    public void Delete(Cliente t)
    {
        // TOOD: Implement Delete Client
        throw new System.NotImplementedException($"Implement {typeof(ClientsViewModel)}:{nameof(Delete)}");
    }

    public void Edit(Cliente t)
    {
        // TODO: Implement Edit Client
        throw new System.NotImplementedException($"Implement {typeof(ClientsViewModel)}:{nameof(Edit)}");
    }

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}