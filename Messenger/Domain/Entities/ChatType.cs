using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

//[Index("Type", IsUnique = true)]
public class ChatType : EntityBase
{
    [Required]
    [MaxLength(50)]
    [AllowedValues("public", "private", "by invitation")]
    public string Type { get; set; }
    
    [MaxLength(200)]
    public string? Description { get; set; }
    
    public ICollection<Chat> Chats { get; set; }
}