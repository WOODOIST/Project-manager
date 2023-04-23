using ProjectManagerAPI.Interfaces;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Repositories
{
    public class UserRepository
    {
        private readonly SchedulerContext _context;

        public UserRepository(SchedulerContext context)     
        
        {
            _context = context;
        }

        //public ICollection<User> GetRoleOfUser(int userId)
        //{
        //    return _context.Users.Where(p => p.Roleid == userId).Select(p => p.Roleid).ToList();
        //}

        public User GetUser(int id)
        {
            return _context.Users.Where(p => p.Userid == id).FirstOrDefault();
        }

        public  ICollection<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
