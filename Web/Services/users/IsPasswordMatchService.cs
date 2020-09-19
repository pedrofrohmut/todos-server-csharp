using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace TodoServer.Web.Services
{
  public class IsPasswordMatchService
  {
    public async Task<bool> Execute(string userHashedPassword, string requestPassword) =>
      BC.Verify(requestPassword, userHashedPassword);
  }
}
