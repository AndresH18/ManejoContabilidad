using System;
using System.Windows.Input;

namespace ManejoContable.ViewModel.Client.Commands;

public class FilterClientCommand : ICommand
{
    private readonly ClientsViewModel _viewModel;

    public FilterClientCommand(ClientsViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public bool CanExecute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public void Execute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}