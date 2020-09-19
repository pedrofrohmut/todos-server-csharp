using System;
using System.Threading.Tasks;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;
using TodoServer.Web.Utils;

namespace TodoServer.Web.UseCases
{
  public class CreateUserUseCase
  {
    private readonly FindUserByEmailService findUserByEmailService;
    private readonly HashPasswordService hashPasswordService;
    private readonly CreateUserService createUserService;
    private readonly TextFormatter textFormatter;

    public CreateUserUseCase(
        FindUserByEmailService findUserByEmailService,
        HashPasswordService hashPasswordService,
        CreateUserService createUserService,
        TextFormatter textFormatter)
    {
      this.findUserByEmailService = findUserByEmailService;
      this.hashPasswordService = hashPasswordService;
      this.createUserService = createUserService;
      this.textFormatter = textFormatter;
    }

    public async Task<bool> CreateUser(User user)
    {
      // Validate user fields
      if (string.IsNullOrWhiteSpace(user.FirstName)) {
        throw new ArgumentNullException("First Name is Required");
      }
      if (string.IsNullOrWhiteSpace(user.LastName)) {
        throw new ArgumentNullException("Last Name is Required");
      }
      if (string.IsNullOrWhiteSpace(user.Email)) {
        throw new ArgumentNullException("E-mail is Required");
      }
      if (string.IsNullOrWhiteSpace(user.Password)) {
        throw new ArgumentNullException("Password is Required");
      }
      
      // Check for e-mail already used
      User userFromEmail = await this.findUserByEmailService.Execute(user.Email);
      if (userFromEmail != null) {
        throw new EmailAlreadyTakenException(
            "This e-mail is already been taken by a registered user");
      }
      
      // Hash password
      string hashedPassword = await this.hashPasswordService.Execute(user.Password);

      // create user
      User newUser = new User
      {
        FirstName = this.textFormatter.Capitalize(user.FirstName),
        LastName = this.textFormatter.Capitalize(user.LastName),
        Email = user.Email,
        Password = hashedPassword
      };
      await this.createUserService.Execute(newUser);

      return true;
    }
  }
}
