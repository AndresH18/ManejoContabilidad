using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class DetallesFacturaController : Controller
{
    private readonly IDetallesFacturaRepository _repository;

    public DetallesFacturaController(IDetallesFacturaRepository repository)
    {
        _repository = repository;
    }

    // GET
    [HttpGet]
    public ActionResult<List<DetallesFactura>> GetAll() => _repository.GetAll().ToList();

    [HttpGet("factura/{facturaId}/producto_factura/{productoFacturaId}")]
    public ActionResult<DetallesFactura?> Get(int facturaId, int productoFacturaId)
    {
        var df = _repository.GetById(facturaId, productoFacturaId);
        if (df == null)
            NotFound();

        return Ok(df);
    }

    // POST
    [HttpPost]
    public ActionResult Create(DetallesFactura detallesFactura)
    {
        _repository.Create(detallesFactura);
        return CreatedAtAction(nameof(Create), new {detallesFactura.FacturaId, detallesFactura.ProductoFacturaId},
            detallesFactura);
    }

    // PUT
    [HttpPut("factura/{facturaId}/producto_factura/{productoFacturaId}")]
    public ActionResult Update(int facturaId, int productoFacturaId, DetallesFactura detallesFactura)
    {
        if (facturaId != detallesFactura.FacturaId || productoFacturaId != detallesFactura.ProductoFacturaId)
            return BadRequest();
    
        var df = _repository.GetById(facturaId, productoFacturaId);
        if (df == null)
            return NotFound();
    
        _repository.Update(detallesFactura);
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("factura/{facturaId}/producto_factura/{productoFacturaId}")]
    public ActionResult Delete(int facturaId, int productoFacturaId, DetallesFactura detallesFactura)
    {
        var df = _repository.GetById(facturaId, productoFacturaId);
        if (df == null)
            return NotFound();
    
        _repository.Delete(facturaId, productoFacturaId);
        return NoContent();
    }
}