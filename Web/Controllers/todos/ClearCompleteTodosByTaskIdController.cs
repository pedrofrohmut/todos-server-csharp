using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/todos/clearcomplete/task/{id}")]
  [ApiController]
  public class ClearCompleteTodosByTaskIdController : ControllerBase
  {
    [HttpDelete]
    public ActionResult index([FromRoute] string id)
    {
      return Ok("Clear Complete Todos By Task Id " + id);
    }
  }
}
