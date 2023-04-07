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
        public Task<IEnumerable<LocationDto>> GetLocation(CancellationToken cancellationToken);
        public Task<IEnumerable<PricedLocationDto>> GetPricedLocation(CancellationToken cancellationToken);
        public Task<ActionResult<DetailedDto>> GetDetailedLocation(int id, CancellationToken cancellationToken);
        public Task<ActionResult<MaxPriceDto>> GetMaxPrice(CancellationToken cancellationToken);
        public Task<IEnumerable<PricedLocationDto>> Search(SearchDto? obj, CancellationToken cancellationToken);
    }
}
