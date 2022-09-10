using AutoMapper;
using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;
using WebApi.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public abstract class AbstractController<TRepo, TModel, TGet> : Controller
    where TRepo : IRepository<TModel>
    where TModel : class, IModel
    where TGet : GetModelRecord
{
    protected TRepo Repo;
    protected IMapper Mapper;

    protected AbstractController(TRepo repo, IMapper mapper)
    {
        Repo = repo;
        Mapper = mapper;
    }

    // GET
    [HttpGet]
    public ActionResult<List<TGet>> GetAll()
    {
        return Ok(Mapper.Map<IEnumerable<TGet>>(Repo.GetAll()));
        // return Repo.GetAll();
    }

    [HttpGet("{id:int}")]
    public ActionResult<TGet?> Get(int id)
    {
        var model = Repo.GetById(id);
        if (model == null)
            return NotFound();

        return Ok(Mapper.Map<TGet>(model));
    }

    // POST
    [HttpPost]
    public ActionResult Create(TModel model)
    {
        Repo.Create(model);
        return CreatedAtAction(nameof(Create), new {model.Id}, model);
    }

    // PUT
    [HttpPut("{id:int}")]
    public ActionResult Update(int id, TModel model)
    {
        if (id != model.Id)
            return BadRequest();

        var existingModel = Repo.GetById(id);
        if (existingModel == null)
            return NotFound();

        Repo.Update(model);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var model = Repo.GetById(id);
        if (model == null)
            return NotFound();

        Repo.Delete(id);
        return NoContent();
    }
}