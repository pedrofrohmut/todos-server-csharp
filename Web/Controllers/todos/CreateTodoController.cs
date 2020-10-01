using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/task/{taskId}")]
  [ApiController]
  public class CreateTodoController : ControllerBase
  {
    private readonly CreateTodoUseCase useCase;

    public CreateTodoController(CreateTodoUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpPost]
    public async Task<ActionResult> index(
        [FromRoute] string taskId, 
        [FromBody] RequestBody requestBody)
    {
      try {
        Todo todo = new Todo
        {
          Name = requestBody.Name,
          Description = requestBody.Description,
          TaskId = taskId
        };
        await this.useCase.CreateTodo(todo);
        // Empty string to satisfy method signature
        return Created("", new {
          httpStatus = 201,
          action = "CreateTodoController [POST]",
          message = "Todo created"
        });
      } catch (TaskNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }

    public class RequestBody 
    {
      public string Name { get; set; }
      public string Description { get; set; }
    }
  }
}
