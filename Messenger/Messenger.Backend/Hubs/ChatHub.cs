using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Messenger.Backend.Hubs;

public class ChatHub(ILogger logger) : Hub
{
    
    [Authorize]
    public async Task Send(string message, string userName)
    {
        await Clients.All.SendAsync("Receive", message, userName);
        logger.LogInformation($"{nameof(Send)} message\r\n {message}	{userName}");
    }
}