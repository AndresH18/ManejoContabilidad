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
    /// Interaction logic for FacturaInformationControl.xaml
    /// </summary>
    [Obsolete]
    public partial class FacturaInformationControl : UserControl
    {
        public static readonly DependencyProperty ClienteProperty = DependencyProperty.Register(
            "Client", typeof(Cliente), typeof(FacturaInformationControl),
            new PropertyMetadata(default(Cliente?), ClientPropertyChanged));

        private static void ClientPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var clientInformationControl = (FacturaInformationControl)d;

            if (e.NewValue is Cliente c)
            {
            }
        }

        public Cliente? Cliente
        {
            get => (Cliente?)GetValue(ClienteProperty);
            set => SetValue(ClienteProperty, value);
        }

        public FacturaInformationControl()
        {
            InitializeComponent();
        }

        private void ClientInformationEditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var clientInformation = new EditClientInformationWindow(Cliente)
            {
                ShowInTaskbar = false
            };

            clientInformation.ShowDialog();
        }
    }
}