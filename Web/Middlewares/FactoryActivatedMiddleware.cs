using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TodoServer.Web.UseCases;

namespace TodoServer.Web.Middlewares
{
  public class FactoryActivatedMiddleware : IMiddleware
  {
    private readonly AuthenticationTokenVerifierUseCase useCase;

    public FactoryActivatedMiddleware(
        AuthenticationTokenVerifierUseCase useCase)
    {
      this.useCase = useCase;
    }

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
      await next(httpContext);
    }
  }
}
