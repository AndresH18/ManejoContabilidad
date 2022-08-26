using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ManejoContable.ViewModel.Commands;

public class DeleteCommand<T> : ICommand
{
    private readonly IBaseViewModel<T> _viewModel;

    public DeleteCommand(IBaseViewModel<T> viewModel)
    {
        _viewModel = viewModel;
    }

    public bool CanExecute(object? parameter)
    {
        Debug.WriteLine($"{GetType().Name}: was called. parameter-type={parameter?.GetType()}");

        return parameter is T;
    }

    public void Execute(object? parameter)
    {
        _viewModel.Delete((T)parameter!);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}