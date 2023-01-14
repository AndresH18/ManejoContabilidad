using System;

namespace ManejoContabilidad.Wpf.Services;

public class ServiceResult
{
    public ResultStatus Status { get; set; }
    public string? ErrorMessage { get; set; }
}

public class ServiceResult<T> : ServiceResult 
{
    public T? Value { get; set; }
}

public enum ResultStatus
{
    Ok,
    Failed
}