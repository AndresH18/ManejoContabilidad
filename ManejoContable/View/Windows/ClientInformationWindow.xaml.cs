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

namespace ManejoContable.View.Windows
{
    /// <summary>
    /// Interaction logic for ClientInformationWindow.xaml
    /// </summary>
    public partial class ClientInformationWindow : Window
    {
        public static readonly DependencyProperty ClientProperty = DependencyProperty.Register(
            "Client", typeof(Cliente), typeof(ClientInformationWindow), new PropertyMetadata(default(Cliente)));

        public Cliente Client
        {
            get { return (Cliente)GetValue(ClientProperty); }
            private init { SetValue(ClientProperty, value); }
        }
        public ClientInformationWindow(Cliente client)
        {
            InitializeComponent();
            Client = client;
            // FacturaInformationControl.ClientInformationEditButton.Visibility = Visibility.Collapsed;

            // DataContext = this;
        }

    }
}