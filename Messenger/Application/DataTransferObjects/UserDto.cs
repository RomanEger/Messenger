using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public record UserDto(
    [Required]
    [MaxLength(120)]
    string UserName
    );