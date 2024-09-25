using Application.DataTransferObjects;

namespace Application.Services.Contracts;

public interface IPasswordManager
{
    Task<bool> ChangePassword(UserForAuthenticationDto userDto, string newPassword);
}