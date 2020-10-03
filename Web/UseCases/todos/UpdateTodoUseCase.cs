using System;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class UpdateTodoUseCase
  {
    private readonly FindTodoByIdService findTodoByIdService;
    private readonly UpdateTodoService updateTodoService;

    public UpdateTodoUseCase(
        FindTodoByIdService findTodoByIdService,
        UpdateTodoService updateTodoService)
    {
      this.findTodoByIdService = findTodoByIdService;
      this.updateTodoService = updateTodoService;
    }

    public async System.Threading.Tasks.Task UpdateTodo(Todo updatedTodo)
    {
      if (string.IsNullOrWhiteSpace(updatedTodo.Id)) {
        throw new ArgumentNullException("TodoId is Required");
      }
      if (string.IsNullOrWhiteSpace(updatedTodo.Name)) {
        throw new ArgumentNullException("Todo name is Required");
      }
      if (string.IsNullOrWhiteSpace(updatedTodo.Description)) {
        throw new ArgumentNullException("Todo description is Required");
      }
      var oldTodo = await this.findTodoByIdService.Execute(updatedTodo.Id);
      if (oldTodo == null) {
        throw new TodoNotFoundByIdException(
            "Todo not found with the passed id. Todo could not be updated");
      }
      await this.updateTodoService.Execute(oldTodo, updatedTodo);
    }
  }
}
