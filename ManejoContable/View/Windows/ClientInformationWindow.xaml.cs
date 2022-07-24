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
using System.Windows.Shapes;
using ModelEntities;

namespace ManejoContable.View.Windows
{
    /// <summary>
    /// Interaction logic for ClientInformationWindow.xaml
    /// </summary>
    public partial class ClientInformationWindow : Window
    {
        public Cliente Cliente { get; }
        public ClientInformationWindow(Cliente cliente)
        {
            InitializeComponent();
            Cliente = cliente;
            // FacturaInformationControl.ClientInformationEditButton.Visibility = Visibility.Collapsed;
            Owner = Application.Current.MainWindow;

            ShowInTaskbar = true;
        }

    }
}