using System.Collections.Generic;
using System.Threading.Tasks;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Configuration;

namespace TodoServer.Web.Services
{
  public class DecodeTokenService
  {
    private IConfiguration configuration; 

    public DecodeTokenService(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    public async Task<IDictionary<string, object>> Execute(string token) =>
      new JwtBuilder()
        .WithAlgorithm(new HMACSHA256Algorithm())
        .WithSecret(this.configuration["JwtSecret"])
        .MustVerifySignature()
        .Decode<IDictionary<string, object>>(token);
  }
}
