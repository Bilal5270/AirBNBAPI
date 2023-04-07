using AirBnb.Model;

namespace AirBNBAPI.Repositories
{
    public interface IAirBnBRepository
    {
    

        public Task<IEnumerable<Location>> GetAllLocationsAsync(CancellationToken cancellationToken);
        public Task<List<Reservation>> GetReservationsByLocationAsync(int locationId, CancellationToken cancellationToken);
        public Task<Location> GetLocationAsync(int id, CancellationToken cancellationToken);
        public Task<List<Reservation>> GetExistingReservationsAsync(int? locationId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
        public Task AddReservationAsync(Reservation reservation, CancellationToken cancellationToken);
        public Task<Customer>GetCustomerByEmailAsync(string email, CancellationToken cancellationToken);

        public Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken);
        public Task SaveChanges(CancellationToken cancellationToken);
    }
}
