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
using ManejoContable.View.Pages.ClientView;
using ModelEntities;

namespace ManejoContable.View.Windows
{
    /// <summary>
    /// Interaction logic for ClientInformationWindow.xaml
    /// </summary>
    public partial class ClientInformationWindow : Window
    {
        public static readonly DependencyProperty ClienteProperty = DependencyProperty.Register(
            "Cliente", typeof(Cliente), typeof(ClientInformationWindow), new PropertyMetadata(default(Cliente)));

        public Cliente Cliente
        {
            get { return (Cliente)GetValue(ClienteProperty); }
            private init { SetValue(ClienteProperty, value); }
        }
        public ClientInformationWindow(Cliente cliente)
        {
            InitializeComponent();
            Cliente = cliente;
        }

    }
}