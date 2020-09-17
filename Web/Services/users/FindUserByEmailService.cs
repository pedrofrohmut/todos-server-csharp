using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class FindUserByEmailService
  {
    private readonly AppDbContext context;

    public FindUserByEmailService(AppDbContext context)
    {
      this.context = context;
    }

    public async Task<User> Execute(string email) => 
      await this.context.Users.FirstOrDefaultAsync(user => user.Email == email);
  }
}
