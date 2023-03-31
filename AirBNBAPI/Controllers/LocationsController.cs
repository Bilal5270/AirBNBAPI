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

        // GET: api/Locations
        [HttpGet("GetAll")]
        public async Task <IEnumerable<Location>> GetAllLocation(CancellationToken cancellationToken)
        {
            return await _searchService.GetAllLocationsAsync(cancellationToken);
        }
        /// <summary>
        /// Pulling all locations for advanced search
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task <IEnumerable<LocationDto>> GetLocation(CancellationToken cancellationToken)
        {
            return (await _searchService.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<LocationDto>(location));
            //return _studentService.GetAllStudents().Select(student => _mapper.Map(student));
        }
        [HttpGet("GetMaxPrice")]
        public async Task<ActionResult<MaxPriceDto>> GetMaxPrice(CancellationToken cancellationToken)
        {
            IEnumerable<MaxPriceDto> list = (await _searchService.GetAllLocationsAsync(cancellationToken)).Select(location => _mapper.Map<MaxPriceDto>(location));
            return list.OrderByDescending(item => item.Price).First();
            //return _studentService.GetAllStudents().Select(student => _mapper.Map(student));
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Location>>> GetLocation()
        //{
        //    return await _context.Location.ToListAsync();
        //}

        // GET: api/Properties/5
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
