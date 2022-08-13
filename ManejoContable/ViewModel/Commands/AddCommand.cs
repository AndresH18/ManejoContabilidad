using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ManejoContable.ViewModel.Commands;

public class AddCommand<T> : ICommand
{
    private readonly IBaseViewModel<T> _viewModel;

    public AddCommand(IBaseViewModel<T> viewModel)
    {
        _viewModel = viewModel;
    }

    public bool CanExecute(object? parameter)
    {
        Debug.WriteLine($"{GetType().Name}: was called. parameter-type={parameter?.GetType()}");
        // return parameter is Cliente;
        return true;
    }

    public void Execute(object? parameter)
    {
        _viewModel.Add();
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}