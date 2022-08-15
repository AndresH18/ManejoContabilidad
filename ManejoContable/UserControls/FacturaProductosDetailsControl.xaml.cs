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

namespace ManejoContable.UserControls
{
    /// <summary>
    /// Interaction logic for FacturaProductosDetailsControl.xaml
    /// </summary>
    [Obsolete]
    public partial class FacturaProductosDetailsControl : UserControl
    {
        private readonly List<ProductoFactura> _productoList = new List<ProductoFactura>();

        public FacturaProductosDetailsControl()
        {
            InitializeComponent();

            for (var i = 0; i < 10; i++)
            {
                _productoList.Add(new ProductoFactura());
            }

            ProductsGrid.ItemsSource = _productoList;
        }

        private void GridButtons_OnClick(object sender, RoutedEventArgs e)
        {
            if (ReferenceEquals(sender, AddButton))
            {
                // TODO: Implement AddButton functionality
                MessageBox.Show("Implement Create Functionality");
            }
            else if (ReferenceEquals(sender, RemoveButton))
            {
                // TODO: Implement RemoveButton functionality
                MessageBox.Show("Implement Remove Functionality");
            }
        }
    }
}