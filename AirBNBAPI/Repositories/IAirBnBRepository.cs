using AirBnb.Model;

namespace AirBNBAPI.Repositories
{
    public interface IAirBnBRepository
    {
        public IEnumerable<Customer> GetAllCustomers();
        public IEnumerable<Reservation> GetAllReservations();

        public IEnumerable<Landlord> GetAllLandlords();

        public Task<IEnumerable<Location>> GetAllLocationsAsync(CancellationToken cancellationToken);
        public Task<List<Reservation>> GetReservationsByLocationAsync(int locationId, CancellationToken cancellationToken);
        public Customer GetCustomer(int id);

        public Reservation GetReservation(int id);

        public Landlord GetLandlord(int id);

        public Task<Location> GetLocationAsync(int id, CancellationToken cancellationToken);



    }
}
