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
        [HttpGet]
        public async Task <IEnumerable<PricedLocationDto>> GetLocation(CancellationToken cancellationToken)
        {
            return (await _searchService.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<PricedLocationDto>(location));
            
        }

        [HttpGet("GetMaxPrice")]
        public async Task<ActionResult<MaxPriceDto>> GetMaxPrice(CancellationToken cancellationToken)
        {
            IEnumerable<MaxPriceDto> list = (await _searchService.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<MaxPriceDto>(location));
            return list.OrderByDescending(item => item.Price).First();
            
        }

        [HttpPost("Search")]
        public async Task<IEnumerable<PricedLocationDto>> Search(SearchDto obj, CancellationToken cancellationToken)
        {
            var list = await _searchService.GetAllLocationsAsync(cancellationToken);
            var filtered = list.Where(item => item.Feature == obj.Feature).Where(item => item.PricePerDay >= obj.MinPrice).Where(item => item.PricePerDay <= obj.MaxPrice).Where(item => item.Type == obj.Type).Where(item => item.Rooms >= obj.Room);
            return filtered.Select(location => _mapper.Map<PricedLocationDto>(location));

        }

        [HttpGet("GetDetails/{id}")]
        public async Task<ActionResult<DetailedDto>> GetLocation(int id)
        {

            var specificLocation = await _searchService.GetSpecificLocationAsync(id);
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
