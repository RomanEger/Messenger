using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public record UserForRegistrationDto(
    [Required]
    string Email,
    [Required]
    string UserName,
    [Required]
    string NickName,
    [Required]
    string PhoneNumber,
    [Required]
    string Password);