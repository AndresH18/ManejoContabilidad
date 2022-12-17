using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ManejoContabilidad.Wpf.Views.Controls
{
    /// <summary>
    /// Interaction logic for InvoiceDetailsControl.xaml
    /// </summary>
    public partial class InvoiceDetailsControl : UserControl
    {
        public InvoiceDetailsControl()
        {
            InitializeComponent();
        }

        private void Path_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            var processStartInfo = new ProcessStartInfo(e.Uri.AbsoluteUri)
            {
                UseShellExecute = true
            };
            Process.Start(processStartInfo);
            e.Handled = true;
        }
    }
}