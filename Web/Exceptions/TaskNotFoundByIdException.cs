using System;

namespace TodoServer.Web.Exceptions
{
  public class TaskNotFoundByIdException : Exception
  {
    public TaskNotFoundByIdException() { }

    public TaskNotFoundByIdException(string message) 
      : base(message) { }

    public TaskNotFoundByIdException(string message, Exception inner) 
      : base (message, inner) { }
  }
}
