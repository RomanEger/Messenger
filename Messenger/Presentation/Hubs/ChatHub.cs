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
    
    public Task Send(MessageDto message)
    {
        return Clients.All.SendAsync(Method.Receive.ToString(), message.Message);
    }

    public Task SendByChatId(MessageDto message)
    {
        return Clients.Group(message.ChatId.ToString()).SendAsync(Method.Receive.ToString(), message.Message);
    }
}