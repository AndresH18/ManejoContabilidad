using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;

namespace ConsoleApp1.Recognizer;

internal class RecognizerService
{
    private readonly DocumentAnalysisClient _analysisClient;
    private readonly string _modelId;

    public RecognizerService(RecognizerConfiguration configuration)
    {
        _modelId = configuration.ModelId;

        var credentials = new AzureKeyCredential(configuration.ApiKey);

        _analysisClient = new DocumentAnalysisClient(configuration.EndpointUri, credentials);
    }

    internal async Task<string> Get(Stream fileStream, string fieldName)
    {
        AnalyzeDocumentOperation operation =
            await _analysisClient.AnalyzeDocumentAsync(WaitUntil.Completed, _modelId, fileStream);

        AnalyzeResult result = operation.Value;

        return result.Documents[0].Fields[fieldName].Content;
    }

    internal async Task GetTable(Stream fileStream, string tableName = "products-details")
    {
        AnalyzeDocumentOperation operation =
            await _analysisClient.AnalyzeDocumentAsync(WaitUntil.Completed, _modelId, fileStream);

        AnalyzeResult result = operation.Value;

        foreach (var analyzedDocument in result.Documents)
        {
            var tableField = analyzedDocument.Fields[tableName];
            if (tableField?.FieldType == DocumentFieldType.List)
            {
                foreach (var tableRow in tableField.Value.AsList())
                {
                    if (tableRow.FieldType == DocumentFieldType.Dictionary)
                    {
                        Console.WriteLine("Table row:");
                        foreach (var documentField in tableRow.Value.AsDictionary())
                        {
                            Console.WriteLine($"\tField '{documentField.Key}'");

                            Console.WriteLine($"\t\tContent: '{documentField.Value.Content}'");
                            Console.WriteLine($"\t\tConfidence: '{documentField.Value.Confidence}'");
                            Console.WriteLine($"\t\tExpected Type: '{documentField.Value.ExpectedFieldType}'");
                            Console.WriteLine($"\t\tType: '{documentField.Value.FieldType}'");
                            // double.Parse(documentField.Value.Content, new System.Globalization.CultureInfo("es-CO")) // this parse 8,00 to 8 instead of 800
                        }
                    }
                }
            }
        }
    }
}