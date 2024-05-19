using System.ComponentModel.DataAnnotations;

namespace Application.DataTrasnferObjects;

public record UserDto(
    [Required]
    [MaxLength(120)]
    string UserName
    );