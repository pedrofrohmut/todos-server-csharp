using Microsoft.AspNetCore.Mvc;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/tasks/user/{userId}")]
  [ApiController]
  public class CreateTaskController : ControllerBase
  {
    private readonly CreateTaskUseCase useCase;

    public CreateTaskController(CreateTaskUseCase useCase)
    {
      this.useCase = useCase;
    }

    [HttpPost]
    public async System.Threading.Tasks.Task<ActionResult> Index(
        [FromRoute] string userId, 
        [FromBody] RequestBody requestBody)
    {
      try {
        Task task = new Task
        {
          Name = requestBody.Name,
          UserId = userId
        };
        await this.useCase.CreateTask(task);
        // Empty string to satisfy method signature
        return Created("", new {
          httpStatus = 201,
          action = "CreateTaskController [POST]",
          message = "Task created"
        });
      } catch (UserNotFoundByIdException e) {
        return BadRequest(e.Message);
      }
    }

    public class RequestBody
    {
      public string Name { get; set; }
    }
  }
}
