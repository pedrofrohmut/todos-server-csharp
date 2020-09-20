using System;

namespace TodoServer.Web.Exceptions
{
  public class UserNotFoundByIdException : Exception
  {
    public UserNotFoundByIdException() { }

    public UserNotFoundByIdException(string message) 
      : base(message) { }

    public UserNotFoundByIdException(string message, Exception inner) 
      : base (message, inner) { }
  }
}
