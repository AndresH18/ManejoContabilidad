using System.Collections.Generic;

namespace ContabilidadWinUI.Services.JsonModels;

internal class ApiHelper
{
    public List<Api> Apis { get; set; } = new();
}

internal class Api
{
    public string Name { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty;
}