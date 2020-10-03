using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/{todoId}")]
  [ApiController]
  public class DeleteTodoController : ControllerBase
  {
    private readonly DeleteTodoUseCase useCase;

    public DeleteTodoController(DeleteTodoUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpDelete]
    public async Task<ActionResult> Index([FromRoute] string todoId)
    {
      try {
        await this.useCase.DeleteTodo(todoId);
        return Ok(new {
          httpStatus = 200,
          action = "DeleteTodoController [DELETE]",
          message = "Todo deleted"
        });
      } catch (ArgumentNullException e) {
        return BadRequest(e.Message);
      } catch (TodoNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
