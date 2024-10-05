using Application.Services.Contracts;
using Domain.Repositories;

namespace Application.Services;

public class PasswordManager : IPasswordManager
{
    private readonly IUserRepository _userRepository;
    
    public PasswordManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> ChangePassword(string userName, string newPassword)
    {
        var user = await _userRepository.FindByConditionAsync(x =>
                x.UserName == userName);
        if (user is null) 
            return false;
        user.Password = newPassword;
        _userRepository.Update(user);
        return true;
    }
}