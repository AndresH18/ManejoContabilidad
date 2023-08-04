namespace Shared;

// TODO: Modify to make this structs instead of records? Consider using on AppSettings 
public record ExcelConfigurationOptions
{
    public const string WorkSheetName = "Sheet1";
    public required string ExcelFile { get; init; }
    public required IReadOnlyDictionary<string, ExcelCell> Cells { get; init; }

    public string FileName => Path.GetFileName(ExcelFile);
}

public readonly record struct ExcelCell(uint Row, string Column);