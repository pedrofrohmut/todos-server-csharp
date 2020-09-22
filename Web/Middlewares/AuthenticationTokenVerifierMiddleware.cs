using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Context;
using TodoServer.Web.Entities;
using TodoServer.Web.Services;

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

    public async System.Threading.Tasks.Task InvokeAsync(HttpContext ctx, AppDbContext db)
    {
      var req = ctx.Request;
      var res = ctx.Response;
      string token =  req.Headers["x-auth-token"];
      if (req.Path.ToString().Contains("private") && string.IsNullOrEmpty(token)) {
        res.StatusCode = 401;
        await res.WriteAsync("Not authenticated, Authentication token either missing or invalid");
      }
      if (req.Path.ToString().Contains("private") && !string.IsNullOrEmpty(token)) {
        dynamic payload = await this.decodeTokenService.Execute(token);
        string userId = payload["userId"];
        if (string.IsNullOrEmpty(userId)) {
          res.StatusCode = 401;
          await res.WriteAsync(
              "The authentication token is invalid and the user could not be authenticated");
        }
        User userFromToken = await db.Users.FirstOrDefaultAsync(user => user.Id == userId);
        if (userFromToken == null) {
          res.StatusCode = 401;
          await res.WriteAsync(
              $"No user found with the token provided. The request is not authorized.");
        } else {
          Console.WriteLine("User found. Request Authorized!");
        }
      }
      await this.next(ctx);
    }
  }
}
