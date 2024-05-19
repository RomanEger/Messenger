using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.Hubs;

public class ChatHub(ILogger<ChatHub> logger) : Hub
{
    public async Task Send( string message)
    {
        await Clients.All.SendAsync("Receive", message);
        logger.LogInformation($"{nameof(Send)} message\r\n {message}");
    }
}