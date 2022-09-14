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
        // try
        // {
        var t = (T) parameter!;
        _viewModel.Show(t);
        // }
        // catch (Exception ex)
        // {
        //     Debug.WriteLine(ex);
        //     throw;
        // }
    }

    public event EventHandler? CanExecuteChanged;
//     {
//         add => CommandManager.RequerySuggested += value;
//         remove => CommandManager.RequerySuggested -= value;
//     }
}