using System.Windows;
using System.Windows.Controls;
using ModelEntities;
using System.Collections.Generic;



namespace ManejoContable.View.Pages.ClientView;

public partial class SearchClientPage : Page
{
    public SearchClientPage()
    {
        InitializeComponent();
    }

    private void SearchButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            // TODO: Crear una consulta y almacenar los resultados en una Lista.
            // TODO?: Crear algun tipo de estructura o clase para almacenar la consulta y el resultado
            var result = new List<Cliente>();
            var clientPage = new ViewClientsPage(result);
            mainWindow.Frame.Navigate(clientPage);
        }
    }
}