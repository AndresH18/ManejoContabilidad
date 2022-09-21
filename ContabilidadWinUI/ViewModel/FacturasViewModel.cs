﻿using System;
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


    // public CreateCommand<FacturaDto> CreateCommand { get; }
    // public DeleteCommand<FacturaDto> DeleteCommand { get; }
    // public EditCommand<FacturaDto> EditCommand { get; }


    public FacturasViewModel()
    {
        _service = App.Current.Services.GetService<IFacturasService>() ??
                   throw new($"Service {typeof(IFacturasService)} is not registered");


        ViewCommand = new ActionCommand { ActionToExecute = Show, CanExecuteFunc = CanExecute };
        CreateCommand = new ActionCommand { ActionToExecute = Create, CanExecuteFunc = CanExecute };
        DeleteCommand = new ActionCommand { ActionToExecute = Delete, CanExecuteFunc = CanExecute };
        EditCommand = new ActionCommand { ActionToExecute = Edit, CanExecuteFunc = CanExecute };


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