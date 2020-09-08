using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/tasks/user/{id}")]
  [ApiController]
  public class FindTaskByUserIdController : ControllerBase
  {
    [HttpGet]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Find Task By User Id Controller " + id);
    }
  }
}
