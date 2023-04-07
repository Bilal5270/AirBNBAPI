using AirBnb.Model;
using AirBNBAPI.Model.DTO;
using AirBNBAPI.Repositories;
using AutoMapper;

namespace AirBNBAPI.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        private readonly IMapper _mapper;
        public ReservationService(IAirBnBRepository airBnBRepository, IMapper mapper)
        {
            _airBnBRepository = airBnBRepository;
            _mapper = mapper;
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
