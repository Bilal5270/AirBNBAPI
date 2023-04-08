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
        private readonly IMapper _mapper;
        //private readonly ILocationService _locationService;
        private readonly ISearchService _searchService;

        public LocationsController(IMapper mapper, ISearchService searchService)
        {
            
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
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocation(CancellationToken cancellationToken)
        {
            var locations = await _searchService.GetAllLocationsAsync(cancellationToken);
            return Ok(locations);
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
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetLocation(CancellationToken cancellationToken)
        {
            var locations = await _searchService.GetLocation(cancellationToken);
            return Ok(locations);
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
           var highestprice = _searchService.GetMaxPrice(cancellationToken);
            //Deze returned geen Ok omdat het niet combineerd met de front-end, hij stuurt extra dingen op in het json object. Voor deze reden is er geen Ok return.
           return await highestprice;
            
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

            var detailedlocation = await _searchService.GetDetailedLocation(id, cancellationToken);
            //Deze returned geen Ok omdat het niet combineerd met de front-end, hij stuurt extra dingen op in het json object. Voor deze reden is er geen Ok return.
            return detailedlocation;

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
            return await _searchService.Search(obj, cancellationToken);

        }
        /// <summary>
        /// Gets the unavailable dates for a specific location based on its reservations.
        /// </summary>
        /// <param name="locationId">The ID of the location to retrieve the unavailable dates for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see cref="ActionResult{T}"/> containing the <see cref="UnavailableDatesDto"/> object with the unavailable dates.</returns>
        [HttpGet("UnAvailableDates/{locationId}")]
        public async Task<ActionResult<UnavailableDatesDto>> GetUnavailableDates(int locationId, CancellationToken cancellationToken)
        {
            var unavailableDatesDto = await _searchService.GetUnavailableDatesAsync(locationId, cancellationToken);
            return unavailableDatesDto;
        }

        
    }
}
