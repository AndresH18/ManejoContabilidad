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
using ManejoContable.UserControls.EventArgs;
using ModelEntities;

namespace ManejoContable.View.Windows.Client
{
    /// <summary>
    /// Interaction logic for EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        public static readonly DependencyProperty ClienteProperty = DependencyProperty.Register(
            "Cliente", typeof(Cliente), typeof(EditClientWindow), new PropertyMetadata(default(Cliente)));

        private Cliente Cliente
        {
            get => (Cliente) GetValue(ClienteProperty);
            init => SetValue(ClienteProperty, value);
        }

        public Cliente NewValue => Cliente;

        public Cliente OldValue { get; }

        public EditClientWindow(Cliente cliente)
        {
            InitializeComponent();

            OldValue = cliente;
            Cliente = (Cliente) cliente.Clone();
        }

        public static EditClientWindow CreateAddClientDialogWindow()
        {
            return new EditClientWindow(new Cliente())
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = false,
                ResizeMode = ResizeMode.NoResize,
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
}