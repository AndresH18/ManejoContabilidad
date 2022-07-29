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


namespace ManejoContable.View.Pages.ClientView
{
    /// <summary>
    /// <para>
    /// Interaction logic for AddClientPage.xaml
    /// </para>
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();

            ClientInformationControl.Ok += Control_OnOk;
            ClientInformationControl.Cancel += Control_OnCancel;
        }

        private void Control_OnOk(object? sender, ClientEventArgs e)
        {
            var client = e.Cliente;
            // TODO: Verify Client doesnt exist in database

            // TODO: If not exists: Add to Database
            // 
            // TODO: If exists: Inform User
        }

        private void Control_OnCancel(object? sender, EventArgs e)
        {
            
            // TODO: Implement Cancel Functionality. Client will not be added 

        }
    }
}