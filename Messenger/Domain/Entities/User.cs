using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index("UserName", IsUnique = true)]
[Index("Email", IsUnique = true)]
[Index("PhoneNumber", IsUnique = true)]
public class User : EntityBase
{
    [MaxLength(120)]
    public string UserName { get; private set; }
    [MaxLength(120)]
    public string Email { get; private set; }
    [MaxLength(20)]
    public string PhoneNumber { get; private set; }
    [MaxLength(70)]
    public string Password { get; private set; }
    public DateTime RegistrationDate { get; private set; } = DateTime.Now;
    
    public ICollection<UserPhoto> UserPhotos { get; private set; }
    public ICollection<Message> Messages { get; private set; }
    public ICollection<ChatMember> ChatMembers { get; private set; }
}