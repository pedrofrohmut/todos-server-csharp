using System.Threading.Tasks;
using JWT.Exceptions;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class AuthenticateUserUseCase
  {
    private readonly DecodeTokenService decodeTokenService;
    private readonly FindUserByIdService findUserByIdService;

    public AuthenticateUserUseCase(
        DecodeTokenService decodeTokenService,
        FindUserByIdService findUserByIdService)
    {
      this.decodeTokenService = decodeTokenService;
      this.findUserByIdService = findUserByIdService;
    }

    public async Task<object> AuthenticateUserByToken(string token)
    {
      if (token == null) {
        throw new MissingRequestAuthTokenException(
            "The Auth Token is missing in the request headers");
      }
      dynamic decodedToken = null;
      try {
        decodedToken = await this.decodeTokenService.Execute(token);
      } catch (TokenExpiredException e) {
        throw new TokenExpiredException(
            "Authentication token has expired");
      }
      if (decodedToken == null || decodedToken["userId"] == null) {
        throw new InvalidRequestAuthTokenException(
            "Request Auth Token is invalid and/or could not be decoded");
      }
      User user = await this.findUserByIdService.Execute(decodedToken["userId"]);
      if (user == null) {
        throw new UserNotFoundByIdException(
            "User not found with the passed auth token userId");
      }
      return new { 
        id = user.Id,
        firstName = user.FirstName,
        lastName = user.LastName,
        email = user.Email
      };
    }
  }
}
