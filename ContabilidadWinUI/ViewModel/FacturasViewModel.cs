using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ContabilidadWinUI.Services;
using ContabilidadWinUI.ViewModel.Commands;
using Microsoft.Extensions.DependencyInjection;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class FacturasViewModel : INotifyPropertyChanged
{
    private readonly IFacturasService _service;

    private FacturaDto? _factura;

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

    public ActionCommand ScannCommand { get; }

    // public CreateCommand<FacturaDto> CreateCommand { get; }
    // public DeleteCommand<FacturaDto> DeleteCommand { get; }
    // public EditCommand<FacturaDto> EditCommand { get; }


    public FacturasViewModel()
    {
        _service = App.Current.Services.GetService<IFacturasService>() ??
                   throw new ArgumentNullException($"Service {typeof(IFacturasService)} is not registered");


        ViewCommand = new ActionCommand {ActionToExecute = Show, CanExecuteFunc = CanExecute};
        CreateCommand = new ActionCommand {ActionToExecute = Create, CanExecuteFunc = CanExecute};
        DeleteCommand = new ActionCommand {ActionToExecute = Delete, CanExecuteFunc = CanExecute};
        EditCommand = new ActionCommand {ActionToExecute = Edit, CanExecuteFunc = CanExecute};

        ScannCommand = new ActionCommand {ActionToExecute = Scan, CanExecuteFunc = _ => true};

        Facturas = new ObservableCollection<FacturaDto>(_service.GetAllFacturas());
    }

    private void Show()
    {
        throw new NotImplementedException();
    }

    private void Delete()
    {
        throw new NotImplementedException();
    }

    private void Edit()
    {
        throw new NotImplementedException();
    }

    private void Create()
    {
        throw new NotImplementedException();
    }

    private void Scan()
    {
        throw new NotImplementedException();
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