using Application.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.Hubs;

[Authorize]
public class ChatHub(ILogger<ChatHub> logger) : Hub
{
    private enum Method
    {
        Receive,
        Send,
        Notify
    }
    
    public async Task Send(MessageDto message)
    {
        await Clients.All.SendAsync(Method.Receive.ToString(), message.Message);
    }

    public async Task SendByChatId(MessageDto message)
    {
        await Clients.Group(message.ChatId.ToString()).SendAsync(Method.Receive.ToString(), message.Message);
    }
}