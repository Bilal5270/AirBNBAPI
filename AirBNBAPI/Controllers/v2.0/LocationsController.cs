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
using AirBNBAPI.Services;
using AutoMapper;

namespace AirBNBAPI.Controllers.v2._0
{
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly AirBNBAPIContext _context;
        private readonly IMapper _mapper;
        private readonly ISearchService _searchService;

        public LocationsController(AirBNBAPIContext context, IMapper mapper, ISearchService searchService)
        {
            _context = context;
            _mapper = mapper;
            _searchService = searchService;
        }

        // GET: api/Locations
        /// <summary>
        /// Retrieves all locations with their corresponding prices
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>An enumerable list of PricedLocationDto objects</returns>
        [HttpGet]
        public async Task <IEnumerable<PricedLocationDto>> GetLocation(CancellationToken cancellationToken)
        {
            return (await _searchService.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<PricedLocationDto>(location));
            
        }
        /// <summary>
        /// Retrieves the location with the highest price
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The MaxPriceDto object of the location with the highest price</returns>
        [HttpGet("GetMaxPrice")]
        public async Task<ActionResult<MaxPriceDto>> GetMaxPrice(CancellationToken cancellationToken)
        {
            IEnumerable<MaxPriceDto> list = (await _searchService.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<MaxPriceDto>(location));
            return list.OrderByDescending(item => item.Price).First();
            
        }
        /// <summary>
        /// Searches for locations that meet the specified criteria
        /// </summary>
        /// <param name="obj">Search criteria object</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>An enumerable list of PricedLocationDto objects that meet the specified criteria</returns>
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
            if (obj.MaxPrice == null)
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
        /// <summary>
        /// Retrieves detailed information about a location based on its ID.
        /// </summary>
        /// <param name="id">The ID of the location to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the request if needed.</param>
        /// <returns>An ActionResult containing a DetailedDto object representing the detailed information about the location.</returns>
        [HttpGet("GetDetails/{id}")]
        public async Task<ActionResult<DetailedDto>> GetLocation(int id, CancellationToken cancellationToken)
        {

            var specificLocation = await _searchService.GetSpecificLocationAsync(id, cancellationToken);
            var detailedLocation = _mapper.Map<DetailedDto>(specificLocation);
            return detailedLocation;

        }

        //// GET: api/Locations/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Location>> GetLocation(int id)
        //{
        //  if (_context.Location == null)
        //  {
        //      return NotFound();
        //  }
        //    var location = await _context.Location.FindAsync(id);

        //    if (location == null)
        //    {
        //        return NotFound();
        //    }

        //    return location;
        //}

        //// PUT: api/Locations/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLocation(int id, Location location)
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Location>> PostLocation(Location location)
        //{
        //    if (_context.Location == null)
        //    {
        //        return Problem("Entity set 'AirBNBAPIContext.Location'  is null.");
        //    }
        //    _context.Location.Add(location);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        //}

        //// DELETE: api/Locations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLocation(int id)
        //{
        //    if (_context.Location == null)
        //    {
        //        return NotFound();
        //    }
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
        //    return (_context.Location?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
