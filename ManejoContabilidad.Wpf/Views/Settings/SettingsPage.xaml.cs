using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ManejoContabilidad.Wpf.Services;
using Shared;

namespace ManejoContabilidad.Wpf.Views.Settings;

/// <summary>
/// Interaction logic for SettingsPage.xaml
/// </summary>
public partial class SettingsPage : Page
{
    private readonly Regex _numberRegex = NumberRegex();
    private readonly SettingsManager _settingsManager;
    private bool _textHasChanged = false;

    public SettingsPage(SettingsManager settingsManager)
    {
        _settingsManager = settingsManager;
        AppSettings = _settingsManager.AppSettings;
        InitializeComponent();
    }

    public AppSettings AppSettings { get; }

    /// <summary>
    /// Checks if the form has changed and has been saved.
    /// </summary>
    /// <returns><b>true</b> if the form has been saved or if nothing was changed. </returns>
    public bool CanReturn()
    {
        if (!_textHasChanged)
            return true;

        var r = MessageBox.Show(App.Current.MainWindow!,
            "Save Settings?",
            "Settings",
            MessageBoxButton.YesNoCancel,
            MessageBoxImage.Question,
            MessageBoxResult.No);

        return r switch
        {
            MessageBoxResult.Cancel => false,
            MessageBoxResult.No => true,
            MessageBoxResult.Yes => SaveSettings(),
            _ => true
        };
    }

    /// <summary>
    /// Save the settings calling the current <see cref="SettingsManager"/>
    /// </summary>
    private bool SaveSettings()
    {
        var result = _settingsManager.SaveSettings(AppSettings);
        if (result.IsError)
        {
        }

        return true;
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        _textHasChanged = true;
    }

    /// <summary>
    /// Checks if input on <see cref="CheckBox"/> that represents <see cref="ExcelCell.Row"/> elements is a number
    /// </summary>
    private void Row_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!_numberRegex.IsMatch(e.Text))
        {
            e.Handled = true;
        }
    }

    [GeneratedRegex("[0-9]+")]
    private static partial Regex NumberRegex();
}