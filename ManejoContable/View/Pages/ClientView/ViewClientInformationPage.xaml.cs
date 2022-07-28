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
using ModelEntities;

namespace ManejoContable.View.Pages.ClientView
{
    /// <summary>
    /// Interaction logic for ViewClientInformationPage.xaml
    /// </summary>
    public partial class ViewClientInformationPage : Page
    {
        public static readonly DependencyProperty ClienteProperty = DependencyProperty.Register(
            "Cliente", typeof(Cliente), typeof(ViewClientInformationPage), new PropertyMetadata(default(Cliente)));

        public Cliente Cliente
        {
            get { return (Cliente)GetValue(ClienteProperty); }
            private set { SetValue(ClienteProperty, value); }
        }
        public ViewClientInformationPage(Cliente cliente)
        {
            InitializeComponent();
            Cliente = cliente;
        }
    }
}