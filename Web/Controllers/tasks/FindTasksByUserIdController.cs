using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/tasks/user/{userId}")]
  [ApiController]
  public class FindTasksByUserIdController : ControllerBase
  {
    private readonly FindTasksByUserIdUseCase useCase;

    public FindTasksByUserIdController(FindTasksByUserIdUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpGet]
    public async Task<ActionResult> Index([FromRoute] string userId)
    {
      try {
        var tasks = await this.useCase.GetTasksByUserId(userId);
        return Ok(new {
          httpStatus = 200,
          action = "FindTaskByUserIdController [GET]",
          message = "Tasks found by user id",
          data = tasks
        });
      } catch (UserNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
