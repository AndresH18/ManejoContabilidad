using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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

    public static InvoicePrintDialog CreatePrintDialog(Models::Invoice invoice, DateTime lastDateTime)
    {
        return new InvoicePrintDialog(invoice, lastDateTime)
        {
            Owner = App.Current.MainWindow,
        };
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

    private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
    {
        // TODO: verify model state
        DialogResult = true;
        Close();
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}