using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class UpdateTaskService
  {
    private readonly AppDbContext context;

    public UpdateTaskService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task Execute(Task oldTask, Task updatedTask)
    {
      var currentTask = await this.context.Tasks.FirstOrDefaultAsync(task => task.Id == oldTask.Id);
      if (currentTask != null) {
        currentTask.Name = updatedTask.Name;
        await this.context.SaveChangesAsync();
      }
    }
  }
}
