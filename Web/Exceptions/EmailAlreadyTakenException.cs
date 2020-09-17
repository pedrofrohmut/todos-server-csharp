using System;

namespace TodoServer.Web.Exceptions
{
  public class EmailAlreadyTakenException : Exception
  {
    public EmailAlreadyTakenException() { }

    public EmailAlreadyTakenException(string message) : base(message) { }

    public EmailAlreadyTakenException(string message, Exception inner) : base (message, inner) { }
  }
}
