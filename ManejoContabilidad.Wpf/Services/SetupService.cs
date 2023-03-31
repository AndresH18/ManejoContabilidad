using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Shared;

namespace ManejoContabilidad.Wpf.Services;

internal class SetupService
{
    private readonly IConfiguration _configuration;
    public bool HasErrors { get; private set; }

    public SetupService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Action<string>? MessageAction;

    public void VerifySetup()
    {
        var cs = _configuration.GetConnectionString(InvoiceDb.DefaultConnection);
        if (cs == null)
        {
            SendMessage($@"Connection string ""{InvoiceDb.DefaultConnection}"" was not found");
        }
    }

    private void SendMessage(string message)
    {
        MessageAction?.Invoke(message);
    }
}