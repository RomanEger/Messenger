namespace Domain.Entities;

public class ChatMember : EntityBase
{
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
    public Guid MemberRoleId { get; set; }
    
    public User? User { get; set; }
    public Chat? Chat { get; set; }
    public MemberRole? MemberRole { get; set; }
}