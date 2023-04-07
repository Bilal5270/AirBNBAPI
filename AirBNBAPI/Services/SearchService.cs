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
        public SearchService(IAirBnBRepository airBnBRepository, IMapper mapper)
        {
            _airBnBRepository = airBnBRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync(CancellationToken cancellationToken)
        {
            return await _airBnBRepository.GetAllLocationsAsync(cancellationToken);

        }

        public async Task<IEnumerable<LocationDto>> GetLocation(CancellationToken cancellationToken)
        {
            return (await _airBnBRepository.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<LocationDto>(location));

        }
        public async Task<IEnumerable<PricedLocationDto>> GetPricedLocation(CancellationToken cancellationToken)
        {
            return (await _airBnBRepository.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<PricedLocationDto>(location));

        }
        public async Task<Location> GetSpecificLocationAsync(int id, CancellationToken cancellationToken)
        {
            return await _airBnBRepository.GetLocationAsync(id, cancellationToken);
        }

        public async Task<ActionResult<MaxPriceDto>> GetMaxPrice(CancellationToken cancellationToken)
        {
            IEnumerable<MaxPriceDto> list = (await _airBnBRepository.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<MaxPriceDto>(location));
            return list.OrderByDescending(item => item.Price).First();

        }

        public async Task<ActionResult<DetailedDto>> GetDetailedLocation(int id, CancellationToken cancellationToken)
        {

            var specificLocation = await _airBnBRepository.GetLocationAsync(id, cancellationToken);
            var detailedLocation = _mapper.Map<DetailedDto>(specificLocation);
            return detailedLocation;

        }
        public async Task<UnavailableDatesDto> GetUnavailableDatesAsync(int locationId, CancellationToken cancellationToken)
        {
            var reservations = await _airBnBRepository.GetReservationsByLocationAsync(locationId, cancellationToken);

            var unavailableDates = reservations.SelectMany(r =>
                Enumerable.Range(0, (r.EndDate - r.StartDate).Days + 1)
                    .Select(i => r.StartDate.AddDays(i))
            ).ToList();
            //Ik heb hier geen automapper toegepast omdat het hier gaat om 1 veld. Een mapper is extreem overbodig en heeft geen toegevoegde waarde.
            return new UnavailableDatesDto { UnavailableDates = unavailableDates };
        }

        public async Task<IEnumerable<PricedLocationDto>> Search(SearchDto? obj, CancellationToken cancellationToken)
        {
            int? MinPrice = obj.MinPrice;
            int? MaxPrice = obj.MaxPrice;
            int? Room = obj.Rooms;

            if (obj.MinPrice == null)
            {
                MinPrice = 0;
            }
            if (obj.MaxPrice == null)
            {
                MaxPrice = int.MaxValue;
            }
            if (obj.Rooms == null)
            {
                Room = 0;
            }
            var list = await _airBnBRepository.GetAllLocationsAsync(cancellationToken);
            if (obj.Features == null && obj.Type == null && obj.MaxPrice == null && obj.MinPrice == null && obj.Rooms == null)
            {
                return list.Select(location => _mapper.Map<PricedLocationDto>(location));
            }
            if (obj.Features == null && obj.Type == null)
            {
                var filtered = list.Where(item => item.PricePerDay >= MinPrice).Where(item => item.PricePerDay <= MaxPrice).Where(item => item.Rooms >= Room);
                return filtered.Select(location => _mapper.Map<PricedLocationDto>(location));
            }
            if (obj.Features == null)
            {
                var filtered = list.Where(item => item.Type == obj.Type).Where(item => item.PricePerDay >= MinPrice).Where(item => item.PricePerDay <= MaxPrice).Where(item => item.Rooms >= Room);
                return filtered.Select(location => _mapper.Map<PricedLocationDto>(location));
            }
            if (obj.Type == null)
            {
                var filtered = list.Where(item => item.Features == obj.Features).Where(item => item.PricePerDay >= MinPrice).Where(item => item.PricePerDay <= MaxPrice).Where(item => item.Rooms >= Room);
                return filtered.Select(location => _mapper.Map<PricedLocationDto>(location));
            }
            else
            {
                var filtered = list.Where(item => item.Features == obj.Features).Where(item => item.PricePerDay >= MinPrice).Where(item => item.PricePerDay <= MaxPrice).Where(item => item.Type == obj.Type).Where(item => item.Rooms >= Room);
                return filtered.Select(location => _mapper.Map<PricedLocationDto>(location));
            }

        }
    }
}