using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ManejoContable.View.Windows;
using ManejoContable.View.Windows.Client;
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
            ClientsDataGrid.ItemsSource = new List<Cliente>
            {
                new()
                {
                    Nombre = "Imporcom", NumeroDocumento = "123-456-7890", TipoDocumento = TipoDocumento.Nit,
                    Direccion = "Cra impor #1", Correo = "imporcom@correo.com", Telefono = "123-456-7890",
                },
                new()
                {
                    Nombre = "Andres' Programmers SAS", NumeroDocumento = "111-222-33-44",
                    TipoDocumento = TipoDocumento.Cc, Correo = "andres@correo.com", Telefono = "111-222-3344",
                    Direccion = "Calle 123 # 445 sur",
                }
            };
        }

        private ClientsPage(IEnumerable<Cliente> clientes)
        {
            InitializeComponent();
            ClientsDataGrid.ItemsSource = clientes;
        }


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

            ShowClient_OnClick(sender, e);
        }

        private void Search_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: filter results according to the filters
        }

        private void Clear_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: Set fields to empty and restore to original results
        }


        private void AddClient_OnClick(object sender, RoutedEventArgs e)
        {
            var dialogResult = new AddClientWindow()
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = false,
            }.ShowDialog();
        }

        private void ShowClient_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: Implement Show client information. already implemented, call it here
            if (ClientsDataGrid.SelectedItem is Cliente c)
            {
                var dialogResult = new ViewClientWindow(c)
                {
                    Owner = Application.Current.MainWindow,
                    ShowInTaskbar = false,
                }.ShowDialog();
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void DeleteClient_OnClick(object sender, RoutedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem is Cliente c)
            {
                // TODO: Implement DeleteClient . use new Window, or use the dialog result
                var result = MessageBox.Show("Implement Delete", "Borrar Cliente?", MessageBoxButton.OKCancel,
                    MessageBoxImage.Question, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.OK)
                {
                    // delete client
                }
                else
                {
                    // Nothing 
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void EditClient_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: Implement Edit Client Information. modify.
            // System.Media.SystemSounds.Asterisk.Play();
            // System.Media.SystemSounds.Hand.Play();
            // System.Media.SystemSounds.Beep.Play();
            // System.Media.SystemSounds.Question.Play();

            if (ClientsDataGrid.SelectedItem is Cliente c)
            {
                var dialogResult = new EditClientWindow(c)
                {
                    Owner = Application.Current.MainWindow,
                    ShowInTaskbar = false
                }.ShowDialog();
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }
    }
}