using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using ContabilidadWinUI.Services;
using ContabilidadWinUI.Services.JsonModels;
using ContabilidadWinUI.ViewModel.Commands;
using Microsoft.Extensions.DependencyInjection;
using ModelEntities;
using Microsoft.UI.Xaml;

namespace ContabilidadWinUI.ViewModel;

public class FacturasViewModel : INotifyPropertyChanged
{
    private readonly IFacturasService _service;
    private FacturaDto? _factura;
    private Visibility _taskVisibility;
    private bool _isError;

    public FacturaDto? SelectedFactura
    {
        get => _factura;
        set
        {
            _factura = value;
            NotifyPropertyChanged(nameof(SelectedFactura));
        }
    }

    public ObservableCollection<FacturaDto> Facturas { get; private set; }

    public ActionCommand ViewCommand { get; }
    public ActionCommand CreateCommand { get; }
    public ActionCommand EditCommand { get; }
    public ActionCommand DeleteCommand { get; }

    /// <summary>
    /// <p>
    /// Gets the <see cref="Visibility"/> based on the <see cref="_taskCounter"/>.
    /// </p>
    /// <p>
    /// This is used for bindings in which the user should know that there is an operation running
    /// </p>
    /// </summary>
    public Visibility TaskVisibility
    {
        get => _taskVisibility;
        private set
        {
            _taskVisibility = value;
            NotifyPropertyChanged(nameof(TaskVisibility));
        }
    }
    // public Visibility TaskVisibility => _taskCounter > 0 ? Visibility.Visible : Visibility.Collapsed;


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

    public FacturasViewModel()
    {
        _service = App.Current.Services.GetService<IFacturasService>() ??
                   throw new($"Service {typeof(IFacturasService)} is not registered");


        ViewCommand = new ActionCommand {ActionToExecute = Show, CanExecuteFunc = CanExecute};
        CreateCommand = new ActionCommand {ActionToExecute = Create, CanExecuteFunc = CanExecute};
        DeleteCommand = new ActionCommand {ActionToExecute = Delete, CanExecuteFunc = CanExecute};
        EditCommand = new ActionCommand {ActionToExecute = Edit, CanExecuteFunc = CanExecute};

        // TODO: async
        Facturas = new ObservableCollection<FacturaDto>(_service.GetAllFacturas());
    }


    private void Show()
    {
        // TODO: Implement show factura
        throw new NotImplementedException();
    }

    private void Delete()
    {
        // TODO: Implement delete factura
        throw new NotImplementedException();
    }

    private void Edit()
    {
        // TODO: Implement edit factura
        throw new NotImplementedException();
    }

    private void Create()
    {
        // TODO: Implement create factura
        throw new NotImplementedException();
    }

    internal async void Scan(StorageFile storageFile)
    {
        await using Stream stream = await storageFile.OpenStreamForReadAsync();

        // TODO: call recognizer api
    }

    private static bool CanExecute(object? o)
    {
        return o?.GetType().IsAssignableTo(typeof(FacturaDto)) ?? false;
    }

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}