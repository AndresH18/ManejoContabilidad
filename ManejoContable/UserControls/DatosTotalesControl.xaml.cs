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
    /// Interaction logic for DatosTotales.xaml
    /// </summary>
    [Obsolete]
    public partial class DatosTotales : UserControl
    {
        // public static readonly DependencyProperty MyPropertyProperty = DependencyProperty.Register(
        //     "MyProperty", typeof(string), typeof(DatosTotales), new PropertyMetadata(default(string)));
        //
        // public string MyProperty
        // {
        //     get { return (string) GetValue(MyPropertyProperty); }
        //     set { SetValue(MyPropertyProperty, value); }
        // }
        public DatosTotales()
        {
            InitializeComponent();
        }
    }
}