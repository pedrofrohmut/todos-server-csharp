using System.Collections.Generic;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class FindTasksByUserIdUseCase
  {
    private readonly FindUserByIdService findUserByIdService;
    private readonly FindTasksByUserIdService findTasksByUserIdService;

    public FindTasksByUserIdUseCase(
        FindUserByIdService findUserByIdService,
        FindTasksByUserIdService findTasksByUserIdService)
    {
      this.findUserByIdService = findUserByIdService;
      this.findTasksByUserIdService = findTasksByUserIdService;
    }

    public async System.Threading.Tasks.Task<IEnumerable<Task>> GetTasksByUserId(string userId)
    {
      User user = await this.findUserByIdService.Execute(userId);
      if (user == null) {
        throw new UserNotFoundByIdException(
            "No user found with the passed id. Tasks could not be recovered");
      }
      var tasks = await this.findTasksByUserIdService.Execute(userId);
      return tasks;
    }
  }
}
