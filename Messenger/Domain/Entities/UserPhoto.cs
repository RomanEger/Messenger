namespace Domain.Entities;

public class UserPhoto : EntityBase
{
    public Guid UserId { get; private set; }
    public byte[] Photo { get; private set; }
    
    public User? User { get; private set; }
}