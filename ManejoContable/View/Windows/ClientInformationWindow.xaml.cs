﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Cliente? _cliente;

        public ClientInformationWindow(Cliente? cliente)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            _cliente = cliente;
        }
    }
}