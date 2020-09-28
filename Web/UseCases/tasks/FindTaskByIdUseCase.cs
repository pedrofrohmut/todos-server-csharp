using TodoServer.Web.Services;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;

namespace TodoServer.Web.UseCases
{
  public class FindTaskByIdUseCase
  {
    private readonly FindTaskByIdService findTaskByIdService;

    public FindTaskByIdUseCase(FindTaskByIdService findTaskByIdService)
    {
      this.findTaskByIdService = findTaskByIdService;
    }

    public async System.Threading.Tasks.Task<Task> FindTaskById(string taskId)
    {
      var task = await this.findTaskByIdService.Execute(taskId);
      if (task == null) {
        throw new TaskNotFoundByIdException("Task not found with the passed id");
      }
      return task;
    }
  }
}
