using AirBnb.Model;
using AirBNBAPI.Data;
using AirBNBAPI.Repositories;

namespace AirBNBAPI.Services
{
    public class UserDatabaseService : IUserService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        public UserDatabaseService(IAirBnBRepository airBnBRepository)
        {
            _airBnBRepository = airBnBRepository;
        }

        public User ChangeUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _airBnBRepository.GetAllUsers();
            
        }

        public User GetSpecificUser(int id)
        {
            return _airBnBRepository.GetUser(id);
        }

         
    }
}
