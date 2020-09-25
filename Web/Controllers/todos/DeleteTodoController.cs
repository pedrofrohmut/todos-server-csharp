using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Web.Controllers
{
  [Route("api/v1/private/todos/{id}")]
  [ApiController]
  public class DeleteTodoController : ControllerBase
  {
    [HttpDelete]
    public ActionResult Index([FromRoute] string id)
    {
      return Ok("Delete Todo Controller " + id);
    }
  }
}
