using System;

namespace TodosServer.Web.Exceptions
{
  public class UserPasswordMismatchException : Exception
  {
    public UserPasswordMismatchException() { }
     
    public UserPasswordMismatchException(string message) 
      : base (message) { }

    public UserPasswordMismatchException(string message, Exception inner) 
      : base (message, inner) { }
  }
}
