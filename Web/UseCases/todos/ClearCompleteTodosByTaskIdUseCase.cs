using System;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class ClearCompleteTodosByTaskIdUseCase
  {
    private readonly FindTaskByIdService findTaskByIdService;
    private readonly ClearCompleteTodosByTaskIdService clearCompleteTodosByTaskIdService;

    public ClearCompleteTodosByTaskIdUseCase(
        FindTaskByIdService findTaskByIdService,
        ClearCompleteTodosByTaskIdService clearCompleteTodosByTaskIdService)
    {
      this.findTaskByIdService = findTaskByIdService;
      this.clearCompleteTodosByTaskIdService = clearCompleteTodosByTaskIdService;
    }

    public async System.Threading.Tasks.Task ClearCompleteTodos(string taskId)
    {
      if (string.IsNullOrWhiteSpace(taskId)) {
        throw new ArgumentNullException("TaskId is Required");
      }
      var task = await this.findTaskByIdService.Execute(taskId);
      if (task == null) {
        throw new TaskNotFoundByIdException(
            "Task not found with the passed id. Complete todos from task could not be cleared");
      }
      await this.clearCompleteTodosByTaskIdService.Execute(taskId);
    }
  }
}
