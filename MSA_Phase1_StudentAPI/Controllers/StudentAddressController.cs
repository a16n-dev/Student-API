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
    public class StudentAddressController : ControllerBase
    {
        private readonly StudentContext _context;

        //constructor
        public StudentAddressController(StudentContext context)
        {
            _context = context;
        }

        //Endpoints by student
        // GET: api/Addresses/5
        // Get the details of a student, specified by their student id
        [HttpPost("{student_id}")]
        public async Task<ActionResult<Address>> CreateAddressByStudent(int student_id, Address Address)
        {
            Address.StudentId = student_id;

            _context.Address.Add(Address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = Address.AddressId }, Address);
        }

        // Change the address of a student
        [HttpPut("{student_id}")]
        public async Task<IActionResult> PutAddressByStudent(int student_id, Address Address)
        {
            var StudentAddress = await _context.Address.SingleOrDefaultAsync<Address>(Address => Address.StudentId == student_id);

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
