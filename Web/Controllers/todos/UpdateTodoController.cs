using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/todos/{id}")]
  [ApiController]
  public class UpdateTodoController : ControllerBase
  {
    [HttpPut]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Update Todo Controller " + id);
    }
  }
}
