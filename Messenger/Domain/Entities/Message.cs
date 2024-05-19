using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Message : EntityBase
{
    public Guid UserId { get; private set; } //Sender
    public Guid ChatId { get; private set; }
    public string MessageData { get; private set; }
    public Guid MessageTypeId { get; private set; }
    public DateTime MessageDateTime { get; private set; } = DateTime.Now;
    public bool IsChanged { get; private set; }
    
    public User? User { get; private set; }
    public Chat? Chat { get; private set; }
    public MessageType? MessageType { get; private set; }
}