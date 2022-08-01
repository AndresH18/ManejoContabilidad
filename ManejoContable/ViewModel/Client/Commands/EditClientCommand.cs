using System;
using System.Diagnostics;
using System.Windows.Input;
using ModelEntities;

namespace ManejoContable.ViewModel.Client.Commands;

public class EditClientCommand : ICommand
{
    private readonly ClientsViewModel _clientViewModel;

    public EditClientCommand(ClientsViewModel clientViewModel)
    {
        _clientViewModel = clientViewModel;
    }

    public bool CanExecute(object? parameter)
    {
        Debug.WriteLine($"{GetType().Name}: was called. parameter-type={parameter?.GetType()}");
        return parameter is Cliente;
    }

    public void Execute(object? parameter)
    {
        _clientViewModel.EditClient((Cliente)parameter!);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}