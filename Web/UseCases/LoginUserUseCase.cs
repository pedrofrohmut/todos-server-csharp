using System.Threading.Tasks;
using TodoServer.Web.Services;
using TodosServer.Web.Exceptions;

namespace TodoServer.Web.UseCases
{
  public class LoginUserUseCase
  {
    private readonly FindUserByEmailService findUserByEmailService;
    private readonly IsPasswordMatchService isPasswordMatchService;
    private readonly GetSignInTokenService getSignInTokenService;

    public LoginUserUseCase(
        FindUserByEmailService findUserByEmailService,
        IsPasswordMatchService isPasswordMatchService,
        GetSignInTokenService getSignInTokenService)
    {
      this.findUserByEmailService = findUserByEmailService;
      this.isPasswordMatchService = isPasswordMatchService;
      this.getSignInTokenService = getSignInTokenService;
    }

    public async Task<object> GetSignedInUser(string email, string password)
    {
      // TODO: validate e-mail
      var user = await this.findUserByEmailService.Execute(email);
      if (user == null) {
        throw new UserNotFoundByEmailException("There is no user that matches the passed e-mail");
      }
      bool isMatch = await this.isPasswordMatchService.Execute(user.Password, password);
      if (!isMatch) {
        throw new UserPasswordMismatchException("The passed password do not match the e-mail passed");
      }
      string signInToken = await this.getSignInTokenService.Execute(user.Id);
      return new {
        user,
        token = signInToken
      };
    }
  }
}
