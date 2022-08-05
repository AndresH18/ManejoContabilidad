using System.Windows;
using ManejoContable.View.Windows.Client;
using ModelEntities;

namespace ManejoContable.ViewModel.Client;

public interface IClientDialogService
{
    public void OpenClientInformationDialog(Cliente cliente);
    public bool DeleteClientDialog(Cliente cliente);
    public bool UpdateClientDialog(Cliente client);
    public bool AddClientDialog();
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

        return false;
    }

    public bool UpdateClientDialog(Cliente client)
    {
        // TODO: Implement Edit Client Information. modify.
        // System.Media.SystemSounds.Asterisk.Play();
        // System.Media.SystemSounds.Hand.Play();
        // System.Media.SystemSounds.Beep.Play();
        // System.Media.SystemSounds.Question.Play();


        var dialogResult = new EditClientWindow(client)
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = false,
            ResizeMode = ResizeMode.NoResize
        }.ShowDialog();

        return dialogResult == true;
    }

    public bool AddClientDialog()
    {
        var dialogResult = new AddClientWindow()
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = false,
            ResizeMode = ResizeMode.NoResize,
        }.ShowDialog();

        return dialogResult == true;
    }
}