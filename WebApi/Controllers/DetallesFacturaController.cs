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

    [HttpGet("factura/{facturaId}/producto_factura/{productoId}")]
    public ActionResult<DetallesFactura?> Get(int facturaId, int productoId)
    {
        var df = _repository.GetById(facturaId, productoId);
        if (df == null)
            NotFound();

        return Ok(df);
    }

    // POST
    [HttpPost]
    public ActionResult Create(DetallesFactura detallesFactura)
    {
        _repository.Create(detallesFactura);
        return CreatedAtAction(nameof(Create), new {detallesFactura.FacturaId, detallesFactura.ProductoId},
            detallesFactura);
    }

    // PUT
    [HttpPut("factura/{facturaId}/producto_factura/{productoId}")]
    public ActionResult Update(int facturaId, int productoId, DetallesFactura detallesFactura)
    {
        if (facturaId != detallesFactura.FacturaId || productoId != detallesFactura.ProductoId)
            return BadRequest();
    
        var df = _repository.GetById(facturaId, productoId);
        if (df == null)
            return NotFound();
    
        _repository.Update(detallesFactura);
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("factura/{facturaId}/producto_factura/{productoId}")]
    public ActionResult Delete(int facturaId, int productoId, DetallesFactura detallesFactura)
    {
        var df = _repository.GetById(facturaId, productoId);
        if (df == null)
            return NotFound();
    
        _repository.Delete(facturaId, productoId);
        return NoContent();
    }
}