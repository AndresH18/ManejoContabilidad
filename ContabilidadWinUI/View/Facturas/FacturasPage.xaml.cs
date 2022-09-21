using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using ContabilidadWinUI.Services;
using ContabilidadWinUI.ViewModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ContabilidadWinUI.View.Facturas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FacturasPage : Page
    {
        private FacturasViewModel _viewModel;

        public FacturasPage()
        {
            this.InitializeComponent();

            _viewModel = (FacturasViewModel) Grid.DataContext;
        }

        private async void ScannButton_OnClick(object sender, RoutedEventArgs e)
        {
            var file = await FileService.SelectFile(App.Current.Window!);
            if (file != null)
            {
                _viewModel.Scan(file);
            }
        }
    }
}