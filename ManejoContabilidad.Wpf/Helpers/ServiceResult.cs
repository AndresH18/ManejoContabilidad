namespace ManejoContabilidad.Wpf.Helpers;

public class ServiceResult<T>
{
    public ResultStatus Status { get; set; }
    public T? Value { get; set; }
}

public enum ResultStatus
{
    Ok,
    Failed
}