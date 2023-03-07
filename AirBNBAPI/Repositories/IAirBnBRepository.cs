using AirBnb.Model;

namespace AirBNBAPI.Repositories
{
    public interface IAirBnBRepository
    {
        public IEnumerable<Customer> GetAllCustomers();
        public IEnumerable<Reservation> GetAllReservations();

        public IEnumerable<Landlord> GetAllLandlords();

        public IEnumerable<Location> GetAllLocations();

        public Customer GetCustomer(int id);

        public Reservation GetReservation(int id);

        public Landlord GetLandlord(int id);

        public Location GetLocation(int id);



    }
}
