using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;

namespace TodoServer.Web.Services
{
  public class ClearCompleteTodosByTaskIdService
  {
    private readonly AppDbContext context;

    public ClearCompleteTodosByTaskIdService(AppDbContext context) 
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task Execute(string taskId)
    {
      var completeTodos = await this.context.Todos
        .Where(todo => todo.TaskId == taskId && todo.IsComplete)
        .ToListAsync();
      this.context.RemoveRange(completeTodos);
      await this.context.SaveChangesAsync();
    }
  }
}
