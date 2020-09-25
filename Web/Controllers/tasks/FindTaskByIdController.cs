using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/tasks/{id}")]
  [ApiController]
  public class FindTaskByIdController : ControllerBase
  {
    [HttpGet]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Find Task By Id  " + id);
    }
  }
}
