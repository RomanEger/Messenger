namespace Application.Services.Contracts;

public interface IUserProfileManager
{
    Task<bool> ChangeUserName(string userName, string newUserName);

    Task<bool> ChangeNickName(string userName, string newNickName);
}