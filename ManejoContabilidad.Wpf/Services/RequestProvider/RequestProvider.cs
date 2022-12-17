using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManejoContabilidad.Wpf.Services.AppEnvironment;

namespace ManejoContabilidad.Wpf.Services.RequestProvider;

internal class RequestProvider : IRequestProvider
{
    private readonly AppEnvironmentService _appEnvironment;

    public RequestProvider(AppEnvironmentService appEnvironment)
    {
        _appEnvironment = appEnvironment;
    }
}