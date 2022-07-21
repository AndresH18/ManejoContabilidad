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

namespace ManejoContable.UserControls
{
    /// <summary>
    /// Interaction logic for ClientInformationControl.xaml
    /// </summary>
    public partial class ClientInformationControl : UserControl
    {
        public ClientInformationControl()
        {
            InitializeComponent();
        }

        private void ClientInformationEditButton_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: Implement Client information dialog
            MessageBox.Show("Implement Edit Client information Dialog");
        }
    }
}
