using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Messenger.Backend.Hubs;

public class ChatHub : Hub
{
    private readonly ILogger _logger;

    public ChatHub(ILogger logger)
    {
        _logger = logger;
    }
    
    [Authorize]
    public async Task Send(string message, string userName)
    {
        await Clients.All.SendAsync("Receive", message, userName);
        _logger.LogInformation($"{nameof(Send)} message\r\n {message}	{userName}");
    }
}