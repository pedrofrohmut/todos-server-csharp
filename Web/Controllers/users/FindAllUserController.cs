using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Entities;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/users")]
  [ApiController]
  public class FindAllUsersController : ControllerBase
  {
    private readonly FindAllUsersUseCase useCase;

    public FindAllUsersController(FindAllUsersUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpGet]
    public async System.Threading.Tasks.Task<ActionResult> Index()
    {
      IEnumerable<User> allUsers = await this.useCase.FindAllUsers();
      return Ok(new {
        httpStatus = 200,
        action = "FindAllUsersController [GET]",
        message = "All Users found",
        data = allUsers
      });
    }
  }
}
