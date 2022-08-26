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

namespace ManejoContable.View.Windows.Product;

/// <summary>
/// Interaction logic for ProductWindow.xaml
/// </summary>
public partial class ProductWindow : Window
{
    public static readonly DependencyProperty ProductoProperty = DependencyProperty.Register(
        nameof(Producto), typeof(Producto), typeof(ProductWindow), new PropertyMetadata(default(Producto)));

    private Producto Producto
    {
        get => (Producto) GetValue(ProductoProperty);
        init => SetValue(ProductoProperty, value);
    }

    public Producto NewValue => Producto;
    public Producto OldValue { get; }

    private ProductWindow(Producto producto)
    {
        InitializeComponent();

        OldValue = producto;
        Producto = (Producto) producto.Clone();
    }

    public static ProductWindow CreateViewProductWindow(Producto producto, bool showInTaskBar = false)
    {
        return new ProductWindow(producto)
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = showInTaskBar,
            ResizeMode = ResizeMode.NoResize,
            CancelButton =
            {
                Visibility = Visibility.Collapsed
            },
            OkButton =
            {
                Visibility = Visibility.Collapsed
            },
            ProductNameTextBox = {IsReadOnly = true},
            CategoriaCombobox = {IsReadOnly = true},
            MarcaCombobox = {IsReadOnly = true},
            CodigoTextBox = {IsReadOnly = true},
            ReferenciaTextBox = {IsReadOnly = true},
            PrecioTextBox = {IsReadOnly = true},
            DescriptionTextBox = {IsReadOnly = true}
        };
    }

    public static ProductWindow CreateAddProductWindow(bool showInTaskBar = false)
    {
        return new ProductWindow(new Producto())
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = showInTaskBar,
            ResizeMode = ResizeMode.NoResize
        };
    }

    public static ProductWindow CreateUpdateProductWindow(Producto producto, bool showInTaskBar = false)
    {
        return new ProductWindow(producto)
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = showInTaskBar,
            ResizeMode = ResizeMode.NoResize
        };
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("implement edit Product");

        DialogResult = true;
    }
}