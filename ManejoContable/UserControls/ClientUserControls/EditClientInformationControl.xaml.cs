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
            var control = (EditClientInformationControl) d;
            if (e.NewValue is Cliente c)
            {
                control._client = c;
            }
        }

        public Cliente Cliente
        {
            get => (Cliente) GetValue(ClienteProperty);
            set => SetValue(ClienteProperty, value);
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
            Cliente = new Cliente() {Nombre = "Andres", TipoDocumento = TipoDocumento.Ti, NumeroDocumento = "123-456"};
        }

        /// <summary>
        /// <para>
        /// Constructor for creating a new <see cref="EditClientInformationControl"/> with a <see cref="Cliente"/> instance.
        /// </para>
        /// <para>Used to edit a <see cref="Cliente"/>'s information.</para>
        /// </summary>
        /// <param name="cliente"></param>
        [Obsolete]
        public EditClientInformationControl(Cliente cliente) : this()
        {
            Cliente = cliente;
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            var args = new ClientEventArgs();
            if (Cliente != null)
            {
                args.Cliente = Cliente;
            }

            Ok?.Invoke(this, args);
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Cliente = new Cliente()
            {
                Nombre = Guid.NewGuid().ToString(), NumeroDocumento = Guid.NewGuid().ToString(),
                TipoDocumento = TipoDocumento.Cc
            };
            // Cancel?.Invoke(this, new ClientEventArgs());
        }

        public event EventHandler<ClientEventArgs>? Ok;

        public event EventHandler<ClientEventArgs>? Cancel;
    }
}