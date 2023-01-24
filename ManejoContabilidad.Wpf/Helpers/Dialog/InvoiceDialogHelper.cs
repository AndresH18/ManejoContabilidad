using System.Windows;
using ManejoContabilidad.Wpf.Views.Invoice;
using Shared.Models;

namespace ManejoContabilidad.Wpf.Helpers.Dialog;

public class InvoiceDialogHelper
{
    /// <summary>
    /// Display a dialog to create a new <see cref="Invoice"/>
    /// </summary>
    /// <param name="invoiceNumber">The suggested invoice number.</param>
    /// <returns>A new instance of <see cref="Invoice"/> or <b>null</b> if no instance is to be created.</returns>
    public Invoice? Add(int invoiceNumber)
    {
        var dialog = new InvoiceWindow(invoiceNumber: invoiceNumber);
        var dialogResult = dialog.ShowDialog();

        return dialogResult == true
            ? dialog.Invoice
            : null;
    }

    /// <summary>
    /// Displays a dialog to confirm deletion of <see cref="Invoice"/>
    /// </summary>
    /// <param name="invoice">The <see cref="Invoice"/> to delete.</param>
    /// <returns><b>true</b> if the invoice should be deleted, <b>false</b> otherwise.</returns>
    public bool Delete(Invoice invoice)
    {
        var result = MessageBox.Show(App.Current.MainWindow!,
            $"Eliminar #{invoice.InvoiceNumber} de '{invoice.ClientName}'?",
            "Borrar Cliente", MessageBoxButton.YesNo);

        return result == MessageBoxResult.Yes;
    }

    /// <summary>
    /// Display a dialog to edit the <see cref="Invoice"/>
    /// </summary>
    /// <param name="invoice">The <see cref="Invoice"/> to delete.</param>
    /// <returns><paramref name="invoice"/> if it should be deleted, <b>null</b> otherwise.</returns>
    public Invoice? Edit(Invoice invoice)
    {
        var dialog = new InvoiceWindow(invoice);
        var dialogResult = dialog.ShowDialog();

        return dialogResult == true
            ? dialog.Invoice
            : null;
    }
}