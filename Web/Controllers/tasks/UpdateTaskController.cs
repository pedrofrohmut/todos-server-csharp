using System;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/tasks/{taskId}")]
  [ApiController]
  public class UpdateTaskController : ControllerBase
  {
    private readonly UpdateTaskUseCase useCase;

    public UpdateTaskController(UpdateTaskUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpPut]
    public async System.Threading.Tasks.Task<ActionResult> index(
        [FromRoute] string taskId,
        [FromBody] RequestBody requestBody)
    {
      try {
        Task updatedTask = new Task
        {
          Id = taskId,
          Name = requestBody.Name
        };
        await this.useCase.UpdateTask(updatedTask);
        return NoContent();
      } catch (ArgumentNullException e) {
        return BadRequest(e.Message);
      } catch (TaskNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }

    public class RequestBody
    {
      public string Name { get; set; }
    }
  }
}
