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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ContabilidadWinUI.Controls
{
    public sealed partial class HeaderTile : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title), typeof(string), typeof(HeaderTile), new PropertyMetadata(default(string)));

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            nameof(Source), typeof(string), typeof(HeaderTile), new PropertyMetadata(default(string)));

        public string Source
        {
            get => (string) GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty SymbolIconProperty = DependencyProperty.Register(
            nameof(SymbolIcon), typeof(Symbol), typeof(HeaderTile), new PropertyMetadata(default(Symbol)));

        public Symbol SymbolIcon
        {
            get => (Symbol) GetValue(SymbolIconProperty);
            set => SetValue(SymbolIconProperty, value);
        }

        public HeaderTile()
        {
            this.InitializeComponent();
        }
    }
}