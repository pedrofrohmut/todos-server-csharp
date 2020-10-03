using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/task/{taskId}")]
  [ApiController]
  public class FindTodosByTaskIdController : ControllerBase
  {
    private readonly FindTodosByTaskIdUseCase useCase;

    public FindTodosByTaskIdController(FindTodosByTaskIdUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpGet]
    public async Task<ActionResult> Index([FromRoute] string taskId)
    {
      try {
        var todos = await this.useCase.FindTodos(taskId);
        return Ok(new {
          httpStatus = 200,
          action = "FindTodosByTaskIdController [GET]",
          message = "Todos found",
          data = todos
        });
      } catch (ArgumentNullException e) {
        return BadRequest(e.Message);
      } catch (TaskNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }
  }
}
