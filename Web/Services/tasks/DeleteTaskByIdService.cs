using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;

namespace TodoServer.Web.Services
{
  public class DeleteTaskByIdService
  {
    private readonly AppDbContext context;

    public DeleteTaskByIdService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task Execute(string taskId)
    {
      var taskToDelete = await this.context.Tasks.FirstOrDefaultAsync(task => task.Id == taskId);
      if (taskToDelete != null) {
        this.context.Tasks.Remove(taskToDelete);
        await this.context.SaveChangesAsync();
      }
    }
  }
}
