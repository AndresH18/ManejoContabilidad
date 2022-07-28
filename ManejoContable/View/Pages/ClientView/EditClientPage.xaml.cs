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
using ManejoContable.View.Windows;
using ModelEntities;

namespace ManejoContable.View.Pages.ClientView
{
    /// <summary>
    /// Interaction logic for EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        private Cliente _cliente;

        public EditClientPage( Cliente cliente)
        {
            InitializeComponent();

            ClientInformationControl.Ok += Control_OnOk;
            ClientInformationControl.Cancel += Control_OnCancel;

            _cliente = cliente;
        }

        private void Control_OnOk(object? sender, ClientEventArgs e)
        {
            var client = e.Cliente;
            // TODO: Verify Changes are valid

            // TODO: Update Client on DB

            // TODO: Notify changes
        }

        private void Control_OnCancel(object? sender, ClientEventArgs e)
        {
            // TODO: Implement Cancel Functionality. Client will not be changed
        }
    }
}