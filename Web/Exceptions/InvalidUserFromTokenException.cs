using System;

namespace TodoServer.Web.Exceptions
{
  public class InvalidUserFromTokenException : Exception
  {
    public InvalidUserFromTokenException() { }

    public InvalidUserFromTokenException(string message) 
      : base(message) { }

    public InvalidUserFromTokenException(string message, Exception inner) 
      : base (message, inner) { }
  }
}
