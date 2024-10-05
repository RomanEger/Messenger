namespace Application.Services.Contracts;

public interface IPasswordManager
{
    Task<bool> ChangePassword(string userName, string newPassword);
}