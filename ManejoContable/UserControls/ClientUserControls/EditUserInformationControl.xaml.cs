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

namespace ManejoContable.UserControls.ClientUserControls
{
    /// <summary>
    /// Interaction logic for EditUserInformationControl.xaml
    /// </summary>
    public partial class EditUserInformationControl : UserControl
    {
        public EditUserInformationControl()
        {
            InitializeComponent();
        }
        
        private void ActionButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ReferenceEquals(sender, OkButton))
            {
                // TODO: Implement OkButton
                MessageBox.Show("Implement OkButton");

                // var tipoDoc = TipoDocumentoComboBox.SelectedItem as Cliente;
            }
            else if (ReferenceEquals(sender, CancelButton))
            {
                // DialogResult = false;
                // Close();
            }
        }
    }
}
