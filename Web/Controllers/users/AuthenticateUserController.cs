using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/users/authenticate")]
  [ApiController]
  public class AuthenticateUserController : ControllerBase
  {
    [HttpGet]
    public ActionResult Index()
    {
      return Ok("Authenticate User Controller");
    }
  }
}
