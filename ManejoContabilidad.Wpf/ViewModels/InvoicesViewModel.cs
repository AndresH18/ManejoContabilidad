using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManejoContabilidad.Wpf.Helpers.Dialog;
using ManejoContabilidad.Wpf.Services.Client;
using ManejoContabilidad.Wpf.Services.Invoice;
using Shared.Models;

namespace ManejoContabilidad.Wpf.ViewModels;

[INotifyPropertyChanged]
public partial class InvoicesViewModel
{
    private readonly IInvoiceService _invoiceService;
    private readonly IDialogHelper<Invoice> _dialogHelper;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(EditInvoiceCommand))]
    [NotifyCanExecuteChangedFor(nameof(DeleteInvoiceCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowInvoiceCommand))]
    private Invoice? _selectedInvoice;

    public ObservableCollection<Invoice> Invoices { get; private set; } = new();

    public InvoicesViewModel(IInvoiceService invoiceService, IDialogHelper<Invoice> dialogHelper)
    {
        _invoiceService = invoiceService;
        _dialogHelper = dialogHelper;

        GetInvoicesAsync();
    }

    private async void GetInvoicesAsync()
    {
        try
        {
            var list = await _invoiceService.GetAllAsync();

            Invoices.Clear();

            foreach (var invoice in list)
            {
                Invoices.Add(invoice);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    [RelayCommand]
    private async void AddInvoice()
    {
        var invoice = _dialogHelper.Add();
        if (invoice is null)
            return;

        invoice = await _invoiceService.AddAsync(invoice);

        if (invoice is not null)
        {
            Invoices.Add(invoice);
        }
        // TODO: notify error
    }

    [RelayCommand(CanExecute = nameof(IsInvoiceSelected))]
    private async void DeleteInvoice(Invoice invoice)
    {
        var result = _dialogHelper.Delete(invoice);
        if (!result)
            return;

        var deleteResult = await _invoiceService.DeleteAsync(invoice);

        if (deleteResult is not null)
        {
            Invoices.Remove(deleteResult);
        }
        // TODO: delete client
    }

    [RelayCommand(CanExecute = nameof(IsInvoiceSelected))]
    private async void EditInvoice(Invoice invoice)
    {
        var result = _dialogHelper.Edit(invoice);
        if (result is null)
            return;

        result = await _invoiceService.EditAsync(result);

        if (result is not null)
        {
            Invoices.Remove(invoice);
            Invoices.Add(invoice);
        }
        // TODO: notify error
    }

    [RelayCommand(CanExecute = nameof(IsInvoiceSelected))]
    private void ShowInvoice(Invoice invoice)
    {
        _dialogHelper.Show(invoice);
    }

    private bool IsInvoiceSelected()
    {
        return SelectedInvoice is not null;
    }
}