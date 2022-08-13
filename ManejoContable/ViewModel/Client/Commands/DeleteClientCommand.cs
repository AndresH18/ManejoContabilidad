using System;
using System.Diagnostics;
using System.Windows.Input;
using ModelEntities;

namespace ManejoContable.ViewModel.Client.Commands;

public class DeleteClientCommand<T> : ICommand
{
    private readonly IBaseViewModel<T> _clientViewModel;

    public DeleteClientCommand(IBaseViewModel<T> clientViewModel)
    {
        _clientViewModel = clientViewModel;
    }

    public bool CanExecute(object? parameter)
    {
        Debug.WriteLine($"{GetType().Name}: was called. parameter-type={parameter?.GetType()}");
        return parameter is T;
    }

    public void Execute(object? parameter)
    {
        _clientViewModel.Delete((T) parameter!);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}