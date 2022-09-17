using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public interface IController<T>
{
    ActionResult<List<T>> GetAll();
    ActionResult<T?> Get(int id);
    ActionResult Update(int id, T t);
    ActionResult Delete(int id);
}