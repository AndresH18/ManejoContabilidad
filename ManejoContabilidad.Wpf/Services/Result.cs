using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ManejoContabilidad.Wpf.Services;

public readonly struct Result<TValue, TError>
{
    private readonly TValue? _value;
    private readonly TError? _error;

    private Result(TValue value)
    {
        IsError = false;
        _value = value;
        _error = default;
    }

    private Result(TError error)
    {
        IsError = true;
        _error = error;
        _value = default;
    }

    public bool IsError { get; }
    
    public bool IsSuccess => !IsError;

    public TValue? Value => _value;

    public TError? Error => _error;

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);

    public static implicit operator Result<TValue, TError>(TError error) => new(error);

    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<TError, TResult> error
    ) => !IsError ? success(_value!) : error(_error!);
}