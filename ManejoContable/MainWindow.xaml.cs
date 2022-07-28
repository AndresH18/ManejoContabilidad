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
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var message = $"{(sender as MenuItem)?.Header}. Not Implemented";
            Debug.WriteLine(message);
            MessageBox.Show(message);

            // Frame.Navigate(
            //     new ClientInformationWindow(new Client() {Nombre = "Andres", NumeroDocumento = string.Empty}).Content);
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new FacturaPage());
        }

        private void ViewClientsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO?: Check if can Navigate
            Frame.Navigate(new ViewClientsPage());
        }

        private void AddClientMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO? Check if can Navigate
            // Frame.Navigate(new EditClientPage());
        }

        private void SearchClientsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var r = new SearchClientWindow(){Owner = this}.ShowDialog();
        }
    }
}