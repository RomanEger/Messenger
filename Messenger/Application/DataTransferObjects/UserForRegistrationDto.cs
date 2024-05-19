using System.ComponentModel.DataAnnotations;

namespace Application.DataTrasnferObjects;

public record UserForRegistrationDto(
    [Required]
    [MaxLength(120)]
    string UserName,
    [Required]
    [MaxLength(120)]
    string Email,
    [Required]
    [MaxLength(20)]
    string PhoneNumber,
    [Required]
    [MaxLength(70)]
    string Password
    );