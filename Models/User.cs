/*
This class implements the User entity with the attributes
UserId, Password, Username, Email
*/
namespace ParkNow.Models;
public class User
{
    public enum Roles
    {
        User,
        Admin
    }
    public int UserId {get; set;}
    public required string Password {get; set;}
    public required string Username {get; set;}
    public required string Email {get; set;}
    public required Roles Role {get; set;}
}
