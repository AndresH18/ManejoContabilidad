using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public abstract class AbstractController<TRepo, TModel> : Controller
    where TRepo : IRepository<TModel> 
    where TModel : class, IModel
{
    protected TRepo _repo;

    protected AbstractController(TRepo repo)
    {
        _repo = repo;
    }

    // GET
    [HttpGet]
    public ActionResult<List<TModel>> GetAll()
    {
        return _repo.GetAll().ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<TModel?> Get(int id)
    {
        var model = _repo.GetById(id);
        if (model == null)
            return NotFound();

        return Ok(model);
    }

    // POST
    [HttpPost]
    public ActionResult Create(TModel model)
    {
        _repo.Create(model);
        return CreatedAtAction(nameof(Create), new {model.Id}, model);
    }

    // PUT
    [HttpPut("{id}")]
    public ActionResult Update(int id, TModel model)
    {
        if (id != model.Id)
            return BadRequest();

        var existingModel = _repo.GetById(id);
        if (existingModel == null)
            return NotFound();

        _repo.Update(model);
        return NotFound();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var model = _repo.GetById(id);
        if (model == null)
            return NotFound();

        _repo.Delete(id);
        return NoContent();
    }
}