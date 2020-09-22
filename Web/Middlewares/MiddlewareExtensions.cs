using Microsoft.AspNetCore.Builder;

namespace TodoServer.Web.Middlewares
{
  public static class MiddlewareExtensions
  {
    public static IApplicationBuilder UseAuthenticationTokenVerifierMiddleware(
        this IApplicationBuilder builder) =>
      builder.UseMiddleware<AuthenticationTokenVerifierMiddleware>();

    public static IApplicationBuilder UseFactoryAcitivatedMiddleware(
        this IApplicationBuilder builder) =>
      builder.UseMiddleware<FactoryActivatedMiddleware>();
  }
}
