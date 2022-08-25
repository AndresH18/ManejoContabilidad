using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ManejoContableWinUISimple.View.Categoria;
using ManejoContableWinUISimple.View.Client;
using ManejoContableWinUISimple.View.Home;
using ManejoContableWinUISimple.View.Marca;
using ManejoContableWinUISimple.View.Producto;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.UI.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ManejoContableWinUISimple
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        /// <summary>
        /// List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        /// </summary>
        private readonly List<(string Tag, Type Page)> _pages = new()
        {
            ("home", typeof(HomePage)),
            ("clientes", typeof(ClientsPage)),
            ("productos", typeof(ProductosPage)),
            ("categorias", typeof(CategoriasPage)),
            ("marcas", typeof(MarcasPage)),
        };

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NavView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }

            Debug.WriteLine(args?.InvokedItemContainer?.Tag?.ToString());
        }

        /// <summary>
        /// NavView_SelectionChanged is not used in this example, but is shown for completeness
        /// You will typically handle either ItemInvoked or SelectionChanged to perform navigation,
        /// but not both.
        /// </summary>
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.SelectedItemContainer != null)
            {
                var navItemTag = args.SelectedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                // _page = typeof(SettingsPage);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }

            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (_page is not null && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        /// <summary>
        /// Called after the <see cref="NavView"/> is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavView_OnLoaded(object sender, RoutedEventArgs e)
        {
            // You can also add items in code.

            #region Comment

            /*
            NavView.MenuItems.Add(new NavigationViewItemSeparator());
            NavView.MenuItems.Add(new NavigationViewItem
            {
                Content = "My content",
                Icon = new SymbolIcon((Symbol)0xF1AD),
                Tag = "content"
            });
            _pages.Add(("content", typeof(MyContentPage)));
            */

            #endregion

            // Add handler for ContentFrame navigation.
            ContentFrame.Navigated += On_Navigated;

            // NavView doesn't load any page by default, so load home page.
            NavView.SelectedItem = NavView.MenuItems[0];
            // If navigation occurs on SelectionChanged, this isn't needed.
            // Because we use ItemInvoked to navigate, we need to call Navigate
            // here to load the home page.
            NavView_Navigate("home", new EntranceNavigationTransitionInfo());

            #region Commented out

            // Listen to the window directly so the app responds
            // to accelerator keys regardless of which element has focus.
            /*Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated +=
                CoreDispatcher_AcceleratorKeyActivated;

            Window.Current.CoreWindow.PointerPressed += CoreWindow_PointerPressed;

            SystemNavigationManager.GetForCurrentView().BackRequested += System_BackRequested;*/

            #endregion
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;

            // if (ContentFrame.SourcePageType == typeof(SettingsPage))
            // {
            //     NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
            // }
            // else
            if (ContentFrame.SourcePageType != null)
            {
                // var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);

                // NavView.SelectedItem = NavView.MenuItems
                //     .OfType<NavigationViewItem>()
                //     .FirstOrDefault(n =>
                //     {
                //         Debug.WriteLine(n.Tag);
                //         return n.Tag.Equals(item.Tag);
                //     });

                NavView.Header = ((NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
            }
        }

        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }

        private bool TryGoBack()
        {
            if (!ContentFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (NavView.IsPaneOpen &&
                NavView.DisplayMode is NavigationViewDisplayMode.Compact or NavigationViewDisplayMode.Minimal)
                return false;

            ContentFrame.GoBack();
            return true;
        }
    }
}