using ManejoContabilidad.Wpf.Views.Client;
using Shared.Models;

namespace ManejoContabilidad.Wpf.Services.Dialog;

public class ClientDialogService : IDialogService<Client>
{
    public void Show(Client client)
    {
        var dialog = new ClientWindow(client, isReadOnly: true);
        dialog.Show();
        
    }

    public Client Add(Client client)
    {
        throw new System.NotImplementedException();
    }

    public Client Edit(Client client)
    {
        throw new System.NotImplementedException();
    }

    public void Delete(Client client)
    {
        throw new System.NotImplementedException();
    }
}