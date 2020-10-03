using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/{todoId}/isnotcomplete")]
  [ApiController]
  public class SetTodoAsNotCompleteController : ControllerBase
  {
    private readonly SetTodoAsNotCompleteUseCase useCase;

    public SetTodoAsNotCompleteController(SetTodoAsNotCompleteUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpPatch]
    public async Task<ActionResult> Index([FromRoute] string todoId)
    {
      try {
        await this.useCase.SetTodoAsNotComplete(todoId);
        return Ok(new {
          httpStatus = 200,
          action = "SetTodoAsNotCompleteController [PATCH]",
          message = "Todo set as not complete"
        });
      } catch (ArgumentNullException e) {
        return BadRequest(e.Message);
      } catch (TodoNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
