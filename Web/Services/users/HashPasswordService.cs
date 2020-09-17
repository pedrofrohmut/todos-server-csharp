using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TodoServer.Web.Services
{
  public class HashPasswordService
  {
    public async Task<string> Execute(string password)
    {
      // generate a 128-bit salt using a secure PRNG
      byte[] salt = new byte[128 / 8];
      using (var rng = RandomNumberGenerator.Create()) 
      {
        rng.GetBytes(salt);
      }

     // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
      string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
          password: password,
          salt: salt,
          prf: KeyDerivationPrf.HMACSHA1,
          iterationCount: 10000,
          numBytesRequested: 256 / 8));

      Console.WriteLine($"Hashed: {hashed}");

      return hashed;
    }
  }
}
