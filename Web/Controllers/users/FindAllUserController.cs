using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controlllers
{
  [Route("api/v1/users")]
  [ApiController]
  public class FindAllUsersController : ControllerBase
  {
    [HttpGet]
    public ActionResult Index()
    {
      return Ok("Find All Users Controller");
    }
  }
}
