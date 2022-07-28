using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Automation;
using ManejoContable.View.Pages.ClientView;
using ModelEntities;

namespace ManejoContable.View.Windows;

public partial class SearchClientWindow : Window
{
    public SearchClientWindow()
    {
        InitializeComponent();
    }

    private void SearchButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            // TODO: Crear una consulta y almacenar los resultados en una Lista.
            // TODO?: Crear algun tipo de estructura o clase para almacenar la consulta y el resultado
            var results = new List<Cliente>()
            {
                new()
                {
                    Nombre = "Avianca", NumeroDocumento = Guid.NewGuid().ToString(), TipoDocumento = TipoDocumento.Nit
                },
                new() {Nombre = "Imporcom", NumeroDocumento = "123-456-7890", TipoDocumento = TipoDocumento.Nit},
                new() {Nombre = "Andres' Programmers SAS", NumeroDocumento = "111-222-33-44"},
                new() {Nombre = "EIA", NumeroDocumento = Guid.NewGuid().ToString(), TipoDocumento = TipoDocumento.Cc},
                new()
                {
                    Nombre = "Fernando", NumeroDocumento = Guid.NewGuid().ToString(), TipoDocumento = TipoDocumento.Ti
                }
            };
            if (results.Count > 0)
            {
                var clientPage = new ViewClientsPage(results);
                Close();
                mainWindow.Frame.Navigate(clientPage);
            }
            else
            {
                MessageBox.Show("No existen Clientes con estos campos");
            }

            
        }
    }
}