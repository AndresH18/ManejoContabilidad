using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ManejoContable.View.Windows;
using ManejoContable.View.Windows.Client;
using ManejoContable.ViewModel.Client;
using ModelEntities;

namespace ManejoContable.View.Pages.ClientView
{
    /// <summary>
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private ClientsPage(IEnumerable<Cliente> clientes)
        {
            InitializeComponent();
            ClientsDataGrid.ItemsSource = clientes;
        }

        [Obsolete]
        private void DataGridRowDoubleClick_OnHandler(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine(
                $"{typeof(ClientsPage)}: {nameof(DataGridRowDoubleClick_OnHandler)}: Row Double Click Event Triggered");

            // var rowCliente = (Cliente)ClientsDataGrid.SelectedItem;
            // var clientDialog = new ClientInformationWindow(rowCliente)
            // {
            //     Owner = Application.Current.MainWindow as MainWindow
            // };
            // if (clientDialog.ShowDialog() == true)
            // {
            //     // Refresh information
            // }
        }

        private void Search_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: filter results according to the filters
        }

        private void Clear_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: Set fields to empty and restore to original results
        }

        
    }
}