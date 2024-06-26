namespace Domain.Entities;

public class UserPhoto : EntityBase
{
    public Guid UserId { get; set; }
    public byte[] Photo { get; set; }
    
    public User? User { get; set; }
}