using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;

namespace TodoServer.Web.Services
{
  public class SetTodoAsNotCompleteService
  {
    private readonly AppDbContext context;

    public SetTodoAsNotCompleteService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task Execute(string todoId)
    {
      var todo = await this.context.Todos.FirstOrDefaultAsync(todo => todo.Id == todoId);
      if (todo != null) {
        todo.IsComplete = false;
        await this.context.SaveChangesAsync();
      }
    }
  }
}
