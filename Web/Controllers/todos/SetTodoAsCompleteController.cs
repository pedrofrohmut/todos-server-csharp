using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/{todoId}/iscomplete")]
  [ApiController]
  public class SetTodoAsCompleteController : ControllerBase
  {
    private readonly SetTodoAsCompleteUseCase useCase;

    public SetTodoAsCompleteController(SetTodoAsCompleteUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpPatch]
    public async Task<ActionResult> Index([FromRoute] string todoId)
    {
      try {
        await this.useCase.SetTodoAsComplete(todoId);
        return Ok(new {
          httpStatus = 200,
          action = "SetTodoAsCompleteController [PATCH]",
          message = "Todo set as complete"
        });
      } catch (ArgumentNullException e) {
        return BadRequest(e.Message);
      } catch (TodoNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
