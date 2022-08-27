using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ModelEntities;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ContabilidadWinUI.View.Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientDialog : Page
    {
        public Cliente Cliente { get; set; }

        private ClientDialog(Cliente cliente)
        {
            this.Cliente = cliente;
            this.InitializeComponent();
        }

        public static ClientDialog CreateClientDialog()
        {
            return new ClientDialog(new Cliente())
            {
            };
        }

        private void DocumentTypeComboBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            DocumentTypeComboBox.SelectedIndex = (int) Cliente.TipoDocumento;
        }
    }
}