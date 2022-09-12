using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using ContabilidadWinUI.ViewModel.Commands;
using Microsoft.UI.Xaml;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class ClientsViewModel : IBaseViewModel<Cliente>, INotifyPropertyChanged
{
    private int _taskCounter;
    private bool _isError;
    private Cliente? _model;

    public ObservableCollection<Cliente> Models { get; }

    /// <summary>
    /// <p>
    /// Gets the <see cref="Visibility"/> based on the <see cref="_taskCounter"/>.
    /// </p>
    /// <p>
    /// This is used for bindings in which the user should know that there is an operation running
    /// </p>
    /// </summary>
    public Visibility TaskVisibility => _taskCounter > 0 ? Visibility.Visible : Visibility.Collapsed;

    /// <summary>
    /// <p>
    /// Gets the error state from <see cref="_isError"/>.
    /// </p>
    /// <p>This is used for bindings in which the user should know that an operation was unsuccessful</p>
    /// </summary>
    public bool IsTaskError
    {
        get => _isError;
        private set
        {
            _isError = value;
            NotifyPropertyChanged(nameof(IsTaskError));
        }
    }

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
        DialogService = new ClientDialogService();

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
                TipoDocumento = TipoDocumento.Cc, Correo = "andres@correo.com", Telefono = "111-876-2394",
                Direccion = "Calle 123 # 445 sur",
            }
        };
    }

    public async void Create()
    {
        // TODO: Implement create client
        var c = await DialogService.CreateDialog();
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
    }

    /// <summary>
    /// Adds 1 to <see cref="_taskCounter"/> and notifies property changed.
    /// </summary>
    private void AddTask()
    {
        _taskCounter++;
        NotifyPropertyChanged(nameof(TaskVisibility));
    }

    /// <summary>
    /// Removes 1 to <see cref="_taskCounter"/> and notifies property changed.
    /// </summary>
    private void RemoveTask()
    {
        _taskCounter--;
        NotifyPropertyChanged(nameof(TaskVisibility));
    }

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}