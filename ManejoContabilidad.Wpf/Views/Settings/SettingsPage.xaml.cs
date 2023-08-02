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
using ManejoContabilidad.Wpf.Services;

namespace ManejoContabilidad.Wpf.Views.Settings;

/// <summary>
/// Interaction logic for SettingsPage.xaml
/// </summary>
public partial class SettingsPage : Page
{
    private readonly SettingsManager _settingsManager;

    public SettingsPage(SettingsManager settingsManager)
    {
        _settingsManager = settingsManager;
        InitializeComponent();
    }

    /// <summary>
    /// Checks if the form has changed and has been saved.
    /// </summary>
    /// <returns><b>true</b> if the form has been saved or if nothing was changed. </returns>
    public bool CanReturn()
    {
        // TODO: verify if data has been changed. 
        return true;
    }
}