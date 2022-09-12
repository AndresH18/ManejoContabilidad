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
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ContabilidadWinUI.Controls
{
    public sealed partial class AppBarControl : UserControl
    {
        public static readonly DependencyProperty CreateCommandProperty = DependencyProperty.Register(
            nameof(CreateCommand), typeof(ICommand), typeof(AppBarControl), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register(
            nameof(DeleteCommand), typeof(ICommand), typeof(AppBarControl), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register(
            nameof(EditCommand), typeof(ICommand), typeof(AppBarControl), new PropertyMetadata(default(ICommand)));


        public ICommand CreateCommand
        {
            get => (ICommand)GetValue(CreateCommandProperty);
            set => SetValue(CreateCommandProperty, value);
        }


        public ICommand EditCommand
        {
            get { return (ICommand)GetValue(EditCommandProperty); }
            set { SetValue(EditCommandProperty, value); }
        }


        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        public AppBarControl()
        {
            this.InitializeComponent();
        }
    }
}