using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index("UserName", IsUnique = true)]
[Index("Email", IsUnique = true)]
[Index("PhoneNumber", IsUnique = true)]
public class User : EntityBase
{
    [NotMapped]
    private string _email = "";
    
    [MaxLength(320)]
    public string Email
    {
        get => _email;
        set
        {
            if (value != null && Regex.IsMatch(value, "^(?=.{1,320}$)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}$"))
                _email = value;
        }
    }
    
    [NotMapped]
    private string _userName = "";

    [MaxLength(120)]
    public string UserName
    {
        get => _userName;
        set
        {
            if (value != null && Regex.IsMatch(value, "^(?!.*\\\\s)[\\\\w.-]{3,120}$"))
                _userName = value;
        }
    }

    [NotMapped]
    private string _phoneNumber = "";

    [MaxLength(20)]
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (value != null && Regex.IsMatch(value, "^\\\\+?[1-9]\\\\d{10}$"))
                _phoneNumber = value;
        }
    }

    [NotMapped]
    private string _password = "";
    
    [MaxLength(70)]
    public string Password
    {
        get => _password;
        set
        {
            if (value != null && Regex.IsMatch(value, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,20}$"))
                _password = new PasswordHasher<User>().HashPassword(this, value);
        }
    }
    
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    
    public ICollection<UserPhoto> UserPhotos { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<ChatMember> ChatMembers { get; set; }
}