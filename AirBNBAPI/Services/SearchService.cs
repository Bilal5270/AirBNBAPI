using AirBnb.Model;
using AirBNBAPI.Model.DTO;
using AirBNBAPI.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AirBNBAPI.Services
{
    public class SearchService : ISearchService 
    {
        private readonly IAirBnBRepository _airBnBRepository;
        private readonly IMapper _mapper;
        public SearchService (IAirBnBRepository airBnBRepository, IMapper mapper)
        {
            _airBnBRepository = airBnBRepository;
            _mapper = mapper;
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


        public async Task<PlacedReservationDto> AddReservationAsync(ReservationDto reservationDto, CancellationToken cancellationToken)
        {
            var customer = await _airBnBRepository.GetCustomerByEmailAsync(reservationDto.Email, cancellationToken);

            if (customer == null)
            {
                customer = new Customer
                {
                    FirstName = reservationDto.FirstName,
                    LastName = reservationDto.LastName,
                    Email = reservationDto.Email
                };
                await _airBnBRepository.AddCustomerAsync(customer, cancellationToken);
            }

            var location = await _airBnBRepository.GetLocationAsync(reservationDto.LocationId, cancellationToken);
            if (location == null)
            {
                throw new ArgumentException("Invalid location ID");
            }

            var reservation = _mapper.Map<Reservation>(reservationDto);
            reservation.Customer = customer;
            reservation.Location = location;

            // Check availability of reservation
            var existingReservations = await _airBnBRepository.GetExistingReservationsAsync(reservation.LocationId, reservation.StartDate, reservation.EndDate, cancellationToken);
            if (existingReservations.Any())
            {
                throw new InvalidOperationException("The reservation conflicts with an existing reservation.");
            }

            await _airBnBRepository.AddReservationAsync(reservation, cancellationToken);
            await _airBnBRepository.SaveChanges(cancellationToken);

            return _mapper.Map<PlacedReservationDto>(reservation);
        }


    }
}
