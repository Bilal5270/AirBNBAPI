using AirBnb.Model;

namespace AirBNBAPI.Repositories
{
    public interface IAirBnBRepository
    {
        public IEnumerable<User> GetAllUsers();

        public IEnumerable<Listing> GetAllListings();

        public IEnumerable<Landlord> GetAllLandlords();

        public IEnumerable<Property> GetAllProperties();

        public User GetUser(int id);

        public Listing GetListing(int id);

        public Landlord GetLandlord(int id);

        public Property GetProperty(int id);



    }
}
