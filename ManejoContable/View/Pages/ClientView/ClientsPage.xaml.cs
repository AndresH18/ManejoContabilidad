using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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

            ShowClient_OnClick(sender, e);
        }

        private void Search_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: filter results according to the filters
        }

        private void Clear_OnClick(object sender, RoutedEventArgs e)
        {
            // set checkboxes to unchecked
            DocumentTypeCheckBox.IsChecked = true;
            DocumentNumberCheckbox.IsChecked = true;
            ClientNameCheckBox.IsChecked = true;
            EmailCheckBox.IsChecked = true;
            PhoneCheckBox.IsChecked = true;

            // clear the fields
            DocumentNumberTextBox.Text = default;
            DocumentTypeComboBox.SelectedIndex = 0;
            NameTextBox.Text = default;
            EmailTextBox.Text = default;
            PhoneTextBox.Text = default;
        }

        [Obsolete("Use IClientDialogService")]
        private void AddClient_OnClick(object sender, RoutedEventArgs e)
        {
            var dialogResult = new AddClientWindow()
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = false,
                ResizeMode = ResizeMode.NoResize,
            }.ShowDialog();
        }

        [Obsolete("Use IClientDialogService")]
        private void ShowClient_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: Implement Show client information. already implemented, call it here
            if (ClientsDataGrid.SelectedItem is Cliente c)
            {
                var dialogResult = new ViewClientWindow(c)
                {
                    Owner = Application.Current.MainWindow,
                    ShowInTaskbar = false,
                    ResizeMode = ResizeMode.NoResize,
                }.ShowDialog();
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        [Obsolete("Use IClientDialogService")]
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

        [Obsolete("Use IClientDialogService")]
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
                    ShowInTaskbar = false,
                    ResizeMode = ResizeMode.NoResize
                }.ShowDialog();
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is not CheckBox c) return;

            if (ReferenceEquals(c, DocumentTypeCheckBox))
            {
                DocumentTypeComboBox.IsEnabled = c.IsChecked ?? false;
            }
            else if (ReferenceEquals(c, DocumentNumberCheckbox))
            {
                DocumentNumberTextBox.IsEnabled = c.IsChecked ?? false;
            }
            else if (ReferenceEquals(c, ClientNameCheckBox))
            {
                NameTextBox.IsEnabled = c.IsChecked ?? false;
            }
            else if (ReferenceEquals(c, EmailCheckBox))
            {
                EmailTextBox.IsEnabled = c.IsChecked ?? false;
            }
            else if (ReferenceEquals(c, PhoneCheckBox))
            {
                PhoneTextBox.IsEnabled = c.IsChecked ?? false;
            }
        }
    }
}