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
using ModelEntities;

namespace ManejoContable.View.Pages.ClientView
{
    /// <summary>
    /// Interaction logic for ClientInformationPage.xaml
    /// </summary>
    public partial class ClientInformationPage : Page
    {
        public static readonly DependencyProperty ClienteProperty = DependencyProperty.Register(
            "Cliente", typeof(Cliente), typeof(ClientInformationPage), new PropertyMetadata(default(Cliente)));

        public Cliente Cliente
        {
            get => (Cliente)GetValue(ClienteProperty);
            private init => SetValue(ClienteProperty, value);
        }


        private Action<Cliente>? _editAction;

        public ClientInformationPage(Cliente cliente)
        {
            InitializeComponent();
            Cliente = cliente;
        }

        public ClientInformationPage(Cliente cliente, Action<Cliente> onEditClickedAction) : this(cliente)
        {
            _editAction = onEditClickedAction;
        }


        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            _editAction?.Invoke(Cliente);
        }
    }
}