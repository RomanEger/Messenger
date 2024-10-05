namespace Domain.Entities;

public class Message : EntityBase
{
    public Guid UserId { get; set; } //Sender
    public Guid ChatId { get; set; }
    public string MessageData { get; set; }
    public Guid MessageTypeId { get; set; }
    public DateTime MessageDateTime { get; private set; } = DateTime.Now;
    public bool IsChanged { get; set; }
    
    public User? User { get; set; }
    public Chat? Chat { get; set; }
    public MessageType? MessageType { get; set; }
}