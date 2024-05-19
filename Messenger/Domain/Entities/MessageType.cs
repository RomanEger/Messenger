using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class MessageType : EntityBase
{
    [Required]
    [MaxLength(50)]
    [AllowedValues("text", "voice", "file", "photo", "video", "gif", "audio")]
    public string Type { get; private set; }
    [MaxLength(200)]
    public string? Description { get; private set; }
    
    public ICollection<Message> Messages { get; private set; }
}
