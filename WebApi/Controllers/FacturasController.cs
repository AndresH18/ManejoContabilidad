using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class FacturasController : Controller
{
    private IFacturaRepository _repository;

    public FacturasController(IFacturaRepository repository)
    {
        _repository = repository;
    }

    // GET 
    [HttpGet]
    public ActionResult<List<Factura>> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Factura?> Get(int id)
    {
        var factura = _repository.GetById(id);
        if (factura == null)
            return NotFound();

        return Ok(factura);
    }

    // POST
    [HttpPost]
    public ActionResult Create(Factura factura)
    {
        _repository.Create(factura);
        return CreatedAtAction(nameof(Create), new {factura.Id}, factura);
    }

    // PUT
    [HttpPut("{id}")]
    public ActionResult Update(int id, Factura factura)
    {
        if (id != factura.Id)
            return BadRequest();

        var existingFactura = _repository.GetById(id);
        if (existingFactura == null)
            return NotFound();

        _repository.Update(existingFactura);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var factura = _repository.GetById(id);
        if (factura == null)
            return NotFound();

        _repository.Delete(id);
        return NotFound();
    }
}