using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class FindAllUsersService
  {
    private readonly AppDbContext context;

    public FindAllUsersService(AppDbContext context)
    {
      this.context = context;
    }

    public async Task<List<User>> Execute() => await this.context.Users.ToListAsync();
  }
}
