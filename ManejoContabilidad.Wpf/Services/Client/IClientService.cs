using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoContabilidad.Wpf.Services.Client;

public interface IClientService
{
    Task<List<Shared.Models.Client>> GetAllAsync();

    Task<Shared.Models.Client?> AddAsync(Shared.Models.Client client);

    Task<Shared.Models.Client?> EditAsync(Shared.Models.Client client);

    Task<Shared.Models.Client?> DeleteAsync(Shared.Models.Client client);
}