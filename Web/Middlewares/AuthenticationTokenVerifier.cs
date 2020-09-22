using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TodosServer.Web.Middlewares
{
  public class AuthenticationTokenVerifier
  {
    private readonly RequestDelegate next;

    public AuthenticationTokenVerifier(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task Invoke(HttpContext ctx)
    {
      var req = ctx.Request;
      var res = ctx.Response;
      string token =  ctx.Request.Headers["x-auth-token"];
      if (req.Path.ToString().Contains("private") && string.IsNullOrEmpty(token)) {
        res.StatusCode = 401;
        await res.WriteAsync("Not authenticated, Authentication token either missing or invalid");
      } else {
        await this.next(ctx);
      }
    }
  }

  public static class AuthenticationTokenVerifierExtensions
  {
    public static IApplicationBuilder UseAuthenticationTokenVerifier(this IApplicationBuilder builder) =>
      builder.UseMiddleware<AuthenticationTokenVerifier>();
  }
}
