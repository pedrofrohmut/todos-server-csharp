using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class FindTaskByIdService
  {
    private readonly AppDbContext context;

    public FindTaskByIdService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task<Task> Execute(string taskId) =>
      await this.context.Tasks.FirstOrDefaultAsync(task => task.Id == taskId);
  }
}
