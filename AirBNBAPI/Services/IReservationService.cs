using AirBNBAPI.Model.DTO;

namespace AirBNBAPI.Services
{
    public interface IReservationService
    {
        public Task<PlacedReservationDto> AddReservationAsync(ReservationDto reservationDto, CancellationToken cancellationToken);
    }
}
