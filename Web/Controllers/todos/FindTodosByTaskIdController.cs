using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/todos/task/{id}")]
  [ApiController]
  public class FindTodosByTaskIdController : ControllerBase
  {
    [HttpGet]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Find Todos By Task Id Controller " + id);
    }
  }
}
