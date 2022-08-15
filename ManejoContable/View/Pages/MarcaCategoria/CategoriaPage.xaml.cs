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
using ManejoContable.ViewModel;
using ModelEntities;

namespace ManejoContable.View.Pages.MarcaCategoria
{
    /// <summary>
    /// Interaction logic for CategoriaPage.xaml
    /// </summary>
    public partial class CategoriaPage : Page
    {
        public CategoriaPage()
        {
            InitializeComponent();
        }

        private void ListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Grid.DataContext is IBaseViewModel<Categoria> m && m.ViewCommand.CanExecute(m.SelectedModel))
            {
                m.ViewCommand.Execute(m.SelectedModel);
            }
        }
    }
}