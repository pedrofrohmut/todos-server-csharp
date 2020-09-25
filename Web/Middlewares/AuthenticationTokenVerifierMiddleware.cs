using JWT.Exceptions;
using Microsoft.AspNetCore.Http;
using TodoServer.Web.Exceptions;
using TodoServer.Web.Services;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Middlewares
{
  public class AuthenticationTokenVerifierMiddleware
  {
    private readonly RequestDelegate next;
    private readonly DecodeTokenService decodeTokenService;

    public AuthenticationTokenVerifierMiddleware(
        RequestDelegate next,
        DecodeTokenService decodeTokenService)
    {
      this.next = next;
      this.decodeTokenService = decodeTokenService;
    }

    public async System.Threading.Tasks.Task InvokeAsync(
        HttpContext ctx, 
        AuthenticationTokenVerifierUseCase useCase)
    {
      var req = ctx.Request;
      var res = ctx.Response;
      string token =  req.Headers["x-auth-token"];
      string path = req.Path.ToString();
      try {
        await useCase.VerifyAuthenticationToken(path, token);
        await this.next(ctx);
      } catch (MissingRequestAuthTokenException e) {
        res.StatusCode = 401;
        await res.WriteAsync(e.Message);
      } catch (TokenExpiredException e) {
        res.StatusCode = 401;
        await res.WriteAsync(e.Message);
      } catch (InvalidRequestAuthTokenException e) {
        res.StatusCode = 401;
        await res.WriteAsync(e.Message);
      } catch (InvalidUserFromTokenException e) {
        res.StatusCode = 401;
        await res.WriteAsync(e.Message);
      }
    }
  }
}
