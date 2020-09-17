using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/users")]
  [ApiController]
  public class CreateUserController : ControllerBase
  {
    private readonly CreateUserUseCase useCase;

    public CreateUserController(CreateUserUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Index([FromBody] RequestBody  requestBody)
    {
      try {
        User user = new User
        {
          FirstName = requestBody.FirstName,
          LastName = requestBody.LastName,
          Email = requestBody.Email,
          Password = requestBody.Password
        };
        await this.useCase.CreateUser(user);
        return StatusCode(201);
      } catch (ArgumentException e) {
        return BadRequest( new {
          errorMessage = "[BadRequest] Invalid user information: " + e.Message
        });
      } catch (EmailAlreadyTakenException e) {
        return BadRequest(new {
          errorMessage = "[Bad Request] Email already taken: " + e.Message
        });
      }
    }


    public class RequestBody
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
    }
  }
}
