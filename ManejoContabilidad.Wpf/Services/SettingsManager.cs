using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using ManejoContabilidad.Wpf.Properties;
using Shared;

namespace ManejoContabilidad.Wpf.Services;

/// <summary>
/// Manages the application settings, providing methods to access and modify configuration options.
/// </summary>
public class SettingsManager
{
    private AppSettings _appSettings = null!;

    internal AppSettings AppSettings
    {
        get => _appSettings.Copy();
        private set => _appSettings = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsManager"/> class with the app settings.
    /// </summary>
    public SettingsManager()
    {
        LoadSettings();
        ExcelConfigurationOptions = ConfigureExcelOptions();

        Settings.Default.SettingsSaving += OnSettingsSaved;
    }

    /// <summary>
    /// Finalizes an instance of the <see cref="SettingsManager"/> class.
    /// </summary>
    ~SettingsManager()
    {
        Settings.Default.SettingsSaving -= OnSettingsSaved;
    }

    /// <summary>
    /// Gets or sets the current application settings.
    /// </summary>
    public ExcelConfigurationOptions ExcelConfigurationOptions { get; private set; }

    /// <summary>
    /// Gets the database connection string from the current application settings.
    /// </summary>
    public string ConnectionString => AppSettings.DbConnection;

    /// <summary>
    /// Saves the provided application settings to the settings store.
    /// </summary>
    /// <param name="settings">The application settings to save</param>
    /// <returns>A <see cref="Result{TValue,TError}"/> indicating the result of the operation. If successful the result is true; otherwise, an <see cref="Exception"/> is returned.</returns>
    public Result<bool, Exception> SaveSettings(AppSettings settings)
    {
        try
        {
            Settings.Default.InvoiceDb = settings.DbConnection;
            Settings.Default.RecognizerKey = settings.RecognizerKey;
            Settings.Default.RecognizerEndpoint = settings.RecognizerEndpoint;
            Settings.Default.RecognizerModel = settings.RecognizerModelId;
            Settings.Default.ExcelFile = settings.ExcelFile;
            Settings.Default.Excel_Client_Row = settings.ExcelClientRow;
            Settings.Default.Excel_Client_Col = settings.ExcelClientCol;
            Settings.Default.Excel_Invoice_Row = settings.ExcelInvoiceRow;
            Settings.Default.Excel_Invoice_Col = settings.ExcelInvoiceCol;
            Settings.Default.Excel_Date_Row = settings.ExcelDateRow;
            Settings.Default.Excel_Date_Col = settings.ExcelDateCol;
            Settings.Default.Excel_Price_Row = settings.ExcelPriceRow;
            Settings.Default.Excel_Price_Col = settings.ExcelPriceCol;

            Settings.Default.Save();

            return true;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Creates a new instance of <see cref="ExcelConfigurationOptions" /> with the current settings
    /// </summary>
    /// <returns>New instance of <see cref="ExcelConfigurationOptions" /></returns>
    private ExcelConfigurationOptions ConfigureExcelOptions()
    {
        return new ExcelConfigurationOptions
        {
            ExcelFile = AppSettings.ExcelFile,
            Cells = new Dictionary<string, ExcelCell>
            {
                { "client", new ExcelCell(AppSettings.ExcelClientRow, AppSettings.ExcelClientCol) },
                { "invoice", new ExcelCell(AppSettings.ExcelInvoiceRow, AppSettings.ExcelInvoiceCol) },
                { "date", new ExcelCell(AppSettings.ExcelDateRow, AppSettings.ExcelDateCol) },
                { "price", new ExcelCell(AppSettings.ExcelPriceRow, AppSettings.ExcelPriceCol) }
            }.ToImmutableDictionary()
        };
    }

    /// <summary>
    /// Loads the initial application settings and configures the Excel options.
    /// </summary>
    private void LoadSettings()
    {
        AppSettings = new AppSettings
        {
            DbConnection = Settings.Default.InvoiceDb,
            ExcelFile = Settings.Default.ExcelFile,
            ExcelClientCol = Settings.Default.Excel_Client_Col,
            ExcelClientRow = Settings.Default.Excel_Client_Row,
            ExcelDateCol = Settings.Default.Excel_Date_Col,
            ExcelDateRow = Settings.Default.Excel_Date_Row,
            ExcelInvoiceCol = Settings.Default.Excel_Invoice_Col,
            ExcelInvoiceRow = Settings.Default.Excel_Invoice_Row,
            ExcelPriceCol = Settings.Default.Excel_Price_Col,
            ExcelPriceRow = Settings.Default.Excel_Price_Row,
            RecognizerEndpoint = Settings.Default.RecognizerEndpoint,
            RecognizerKey = Settings.Default.RecognizerKey,
            RecognizerModelId = Settings.Default.RecognizerModel
        };
        ExcelConfigurationOptions = ConfigureExcelOptions();
    }

    /// <summary>
    ///     Loads a new instance of the <see cref="ExcelConfigurationOptions" /> and notifies subscribers of
    ///     <see cref="ExcelSettingsChanged" />
    /// </summary>
    private void OnSettingsSaved(object sender, CancelEventArgs e)
    {
        LoadSettings();
        ExcelSettingsChanged?.Invoke(this, ExcelConfigurationOptions);
    }

    /// <summary>
    /// Event that is raised when Excel settings have been changed and saved.
    /// </summary>
    public event EventHandler<ExcelSettingsChangedEventArgs>? ExcelSettingsChanged;
}

/// <summary>
/// Represents the event arguments for the Excel settings changed event
/// </summary>
public class ExcelSettingsChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the Excel configuration options associated with the event.
    /// </summary>
    public required ExcelConfigurationOptions ExcelConfigurationOptions { get; init; }

    /// <summary>
    /// Creates an instance of <see cref="ExcelSettingsChangedEventArgs"/> using the provided Excel configuration options.
    /// </summary>
    /// <param name="options">The Excel configuration options to associate with the event</param>
    public static implicit operator ExcelSettingsChangedEventArgs(ExcelConfigurationOptions options)
    {
        return new ExcelSettingsChangedEventArgs { ExcelConfigurationOptions = options };
    }
}

/// <summary>
/// Represents the settings for the application
/// </summary>
public class AppSettings
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

    /// <summary>
    /// Creates a shallow copy of the current <see cref="AppSettings"/> object
    /// </summary>
    /// <returns>A shallow copy of the current <see cref="AppSettings"/> object</returns>
    public AppSettings Copy() => (AppSettings)MemberwiseClone();
}