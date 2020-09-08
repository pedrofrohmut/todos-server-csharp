using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/todos/{id}/isnotcomplete")]
  [ApiController]
  public class SetTodoAsNotCompleteController : ControllerBase
  {
    [HttpPatch]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Set Todo As NOT Complete Controller " + id);
    }
  }
}
