using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public interface IInvoiceService
{
    Task<List<Shared.Models.Invoice>> GetAllAsync();

    Task<Shared.Models.Invoice?> AddAsync(Shared.Models.Invoice invoice);

    Task<Shared.Models.Invoice?> EditAsync(Shared.Models.Invoice invoice);

    Task<Shared.Models.Invoice?> DeleteAsync(Shared.Models.Invoice invoice);
}