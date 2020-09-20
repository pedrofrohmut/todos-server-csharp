using System;

namespace TodosServer.Web.Exceptions
{
  public class UserNotFoundByEmailException : Exception
  {
    public UserNotFoundByEmailException() { }
     
    public UserNotFoundByEmailException(string message) 
      : base (message) { }

    public UserNotFoundByEmailException(string message, Exception inner) 
      : base (message, inner) { }
  }
}
