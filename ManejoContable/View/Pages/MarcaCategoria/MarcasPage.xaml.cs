﻿using System;
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
using ManejoContable.ViewModel.MarcaCategoria;
using ModelEntities;

namespace ManejoContable.View.Pages.MarcaCategoria
{
    /// <summary>
    /// Interaction logic for MarcasPage.xaml
    /// </summary>
    public partial class MarcasPage : Page
    {
        public MarcasPage()
        {
            InitializeComponent();
        }

        private void ListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Grid.DataContext is IBaseViewModel<Marca> m && m.ViewCommand.CanExecute(m.SelectedModel))
            {
                m.ViewCommand.Execute(m.SelectedModel);
            }
        }
    }
}