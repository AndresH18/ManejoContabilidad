using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ManejoContabilidad.Wpf.Services.Client;

public class ClientService : IClientService
{
    private readonly List<Shared.Models.Client> _clients;

    public ClientService()
    {
        _clients = new List<Shared.Models.Client>
        {
            new() {Id = 1, Name = "Andres", Document = "1", Email = "andres@email.com"},
            new() {Id = 2, Name = "David", Document = "2", Email = "david@email.com"}
        };
    }

    public async Task<List<Shared.Models.Client>> GetAllAsync()
    {
        await Task.Run(() => Thread.Sleep(2000));

        return new List<Shared.Models.Client>(_clients);
    }

    public async Task<Shared.Models.Client?> AddAsync(Shared.Models.Client client)
    {
        await Task.Run(() => Thread.Sleep(2000));
        _clients.Add(client);
        client.Id = _clients.Count;

        return client;
    }

    public async Task<Shared.Models.Client?> EditAsync(Shared.Models.Client client)
    {
        await Task.Run(() => Thread.Sleep(2000));
        var index = _clients.FindIndex(c => c.Id == client.Id);
        if (index >= 0)
            _clients[index] = client;

        return client;
    }

    public async Task<Shared.Models.Client?> DeleteAsync(Shared.Models.Client client)
    {
        await Task.Run(() => Thread.Sleep(2000));
        
        return _clients.Remove(client) ? client : null;
    }
}