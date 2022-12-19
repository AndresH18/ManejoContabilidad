using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManejoContabilidad.Wpf.Helpers.Dialog;
using ManejoContabilidad.Wpf.Services.Invoice;
using Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ManejoContabilidad.Wpf.ViewModels;

[INotifyPropertyChanged]
public partial class InvoicesViewModel
{
    private readonly IInvoiceService _invoiceService;
    private readonly IDialogHelper<Invoice> _dialogHelper;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(EditInvoiceCommand))]
    [NotifyCanExecuteChangedFor(nameof(DeleteInvoiceCommand))]
    private Invoice? _selectedInvoice;

    [ObservableProperty,
     NotifyCanExecuteChangedFor(nameof(GoBackCommand))]
    private int _pageIndex;

    public ObservableCollection<Invoice> Invoices { get; private set; } = new();

    public InvoicesViewModel(IInvoiceService invoiceService, IDialogHelper<Invoice> dialogHelper)
    {
        _invoiceService = invoiceService;
        _dialogHelper = dialogHelper;

        GetInvoices();
    }

    private async void GetInvoices(int page = 0)
    {
        try
        {
            Invoices.Clear();

            var list = await _invoiceService.GetAllAsync(page);

            foreach (var invoice in list)
            {
                Invoices.Add(invoice);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Failed to get invoices. {0}", ex);
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
            Invoices.Add(result);
        }
        // TODO: notify error
    }

    [RelayCommand(CanExecute = nameof(IsInvoiceSelected))]
    private void Print(Invoice invoice)
    {
        // TODO: Implement 
    }

    [RelayCommand(CanExecute = nameof(CanGoBack))]
    private void GoBack()
    {
        PageIndex--;
        // TODO: Implement Pagination's GoBack
    }

    [RelayCommand]
    private void GoForward()
    {
        PageIndex++;
        // TODO: Implement Pagination's GoForward
    }

    private bool IsInvoiceSelected()
    {
        return SelectedInvoice is not null;
    }

    private bool CanGoBack()
    {
        return _pageIndex > 0;
    }
}