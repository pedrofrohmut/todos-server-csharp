using System;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class CreateTodoUseCase
  {
    private readonly FindTaskByIdService findTaskByIdService;
    private readonly CreateTodoService createTodoService;

    public CreateTodoUseCase(
        FindTaskByIdService findTaskByIdService,
        CreateTodoService createTodoService)
    {
      this.findTaskByIdService = findTaskByIdService;
      this.createTodoService = createTodoService;
    }

    public async System.Threading.Tasks.Task CreateTodo(Todo todo)
    {
      if (string.IsNullOrWhiteSpace(todo.Name)) {
        throw new ArgumentNullException("Todo name is Required");
      }
      if (string.IsNullOrWhiteSpace(todo.Description)) {
        throw new ArgumentNullException("Todo description is Required");
      }
      Task task = await this.findTaskByIdService.Execute(todo.TaskId);
      if (task == null) {
        throw new TaskNotFoundByIdException(
            "Task not found with the passed taskId. Todo could not be created");
      }
      Todo newTodo = new Todo
      {
        Name = todo.Name,
        Description = todo.Description,
        IsComplete = false,
        TaskId = todo.TaskId
      };
      await this.createTodoService.Execute(newTodo);
    }
  }
}
