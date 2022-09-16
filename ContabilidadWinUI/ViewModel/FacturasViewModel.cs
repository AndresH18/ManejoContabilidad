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

    // public ViewCommand<FacturaDto> ViewCommand { get; }
    // public CreateCommand<FacturaDto> CreateCommand { get; }
    // public DeleteCommand<FacturaDto> DeleteCommand { get; }
    // public EditCommand<FacturaDto> EditCommand { get; }


    public FacturasViewModel()
    {
        _service = App.Current.Services.GetService<IFacturasService>() ??
                   throw new ArgumentNullException($"Service {typeof(IFacturasService)} is not registered");


        // ViewCommand = new ViewCommand<FacturaDto>(this);
        // CreateCommand = new CreateCommand<FacturaDto>(this);
        // DeleteCommand = new DeleteCommand<FacturaDto>(this);
        // EditCommand = new EditCommand<FacturaDto>(this);

        Facturas = new ObservableCollection<FacturaDto>(_service.GetAllFacturas());
    }

    public void Show()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void Edit()
    {
        throw new NotImplementedException();
    }

    public void Create()
    {
        throw new NotImplementedException();
    }


    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}

internal class CreateCommand : ICommand
{
    private readonly FacturasViewModel _viewModel;

    public CreateCommand(FacturasViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is FacturaDto;
    }

    public void Execute(object? parameter)
    {
        _viewModel.Create();
    }

    public event EventHandler? CanExecuteChanged;
}