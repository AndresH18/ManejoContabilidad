using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class ClientesRepository : Controller
{
    private IClienteRepository _repository;

    public ClientesRepository()
    {
        _repository = new ClienteRepository();
    }

    public ClientesRepository(IClienteRepository repository)
    {
        _repository = repository;
    }

    // GET
    [HttpGet]
    public ActionResult<List<Cliente>> GetAll() => _repository.GetAll().ToList();

    [HttpGet("{id}")]
    public ActionResult<Cliente> Get(int id)
    {
        var cliente = _repository.GetById(id);
        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }

    // POST
    [HttpPost]
    public ActionResult Create(Cliente cliente)
    {
        _repository.Create(cliente);
        return CreatedAtAction(nameof(Create), new { cliente.Id }, cliente);
    }

    // PUT
    [HttpPut("{id}")]
    public ActionResult Update(int id, Cliente cliente)
    {
        if (id != cliente.Id)
            return BadRequest();

        var existingCliente = _repository.GetById(id);
        if (existingCliente == null)
            return NotFound();

        _repository.Update(existingCliente);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var cliente = _repository.GetById(id);
        if (cliente == null)
            return NotFound();

        _repository.Delete(id);
        return NoContent();
    }
}