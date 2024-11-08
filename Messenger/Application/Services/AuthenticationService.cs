using System.Security.Claims;
using Application.DataTransferObjects;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static Infrastructure.TokenConstants;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly PasswordHasher<User> _passwordHasher = new();
        
    public AuthenticationService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    
    public Task<bool> CreateUserAsync(UserForRegistrationDto userForRegistrationDto)
    {
        var user = new User()
        {
            UserName = userForRegistrationDto.UserName,
            NickName = userForRegistrationDto.NickName,
            PhoneNumber = userForRegistrationDto.PhoneNumber,
            Email = userForRegistrationDto.Email,
            Password = userForRegistrationDto.Password,
            RefreshToken = _tokenService.GenerateRefreshToken(),
            RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(RefreshTokenExpiryMonth)
        };
        return _userRepository.CreateAsync(user);
    }

    public async Task<ResponseTokenDto?> LoginAsync(UserForAuthenticationDto userForAuthenticationDto)
    {
        var user = await _userRepository.FindByConditionAsync(
            x => x.Email == userForAuthenticationDto.UserPersonalData || x.PhoneNumber == userForAuthenticationDto.UserPersonalData);
        if (user is null)
            return null;
        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, userForAuthenticationDto.Password);
        
        return result != PasswordVerificationResult.Success ? null 
            : new ResponseTokenDto(_tokenService.GenerateAccessToken(new Claim[]
            {
                new(ClaimTypes.Name, user.UserName)
            }), user.RefreshToken);
    }
    
    /// <returns>New pair of tokens</returns>
    /// <exception cref="SecurityTokenException"></exception>
    public async Task<ResponseTokenDto> RefreshTokensAsync(TokenDto tokenDto, IUnitOfWork unitOfWork)
    {
        var principal  = _tokenService.GetPrincipalFromExpiredToken(tokenDto.AccessToken);
        
        var user = await _userRepository.FindByConditionAsync(u => principal.Identity != null && u.UserName == principal.Identity.Name);
        
        if (user is null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            throw new SecurityTokenException("Incorrect token");
        }

        user.RefreshToken = _tokenService.GenerateRefreshToken();
        
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(RefreshTokenExpiryMonth);

        await unitOfWork.SaveChangesAsync();
        
        return new ResponseTokenDto(_tokenService.GenerateAccessToken(principal.Claims), user.RefreshToken);
    }
}