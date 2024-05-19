using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index("UserName", IsUnique = true)]
[Index("Email", IsUnique = true)]
[Index("PhoneNumber", IsUnique = true)]
public class User : EntityBase
{
    [Required]
    [MaxLength(320)]
    [RegularExpression("^(?=.{1,320}$)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}$")]
    public string Email { get; private set; }
    
    [Required]
    [MaxLength(120)]
    [RegularExpression("^(?!.*\\s)[\\w.-]{3,120}$")]
    public string UserName { get; private set; }
    
    [Required]
    [MaxLength(20)]
    [RegularExpression("^\\\\+?[1-9]\\\\d{10}$")]
    public string PhoneNumber { get; private set; }
    
    [Required]
    [MaxLength(70)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,20}$")]
    public string Password { get; private set; }
    
    public DateTime RegistrationDate { get; private set; } = DateTime.Now;
    
    public ICollection<UserPhoto> UserPhotos { get; private set; }
    public ICollection<Message> Messages { get; private set; }
    public ICollection<ChatMember> ChatMembers { get; private set; }
}