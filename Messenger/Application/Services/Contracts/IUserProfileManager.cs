using Application.DataTransferObjects;

namespace Application.Services.Contracts;

public interface IUserProfileManager
{
    Task<bool> ChangeUserName(string userName, string newUserName);
}