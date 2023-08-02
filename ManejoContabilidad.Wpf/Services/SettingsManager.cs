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

    private static ExcelConfigurationOptions ConfigureExcelOptions()
    {
        // return new ExcelConfigurationOptions
        // {
        //     ClientCol = Settings.Default.Excel_Client_Col,
        //     ClientRow = Settings.Default.Excel_Client_Row,
        //     InvoiceCol = Settings.Default.Excel_Invoice_Col,
        //     InvoiceRow = Settings.Default.Excel_Invoice_Row,
        //     DateCol = Settings.Default.Excel_Date_Col,
        //     DateRow = Settings.Default.Excel_Date_Row,
        //     PriceCol = Settings.Default.Excel_Price_Col,
        //     PriceRow = Settings.Default.Excel_Price_Row
        // };

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
    public required ImmutableDictionary<string, ExcelCell> Cells { get; init; }
}

public readonly record struct ExcelCell(uint Row, string Col);