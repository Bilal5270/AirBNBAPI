using AirBnb.Model;

namespace AirBNBAPI.Services
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetSpecificUser(int id);

        public User ChangeUser(int id, User user);
    }
}
