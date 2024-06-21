using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.DataTransferObjects;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly JwtOptions _jwtOptions;
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        
    public AuthenticationService(IOptions<JwtOptions> options, IUserRepository userRepository)
    {
        _jwtOptions = options.Value;
        _userRepository = userRepository;
    }
    
    public async Task<bool> CreateUserAsync(UserForRegistrationDto userForRegistrationDto)
    {
        var user = new User()
        {
            UserName = userForRegistrationDto.UserName,
            PhoneNumber = userForRegistrationDto.PhoneNumber,
            Email = userForRegistrationDto.Email
        };
        user.Password = _passwordHasher.HashPassword(user, userForRegistrationDto.Password);
        return await _userRepository.CreateAsync(user);
    }

    private string GenerateJwt(UserDto user)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Name, user.UserName)
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddDays(3),
            signingCredentials);

        var accessToken = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return accessToken;
    }

    public async Task<string?> LoginAsync(UserForAuthenticationDto userForAuthenticationDto)
    {
        var user = await _userRepository.FindByConditionAsync(x => x.Email == userForAuthenticationDto.UserPersonalData || x.PhoneNumber == userForAuthenticationDto.UserPersonalData);
        if (user is null)
            return null;
        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, userForAuthenticationDto.Password);
        return result != PasswordVerificationResult.Success ? null : GenerateJwt(new UserDto(user.UserName));
    }
}