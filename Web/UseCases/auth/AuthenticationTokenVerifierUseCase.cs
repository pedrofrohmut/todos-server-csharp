using JWT.Exceptions;
using TodoServer.Web.Entities;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;

namespace TodoServer.Web.UseCases
{
  public class AuthenticationTokenVerifierUseCase
  {
    private readonly DecodeTokenService decodeTokenService;
    private readonly FindUserByIdService findUserByIdService;

    public AuthenticationTokenVerifierUseCase(
        DecodeTokenService decodeTokenService,
        FindUserByIdService findUserByIdService)
    {
      this.decodeTokenService = decodeTokenService;
      this.findUserByIdService = findUserByIdService;
    }

    public async System.Threading.Tasks.Task VerifyAuthenticationToken(string path, string token)
    {
      if (!path.Contains("private")) {
        return;
      }
      if (string.IsNullOrEmpty(token)) {
        throw new MissingRequestAuthTokenException(            
            "Not authenticated, Authentication token either missing or invalid");
      }
      dynamic payload = null;
      try {
        payload = await this.decodeTokenService.Execute(token);
      } catch (TokenExpiredException e) {
        throw new TokenExpiredException(
            "The authentication token experied");
      }
      string userId = payload["userId"];
      if (string.IsNullOrEmpty(userId)) {
        throw new InvalidRequestAuthTokenException(
            "The authentication token is invalid and the user could not be authenticated");
      }
      User userFromToken = await this.findUserByIdService.Execute(userId);
      if (userFromToken == null) {
        throw new InvalidUserFromTokenException(
            "No user found with the token provided. The request is not authorized.");
      }
    }
  }
}
