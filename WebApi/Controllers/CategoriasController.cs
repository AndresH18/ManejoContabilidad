using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class CategoriasController : Controller
{
    private ICategoriaRepository _repository;

    public CategoriasController()
    {
        _repository = new CategoriaRepository();
    }

    public CategoriasController(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    // GET
    [HttpGet]
    public ActionResult<List<Categoria>> GetAll() => _repository.GetAll().ToList();

    [HttpGet("{id}")]
    public ActionResult<Categoria?> Get(int id)
    {
        var categoria = _repository.GetById(id);
        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    // POST
    [HttpPost]
    public ActionResult Create(Categoria categoria)
    {
        _repository.Create(categoria);
        return CreatedAtAction(nameof(Create), new { categoria.Id }, categoria);
    }

    // PUT
    [HttpPut("{id}")]
    public ActionResult Update(int id, Categoria categoria)
    {
        if (id != categoria.Id)
            return BadRequest();


        var exisitingCategoria = _repository.GetById(id);
        if (exisitingCategoria == null)
            return NotFound();

        _repository.Update(exisitingCategoria);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var categoria = _repository.GetById(id);
        if (categoria == null)
            return NotFound();

        _repository.Delete(id);
        return NoContent();
    }
}