using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

//[Index("Name", IsUnique = true)]
public class ChatAccessibility : EntityBase
{
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    
    public ICollection<Chat> Chats { get; set; }
}