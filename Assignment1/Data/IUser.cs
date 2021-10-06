using Models;

namespace Assignment1.Data
{
    public interface IUser
    {
        User ValidateUser(string userName, string Password);
    }
}