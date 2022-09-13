using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using ContabilidadWinUI.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Model = ModelEntities;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ContabilidadWinUI.View.Producto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductoDialog : Page
    {
        private readonly IProductsService _service;

        public Model::Producto Producto { get; }
        public bool IsReadOnly { get; private init; }
        public bool IsEditEnabled => !IsReadOnly;

        private ProductoDialog(Model::Producto producto)
        {
            this.Producto = producto;
            _service = App.Current.Services.GetService<IProductsService>() ??
                       throw new ArgumentNullException($"Service {typeof(IProductsService)} is not registered.");

            this.InitializeComponent();
        }

        public static ProductoDialog CreateDialog(Model::Producto producto, bool isReadOnly = false) =>
            new(producto) {IsReadOnly = isReadOnly};

        private void CategoriasComboBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            CategoriaComboBox.ItemsSource = _service.GetAllCategorias();
            CategoriaComboBox.SelectedIndex = Producto.CategoriaId != 0 ? Producto.CategoriaId - 1 : 0;
        }

        private void MarcasComboBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            MarcasComboBox.ItemsSource = _service.GetAllMarcas();
            MarcasComboBox.SelectedIndex = Producto.MarcaId != 0 ? Producto.MarcaId - 1 : 0;
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("HHEHEHEHEHEHE");
        }
    }

    internal class DecimalToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return System.Convert.ToDouble((decimal) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return System.Convert.ToDecimal((double) value);
        }
    }
}