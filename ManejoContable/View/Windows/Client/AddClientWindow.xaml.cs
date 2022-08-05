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

namespace ManejoContable.View.Windows.Client
{
    /// <summary>
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
            
            ClientInformationControl.Ok += AddClient_OnOk;
            ClientInformationControl.Cancel += AddClient_OnCancel;
        }

        private void AddClient_OnCancel(object? sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AddClient_OnOk(object? sender, ClientEventArgs e)
        {
            // TODO : Add Client
            MessageBox.Show("implement add client");
        }
    }
}