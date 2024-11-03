using Application.DataTransferObjects;
using Domain.Repositories;

namespace Application.Services.Contracts;

public interface IAuthenticationService
{
    Task<bool> CreateUserAsync(UserForRegistrationDto user);

    Task<TokenDto?> LoginAsync(UserForAuthenticationDto userForAuthenticationDto);

    Task<TokenDto> RefreshTokensAsync(TokenDto tokenDto, IUnitOfWork unitOfWork);
}