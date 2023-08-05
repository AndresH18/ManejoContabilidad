using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ManejoContabilidad.Wpf.Services;
using ManejoContabilidad.Wpf.Services.Navigation;
using Shared;

namespace ManejoContabilidad.Wpf.Views.Settings;

/// <summary>
/// Interaction logic for SettingsPage.xaml
/// </summary>
public partial class SettingsPage : Page
{
    private readonly SettingsManager _settingsManager;
    private readonly INavigationService _navigation;
    private readonly Regex _numberRegex = NumberRegex();
    private readonly Action? _textChangedAction;
    private bool _textHasChanged;

    public SettingsPage(SettingsManager settingsManager, INavigationService navigation)
    {
        _settingsManager = settingsManager;
        _navigation = navigation;
        AppSettings = _settingsManager.AppSettings;
        InitializeComponent();
        // assign event after InitializeComponent to prevent premature invocation
        _textChangedAction = () => _textHasChanged = true;
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

    [RelayCommand]
    private void Save()
    {
        if (!_textHasChanged)
            return;

        var messageBoxResult = MessageBox.Show(App.Current.MainWindow!,
            "Save Settings?",
            "Save",
            MessageBoxButton.YesNo);

        if (messageBoxResult != MessageBoxResult.Yes)
            return;

        if (SaveSettings())
        {
            _textHasChanged = false;
            _navigation.NavigateTo("invoices");
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        _textHasChanged = false;
        _navigation.NavigateTo("invoices");
    }

    /// <summary>
    /// Save the settings calling the current <see cref="SettingsManager"/>
    /// </summary>
    private bool SaveSettings()
    {
        var result = _settingsManager.SaveSettings(AppSettings);
        if (result.IsError)
        {
            // notify error
            MessageBox.Show(App.Current.MainWindow!,
                $"{result.Error!.Message}",
                "Error while saving settings",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return false;
        }

        return true;
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        _textChangedAction?.Invoke();
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