using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class FindUserByIdService
  {
    private readonly AppDbContext context;

    public FindUserByIdService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task<User> Execute(string userId) =>
      await this.context.Users.FirstOrDefaultAsync(user => user.Id == userId);
  }
}
