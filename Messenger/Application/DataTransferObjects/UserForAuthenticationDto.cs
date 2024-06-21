using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;


/// <param name="UserPersonalData">Email or PhoneNumber</param>
public record UserForAuthenticationDto([Required] string UserPersonalData, [Required] string Password);