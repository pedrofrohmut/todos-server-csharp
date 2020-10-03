using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/clearcomplete/task/{taskId}")]
  [ApiController]
  public class ClearCompleteTodosByTaskIdController : ControllerBase
  {
    private readonly ClearCompleteTodosByTaskIdUseCase useCase;

    public ClearCompleteTodosByTaskIdController(ClearCompleteTodosByTaskIdUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpDelete]
    public async Task<ActionResult> Index([FromRoute] string taskId)
    {
      try {
        await this.useCase.ClearCompleteTodos(taskId);
        return Ok(new {
          httpStatus = 200,
          action = "ClearCompleteTodosByTaskIdController [DELETE]",
          message = "Complete todos cleared"
        });
      } catch (ArgumentNullException e) {
        return BadRequest(e.Message);
      } catch (TaskNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
