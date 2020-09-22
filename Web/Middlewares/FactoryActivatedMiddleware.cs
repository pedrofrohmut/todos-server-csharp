using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TodoServer.Web.Context;

namespace TodoServer.Web.Middlewares
{
  public class FactoryActivatedMiddleware : IMiddleware
  {
    private readonly AppDbContext dbContext;

    public FactoryActivatedMiddleware(AppDbContext dbContext)
    {
      this.dbContext = dbContext;
    }

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
      await next(httpContext);
    }
  }
}
