using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/tasks/{taskId}")]
  [ApiController]
  public class FindTaskByIdController : ControllerBase
  {
    private readonly FindTaskByIdUseCase useCase;

    public FindTaskByIdController(FindTaskByIdUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpGet]
    public async System.Threading.Tasks.Task<ActionResult> Index([FromRoute] string taskId)
    {
      try {
        var task = await this.useCase.FindTaskById(taskId);
        return Ok(new {
          httpStatus = 200,
          action = "FindTaskByIdController [GET]",
          message = "Task found",
          data = task
        });
      } catch (TaskNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
