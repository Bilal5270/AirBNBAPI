using AirBnb.Model;
using AirBNBAPI.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AirBNBAPI.Services
{
    public interface ISearchService
    {
        public  Task <IEnumerable<Location>> GetAllLocationsAsync(CancellationToken cancellationToken);
        public Task <Location> GetSpecificLocationAsync(int id, CancellationToken cancellationToken);
        public Task<UnavailableDatesDto> GetUnavailableDatesAsync(int locationId, CancellationToken cancellationToken);
        Task<PlacedReservationDto> AddReservationAsync(ReservationDto reservationDto, CancellationToken cancellationToken);

    }
}
