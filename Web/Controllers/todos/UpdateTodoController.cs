using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/{todoId}")]
  [ApiController]
  public class UpdateTodoController : ControllerBase
  {
    private readonly UpdateTodoUseCase useCase;

    public UpdateTodoController(UpdateTodoUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpPut]
    public async Task<ActionResult> Index(
        [FromRoute] string todoId,
        [FromBody] RequestBody requestBody)
    {
      try {
        var todo = new Todo
        {
          Id = todoId,
          Name = requestBody.Name,
          Description = requestBody.Description
        };
        await this.useCase.UpdateTodo(todo);
        return Ok(new {
          httpStatus = 200,
          action = "UpdateTodoController [PUT]",
          message = "Todo updated"
        });
      } catch (ArgumentNullException e) {
        return BadRequest(e.Message);
      } catch (TodoNotFoundByIdException e) {
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
