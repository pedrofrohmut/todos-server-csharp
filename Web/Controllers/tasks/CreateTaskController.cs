using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/tasks/user/{id}")]
  [ApiController]
  public class CreateTaskController : ControllerBase
  {
    [HttpPost]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Create Task Controller " + id);
    }
  }
}
