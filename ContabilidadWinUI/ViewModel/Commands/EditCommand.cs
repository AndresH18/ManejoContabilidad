using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ContabilidadWinUI.ViewModel.Commands;

public class EditCommand<T> : ICommand
{
    private readonly IBaseViewModel<T> _viewModel;

    public EditCommand(IBaseViewModel<T> viewModel)
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
        _viewModel.Edit((T)parameter!);
    }

    public event EventHandler? CanExecuteChanged;
//     {
//         add => CommandManager.RequerySuggested += value;
//         remove => CommandManager.RequerySuggested -= value;
//     }
}