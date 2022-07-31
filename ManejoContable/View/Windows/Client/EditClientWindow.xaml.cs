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
        private Cliente _cliente;
        public EditClientWindow(Cliente cliente)
        {
            InitializeComponent();
            ClientInformationControl.Ok += EditClientOnOk;
            ClientInformationControl.Cancel += EditClientOnCancel;

            _cliente = cliente;
            ClientInformationControl.Cliente = _cliente;
        }

        private void EditClientOnCancel(object? sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void EditClientOnOk(object? sender, ClientEventArgs e)
        {
            // TODO : Add Client
            MessageBox.Show("implement edit client");
        }
    }
}
