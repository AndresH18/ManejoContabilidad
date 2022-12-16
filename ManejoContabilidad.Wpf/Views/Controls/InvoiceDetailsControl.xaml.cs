using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Models = Shared.Models;

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
            try
            {
                var processStartInfo = new ProcessStartInfo(e.Uri.AbsoluteUri)
                {
                    UseShellExecute = true
                };
                var process = Process.Start(processStartInfo);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}