using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MSA_Phase1_StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly StudentContext _context;

        //constructor
        public AddressesController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await _context.Address.ToListAsync();
        }

        // GET: api/Addresses/5
        // Get the details of a student, specified by their student id
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var Address = await _context.Address.FindAsync(id);

            if (Address == null)
            {
                return NotFound();
            }

            return Address;
        }

        // PUT: api/Addresses/5
        // Update the details of a student with the provided id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address Address)
        {
            if (id != Address.AddressId)
            {
                return BadRequest();
            }

            _context.Entry(Address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        // Add a student with the provided details
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address Address)
        {
            _context.Address.Add(Address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = Address.AddressId }, Address);
        }

        // DELETE: api/Addresses/5
        // Delete a student with the given student ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var Address = await _context.Address.FindAsync(id);
            if (Address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(Address);
            await _context.SaveChangesAsync();

            return Address;
        }

        //Endpoints by student
        // GET: api/Addresses/5
        // Get the details of a student, specified by their student id
        [HttpGet("ByStudent/{id}")]
        public async Task<ActionResult<Address>> GetAddressByStudent(int id)
        {
            var Address = await _context.Address.SingleOrDefaultAsync<Address>(Address => Address.StudentId == id);

            if (Address == null)
            {
                return NotFound();
            }

            return Address;
        }

        // Update the details of a student with the provided id
        [HttpPut("ByStudent/{id}")]
        public async Task<IActionResult> PutAddressByStudent(int id, Address Address)
        {
            var StudentAddress = await _context.Address.SingleOrDefaultAsync<Address>(Address => Address.StudentId == id);

            StudentAddress.StreetNumber = Address.StreetNumber;
            StudentAddress.Street = Address.Street;
            StudentAddress.Suburb = Address.Suburb;
            StudentAddress.City = Address.City;
            StudentAddress.Country = Address.Country;
            StudentAddress.Postcode = Address.Postcode;

            _context.Update(StudentAddress);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //helper methods
        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.AddressId == id);
        }
    }
}
