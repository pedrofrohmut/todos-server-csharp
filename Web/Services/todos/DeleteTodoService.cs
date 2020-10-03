using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;

namespace TodoServer.Web.Services
{
  public class DeleteTodoService
  {
    private readonly AppDbContext context;

    public DeleteTodoService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task Execute(string todoId)
    {
      var todoToDelete = await this.context.Todos.FirstOrDefaultAsync(todo => todo.Id == todoId);
      if (todoToDelete != null) {
        this.context.Todos.Remove(todoToDelete);
        await this.context.SaveChangesAsync();
      }
    }
  }
}
