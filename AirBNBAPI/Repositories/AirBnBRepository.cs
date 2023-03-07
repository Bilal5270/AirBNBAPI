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

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _context.Reservation.ToList();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Location.ToList();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.User.ToList();
        }

        public Landlord GetLandlord(int id)
        {
            return _context.Landlord.Find(id);
        }

        public Reservation GetReservation(int id)
        {
            return _context.Reservation.Find(id);
        }

        public Location GetLocation(int id)
        {
            return _context.Location.Find(id);
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customer.Find(id);
        }
    }
}
