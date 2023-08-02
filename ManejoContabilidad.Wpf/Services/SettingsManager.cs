using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using ManejoContabilidad.Wpf.Properties;

namespace ManejoContabilidad.Wpf.Services;

/// <summary>
/// Encapsulates the application settings 
/// </summary>
public class SettingsManager
{
    /// <summary>
    /// Holds current instance of <see cref="ExcelConfigurationOptions"/>
    /// </summary>
    public ExcelConfigurationOptions ExcelConfigurationOptions { get; private set; }

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
    /// Creates a new instance of <see cref="ExcelConfigurationOptions"/> with the current settings
    /// </summary>
    /// <returns>New instance of <see cref="ExcelConfigurationOptions"/></returns>
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
                {"price", new ExcelCell(Settings.Default.Excel_Price_Row, Settings.Default.Excel_Price_Col)},
            }.ToImmutableDictionary()
        };
    }

    /// <summary>
    /// Loads a new instance of the <see cref="ExcelConfigurationOptions"/> and notifies subscribers of <see cref="ExcelSettingsChanged"/>
    /// </summary>
    private void SettingsSaved(object sender, System.ComponentModel.CancelEventArgs e)
    {
        ExcelConfigurationOptions = ConfigureExcelOptions();
        ExcelSettingsChanged?.Invoke(this, EventArgs.Empty);
    }


    public string? ConnectionString => Settings.Default.InvoiceDb;

    public event EventHandler? ExcelSettingsChanged;
}

public class ExcelSettingsChangedEventArgs : EventArgs
{
}

public record ExcelConfigurationOptions
{
    public required string ExcelFile { get; init; }
    public required IReadOnlyDictionary<string, ExcelCell> Cells { get; init; }
}

public readonly record struct ExcelCell(uint Row, string Col);