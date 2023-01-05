using System;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using Models = Shared.Models;

namespace ManejoContabilidad.Wpf.Views.Invoice;

/// <summary>
/// Interaction logic for InvoicePrintDialog.xaml
/// </summary>
public partial class InvoicePrintDialog : Window
{
    public static string NameTooltip => "El nombre del cliente";
    public static string DateTooltip => "Fecha de pago/abono de la factura";
    public static string PriceTooltip => "El valor que fue pagado/abonado";
    public static string InvoiceNumberTooltip => "El numero del recibo pagado/abonado";
    public static string SimplePrintTooltip => "Imprime el recibo sin registrarlo en el sistema.";

    public Models::InvoicePrintDto InvoiceDto { get; }

    public InvoicePrintDialog(Models::Invoice invoice, DateTime lastDateTime)
    {
        InvoiceDto = new Models.InvoicePrintDto(invoice) {DateTime = lastDateTime};

        InitializeComponent();
    }

    private void TotalToggleButton_OnChecked(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void PagoRadioButton_OnChecked(object sender, RoutedEventArgs e)
    {
        InvoiceDto.PaymentType = Models::InvoicePrintDto.TipoPago.Pago;
    }

    private void AbonoRadioButton_OnChecked(object sender, RoutedEventArgs e)
    {
        InvoiceDto.PaymentType = Models::InvoicePrintDto.TipoPago.Abono;
    }

    private void PrintButton_OnClick(object sender, RoutedEventArgs e)
    {
        var printTag = (sender as Button)?.Tag as string;

        switch (printTag)
        {
            case "print" when InvoiceDto.HasErrors:
                // TODO: verify model State
                DialogResult = true;
                Close();
                break;
            case "cancel":
                Cancel();
                break;
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        DialogResult = false;
        Close();
    }
}