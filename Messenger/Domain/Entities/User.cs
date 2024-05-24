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
    public string Email { get; set; }
    
    [Required]
    [MaxLength(120)]
    [RegularExpression("^(?!.*\\s)[\\w.-]{3,120}$")]
    public string UserName { get; set; }
    
    [Required]
    [MaxLength(20)]
    [RegularExpression("^\\\\+?[1-9]\\\\d{10}$")]
    public string PhoneNumber { get; set; }
    
    [Required]
    [MaxLength(70)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,20}$")]
    public string Password { get; set; }
    
    public DateTime RegistrationDate { get; private set; } = DateTime.Now;
    
    public ICollection<UserPhoto> UserPhotos { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<ChatMember> ChatMembers { get; set; }
}