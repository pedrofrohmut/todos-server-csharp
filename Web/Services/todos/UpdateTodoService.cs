using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class UpdateTodoService
  {
    private readonly AppDbContext context;

    public UpdateTodoService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task Execute(Todo oldTodo, Todo updatedTodo)
    {
      var currentTodo = await this.context.Todos.FirstOrDefaultAsync(todo => todo.Id == oldTodo.Id);
      if (currentTodo != null) {
        currentTodo.Name = updatedTodo.Name;
        currentTodo.Description = updatedTodo.Description;
        await this.context.SaveChangesAsync();
      }
    }
  }
}
