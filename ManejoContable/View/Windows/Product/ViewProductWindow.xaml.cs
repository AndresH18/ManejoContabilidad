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
    /// Interaction logic for ViewProductWindow.xaml
    /// </summary>
    public partial class ViewProductWindow : Window
    {

        public static readonly DependencyProperty ProductoProperty = DependencyProperty.Register(
            nameof(Producto), typeof(Producto), typeof(ViewProductWindow), new PropertyMetadata(default(Producto)));

        public Producto Producto
        {
            get => (Producto) GetValue(ProductoProperty);
            private init => SetValue(ProductoProperty, value);
        }

        public ViewProductWindow(Producto producto)
        {
            InitializeComponent();

            Producto = producto;
        }
    }
}