using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/tasks/{taskId}")]
  [ApiController]
  public class DeleteTaskController : ControllerBase
  {
    private readonly DeleteTaskUseCase useCase;

    public DeleteTaskController(DeleteTaskUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpDelete]
    public async System.Threading.Tasks.Task<ActionResult> Index([FromRoute] string taskId)
    {
      try {
        await this.useCase.DeleteTaskById(taskId);
        return NoContent();
      } catch(TaskNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
