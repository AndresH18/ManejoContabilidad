using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ManejoContable.View.Windows;
using ModelEntities;

namespace ManejoContable.View.Pages.ClientView
{
    /// <summary>
    /// Interaction logic for ViewClientsPage.xaml
    /// </summary>
    public partial class ViewClientsPage : Page
    {
        
        public ViewClientsPage()
        {
            InitializeComponent();
            ClientsDataGrid.ItemsSource = new List<Cliente>
            {
                new() {Nombre = "Imporcom", NumeroDocumento = "123-456-7890", TipoDocumento = TipoDocumento.Nit},
                new() {Nombre = "Andres' Programmers SAS", NumeroDocumento = "111-222-33-44"}
            };
        }

        public ViewClientsPage(IEnumerable<Cliente> clientes)
        {
            InitializeComponent();
            ClientsDataGrid.ItemsSource = clientes;
        }
        

        private void DataGridRowDoubleClick_OnHandler(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine(
                $"{typeof(ViewClientsPage)}: {nameof(DataGridRowDoubleClick_OnHandler)}: Row Double Click Event Triggered");

            var rowCliente = (Cliente) ClientsDataGrid.SelectedItem;
            var clientDialog = new ClientInformationWindow(rowCliente)
            {
                Owner = Application.Current.MainWindow as MainWindow
            };
            if (clientDialog.ShowDialog() == true)
            {
                // TODO: Refresh information
            }
        }
    }
}