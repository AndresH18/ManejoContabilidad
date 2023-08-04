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
    internal AppSettings AppSettings { get; private set; }

    public SettingsManager()
    {
        Settings.Default.SettingsSaving += SettingsSaved;

        ExcelConfigurationOptions = ConfigureExcelOptions();
    }

    ~SettingsManager()
    {
        Settings.Default.SettingsSaving -= SettingsSaved;
    }

    /// <summary>
    ///     Holds current instance of <see cref="ExcelConfigurationOptions" />
    /// </summary>
    public ExcelConfigurationOptions ExcelConfigurationOptions { get; private set; }

    public string ConnectionString => Settings.Default.InvoiceDb;

    public Result<bool, Exception> SaveSettings(AppSettings settings)
    {
        // TODO: Map settings to app settings, save settings. Set class to new object
        return true;
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

public struct AppSettings
{
    public required string DbConnection { get; set; }
    public required string RecognizerKey { get; set; }
    public required string RecognizerEndpoint { get; set; }
    public required string RecognizerModelId { get; set; }
    public required string ExcelFile { get; set; }
    public required uint ExcelClientRow { get; set; }
    public required string ExcelClientCol { get; set; }
    public required uint ExcelInvoiceRow { get; set; }
    public required string ExcelInvoiceCol { get; set; }
    public required uint ExcelDateRow { get; set; }
    public required string ExcelDateCol { get; set; }
    public required uint ExcelPriceRow { get; set; }
    public required string ExcelPriceCol { get; set; }
}

public class ExcelSettingsChangedEventArgs : EventArgs
{
    public required ExcelConfigurationOptions ExcelConfigurationOptions { get; init; }

    public static implicit operator ExcelSettingsChangedEventArgs(ExcelConfigurationOptions options)
    {
        return new ExcelSettingsChangedEventArgs {ExcelConfigurationOptions = options};
    }
}