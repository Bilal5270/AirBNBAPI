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

            // Heb een extra validatie toegevoegd..
            // Ik heb een probleem gevonden met de front-end.
            // Het lijkt erop dat als je een datum aanklikt in de datepicker dat hij de startdatum en einddatum een dag eerder pakt.
            // Hierdoor geeft hij onjuiste waardes aan naar mijn POST request.
            // Normaal gesproken is dit geen probleem, echter heb ik een conflict checker aangemaakt die dus wel nu op de bestaande reserveringen controleerd.
            // Omdat die nu een dag eerder zijn botst die met mijn conflict checker. Ik snap dat het nu al de dag van de deadline is en dat dit niet gefixt kan worden.
            // Kan hier echter wel rekening mee gehouden worden voor mijn conflict checker?
            // Als je conflicten hebt zet of deze extra check uit, of reserveer in de front-end 1 dag later dan de laatste unavailable date in de date picker.
            //Dus als 10 mei is gereserveerd in de datepicker, dan kan je pas vanaf 12 mei in de front-end een reservering maken zonder conflict.
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
