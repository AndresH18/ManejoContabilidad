using ManejoContabilidad.Wpf.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public interface IInvoiceService
{
    Task<ServiceResult<List<Shared.Models.Invoice>>> GetAllAsync(int page);

    Task<ServiceResult<Shared.Models.Invoice>> AddAsync(Shared.Models.Invoice invoice);

    Task<ServiceResult<Shared.Models.Invoice>> EditAsync(Shared.Models.Invoice invoice);

    Task<ServiceResult<Shared.Models.Invoice>> DeleteAsync(Shared.Models.Invoice invoice);
}