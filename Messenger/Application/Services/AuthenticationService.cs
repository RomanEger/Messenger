using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DataTransferObjects;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        
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
            RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(1)
        };
        return _userRepository.CreateAsync(user);
    }

    public async Task<TokenDto?> LoginAsync(UserForAuthenticationDto userForAuthenticationDto)
    {
        var user = await _userRepository.FindByConditionAsync(
            x => x.Email == userForAuthenticationDto.UserPersonalData || x.PhoneNumber == userForAuthenticationDto.UserPersonalData);
        if (user is null)
            return null;
        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, userForAuthenticationDto.Password);
        
        return result != PasswordVerificationResult.Success ? null 
            : new TokenDto(_tokenService.GenerateAccessToken(new Claim[]
            {
                new(ClaimTypes.Name, user.UserName)
            }), user.RefreshToken ?? _tokenService.GenerateRefreshToken());
    }
    
    /// <returns>New pair of tokens</returns>
    /// <exception cref="SecurityTokenException"></exception>
    public async Task<TokenDto> RefreshTokensAsync(TokenDto tokenDto, IUnitOfWork unitOfWork)
    {
        var principal  = _tokenService.GetPrincipalFromExpiredToken(tokenDto.AccessToken);
        
        var user = await _userRepository.FindByConditionAsync(u => u.UserName == principal.Identity.Name);
        
        if (user is null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            throw new SecurityTokenException("Incorrect token");
        }

        user.RefreshToken = _tokenService.GenerateRefreshToken();
        
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(1);

        await unitOfWork.SaveChangesAsync();
        
        return new TokenDto(_tokenService.GenerateAccessToken(principal.Claims), user.RefreshToken);
    }
}