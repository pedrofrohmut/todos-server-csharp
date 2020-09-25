using System.Threading.Tasks;
using JWT.Exceptions;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/users/authenticate")]
  [ApiController]
  public class AuthenticateUserController : ControllerBase
  {
    private readonly AuthenticateUserUseCase useCase;

    public AuthenticateUserController(AuthenticateUserUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
      try {
        var token = Request.Headers["x-auth-token"];
        var signedInUser = await this.useCase.AuthenticateUserByToken(token);
        return Ok(new {
          httpStatus = 200,
          action = "AuthenticateUserController [GET]",
          message = "User Authenticated",
          data = signedInUser
        });
      } catch (MissingRequestAuthTokenException e) {
        return BadRequest(e.Message);
      } catch (TokenExpiredException e) {
        return BadRequest(e.Message);
      } catch (InvalidRequestAuthTokenException e) {
        return BadRequest(e.Message);
      } catch (UserNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
