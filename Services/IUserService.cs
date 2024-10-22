using ParkNow.Models;
namespace ParkNow.Services;
/*
This interface implements the methods of the User entity
GetUser, HashPassword, VerifyPassword, VerifyCredentials, Register
*/

public interface IUserService
{
    Task<User> GetUser (string username);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash, string salt);
    Task<bool> ChangePassword(string username, string oldPassword, string newPassword);
    Task<bool> VerifyCredentials(string username, string password);
    Task<bool> Register(string username, string email, string password);

}
