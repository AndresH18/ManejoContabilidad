using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Models = Shared.Models;

namespace ManejoContabilidad.Wpf.Views.Client;

public partial class ClientWindow : Window
{
    public bool IsReadOnly { get; }
    public Visibility IsConfirmVisible => IsReadOnly ? Visibility.Collapsed : Visibility.Visible;
    public Models::Client Client { get; private set; }

    public ClientWindow(Models::Client client, bool isReadOnly = false)
    {
        Client = client;
        IsReadOnly = isReadOnly;

        InitializeComponent();

        Owner = App.Current.MainWindow;
    }

    [RelayCommand]
    private void Confirm()
    {
        var name = NameTextBox.Text;
        var document = DocumentTextBox.Text;
        var email = EmailTextBox.Text;
        var phone = PhoneTextBox.Text;

        Client = new Models.Client
        {
            Name = name, Document = document,
            Email = email, Phone = phone
        };

        DialogResult = true;
    }

    [RelayCommand]
    private void Cancel()
    {
        DialogResult = false;
    }
}