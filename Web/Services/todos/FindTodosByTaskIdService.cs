using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class FindTodosByTaskIdService
  {
    private readonly AppDbContext context;

    public FindTodosByTaskIdService(AppDbContext context)
    {
      this.context = context;
    }

    public async Task<IEnumerable<Todo>> Execute(string taskId) =>
      await this.context.Todos
        .Where(todo => todo.TaskId == taskId)
        .ToListAsync();
  }
}
