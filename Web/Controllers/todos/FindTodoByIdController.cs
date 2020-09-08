using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/todos/{id}")]
  [ApiController]
  public class FindTodoByIdController : ControllerBase
  {
    [HttpGet]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Find Todo By Id Controller " + id);
    }
  }
}
