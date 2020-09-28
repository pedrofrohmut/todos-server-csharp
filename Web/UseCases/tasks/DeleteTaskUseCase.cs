using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class DeleteTaskUseCase
  {
    private readonly FindTaskByIdService findTaskByIdService;
    private readonly DeleteTaskByIdService deleteTaskByIdService;

    public DeleteTaskUseCase(
        FindTaskByIdService findTaskByIdService,
        DeleteTaskByIdService deleteTaskByIdService)
    {
      this.findTaskByIdService = findTaskByIdService;
      this.deleteTaskByIdService = deleteTaskByIdService;
    }

    public async System.Threading.Tasks.Task DeleteTaskById(string taskId)
    {
      var taskToDelete = await this.findTaskByIdService.Execute(taskId);
      if (taskToDelete == null) {
        throw new TaskNotFoundByIdException(
            "Task not found with the passed id. Task could not be removed");
      }
      await this.deleteTaskByIdService.Execute(taskId);
    }
  }
}
