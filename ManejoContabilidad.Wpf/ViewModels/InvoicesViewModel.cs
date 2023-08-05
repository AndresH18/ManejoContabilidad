using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManejoContabilidad.Wpf.Helpers.Dialog;
using ManejoContabilidad.Wpf.Services.Invoice;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ManejoContabilidad.Wpf.Views.Invoice;
using Invoice = Shared.Models.Invoice;
using ManejoContabilidad.Wpf.Services;

namespace ManejoContabilidad.Wpf.ViewModels;

public partial class InvoicesViewModel : ObservableObject, IDisposable
{
    private readonly IInvoiceService _invoiceService;
    private readonly InvoiceDialogHelper _dialogHelper;
    private readonly PrintService _printService;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(EditInvoiceCommand))]
    [NotifyCanExecuteChangedFor(nameof(DeleteInvoiceCommand))]
    private Invoice? _selectedInvoice;

    [ObservableProperty,
     NotifyCanExecuteChangedFor(nameof(GoBackCommand))]
    private int _pageIndex;

    private DateTime _lastPrintedDateTime = DateTime.Now;

    public int? SearchNumber { get; set; }

    public ObservableCollection<Invoice> Invoices { get; private set; } = new();

    public InvoicesViewModel(IInvoiceService invoiceService, InvoiceDialogHelper dialogHelper,
        PrintService printService)
    {
        _printService = printService;
        _invoiceService = invoiceService;
        _dialogHelper = dialogHelper;

        GetInvoices();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    private async void GetInvoices(int page = 0)
    {
        var result = await _invoiceService.GetAllAsync(page);

        if (result.IsSuccess)
        {
            Invoices.Clear();
            foreach (var invoice in result.Value!)
            {
                Invoices.Add(invoice);
            }
        }
        else
        {
            NotifyError();
        }
    }

    [RelayCommand]
    private async Task AddInvoice()
    {
        var invoice = _dialogHelper.Add((Invoices.Any() ? Invoices.Max(i => i.InvoiceNumber) : 0) + 1);
        if (invoice is null)
            return;

        var result = await _invoiceService.AddAsync(invoice);

        if (result.IsSuccess)
        {
            Invoices.Add(result.Value!);
        }
        else
        {
            NotifyError();
        }
    }

    [RelayCommand(CanExecute = nameof(IsInvoiceSelected))]
    private async Task DeleteInvoice(Invoice invoice)
    {
        var dialogResult = _dialogHelper.Delete(invoice);
        if (!dialogResult)
            return;

        var result = await _invoiceService.DeleteAsync(invoice);

        if (result.IsSuccess)
        {
            Invoices.Remove(result.Value!);
        }
        else
        {
            NotifyError();
        }
    }

    [RelayCommand(CanExecute = nameof(IsInvoiceSelected))]
    private async Task EditInvoice(Invoice invoice)
    {
        var dialogResult = _dialogHelper.Edit(invoice);
        if (dialogResult is null)
            return;

        var result = await _invoiceService.EditAsync(dialogResult);

        if (result.IsSuccess)
        {
            invoice.CopyFrom(result.Value!);
        }
        else
        {
            NotifyError();
        }
    }

    [RelayCommand]
    private void SearchInvoice()
    {
        var invoice = Invoices.FirstOrDefault(i => i.InvoiceNumber == SearchNumber);
        if (invoice == null)
            return;
        SelectedInvoice = invoice;
    }

    [RelayCommand(CanExecute = nameof(IsInvoiceSelected))]
    private async void Print(Invoice invoice)
    {
        var dialog = new InvoicePrintDialog(invoice, _lastPrintedDateTime)
        {
            Owner = App.Current.MainWindow,
        };
        var result = dialog.ShowDialog();

        if (result == true)
        {
            // print
            await _printService.Print(dialog.InvoiceDto, InvoicePrintDialog.PreviewPrint);
            _lastPrintedDateTime = dialog.InvoiceDto.DateTime;
        }
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
        return PageIndex > 0;
    }

    private void NotifyError()
    {
        // TODO: notify error
    }
}