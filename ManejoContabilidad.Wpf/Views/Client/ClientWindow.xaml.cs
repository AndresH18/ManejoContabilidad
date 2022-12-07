using System;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Models = Shared.Models;

namespace ManejoContabilidad.Wpf.Views.Client;

public partial class ClientWindow : Window
{
    public bool IsReadOnly { get; }
    public Visibility IsConfirmVisible => IsReadOnly ? Visibility.Collapsed : Visibility.Visible;
    public Models::Client Client { get; }

    public ClientWindow(Models::Client client, bool isReadOnly = false)
    {
        Client = client;
        IsReadOnly = isReadOnly;

        InitializeComponent();
    }

    [RelayCommand]
    private void Confirm()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private void Cancel()
    {
        throw new NotImplementedException();
    }
}