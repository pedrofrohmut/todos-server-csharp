using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class FindTodoByIdService
  {
    private readonly AppDbContext context;

    public FindTodoByIdService(AppDbContext context)
    {
      this.context = context;
    }

    public async Task<Todo> Execute(string todoId) =>
      await this.context.Todos
        .Include(todo => todo.Task)
        .Include(todo => todo.Task.User)
        .FirstOrDefaultAsync(todo => todo.Id == todoId);
  }
}
