using AirBnb.Model;
using AirBNBAPI.Data;

namespace AirBNBAPI.Repositories
{
    public class AirBnBRepository : IAirBnBRepository
    {   
        private readonly AirBNBAPIContext _context;
        public AirBnBRepository(AirBNBAPIContext context) 
        { 
            _context= context;
        }

        public IEnumerable<Landlord> GetAllLandlords()
        {
            return _context.Landlord.ToList();
        }

        public IEnumerable<Listing> GetAllListings()
        {
            return _context.Listing.ToList();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _context.Property.ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.User.ToList();
        }

        public Landlord GetLandlord(int id)
        {
            return _context.Landlord.Find(id);
        }

        public Listing GetListing(int id)
        {
            return _context.Listing.Find(id);
        }

        public Property GetProperty(int id)
        {
            return _context.Property.Find(id);
        }

        public User GetUser(int id)
        {
            return _context.User.Find(id);
        }
    }
}
