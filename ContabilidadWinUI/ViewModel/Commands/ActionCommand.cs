using ContabilidadWinUI.Services;
using System;
using System.Windows.Input;

namespace ContabilidadWinUI.ViewModel.Commands;

public class ActionCommand : ICommand
{
    public Func<object?, bool>? CanExecuteFunc { get; init; }
    public Action? ActionToExecute { get; init; }


    public bool CanExecute(object? parameter)
    {
        // return parameter is FacturaDto;
        return CanExecuteFunc?.Invoke(parameter) ?? false;
    }

    public void Execute(object? parameter)
    {
        ActionToExecute?.Invoke();
    }

    public event EventHandler? CanExecuteChanged;
}