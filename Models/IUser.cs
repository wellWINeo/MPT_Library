namespace Library.Models;

public interface IUser
{
    public string Email { get; set; }
    public string Password { get; set; }
}