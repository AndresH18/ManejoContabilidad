using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Model = ModelEntities;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ContabilidadWinUI.View.Marca
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MarcaDialog : Page
    {
        public bool IsReadOnly { get; private set; }

        public Model::Marca Marca { get; }

        private MarcaDialog(Model::Marca marca)
        {
            Marca = marca;
            this.InitializeComponent();
        }

        public static MarcaDialog CreateDialog(Model::Marca marca, bool isReadOnly = false) =>
            new(marca) {IsReadOnly = isReadOnly};
    }
}