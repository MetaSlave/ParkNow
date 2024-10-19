using ParkNow.Models;
namespace ParkNow.Services;
public interface IUserService
{
    Task<User> GetUser (string username);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash, string salt);
    Task<bool> VerifyCredentials(string username, string password);
    Task<bool> Register(string username, string email, string password);

}
