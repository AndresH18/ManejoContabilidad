using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// ReSharper disable MemberCanBePrivate.Global

namespace ConsoleApp1.Recognizer;

public record RecognizerConfiguration(string ApiKey, string Endpoint, string ModelId)
{
    public Uri EndpointUri => new(Endpoint);
}

// public record RecognizerConfiguration
// {
//     public string ApiKey { get; init; } = string.Empty;
//     public string Endpoint { get; init; } = string.Empty;
//     public string ModelId { get; init; } = string.Empty;
//     public Uri EndpointUri => new("https://www.google.com");
//
//     public override string ToString()
//     {
//         return $"{nameof(ApiKey)}: {ApiKey}, {nameof(Endpoint)}: {Endpoint}, {nameof(ModelId)}: {ModelId}, {nameof(EndpointUri)}: {EndpointUri}";
//     }
// }
// internal class RecognizerConfiguration
// {
//     public string ApiKey { get; set; } = string.Empty;
//     public string Endpoint { get; set; } = string.Empty;
//     public string ModelId { get; set; } = string.Empty;
//
//     public Uri EndpointUri => new Uri(Endpoint);
// }