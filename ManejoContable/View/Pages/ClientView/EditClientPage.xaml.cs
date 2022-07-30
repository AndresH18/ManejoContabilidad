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
        private readonly Cliente _cliente;
        private readonly Action? _returnToClientViewAction;

        private EditClientPage(Cliente cliente)
        {
            InitializeComponent();

            ClientInformationControl.Ok += Control_OnOk;
            ClientInformationControl.Cancel += Control_OnCancel;

            ClientInformationControl.OkButton.Content = "Guardar";

            _cliente = cliente;

            ClientInformationControl.Cliente = cliente;
        }

        public EditClientPage(Cliente cliente, Action returnToClientViewAction) : this(cliente)
        {
            _returnToClientViewAction = returnToClientViewAction;
        }

        private void Control_OnOk(object? sender, ClientEventArgs e)
        {
            var client = e.Cliente;

            // var result = MessageBox.Show("Quieres Guardar los Cambios?", "", MessageBoxButton.OKCancel,
            //     MessageBoxImage.Question, MessageBoxResult.Cancel);
            // if (result == MessageBoxResult.OK)

            // TODO: Verify Changes are valid

            // TODO: Update Client on DB

            // TODO: Notify changes

            MessageBox.Show("Save not implemented");
        }

        private void Control_OnCancel(object? sender, EventArgs e)
        {
            // TODO: Implement Cancel Functionality. Client will not be changed

            // return to client information page
            _returnToClientViewAction?.Invoke();
        }
    }
}