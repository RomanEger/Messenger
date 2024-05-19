using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

//[Index("Name", IsUnique = true)]
public class ChatAccessibility : EntityBase
{
    [MaxLength(50)]
    public string Name { get; private set; }
    [MaxLength(200)]
    public string? Description { get; private set; }
    
    public ICollection<Chat> Chats { get; private set; }
}