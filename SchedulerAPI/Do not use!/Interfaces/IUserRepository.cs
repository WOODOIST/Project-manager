using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        User GetUser(int id);

        ICollection<User> GetRoleOfUser(int userId);

        
    }
}
