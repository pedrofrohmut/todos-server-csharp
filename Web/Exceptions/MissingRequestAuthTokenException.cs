using System;

namespace TodoServer.Web.Exceptions
{
  public class MissingRequestAuthTokenException : Exception
  {
    public MissingRequestAuthTokenException() { }

    public MissingRequestAuthTokenException(string message) 
      : base(message) { }

    public MissingRequestAuthTokenException(string message, Exception inner) 
      : base (message, inner) { }
  }
}
