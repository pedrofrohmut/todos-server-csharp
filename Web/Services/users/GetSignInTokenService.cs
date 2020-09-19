using System.Threading.Tasks;

namespace TodoServer.Web.Services
{
  public class GetSignInTokenService
  {
    public async Task<string> Execute(string userId)
    {
      return "STUB_SIGN_IN_TOKEN";
    }
  }
}
