using TodoServer.Web.Services;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using System;

namespace TodoServer.Web.UseCases
{
  public class UpdateTaskUseCase
  {
    private readonly FindTaskByIdService findTaskByIdService;
    private readonly UpdateTaskService updateTaskService;

    public UpdateTaskUseCase(
        FindTaskByIdService findTaskByIdService,
        UpdateTaskService updateTaskService)
    {
      this.findTaskByIdService = findTaskByIdService;
      this.updateTaskService = updateTaskService;
    }

    public async System.Threading.Tasks.Task UpdateTask(Task updatedTask)
    {
      if (string.IsNullOrWhiteSpace(updatedTask.Id)) {
        throw new ArgumentNullException(
            "The TaskId is Required to update a task");
      }
      if (string.IsNullOrWhiteSpace(updatedTask.Name)) {
        throw new ArgumentNullException(
            "The Name is Required to update a task");
      }
      var oldTask = await this.findTaskByIdService.Execute(updatedTask.Id);
      if (oldTask == null) {
        throw new TaskNotFoundByIdException(
            "Task not found with the passed id. Task could not be updated");
      }
      await this.updateTaskService.Execute(oldTask, updatedTask);
    }
  }
}
