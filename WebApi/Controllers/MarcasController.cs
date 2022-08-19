using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class MarcasController : Controller
{
    private IMarcaRepository _repository;

    public MarcasController()
    {
        _repository = new MarcaRepository();
    }

    public MarcasController(IMarcaRepository repository)
    {
        _repository = repository;
    }

    // GET
    [HttpGet]
    public ActionResult<List<Marca>> GetAll() => _repository.GetAll().ToList();

    [HttpGet("{id}")]
    public ActionResult<Marca> Get(int id)
    {
        var marca = _repository.GetById(id);
        if (marca == null)
            return NotFound();

        return Ok(marca);
    }

    // POST
    [HttpPost]
    public ActionResult Create(Marca marca)
    {
        _repository.Create(marca);
        return CreatedAtAction(nameof(Create), new { marca.Id }, marca);
    }

    // PUT
    [HttpPut("{id}")]
    public ActionResult Update(int id, Marca marca)
    {
        if (id != marca.Id)
            return BadRequest();

        var existingMarca = _repository.GetById(marca.Id);
        if (existingMarca == null)
            return NotFound();

        _repository.Update(marca);

        return NoContent();
    }

    // DELETE   
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingMarca = _repository.GetById(id);
        if (existingMarca == null)
        {
            return NotFound();
        }

        _repository.Delete(id);
        return NoContent();
    }
}