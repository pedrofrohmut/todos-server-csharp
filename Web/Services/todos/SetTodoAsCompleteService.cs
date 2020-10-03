using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;

namespace TodoServer.Web.Services
{
  public class SetTodoAsCompleteService
  {
    private readonly AppDbContext context;

    public SetTodoAsCompleteService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task Execute(string todoId)
    {
      var todoToSet = await this.context.Todos.FirstOrDefaultAsync(todo => todo.Id == todoId);
      if (todoToSet != null) {
        todoToSet.IsComplete = true;
        await this.context.SaveChangesAsync();
      }
    }
  }
}
