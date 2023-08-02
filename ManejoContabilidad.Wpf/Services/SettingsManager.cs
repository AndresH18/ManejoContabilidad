using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using ManejoContabilidad.Wpf.Properties;
using Shared;

namespace ManejoContabilidad.Wpf.Services;

/// <summary>
///     Encapsulates the application settings
/// </summary>
public class SettingsManager
{
    public SettingsManager()
    {
        Settings.Default.SettingsSaving += SettingsSaved;

        ExcelConfigurationOptions = ConfigureExcelOptions();
    }

    /// <summary>
    ///     Holds current instance of <see cref="ExcelConfigurationOptions" />
    /// </summary>
    public ExcelConfigurationOptions ExcelConfigurationOptions { get; private set; }


    public string ConnectionString => Settings.Default.InvoiceDb;

    ~SettingsManager()
    {
        Settings.Default.SettingsSaving -= SettingsSaved;
    }

    /// <summary>
    ///     Creates a new instance of <see cref="ExcelConfigurationOptions" /> with the current settings
    /// </summary>
    /// <returns>New instance of <see cref="ExcelConfigurationOptions" /></returns>
    private static ExcelConfigurationOptions ConfigureExcelOptions()
    {
        return new ExcelConfigurationOptions
        {
            ExcelFile = Settings.Default.ExcelFile,
            Cells = new Dictionary<string, ExcelCell>
            {
                {"client", new ExcelCell(Settings.Default.Excel_Client_Row, Settings.Default.Excel_Client_Col)},
                {"invoice", new ExcelCell(Settings.Default.Excel_Invoice_Row, Settings.Default.Excel_Invoice_Col)},
                {"date", new ExcelCell(Settings.Default.Excel_Date_Row, Settings.Default.Excel_Date_Col)},
                {"price", new ExcelCell(Settings.Default.Excel_Price_Row, Settings.Default.Excel_Price_Col)}
            }.ToImmutableDictionary()
        };
    }

    /// <summary>
    ///     Loads a new instance of the <see cref="ExcelConfigurationOptions" /> and notifies subscribers of
    ///     <see cref="ExcelSettingsChanged" />
    /// </summary>
    private void SettingsSaved(object sender, CancelEventArgs e)
    {
        ExcelConfigurationOptions = ConfigureExcelOptions();
        ExcelSettingsChanged?.Invoke(this, ExcelConfigurationOptions);
    }

    public event EventHandler<ExcelSettingsChangedEventArgs>? ExcelSettingsChanged;
}

public class ExcelSettingsChangedEventArgs : EventArgs
{
    public ExcelConfigurationOptions ExcelConfigurationOptions { get; init; }

    public static implicit operator ExcelSettingsChangedEventArgs(ExcelConfigurationOptions options)
    {
        return new ExcelSettingsChangedEventArgs {ExcelConfigurationOptions = options};
    }
}