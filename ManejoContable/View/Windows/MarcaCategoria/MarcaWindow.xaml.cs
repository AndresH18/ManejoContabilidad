using System.Windows;
using ModelEntities;

namespace ManejoContable.View.Windows.MarcaCategoria
{
    public partial class MarcaWindow : Window
    {
        public static readonly DependencyProperty MarcaProperty = DependencyProperty.Register(
            nameof(Marca), typeof(Marca), typeof(MarcaWindow), new PropertyMetadata(default(Marca)));

        private Marca Marca
        {
            get => (Marca) GetValue(MarcaProperty);
            init => SetValue(MarcaProperty, value);
        }

        public Marca NewValue => Marca;
        public Marca OldValue { get; }

        protected MarcaWindow(Marca marca)
        {
            InitializeComponent();
            OldValue = marca;
            Marca = (Marca) marca.Clone();
        }

        public static MarcaWindow CreateViewMarcaWindow(Marca marca, bool showInTaskBar = false)
        {
            /*var window = new MarcaWindow(marca)
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = false,
                ResizeMode = ResizeMode.NoResize,
            };
            window.CancelButton.Visibility = Visibility.Collapsed;
            window.NameTextBox.IsReadOnly = true;
            window.DescriptionTextBox.IsReadOnly = true;
            */
            return new MarcaWindow(marca)
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = showInTaskBar,
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

        public static MarcaWindow CreateAddMarcaWindow(bool showInTaskbar = false)
        {
            return new MarcaWindow(new Marca())
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = showInTaskbar,
                ResizeMode = ResizeMode.NoResize
            };
        }

        public static MarcaWindow CreateUpdateMarcaWindow(Marca marca, bool showInTaskbar = false)
        {
            return new MarcaWindow(marca)
            {
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = showInTaskbar,
                ResizeMode = ResizeMode.NoResize
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