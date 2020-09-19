using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.UseCases;
using TodosServer.Web.Exceptions;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/users/login")]
  [ApiController]
  public class LoginUserController : ControllerBase
  {
    private readonly LoginUserUseCase useCase;

    public LoginUserController(LoginUserUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpPost]
    public async Task<ActionResult> Index([FromBody] RequestBody requestBody)
    {
      try {
        var signedInUser = 
          await this.useCase.GetSignedInUser(requestBody.Email, requestBody.Password);
        return Ok(new { 
            httpStatus = 200,
            action = "LoginUserController [POST]", 
            message = "User logged in", 
            data = signedInUser 
        });
      } catch (UserNotFoundByEmailException e) {
        return NotFound(e.Message);
      } catch (UserPasswordMismatchException e) {
        return BadRequest(e.Message);
      }
    }

    public class RequestBody
    {
      public string Email { get; set; }
      public string Password { get; set; }
    }
  }
}
