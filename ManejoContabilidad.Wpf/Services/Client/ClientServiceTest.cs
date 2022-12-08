using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ManejoContabilidad.Wpf.Services.Client;

public class ClientServiceTest : IClientService
{
    public async Task<List<Shared.Models.Client>> GetAllAsync()
    {
        await Task.Run(() => Thread.Sleep(2000));
        await using var db = new TestDbContext();
        return await db.Clients.ToListAsync();
    }

    public async Task<Shared.Models.Client?> AddAsync(Shared.Models.Client client)
    {
        await Task.Run(() => Thread.Sleep(2000));
        await using var db = new TestDbContext();
        await db.Clients.AddAsync(client);
        await db.SaveChangesAsync();

        return client;
    }

    public async Task<Shared.Models.Client?> EditAsync(Shared.Models.Client client)
    {
        await Task.Run(() => Thread.Sleep(2000));
        await using var db = new TestDbContext();
        // testing how ""update"" or ""db.Entry(client).CurrentValues.SetValues(..);"" works
        var old = await db.Clients.FirstAsync(c => c.Id == client.Id);

        db.Entry(old).CurrentValues.SetValues(client);

        await db.SaveChangesAsync();

        return client;
    }

    public async Task<Shared.Models.Client?> DeleteAsync(Shared.Models.Client client)
    {
        await Task.Run(() => Thread.Sleep(2000));

        await using var db = new TestDbContext();

        db.Clients.Remove(client);
        await db.SaveChangesAsync();

        return client;
    }
}