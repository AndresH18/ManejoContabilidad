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

namespace ManejoContable.View.Windows.Product
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public static readonly DependencyProperty ProductoProperty = DependencyProperty.Register(
            nameof(Producto), typeof(Producto), typeof(EditProductWindow), new PropertyMetadata(default(Producto?)));

        private Producto Producto
        {
            get => (Producto) GetValue(ProductoProperty);
            init => SetValue(ProductoProperty, value);
        }

        public Producto NewValue => Producto;
        public Producto OldValue { get; }

        public EditProductWindow(Producto producto)
        {
            InitializeComponent();
            OldValue = producto;
            Producto = (Producto) producto.Clone();
        }

        public static EditProductWindow CreateAddProductDialogWindow()
        {
            return new EditProductWindow(new Producto())
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = false,
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
}