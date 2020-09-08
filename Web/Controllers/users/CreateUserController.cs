using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/users")]
  [ApiController]
  public class CreateUserController : ControllerBase
  {
    [HttpPost]
    public ActionResult Index()
    {
      return Ok("Create User Controller");
    }
  }
}
