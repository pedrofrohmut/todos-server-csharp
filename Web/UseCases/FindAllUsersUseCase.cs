using System.Collections.Generic;
using System.Threading.Tasks;
using TodoServer.Web.Entities;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class FindAllUsersUseCase
  {
    private readonly FindAllUsersService findAllUsersService;

    public FindAllUsersUseCase(FindAllUsersService findAllUsersService)
    {
      this.findAllUsersService = findAllUsersService;
    }

    public async Task<IEnumerable<User>> FindAllUsers()
    {
      List<User> users = await this.findAllUsersService.Execute();
      return users;
    }
  }
}
