using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/{todoId}")]
  [ApiController]
  public class FindTodoByIdController : ControllerBase
  {
    private readonly FindTodoByIdUseCase useCase;

    public FindTodoByIdController(FindTodoByIdUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpGet]
    public async Task<ActionResult> Index([FromRoute] string todoId)
    {
      try {
        var todo = await this.useCase.FindTodo(todoId);
        return Ok(new {
          httpStatus = 200,
          action = "FindTodoByIdController [GET]",
          message = "Todo found",
          data = todo
        });
      } catch (TodoNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
