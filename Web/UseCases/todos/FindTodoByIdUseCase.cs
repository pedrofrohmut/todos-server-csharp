using System;
using System.Threading.Tasks;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class FindTodoByIdUseCase
  {
    private readonly FindTodoByIdService findTodoByIdService;

    public FindTodoByIdUseCase(FindTodoByIdService findTodoByIdService)
    {
      this.findTodoByIdService = findTodoByIdService;
    }

    public async Task<Todo> FindTodo(string todoId)
    {
      if (string.IsNullOrWhiteSpace(todoId)) {
        throw new ArgumentNullException("TodoId is Required");
      }
      var todo = await this.findTodoByIdService.Execute(todoId);
      if (todo == null) {
        throw new TodoNotFoundByIdException(
            "Todo not found with the passed id. Todo could not be recovered");
      }
      return todo;
    }
  }
}
