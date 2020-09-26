using System;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class CreateTaskService
  {
    private readonly AppDbContext context;

    public CreateTaskService(AppDbContext context)
    {
      this.context = context;
    }
    
    public async System.Threading.Tasks.Task Execute(Task newTask)
    {
      newTask.Id = Guid.NewGuid().ToString();
      await this.context.AddAsync(newTask);
      await this.context.SaveChangesAsync();
    }
  }
}
