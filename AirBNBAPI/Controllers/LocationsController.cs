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

namespace AirBNBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]

   
    public class LocationsController : ControllerBase
    {
        private readonly AirBNBAPIContext _context;
        private readonly IMapper _mapper;
        private readonly ILocationService _locationService;

        public LocationsController(AirBNBAPIContext context, IMapper mapper, ILocationService locationService)
        {
            _context = context;
            _mapper = mapper;
            _locationService = locationService;
        }

        // GET: api/Locations
        [HttpGet("GetAll")]
        public IEnumerable<Location> GetAllLocation()
        {
            return _locationService.GetAllLocations();
        }
        /// <summary>
        /// Pulling all locations for advanced search
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<LocationDto> GetLocation()
        {
            return _locationService.GetAllLocations().Select(location => _mapper.Map<LocationDto>(location));
            //return _studentService.GetAllStudents().Select(student => _mapper.Map(student));
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Location>>> GetLocation()
        //{
        //    return await _context.Location.ToListAsync();
        //}

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {

            return _locationService.GetSpecificLocation(id);
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            _context.Location.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Location.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.Id == id);
        }
    }
}
