using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirBNBAPI.Data;
using AirBnb.Model;
using AirBNBAPI.Model.DTO;
using AutoMapper;
using AirBNBAPI.Services;
using System.Threading;

namespace AirBNBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]

   
    public class LocationsController : ControllerBase
    {
        private readonly AirBNBAPIContext _context;
        private readonly IMapper _mapper;
        //private readonly ILocationService _locationService;
        private readonly ISearchService _searchService;

        public LocationsController(AirBNBAPIContext context, IMapper mapper, ISearchService searchService)
        {
            _context = context;
            _mapper = mapper;
            _searchService = searchService;

        }
        /// <summary>
        /// Gets all locations.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Locations/GetAll
        ///
        /// </remarks>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see cref="IEnumerable{Location}"/> of all locations.</returns>
        /// 
        // GET: api/Locations
        [HttpGet("GetAll")]
        public async Task <IEnumerable<Location>> GetAllLocation(CancellationToken cancellationToken)
        {
            return await _searchService.GetAllLocationsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets all locations as DTOs.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Locations
        ///
        /// </remarks>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see cref="IEnumerable{LocationDto}"/> of all locations as DTOs.</returns>

        [HttpGet]
        public async Task <IEnumerable<LocationDto>> GetLocation(CancellationToken cancellationToken)
        {
            return (await _searchService.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<LocationDto>(location));
            //return _studentService.GetAllStudents().Select(student => _mapper.Map(student));
        }
        /// <summary>
        /// Gets the max price for a location.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Locations/GetMaxPrice
        ///
        /// </remarks>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="MaxPriceDto"/> of the location with the maximum price.</returns>
        [HttpGet("GetMaxPrice")]
        public async Task<ActionResult<MaxPriceDto>> GetMaxPrice(CancellationToken cancellationToken)
        {
            IEnumerable<MaxPriceDto> list = (await _searchService.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<MaxPriceDto>(location));
            return list.OrderByDescending(item => item.Price).First();
            //return _studentService.GetAllStudents().Select(student => _mapper.Map(student));
        }
        /// <summary>
        /// Gets the detailed information for a specific location.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Locations/GetDetails/{id}
        ///
        /// </remarks>
        /// <param name="id">The ID of the location.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="DetailedDto"/> of the specified location.</returns>
        [HttpGet("GetDetails/{id}")]
        public async Task<ActionResult<DetailedDto>> GetLocation(int id, CancellationToken cancellationToken)
        {

            var specificLocation = await _searchService.GetSpecificLocationAsync(id, cancellationToken);
            var detailedLocation = _mapper.Map<DetailedDto>(specificLocation);
            return detailedLocation;

        }
       
        [HttpPost("Search")]
        public async Task<IEnumerable<PricedLocationDto>> Search(SearchDto? obj, CancellationToken cancellationToken)
        {
            int? MinPrice = obj.MinPrice;
            int? MaxPrice = obj.MaxPrice;
            int? Room = obj.Rooms;

            if (obj.MinPrice == null)
            {
                MinPrice = 0;
            }
            if(obj.MaxPrice == null)
            {
                MaxPrice = int.MaxValue;
            }
            if (obj.Rooms == null)
            {
                Room = 0;
            }
            var list = await _searchService.GetAllLocationsAsync(cancellationToken);
            if (obj.Features == null && obj.Type == null && obj.MaxPrice == null && obj.MinPrice == null && obj.Rooms == null)
            {
                return list.Select(location => _mapper.Map<PricedLocationDto>(location));
            }
            if(obj.Features == null && obj.Type == null)
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

        [HttpGet("UnAvailableDates/{locationId}")]
        public async Task<ActionResult<UnavailableDatesDto>> GetUnavailableDates(int locationId, CancellationToken cancellationToken)
        {
            var reservations = await _searchService.GetReservationsByLocationAsync(locationId,cancellationToken);
            var unavailableDates = reservations.SelectMany(r =>
                Enumerable.Range(0, (r.EndDate - r.StartDate).Days + 1)
                    .Select(i => r.StartDate.AddDays(i))
            ).ToList();
            var dto = new UnavailableDatesDto { UnavailableDates = unavailableDates };
            return Ok(dto);
        }

        // GET: api/Locations

        //// PUT: api/Properties/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProperty(int id, Location location)
        //{
        //    if (id != location.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(location).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LocationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        //// DELETE: api/Properties/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLocation(int id)
        //{
        //    var location = await _context.Location.FindAsync(id);
        //    if (location == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Location.Remove(location);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool LocationExists(int id)
        //{
        //    return _context.Location.Any(e => e.Id == id);
        //}
    }
}
