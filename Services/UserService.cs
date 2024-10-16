using ParkNow.Models;
using ParkNow.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ParkNow.Services;

public class UserService : IUserService
{
    // Get Database Context and Constructor to include context
    private readonly AppDbContext _context;
    public UserService(AppDbContext context) {
        _context = context;
    }
    public async Task<int> GetUserid (string username) {
        return await _context.Users.Where(u => u.Username == username).Select(u => u.UserId).FirstOrDefaultAsync();
    }
    public bool VerifyPassword(string password, string hash, string salt) {
        var byte_salt = Encoding.UTF8.GetBytes(salt);
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, byte_salt, 350000, HashAlgorithmName.SHA512, 64);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
    public string HashPassword(string password) {
        var byte_salt = Encoding.UTF8.GetBytes("35cdd9db5a7eb3bf27ecb65e351dd6d4088f82bbdedcc800ca2a44e4b34df82e946972ab434762f87cd56fe09e7e8b2d83c33f101874d7f1e66303c510256525");
        var hashBytes = Rfc2898DeriveBytes.Pbkdf2(password, byte_salt, 350000, HashAlgorithmName.SHA512, 64);
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant(); // Convert to hex string
    }
    public async Task<bool> VerifyCredentials(string username, string password) {
        var user = await _context.Users.Where(e => e.Username == username).SingleOrDefaultAsync();
        bool valid = VerifyPassword(password, user.Password, "35cdd9db5a7eb3bf27ecb65e351dd6d4088f82bbdedcc800ca2a44e4b34df82e946972ab434762f87cd56fe09e7e8b2d83c33f101874d7f1e66303c510256525");
        if (user == null || !valid) {
            return false;
        }
        return true;
    }
    public async Task<bool> Register(string username, string email, string password) {
        bool exists = await _context.Users.AnyAsync(e => e.Username == username);
        if (exists){
            return false;
        }
        else {
            User temp = new User{Username=username,Password=password,Email=email};
            _context.Users.Add(temp);
            await _context.SaveChangesAsync();
        }
        return true;
    }


}
