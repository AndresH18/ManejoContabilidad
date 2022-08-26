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
using System.Windows.Shapes;
using ModelEntities;

namespace ManejoContable.View.Windows.MarcaCategoria
{
    /// <summary>
    /// Interaction logic for CategoriaWindow.xaml
    /// </summary>
    public partial class CategoriaWindow : Window
    {
        public static readonly DependencyProperty CategoriaProperty = DependencyProperty.Register(
            nameof(Categoria), typeof(Categoria), typeof(CategoriaWindow), new PropertyMetadata(default(Categoria)));

        public Categoria Categoria
        {
            get => (Categoria) GetValue(CategoriaProperty);
            set => SetValue(CategoriaProperty, value);
        }

        public Categoria NewValue => Categoria;
        public Categoria OldValue { get; }

        private CategoriaWindow(Categoria categoria)
        {
            InitializeComponent();
            OldValue = categoria;
            Categoria = (Categoria) categoria.Clone();
        }

        public static CategoriaWindow CreateViewCategoriaWindow(Categoria categoria, bool showInTaskbasr = false)
        {
            // var window = new CategoriaWindow(categoria)
            // {
            //     Owner = Application.Current.MainWindow,
            //     ShowInTaskbar = showInTaskbasr,
            //     ResizeMode = ResizeMode.NoResize,
            // };
            // window.CancelButton.Visibility = Visibility.Collapsed;
            // window.NameTextBox.IsReadOnly = true;
            // window.DescriptionTextBox.IsReadOnly = true;
            return new CategoriaWindow(categoria)
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = showInTaskbasr,
                ResizeMode = ResizeMode.NoResize,
                CancelButton =
                {
                    Visibility = Visibility.Collapsed
                },
                OkButton =
                {
                    Visibility = Visibility.Collapsed
                },
                NameTextBox =
                {
                    IsReadOnly = true
                },
                DescriptionTextBox =
                {
                    IsReadOnly = true
                }
            };
        }

        public static CategoriaWindow CreateAddCategoriaWindow(bool showInTaskBar = false)
        {
            return new CategoriaWindow(new Categoria())
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = showInTaskBar,
                ResizeMode = ResizeMode.NoResize
            };
        }

        public static CategoriaWindow CreateUpdateCategoriaWindow(Categoria categoria, bool showInTaskBar = false)
        {
            return new CategoriaWindow(categoria)
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = showInTaskBar,
                ResizeMode = ResizeMode.NoResize,
            };
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("implement edit SelectedModel");

            DialogResult = true;
        }
    }
}