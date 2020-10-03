using System;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class SetTodoAsNotCompleteUseCase
  {
    private readonly FindTodoByIdService findTodoByIdService;
    private readonly SetTodoAsNotCompleteService setTodoAsNotCompleteService;

    public SetTodoAsNotCompleteUseCase(
        FindTodoByIdService findTodoByIdService,
        SetTodoAsNotCompleteService setTodoAsNotCompleteService)
    {
      this.findTodoByIdService = findTodoByIdService;
      this.setTodoAsNotCompleteService = setTodoAsNotCompleteService;
    }

    public async System.Threading.Tasks.Task SetTodoAsNotComplete(string todoId)
    {
      if (string.IsNullOrWhiteSpace(todoId)) {
        throw new ArgumentNullException("TodoId is Required");
      }
      var todo = await this.findTodoByIdService.Execute(todoId);
      if (todo == null) {
        throw new TodoNotFoundByIdException(
            "Todo not found with the passed id. Todo could not be set as not complete");
      }
      await this.setTodoAsNotCompleteService.Execute(todoId);
    }
  }
}
