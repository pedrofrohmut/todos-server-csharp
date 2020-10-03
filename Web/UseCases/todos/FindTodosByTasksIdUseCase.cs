using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class FindTodosByTaskIdUseCase
  {
    private readonly FindTaskByIdService findTaskByIdService;
    private readonly FindTodosByTaskIdService findTodosByTaskIdService;

    public FindTodosByTaskIdUseCase(
        FindTaskByIdService findTaskByIdService,
        FindTodosByTaskIdService findTodosByTaskIdService)
    {
      this.findTaskByIdService = findTaskByIdService;
      this.findTodosByTaskIdService = findTodosByTaskIdService;
    }

    public async Task<IEnumerable<Todo>> FindTodos(string taskId)
    {
      if (string.IsNullOrWhiteSpace(taskId)) {
        throw new ArgumentNullException("TaskId is Required");
      }
      var task = await this.findTaskByIdService.Execute(taskId);
      if (task == null) {
        throw new TaskNotFoundByIdException(
            "No task found with the passed id. Todos could not be retrived");
      }
      var todos = await this.findTodosByTaskIdService.Execute(taskId);
      return todos;
    }
  }
}
