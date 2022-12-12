using System.Windows;
using ManejoContabilidad.Wpf.Views.Invoice;
using Shared.Models;

namespace ManejoContabilidad.Wpf.Helpers.Dialog;

public class InvoiceDialogHelper : IDialogHelper<Invoice>
{
    public Invoice? Add()
    {
        var dialog = new InvoiceWindow(new Invoice(), isReadOnly: false);
        var dialogResult = dialog.ShowDialog();

        return dialogResult == true
            ? dialog.Invoice
            : null;
    }

    public bool Delete(Invoice invoice)
    {
        var result = MessageBox.Show(App.Current.MainWindow!, $"Eliminar {invoice.InvoiceNumber}?",
            "Borrar Cliente", MessageBoxButton.YesNo);

        return result == MessageBoxResult.Yes;
    }

    public Invoice? Edit(Invoice t)
    {
        return null;
    }

    public void Show(Invoice invoice)
    {
        var dialog = new InvoiceWindow(invoice, true);
        dialog.ShowDialog();
    }
}