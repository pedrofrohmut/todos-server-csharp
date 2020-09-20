using System;

namespace TodoServer.Web.Exceptions
{
  public class InvalidRequestAuthTokenException : Exception
  {
    public InvalidRequestAuthTokenException() { }

    public InvalidRequestAuthTokenException(string message) 
      : base(message) { }

    public InvalidRequestAuthTokenException(string message, Exception inner) 
      : base (message, inner) { }
  }
}
