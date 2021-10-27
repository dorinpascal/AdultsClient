using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IUser
    {
        Task<User> ValidateUser(string userName, string Password);
    }
}