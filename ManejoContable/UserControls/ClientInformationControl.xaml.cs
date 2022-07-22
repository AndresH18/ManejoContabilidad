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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ManejoContable.View.Windows;
using ModelEntities;

namespace ManejoContable.UserControls
{
    /// <summary>
    /// Interaction logic for ClientInformationControl.xaml
    /// </summary>
    public partial class ClientInformationControl : UserControl
    {

        public static readonly DependencyProperty ClienteProperty = DependencyProperty.Register(
            "Cliente", typeof(Cliente), typeof(ClientInformationControl), new PropertyMetadata(default(Cliente?)));

        public Cliente? Cliente
        {
            get { return (Cliente?)GetValue(ClienteProperty); }
            set { SetValue(ClienteProperty, value); }
        }

        public ClientInformationControl()
        {
            InitializeComponent();
        }

        private void ClientInformationEditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var clientInformation = new ClientInformationWindow(Cliente)
            {
                ShowInTaskbar = false
            };

             clientInformation.ShowDialog();
        }
    }
}
