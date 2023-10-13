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
    public class OfficeAssignmentController : ControllerBase
    {
        private readonly SchoolContext _context;

        public OfficeAssignmentController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/OfficeAssignment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeAssignment>>> GetOfficeAssignments()
        {
            return await _context.OfficeAssignments.ToListAsync();
        }

        // GET: api/OfficeAssignment/5
        [HttpGet("{instructorId}")]
        public async Task<ActionResult<OfficeAssignment>> GetOfficeAssignment(int instructorId)
        {
            var officeAssignment = await _context.OfficeAssignments.FindAsync(instructorId);

            if (officeAssignment == null)
            {
                return NotFound();
            }

            return officeAssignment;
        }

        // POST: api/OfficeAssignment
        [HttpPost]
        public async Task<ActionResult<OfficeAssignment>> PostOfficeAssignment(OfficeAssignmentDTO officeAssignment)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var newOfficeAssignment = new OfficeAssignment
            {
                InstructorID = officeAssignment.InstructorID,
                Location = officeAssignment.Location
            };

            _context.OfficeAssignments.Add(newOfficeAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOfficeAssignment), new { instructorId = officeAssignment.InstructorID }, officeAssignment);
        }

        // DELETE: api/OfficeAssignment/5
        [HttpDelete("{instructorId}")]
        public async Task<IActionResult> DeleteOfficeAssignment(int instructorId)
        {
            var officeAssignment = await _context.OfficeAssignments.FindAsync(instructorId);
            if (officeAssignment == null)
            {
                return NotFound();
            }

            _context.OfficeAssignments.Remove(officeAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
