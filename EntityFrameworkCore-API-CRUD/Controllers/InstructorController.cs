using EntityFrameworkCore_API_CRUD.Data;
using EntityFrameworkCore_API_CRUD.Models;
using EntityFrameworkCore_API_CRUD.Models.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EntityFrameworkCore_API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly SchoolContext _context;

        public InstructorController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Instructor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetInstructors()
        {
            return await _context.Instructors.ToListAsync();
        }

        // GET: api/Instructor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> GetInstructor(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return instructor;
        }

        // POST: api/Instructor
        [HttpPost]
        public async Task<ActionResult<Instructor>> PostInstructor(InstructorDTO instructor)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var newInstructor = new Instructor { 
                LastName = instructor.LastName, 
                FirstMidName = instructor.FirstMidName, 
                HireDate = instructor.HireDate
            };

            _context.Instructors.Add(newInstructor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstructor), new { id = newInstructor.ID }, instructor);
        }

        // DELETE: api/Instructor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
