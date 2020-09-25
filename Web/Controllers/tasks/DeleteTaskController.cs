using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/tasks/{id}")]
  [ApiController]
  public class DeleteTaskController : ControllerBase
  {
    [HttpDelete]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Delete Task Controller " + id);
    }
  }
}
