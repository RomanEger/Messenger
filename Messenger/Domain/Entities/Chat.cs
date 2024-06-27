using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index("ChatName", IsUnique = true)]
public class Chat : EntityBase
{
    public string ChatName { get; set; }
    public string Name { get; set; }
    public Guid ChatTypeId { get; set; }
    public Guid ChatAccessibilityId { get; set; }
    
    public ChatType? ChatType { get; set; }
    public ChatAccessibility? ChatAccessibility { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<ChatMember> ChatMembers { get; set; }
}