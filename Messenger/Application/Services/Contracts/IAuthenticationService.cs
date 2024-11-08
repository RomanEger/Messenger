using Application.DataTransferObjects;
using Domain.Repositories;

namespace Application.Services.Contracts;

public interface IAuthenticationService
{
    Task<bool> CreateUserAsync(UserForRegistrationDto user);

    Task<ResponseTokenDto?> LoginAsync(UserForAuthenticationDto userForAuthenticationDto);

    Task<ResponseTokenDto> RefreshTokensAsync(TokenDto tokenDto, IUnitOfWork unitOfWork);
}