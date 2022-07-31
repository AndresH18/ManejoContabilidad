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

namespace ManejoContable.View.Windows.Client
{
    /// <summary>
    /// Interaction logic for ViewClientWindow.xaml
    /// </summary>
    public partial class ViewClientWindow : Window
    {
        public static readonly DependencyProperty ClienteProperty = DependencyProperty.Register(
            "Cliente", typeof(Cliente), typeof(ViewClientWindow), new PropertyMetadata(default(Cliente)));

        public Cliente Cliente
        {
            get => (Cliente) GetValue(ClienteProperty);
            init => SetValue(ClienteProperty, value);
        }
        public ViewClientWindow(Cliente cliente)
        {
            InitializeComponent();
            Cliente = cliente;
        }
    }
}
