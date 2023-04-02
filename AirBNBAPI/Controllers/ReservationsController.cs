using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirBNBAPI.Data;
using AirBnb.Model;
using AirBNBAPI.Services;
using AirBNBAPI.Model.DTO;
using AutoMapper;

namespace AirBNBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AirBNBAPIContext _context;
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public ReservationsController(AirBNBAPIContext context, ISearchService searchService, IMapper mapper)
        {
            _context = context;
            _searchService = searchService;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new reservation for a customer at a specified location.
        /// </summary>
        /// <param name="reservationDto">The reservation data to create.</param>
        /// <returns>The created reservation data.</returns>
        /// <response code="200">Returns the created reservation data.</response>
        /// <response code="400">If the location ID is invalid.</response>
        [HttpPost]
        [ProducesResponseType(typeof(PlacedReservationDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<PlacedReservationDto>> PostReservation(ReservationDto reservationDto)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Email == reservationDto.Email);

            if (customer == null)
            {
                customer = new Customer
                {
                    FirstName = reservationDto.FirstName,
                    LastName = reservationDto.LastName,
                    Email = reservationDto.Email
                };
                _context.Customer.Add(customer);
            }

            var location = await _context.Location.FindAsync(reservationDto.LocationId);
            if (location == null)
            {
                return BadRequest("Invalid location ID");
            }

            var reservation = _mapper.Map<Reservation>(reservationDto); // map DTO to model
            reservation.Customer = customer; // associate reservation with customer
            reservation.Location = location; // associate reservation with location
            _context.Reservation.Add(reservation); // add model to context
            await _context.SaveChangesAsync(); // save changes

            var placedReservationDto = _mapper.Map<PlacedReservationDto>(reservation); // map model to DTO for response

            return Ok(placedReservationDto);
        }
        //// GET: api/Listings
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Reservation>>> GetReservation()
        //{
        //    return await _context.Reservation.ToListAsync();
        //}

        // GET: api/Listings/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Reservation>> GetReservation(int id)
        //{
        //    var reservation = await _context.Reservation.FindAsync(id);

        //    if (reservation == null)
        //    {
        //        return NotFound();
        //    }

        //    return reservation;
        //}

        //// PUT: api/Listings/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        //{
        //    if (id != reservation.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(reservation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReservationExists(id))
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

        //// POST: api/Listings
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        //{
        //    _context.Reservation.Add(reservation);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        //}

        //// DELETE: api/Listings/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteReservation(int id)
        //{
        //    var reservation = await _context.Reservation.FindAsync(id);
        //    if (reservation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Reservation.Remove(reservation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ReservationExists(int id)
        //{
        //    return _context.Reservation.Any(e => e.Id == id);
        //}
    }
}
