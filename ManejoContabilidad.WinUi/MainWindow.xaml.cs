// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
using ManejoContabilidad.WinUi.View.Pages;
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ManejoContabilidad.WinUi;

/// <summary>
/// An empty window that can be used on its own or navigated to within a ContentFrame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly List<(string Tag, Type pageType)> _pages = new()
    {
        ("home", typeof(HomePage)),
        ("settings", typeof(SettingsPage)),
    };

    public MainWindow()
    {
        this.InitializeComponent();
    }

    public void Navigate(string tag)
    {
        NavigationView_Navigate(tag, new CommonNavigationTransitionInfo());
    }

    private void NavigationView_Navigate(string? navItemTag, NavigationTransitionInfo transitionInfo)
    {
        if (navItemTag == null)
            return;

        Type? page = null;

        var item = _pages.FirstOrDefault(t => t.Tag == navItemTag);
        page = item.pageType;


        var currentPageType = ContentFrame.CurrentSourcePageType;
        if (page != null && currentPageType != page)
        {
            ContentFrame.Navigate(page, null, transitionInfo);
        }
    }

    private void NavigationView_OnLoaded(object sender, RoutedEventArgs e)
    {
        NavigationView.SelectedItem = NavigationView.MenuItems[0];
    }

    private void NavigationView_OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            // handle settings
            NavigationView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
        }
        else if (args.SelectedItemContainer is not null)
        {
            var navItemTag = args.SelectedItemContainer.Tag.ToString();
            NavigationView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
        }
    }

    private void ContentFrame_OnNavigated(object sender, NavigationEventArgs e)
    {
        NavigationView.Header = ((NavigationViewItem) NavigationView.SelectedItem).Content?.ToString();
    }
}