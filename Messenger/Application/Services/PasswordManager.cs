using Application.DataTransferObjects;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class PasswordManager : IPasswordManager
{
    private readonly IUserRepository _userRepository;
    
    public PasswordManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> ChangePassword(UserForAuthenticationDto userDto, string newPassword)
    {
        var passwordHasher = new PasswordHasher<User>();
        var user = await _userRepository.FindByConditionAsync(x =>
                x.Email == userDto.UserPersonalData || x.PhoneNumber == userDto.UserPersonalData);

        if (user is not null && 
            passwordHasher.VerifyHashedPassword(
                    user, user.Password, userDto.Password) == PasswordVerificationResult.Success)
        {
            user.Password = newPassword;
            _userRepository.Update(user);
            return true;
        }
        return false;
    }
}