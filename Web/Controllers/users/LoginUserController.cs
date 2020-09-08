using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/users/login")]
  [ApiController]
  public class LoginUserController : ControllerBase
  {
    [HttpPost]
    public ActionResult Index()
    {
      return Ok("Log in User Controller");
    }
  }
}
