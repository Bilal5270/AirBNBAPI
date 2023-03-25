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

namespace AirBNBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AirBNBAPIContext _context;
        private readonly ISearchService _searchService;
        public CustomersController(AirBNBAPIContext context, ISearchService searchService)
        {
            _context = context;
            _searchService = searchService;
        }

        //// GET: api/Users
        //[HttpGet]
        //public IEnumerable<Customer> GetCustomer()
        //{
        //    return _searchService.GetAllCustomers();
        //}

        //// GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        //{

        //    return _searchService.GetSpecificCustomer(id);
        //}

        ////// PUT: api/Users/5
        ////// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        ////[HttpPut("{id}")]
        ////public async Task<IActionResult> PutCustomer(int id, Customer customer)
        ////{
        ////    if (id != customer.Id)
        ////    {
        ////        return BadRequest();
        ////    }

        ////    _context.Entry(customer).State = EntityState.Modified;

        ////    try
        ////    {
        ////        await _context.SaveChangesAsync();
        ////    }
        ////    catch (DbUpdateConcurrencyException)
        ////    {
        ////        if (!CustomerExists(id))
        ////        {
        ////            return NotFound();
        ////        }
        ////        else
        ////        {
        ////            throw;
        ////        }
        ////    }

        ////    return NoContent();
        ////}

        ////// POST: api/Users
        ////// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        ////[HttpPost]
        ////public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        ////{
        ////    _context.Customer.Add(customer);
        ////    await _context.SaveChangesAsync();

        ////    return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        ////}

        ////// DELETE: api/Users/5
        ////[HttpDelete("{id}")]
        ////public async Task<IActionResult> DeleteCustomer(int id)
        ////{
        ////    var customer = await _context.Customer.FindAsync(id);
        ////    if (customer == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    _context.Customer.Remove(customer);
        ////    await _context.SaveChangesAsync();

        ////    return NoContent();
        ////}

        ////private bool CustomerExists(int id)
        ////{
        ////    return _context.Customer.Any(e => e.Id == id);
        ////}
    }
}
