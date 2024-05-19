using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class MessageType : EntityBase
{
    [MaxLength(50)]
    public string Type { get; private set; }
    [MaxLength(200)]
    public string? Description { get; private set; }
    
    public ICollection<Message> Messages { get; private set; }
}