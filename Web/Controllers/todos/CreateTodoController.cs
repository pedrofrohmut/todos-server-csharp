using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/todos/task/{id}")]
  [ApiController]
  public class CreateTodoController : ControllerBase
  {
    [HttpPost]
    public ActionResult index([FromRoute] string id)
    {
      return Ok("Create Todo Controller");
    }
  }
}
