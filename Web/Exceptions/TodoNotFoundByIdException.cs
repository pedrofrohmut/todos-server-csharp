using System;

namespace TodoServer.Web.Exceptions
{
  public class TodoNotFoundByIdException : Exception
  {
    public TodoNotFoundByIdException() { }

    public TodoNotFoundByIdException(string message) 
      : base(message) { }

    public TodoNotFoundByIdException(string message, Exception inner) 
      : base (message, inner) { }
  }
}
