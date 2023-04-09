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
        
        private readonly IReservationService _reservationService;
        
      

        public ReservationsController( IReservationService reservationService)
        {
            
            _reservationService = reservationService;
        
        }

        /// <summary>
        /// Creates a new reservation for a customer at a specified location. This is for weekopdracht 7
        /// </summary>
        /// <param name="reservationDto">The reservation data to create.</param>
        /// <returns>The created reservation data.</returns>
        /// <response code="200">Returns the created reservation data.</response>
        /// <response code="400">If the location ID is invalid.</response>
        /// <response code="409">If the reservation conflicts with another one.</response>
        [HttpPost]
        [ProducesResponseType(typeof(PlacedReservationDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 409)]
        public async Task<IActionResult> PostReservation(ReservationDto reservationDto, CancellationToken cancellationToken)
        {
            try
            {
                var placedReservationDto = await _reservationService.AddReservationAsync(reservationDto, cancellationToken);
                return Ok(placedReservationDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

    }
}
