using Application.DataTransferObjects;

namespace Application.Services.Contracts;

public interface IAuthenticationService
{
    Task<bool> CreateUserAsync(UserForRegistrationDto user);

    Task<AuthenticationResult?> LoginAsync(UserForAuthenticationDto userForAuthenticationDto);
}