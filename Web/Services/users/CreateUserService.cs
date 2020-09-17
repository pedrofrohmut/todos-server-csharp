using System;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Services
{
  public class CreateUserService
  {
    private readonly AppDbContext context;

    public CreateUserService(AppDbContext context)
    {
      this.context = context;
    }

    public async System.Threading.Tasks.Task Execute(User newUser)
    {
      // You have to assign the Id manually AspNetCore 3.0 Breaking Change
      newUser.Id = Guid.NewGuid().ToString();
      await this.context.AddAsync(newUser);
      await this.context.SaveChangesAsync();
    }
  }
}
