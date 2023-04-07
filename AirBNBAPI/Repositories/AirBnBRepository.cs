using AirBnb.Model;
using AirBNBAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AirBNBAPI.Repositories
{
    public class AirBnBRepository : IAirBnBRepository
    {   
        private readonly AirBNBAPIContext _context;
        public AirBnBRepository(AirBNBAPIContext context) 
        { 
            _context= context;
        }

    

        public async Task <IEnumerable<Location>> GetAllLocationsAsync(CancellationToken cancellationToken)
        {
            return await _context.Location.Include(location => location.Images).Include(location => location.Landlord).ToListAsync(cancellationToken);
        }
        public async Task<List<Reservation>> GetReservationsByLocationAsync(int locationId, CancellationToken cancellationToken)
        {
            return await _context.Reservation.Where(r => r.LocationId == locationId && r.EndDate >= DateTime.Today)
                                                 .ToListAsync(cancellationToken);
        }
  
        public async Task<Location> GetLocationAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Location.FindAsync(new object[] { id }, cancellationToken);
        }
    
        public async Task<List<Reservation>> GetExistingReservationsAsync(int? locationId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            return await _context.Reservation.Where(r => r.LocationId == locationId
            && r.StartDate <= endDate && r.EndDate >= startDate).ToListAsync(cancellationToken);
        }

        public async Task AddReservationAsync(Reservation reservation, CancellationToken cancellationToken)
        {
            await _context.Reservation.AddAsync(reservation, cancellationToken);
        }
        public async Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _context.Customer.AddAsync(customer, cancellationToken);
           
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Customer.FirstOrDefaultAsync(obj => obj.Email == email, cancellationToken);
        }

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
