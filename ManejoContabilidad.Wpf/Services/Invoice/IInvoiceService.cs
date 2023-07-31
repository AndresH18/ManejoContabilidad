using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public interface IInvoiceService
{
    Task<Result<List<Shared.Models.Invoice>, Exception>> GetAllAsync(int page);

    Task<Result<Shared.Models.Invoice, Exception>> AddAsync(Shared.Models.Invoice invoice);

    Task<Result<Shared.Models.Invoice, Exception>> EditAsync(Shared.Models.Invoice invoice);

    Task<Result<Shared.Models.Invoice, Exception>> DeleteAsync(Shared.Models.Invoice invoice);
}