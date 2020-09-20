using System;
using System.Threading.Tasks;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Configuration;

namespace TodoServer.Web.Services
{
  public class GetSignInTokenService
  {
    private readonly IConfiguration configuration;

    public GetSignInTokenService(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    public async Task<string> Execute(string userId) =>
      new JwtBuilder()
        .WithAlgorithm(new HMACSHA256Algorithm())
        .WithSecret(this.configuration["JwtSecret"])
        .AddClaim("userId", userId)
        .AddClaim("exp", DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds())
        .Encode();
  }
}
