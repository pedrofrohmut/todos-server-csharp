using System.Globalization;

namespace TodoServer.Web.Utils
{
  public class TextFormatter
  {
    public string Capitalize(string text)
    {
      TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
      return textInfo.ToTitleCase(text);
    }
  }
}
