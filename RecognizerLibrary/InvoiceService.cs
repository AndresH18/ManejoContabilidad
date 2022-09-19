using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure;

namespace RecognizerLibrary;

public class InvoiceService
{
    private readonly string _endPoint;
    private readonly string _apiKey;
    private readonly AzureKeyCredential _credential;

    private DocumentAnalysisClient _analysisClient;

    public InvoiceService(string endPoint, string apiKey)
    {
        _endPoint = endPoint;
        _apiKey = apiKey;

        _credential = new AzureKeyCredential(_apiKey);
        _analysisClient = new DocumentAnalysisClient(new Uri(endPoint), _credential);
    }

    public string ModelId { get; set; } = string.Empty;

    public async Task AnalyzeDocumentFromStream(Uri fileUri)
    {
        AnalyzeDocumentOperation operation =
            await _analysisClient.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, ModelId, fileUri);

        AnalyzeResult result = operation.Value;

        Console.WriteLine($"Document was analyzed with model ID: {result.ModelId}");

        foreach (var document in result.Documents)
        {
            Console.WriteLine($"Document of Type: {document.DocumentType}");

            foreach (KeyValuePair<string, DocumentField> fieldKeyValuePair in document.Fields)
            {
                string fieldName = fieldKeyValuePair.Key;
                DocumentField field = fieldKeyValuePair.Value;

                Console.WriteLine($"Field '{fieldName}'");

                Console.WriteLine($"\tContent: '{field.Content}'");
                Console.WriteLine($"\tConfidence: '{field.Confidence}'");
            }
        }
    }

    public async Task AnalyzeDocumentFromStream(Stream fileStream)
    {
        AnalyzeDocumentOperation operation =
            await _analysisClient.AnalyzeDocumentAsync(WaitUntil.Completed, ModelId, fileStream);

        AnalyzeResult result = operation.Value;
        // https://learn.microsoft.com/en-us/dotnet/api/azure.ai.formrecognizer.documentanalysis.analyzeresult?view=azure-dotnet

        Console.WriteLine($"Document was analyzed with model with ID: {result.ModelId}");

        foreach (AnalyzedDocument document in result.Documents)
        {
            // https://learn.microsoft.com/en-us/dotnet/api/azure.ai.formrecognizer.documentanalysis.analyzeddocument?view=azure-dotnet


            Console.WriteLine($"Document of type: {document.DocumentType}");

            foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
            {
                string fieldName = fieldKvp.Key;
                DocumentField field = fieldKvp.Value;

                Console.WriteLine($"Field '{fieldName}': ");

                Console.WriteLine($"\tContent: '{field.Content}'");
                Console.WriteLine($"\tConfidence: '{field.Confidence}'");
                Console.WriteLine($"\tExpected Type: '{field.ExpectedFieldType}'");
                Console.WriteLine($"\tType: '{field.FieldType}'");

                // check to see if it is a list, tables seem to be considered as lists.
                // https://learn.microsoft.com/en-us/dotnet/api/Azure.AI.FormRecognizer.DocumentAnalysis.DocumentFieldType?view=azure-dotnet&viewFallbackFrom=netstandard-2.0
                if (field.FieldType == DocumentFieldType.List)
                {
                    foreach (var listField in field.Value.AsList())
                    {
                        /* Check if it is a dictionary(key value pair).
                         * Since it comes from a list (maybe table?), the key would be the column
                         * and the value would be the cell value.
                         */
                        if (listField.FieldType == DocumentFieldType.Dictionary)
                        {
                            foreach (var documentField in listField.Value.AsDictionary())
                            {
                                Console.WriteLine($"\tField '{documentField.Key}'");

                                Console.WriteLine($"\t\tContent: '{documentField.Value.Content}'");
                                Console.WriteLine($"\t\tConfidence: '{documentField.Value.Confidence}'");
                                Console.WriteLine($"\t\tExpected Type: '{documentField.Value.ExpectedFieldType}'");
                                Console.WriteLine($"\t\tType: '{documentField.Value.FieldType}'");
                            }
                        }
                    }
                }
            }
        }

        // Console.WriteLine("== Iterating over EVERY line and selection marks on each page ==");
        // foreach (DocumentPage page in result.Pages)
        // {
        //     Console.WriteLine($"Lines found on page {page.PageNumber}");
        //     foreach (var line in page.Lines)
        //     {
        //         Console.WriteLine($"  {line.Content}");
        //     }
        //
        //     Console.WriteLine($"Selection marks found on page {page.PageNumber}");
        //     foreach (var selectionMark in page.SelectionMarks)
        //     {
        //         Console.WriteLine(
        //             $"  Selection mark is '{selectionMark.State}' with confidence {selectionMark.Confidence}");
        //     }
        // }
        //
        // Console.WriteLine("== Iterating over the Document Tables ==");
        // for (int i = 0; i < result.Tables.Count; i++)
        // {
        //     Console.WriteLine($"Table {i + 1}, {result.Tables[i]}");
        //     foreach (var cell in result.Tables[i].Cells)
        //     {
        //         Console.WriteLine(
        //             $"  Cell[{cell.RowIndex}][{cell.ColumnIndex}] has content '{cell.Content}' with kind '{cell.Kind}'");
        //     }
        // }
    }

    public async Task AnalyzeDocumentFromStream(string filePath)
    {
        await using var stream = new FileStream(filePath, FileMode.Truncate);

        AnalyzeDocumentOperation operation =
            await _analysisClient.AnalyzeDocumentAsync(WaitUntil.Completed, ModelId, stream);
        AnalyzeResult result = operation.Value;

        Console.WriteLine($"Document was analyzed with model with ID: {result.ModelId}");

        foreach (AnalyzedDocument document in result.Documents)
        {
            Console.WriteLine($"Document of type: {document.DocumentType}");

            foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
            {
                string fieldName = fieldKvp.Key;
                DocumentField field = fieldKvp.Value;

                Console.WriteLine($"Field '{fieldName}': ");

                Console.WriteLine($"  Content: '{field.Content}'");
                Console.WriteLine($"  Confidence: '{field.Confidence}'");
            }
        }
    }
}