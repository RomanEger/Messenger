using Application.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.Hubs;

public class ChatHub(ILogger<ChatHub> logger) : Hub
{
    //[Authorize]
    public async Task Send(MessageDto message)
    {
        await Clients.All.SendAsync("Receive", message.Message);
        logger.LogInformation($"User {message.UserName} {nameof(Send)} message\r\n {message.Message}");
    }
}