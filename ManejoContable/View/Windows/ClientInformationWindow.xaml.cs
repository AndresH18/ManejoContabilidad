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
using ManejoContable.View.Pages.ClientView;
using ModelEntities;

namespace ManejoContable.View.Windows
{
    /// <summary>
    /// Interaction logic for ClientInformationWindow.xaml
    /// </summary>
    public partial class ClientInformationWindow : Window
    {
        private readonly Cliente _cliente;

        public ClientInformationWindow(Cliente cliente)
        {
            InitializeComponent();

            _cliente = cliente;

            NavigateToClientInformationAction();
            // Frame.Navigate(new ClientInformationPage(_cliente, OnEditClickedAction));
        }

        private void OnEditClickedAction()
        {
            // Navigate to EditClientPage
            Frame.Navigate(new EditClientPage(_cliente, NavigateToClientInformationAction));
        }

        private void NavigateToClientInformationAction()
        {
            // Return to Client information window
            Frame.Navigate(new ClientInformationPage(_cliente, OnEditClickedAction));
        }
    }
}