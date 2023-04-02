using AirBnb.Model;
using AirBNBAPI.Model.DTO;
using AirBNBAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirBNBAPI.Services
{
    public class SearchService : ISearchService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        public SearchService (IAirBnBRepository airBnBRepository)
        {
            _airBnBRepository = airBnBRepository;
        }
        //LOCATIONS
        public Location ChangeLocation(int id, Location location)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync(CancellationToken cancellationToken)
        {
            return await _airBnBRepository.GetAllLocationsAsync(cancellationToken);

        }

        public async Task<Location> GetSpecificLocationAsync(int id, CancellationToken cancellationToken)
        {
            return await _airBnBRepository.GetLocationAsync(id, cancellationToken);
        }

        //RESERVATIONS

        public async Task<UnavailableDatesDto> GetUnavailableDatesAsync(int locationId, CancellationToken cancellationToken)
        {
            var reservations = await _airBnBRepository.GetReservationsByLocationAsync(locationId, cancellationToken);

            var unavailableDates = reservations.SelectMany(r =>
                Enumerable.Range(0, (r.EndDate - r.StartDate).Days + 1)
                    .Select(i => r.StartDate.AddDays(i))
            ).ToList();

            return new UnavailableDatesDto { UnavailableDates = unavailableDates };
        }

        public Reservation ChangeReservation(int id, Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _airBnBRepository.GetAllReservations();

        }

        public Reservation GetSpecificReservation(int id)
        {
            return _airBnBRepository.GetReservation(id);
        }

        //CUSTOMERS
        public Customer ChangeCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _airBnBRepository.GetAllCustomers();

        }

        public Customer GetSpecificCustomer(int id)
        {
            return _airBnBRepository.GetCustomer(id);
        }

        //LANDLORDS
        public Landlord ChangeLandlord(int id, Landlord landlord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Landlord> GetAllLandlords()
        {
            return _airBnBRepository.GetAllLandlords();

        }

        public Landlord GetSpecificLandlord(int id)
        {
            return _airBnBRepository.GetLandlord(id);
        }
    }
}
