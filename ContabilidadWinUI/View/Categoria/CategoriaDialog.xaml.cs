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

namespace ContabilidadWinUI.View.Categoria
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoriaDialog : Page
    {
        public bool IsReadOnly { get; private init; }

        public Model::Categoria Categoria { get; set; }

        private CategoriaDialog(Model::Categoria categoria)
        {
            Categoria = categoria;
            this.InitializeComponent();
        }

        public static CategoriaDialog CreateDialog(Model::Categoria categoria, bool isReadOnly = false) =>
            new(categoria) { IsReadOnly = isReadOnly };

    }
}