using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

//[Index("Type", IsUnique = true)]
public class ChatType : EntityBase
{
    [Required]
    [MaxLength(50)]
    [AllowedValues("public", "private", "by invitation")]
    public string Type { get; private set; }
    
    [MaxLength(200)]
    public string? Description { get; private set; }
    
    public ICollection<Chat> Chats { get; private set; }
}