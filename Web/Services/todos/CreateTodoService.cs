using System;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class CreateTodoService
  {
    private readonly AppDbContext context;

    public  CreateTodoService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task Execute(Todo newTodo)
    {
      newTodo.Id = Guid.NewGuid().ToString();
      await this.context.AddAsync(newTodo);
      await this.context.SaveChangesAsync();
    }
  }
}
