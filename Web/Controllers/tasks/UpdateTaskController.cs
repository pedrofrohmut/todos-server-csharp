using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/tasks/{id}")]
  [ApiController]
  public class UpdateTaskController : ControllerBase
  {
    [HttpPut]
    public ActionResult index([FromRoute] string id)
    {
      return Ok("Update Task Controller " + id);
    }
  }
}
