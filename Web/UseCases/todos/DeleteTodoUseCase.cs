using System;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class DeleteTodoUseCase
  {
    private readonly FindTodoByIdService findTodoByIdService;
    private readonly DeleteTodoService deleteTodoService;

    public DeleteTodoUseCase(
        FindTodoByIdService findTodoByIdService,
        DeleteTodoService deleteTodoService)
    {
      this.findTodoByIdService = findTodoByIdService;
      this.deleteTodoService = deleteTodoService;
    }

    public async System.Threading.Tasks.Task DeleteTodo(string todoId)
    {
      if (string.IsNullOrWhiteSpace(todoId)) {
        throw new ArgumentNullException("TodoId is Required");
      }
      var todo = await this.findTodoByIdService.Execute(todoId);
      if (todo == null) {
        throw new TodoNotFoundByIdException(
            "Todo not found with the passed id. Todo could not be deleted");
      }
      await this.deleteTodoService.Execute(todoId);
    }
  }
}
