using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class FindTasksByUserIdService
  {
    private readonly AppDbContext context;

    public FindTasksByUserIdService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task<IEnumerable<Task>> Execute(string userId) =>
      await this.context.Tasks
              .Where(task => task.UserId == userId)
              .ToListAsync();
  }
}
