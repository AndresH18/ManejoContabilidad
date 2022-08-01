﻿using System;
using System.Diagnostics;
using System.Windows.Input;
using ModelEntities;

namespace ManejoContable.ViewModel.Client.Commands;

public class AddClientCommand : ICommand
{
    private readonly ClientsViewModel _clientViewModel;

    public AddClientCommand(ClientsViewModel clientViewModel)
    {
        _clientViewModel = clientViewModel;
    }

    public bool CanExecute(object? parameter)
    {
        Debug.WriteLine($"{GetType().Name}: was called. parameter-type={parameter?.GetType()}");
        // return parameter is Cliente;
        return true;
    }

    public void Execute(object? parameter)
    {
        _clientViewModel.AddClient();
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}