using System;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class CreateTaskUseCase
  {
    private readonly FindUserByIdService findUserByIdService;
    private readonly CreateTaskService createTaskService;

    public CreateTaskUseCase(
        FindUserByIdService findUserByIdService,
        CreateTaskService createTaskService)
    {
      this.findUserByIdService = findUserByIdService;
      this.createTaskService = createTaskService;
    }

    public async System.Threading.Tasks.Task CreateTask(Task task)
    {
      // Validate Task Fields
      if (string.IsNullOrWhiteSpace(task.Name)) {
        throw new ArgumentNullException("Task name is Required");
      }
      // Check if user exists
      User user = await this.findUserByIdService.Execute(task.UserId);
      if (user == null) {
        throw new UserNotFoundByIdException("User not found with the passed userId");
      }
      Task newTask = new Task
      {
        Name = task.Name,
        UserId = task.UserId
      };
      await this.createTaskService.Execute(newTask);
    }
  }
}
