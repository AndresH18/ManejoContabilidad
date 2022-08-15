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
using ModelEntities;

namespace ManejoContable.View.Windows.Client;

/// <summary>
/// Interaction logic for ClientWindow.xaml
/// </summary>
public partial class ClientWindow : Window
{
    public static readonly DependencyProperty ClienteProperty = DependencyProperty.Register(
        nameof(Cliente), typeof(Cliente), typeof(ClientWindow), new PropertyMetadata(default(Cliente)));

    private Cliente Cliente
    {
        get => (Cliente) GetValue(ClienteProperty);
        init => SetValue(ClienteProperty, value);
    }


    public Cliente NewValue => Cliente;

    public Cliente OldValue { get; }

    private ClientWindow(Cliente cliente)
    {
        InitializeComponent();

        OldValue = cliente;
        Cliente = (Cliente) cliente.Clone();
    }

    public static ClientWindow CreateViewClientWindow(Cliente cliente, bool showInTaskbar = false)
    {
        return new ClientWindow(cliente)
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = showInTaskbar,
            ResizeMode = ResizeMode.NoResize,
            CancelButton =
            {
                Visibility = Visibility.Collapsed,
            },
            OkButton =
            {
                Visibility = Visibility.Collapsed
            },
            NameTextBox = {IsReadOnly = true},
            DocumentNumberTextBox = {IsReadOnly = true},
            DepartamentoComboBox = {IsReadOnly = true},
            AddressTextBox = {IsReadOnly = true},
            PhoneTextBox = {IsReadOnly = true},
            DocumentTypeComboBox = {IsReadOnly = true},
            MunicipioComboBox = {IsReadOnly = true},
            EmailTextBox = {IsReadOnly = true},
            TipoContribuyenteComboBox = {IsReadOnly = true}
        };
    }

    public static ClientWindow CreateAddClientWindow(bool showInTaskBar = false)
    {
        return new ClientWindow(new Cliente())
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = showInTaskBar,
            ResizeMode = ResizeMode.NoResize
        };
    }

    public static ClientWindow CreateUpdateClientWindow(Cliente cliente, bool showInTaskBar = false)
    {
        return new ClientWindow(cliente)
        {
            Owner = Application.Current.MainWindow,
            ResizeMode = ResizeMode.NoResize,
            ShowInTaskbar = showInTaskBar
        };
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("implement edit client");

        DialogResult = true;
    }
}