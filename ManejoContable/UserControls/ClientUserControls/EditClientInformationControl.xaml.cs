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
using ManejoContable.UserControls.EventArgs;
using ModelEntities;

namespace ManejoContable.UserControls.ClientUserControls
{
    /// <summary>
    /// Interaction logic for EditClientInformationControl.xaml
    /// </summary>
    public partial class EditClientInformationControl : UserControl
    {
        public static readonly DependencyProperty ClienteProperty = DependencyProperty.Register(
            "Cliente", typeof(Cliente), typeof(EditClientInformationControl),
            new PropertyMetadata(default(Cliente?), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (EditClientInformationControl)d;
            if (e.NewValue is Cliente c)
            {
                control._client = c;
            }
        }

        public Cliente? Cliente
        {
            get => (Cliente)GetValue(ClienteProperty);
            set
            {
                if (value is not null)
                {
                    SetValue(ClienteProperty, value);
                }
                else
                {
                    // clear Fields
                }
            }
        }

        private Cliente? _client;

        /// <summary>
        /// <para>
        /// Constructor for creating a new <see cref="EditClientInformationControl"/>.
        /// </para>
        /// <para>Used to create a new <see cref="Cliente"/>.</para>
        /// </summary>
        public EditClientInformationControl()
        {
            InitializeComponent();
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            // if (Cliente != null)
            // {
            //     args.Cliente = Cliente;
            // }
            var args = new ClientEventArgs { Cliente = Cliente ?? CreateClient() };
            Ok?.Invoke(this, args);
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Cancel?.Invoke(this, System.EventArgs.Empty);
        }

        private Cliente CreateClient()
        {
            var c = new Cliente
            {
                Correo = EmailTextBox.Text,
                Direccion = AddressTextBox.Text,
                MunicipioId = MunicipioComboBox.SelectedItem.ToString(),
                Nombre = NameTextBox.Text,
                NumeroDocumento = DocumentNumberTextBox.Text,
                TipoDocumento = (TipoDocumento)DocumentTypeComboBox.SelectedItem,
                Telefono = PhoneTextBox.Text,
                TipoContribuyente = TipoContribuyenteTextBox.Text,
            };
            return c;
        }

        public event EventHandler<ClientEventArgs>? Ok;

        public event EventHandler? Cancel;
    }
}