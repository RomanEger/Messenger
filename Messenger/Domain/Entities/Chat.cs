namespace Domain.Entities;

public class Chat : EntityBase
{
    public string Name { get; private set; }
    public Guid ChatTypeId { get; private set; }
    public Guid ChatAccessibilityId { get; private set; }
    
    public ChatType? ChatType { get; private set; }
    public ChatAccessibility? ChatAccessibility { get; private set; }
    public ICollection<Message> Messages { get; private set; }
    public ICollection<ChatMember> ChatMembers { get; private set; }
}