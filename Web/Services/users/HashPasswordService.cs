using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace TodoServer.Web.Services
{
  public class HashPasswordService
  {
    // Note: Although this library allows you to supply your own salt, it is 
    // highly advisable that you allow the library to generate the salt for you. 
    // These methods are supplied to maintain compatibility and for more advanced 
    // cross-platform requirements that may necessitate their use.
    public async Task<string> Execute(string password) => BC.HashPassword(password);
  }
}
