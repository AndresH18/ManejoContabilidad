using System;
using System.Windows;
using ManejoContable.View.Windows.Client;
using ModelEntities;

namespace ManejoContable.ViewModel.Client;

public interface IClientDialogService
{
    public void OpenClientInformationDialog(Cliente cliente);
    public bool DeleteClientDialog(Cliente cliente);
    public Cliente? UpdateClientDialog(Cliente client);
    public Cliente? AddClientDialog();
}

public class ClientClientDialogService : IClientDialogService
{
    public void OpenClientInformationDialog(Cliente cliente)
    {
        var dialogResult = new ViewClientWindow(cliente)
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = false,
            ResizeMode = ResizeMode.NoResize,
        }.ShowDialog();
    }

    public bool DeleteClientDialog(Cliente cliente)
    {
        // TODO: Implement DeleteClient . use new Window, or use the dialog result
        var result = MessageBox.Show("Implement Delete", "Borrar Cliente?",
            MessageBoxButton.OKCancel,
            MessageBoxImage.Question, MessageBoxResult.Cancel);
        if (result == MessageBoxResult.OK)
        {
            // delete client
        }
        else
        {
            // Nothing 
        }

        return true;
    }

    public Cliente? UpdateClientDialog(Cliente client)
    {
        // System.Media.SystemSounds.Asterisk.Play();
        // System.Media.SystemSounds.Hand.Play();
        // System.Media.SystemSounds.Beep.Play();
        // System.Media.SystemSounds.Question.Play();

        var dialog = new EditClientWindow(client)
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = false,
            ResizeMode = ResizeMode.NoResize
        };
        var dialogResult = dialog.ShowDialog();

        // return dialogResult == true ? dialog.NewValue : dialog.OldValue;
        return dialogResult == true ? dialog.NewValue : default;
    }

    public Cliente? AddClientDialog()
    {
        var window = EditClientWindow.CreateAddClientDialogWindow();

        var result = window.ShowDialog();

        return result == true ? window.NewValue : default;
    }

    private Cliente dd()
    {
        Cliente c;

        H(out c);

        return c;
    }

    private void H(out Cliente c)
    {
        c = new Cliente();
    }
}