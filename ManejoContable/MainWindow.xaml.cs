using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ManejoContable.View.Pages;
using ManejoContable.View.Pages.ClientView;
using ManejoContable.View.Pages.MarcaCategoria;
using ManejoContable.View.Pages.Product;
using ManejoContable.View.Windows;
using ModelEntities;

namespace ManejoContable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Frame.Navigated += delegate(object sender, NavigationEventArgs args)
            // {
            //     if (sender is Frame {Content: Page page})
            //     {
            //         MinHeight = page.MinHeight;
            //         MinWidth = page.MinWidth;
            //     }
            // };
        }

        // private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        // {
        //     var message = $"{(sender as MenuItem)?.Header}. Not Implemented";
        //     Debug.WriteLine(message);
        //     MessageBox.Show(message);
        //
        //     // Frame.Navigate(
        //     //     new ClientInformationWindow(new Client() {Nombre = "Andres", NumeroDocumento = string.Empty}).Content);
        // }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        [Obsolete("This method was only for testing purposes and will be deleted")]
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new FacturaPage());
        }

        private void ViewClientsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO?: Check if can Navigate
            Frame.Navigate(new ClientsPage());
        }

        // private void AddClientMenuItem_OnClick(object sender, RoutedEventArgs e)
        // {
        //     // TODO? Check if can Navigate
        //     Frame.Navigate(new AddClientPage(null));
        // }
        private void ProductsMenuItem_OnCLick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ProductsPage());
        }

        private void MarcasMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new MarcasPage());
        }

        private void CategoriasMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new CategoriaPage());
        }
    }
}