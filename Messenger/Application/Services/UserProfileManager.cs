using Application.Services.Contracts;
using Domain.Repositories;

namespace Application.Services;

public class UserProfileManager : IUserProfileManager
{
    private readonly IUserRepository _userRepository;
    
    public UserProfileManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> ChangeUserName(string userName, string newUserName)
    {
        var user = await _userRepository.FindByConditionAsync(x =>
            x.UserName == userName);
        if (user is null) 
            return false;
        user.UserName = newUserName;
        _userRepository.Update(user);
        return true;
    }
}