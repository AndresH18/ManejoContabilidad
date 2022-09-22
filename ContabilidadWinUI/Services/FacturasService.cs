using System;
using System.Collections.Generic;
using System.Linq;
using DbContextLibrary;
using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace ContabilidadWinUI.Services;

public interface IFacturasService
{
    IEnumerable<FacturaDto> GetAllFacturas();
}

public class FacturasService : IFacturasService
{
    private readonly ContabilidadDbContext _db;

    public FacturasService(ContabilidadDbContext db)
    {
        _db = db;
    }

    public IEnumerable<FacturaDto> GetAllFacturas()
    {
        var s = _db.Facturas.Include(f => f.Cliente).Include(f => f.InfoFactura).ToList();

        return (from entry in s
            select new FacturaDto(entry.Id, entry.InfoFactura!.NumeroFactura, entry.ClienteId, entry.Cliente!.Nombre,
                entry.Cliente.NumeroDocumento)).ToList();
    }
}

public class FacturaDto
{
    public int Id { get; set; }
    public string? NumeroFactura { get; set; }
    public int ClienteId { get; set; }
    public string NombreCliente { get; set; }
    public string DocumentoCliente { get; set; }

    public FacturaDto(int id, string? numeroFactura, int clienteId, string nombreCliente, string documentoCliente)
    {
        Id = id;
        NumeroFactura = numeroFactura;
        ClienteId = clienteId;
        NombreCliente = nombreCliente;
        DocumentoCliente = documentoCliente;
    }

    /// <summary>
    /// <p>Calls to this method will throw <see cref="NotImplementedException"/></p>
    /// </summary>
    /// <param name="o"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void CopyFrom(object o)
    {
        throw new NotImplementedException();
    }
}