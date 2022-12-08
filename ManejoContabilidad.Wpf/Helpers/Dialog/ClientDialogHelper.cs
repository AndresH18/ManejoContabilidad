using System.Windows;
using ManejoContabilidad.Wpf.Views.Client;
using Shared.Models;

namespace ManejoContabilidad.Wpf.Helpers.Dialog;

public class ClientDialogHelper : IDialogHelper<Client>
{
    public void Show(Client client)
    {
        var dialog = new ClientWindow(client, isReadOnly: true);
        dialog.ShowDialog();
    }

    public Client? Add()
    {
        var dialog = new ClientWindow(new Client(), isReadOnly: false);
        var dialogResult = dialog.ShowDialog();

        return dialogResult == true
            ? dialog.Client
            : null;
    }

    public Client? Edit(Client client)
    {
        var dialog = new ClientWindow(client);
        var dialogResult = dialog.ShowDialog();

        return dialogResult == true
            ? dialog.Client
            : null;
    }

    public bool Delete(Client client)
    {
        var result = MessageBox.Show($"Eliminar {client.Name}?",
            "Borrar Cliente", MessageBoxButton.YesNo);

        return result == MessageBoxResult.Yes;
    }
}