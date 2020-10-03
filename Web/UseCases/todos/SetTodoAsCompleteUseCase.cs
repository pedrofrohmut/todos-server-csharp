using System;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class SetTodoAsCompleteUseCase
  {
    private readonly FindTodoByIdService findTodoByIdService;
    private readonly SetTodoAsCompleteService setTodoAsCompleteService;

    public SetTodoAsCompleteUseCase(
        FindTodoByIdService findTodoByIdService,
        SetTodoAsCompleteService setTodoAsCompleteService)
    {
      this.findTodoByIdService = findTodoByIdService;
      this.setTodoAsCompleteService = setTodoAsCompleteService;
    }

    public async System.Threading.Tasks.Task SetTodoAsComplete(string todoId)
    {
      if (string.IsNullOrWhiteSpace(todoId)) {
        throw new ArgumentNullException("TodoId is Required");
      }
      var todo = await this.findTodoByIdService.Execute(todoId);
      if (todo == null) {
        throw new TodoNotFoundByIdException(
            "Todo not found with the passed id. Todo could not be set as complete");
      }
      await this.setTodoAsCompleteService.Execute(todoId);
    }
  }
}
