namespace Domain.Entities;

public class ChatMember : EntityBase
{
    public Guid UserId { get; private set; }
    public Guid ChatId { get; private set; }
    public Guid MemberRoleId { get; private set; }
    
    public User? User { get; private set; }
    public Chat? Chat { get; private set; }
    public MemberRole? MemberRole { get; private set; }
}