using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/{id}/iscomplete")]
  [ApiController]
  public class SetTodoAsCompleteController : ControllerBase
  {
    [HttpPatch]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Set Todo As Complete Controller " + id);
    }
  }
}
