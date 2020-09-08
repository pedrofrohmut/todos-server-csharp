using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/tasks/{id}")]
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
