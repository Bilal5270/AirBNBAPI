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

        public IEnumerable<Landlord> GetAllLandlords()
        {
            return _context.Landlord.ToList();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _context.Reservation.ToList();
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
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customer.ToList();
        }

        public Landlord GetLandlord(int id)
        {
            return _context.Landlord.Find(id);
        }

        public Reservation GetReservation(int id)
        {
            return _context.Reservation.Find(id);
        }

        public async Task<Location> GetLocationAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Location.FindAsync(new object[] { id }, cancellationToken);
        }
        //public async Task<Location> GetMaxPrice()
        //{
        //    return await _context.Location.Where(p => p.PricePerDay == Max);
        //}
        //public async Task<List<Reservation>> GetReservationsByLocationAsync(int locationId, CancellationToken cancellationToken)
        //{
        //    var reservations = await _context.Reservation
        //        .Include(r => r.Location)
        //        .Include(r => r.Customer)
        //        .Where(r => r.LocationId == locationId)
        //        .ToListAsync(cancellationToken);

        //    return reservations;
        //}
        public Customer GetCustomer(int id)
        {
            return _context.Customer.Find(id);
        }
    }
}
