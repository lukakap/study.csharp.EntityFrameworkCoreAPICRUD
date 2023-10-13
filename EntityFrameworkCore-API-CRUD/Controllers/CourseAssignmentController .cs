using EntityFrameworkCore_API_CRUD.Data;
using EntityFrameworkCore_API_CRUD.Models;
using EntityFrameworkCore_API_CRUD.Models.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore_API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAssignmentController : ControllerBase
    {
        private readonly SchoolContext _context;

        public CourseAssignmentController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/CourseAssignment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseAssignment>>> GetCourseAssignments()
        {
            return await _context.CourseAssignments.ToListAsync();
        }

        // GET: api/CourseAssignment/5
        [HttpGet("{instructorId}/{courseId}")]
        public async Task<ActionResult<CourseAssignment>> GetCourseAssignment(int instructorId, int courseId)
        {
            var courseAssignment = await _context.CourseAssignments.FindAsync(instructorId, courseId);

            if (courseAssignment == null)
            {
                return NotFound();
            }

            return courseAssignment;
        }

        // POST: api/CourseAssignment
        [HttpPost]
        public async Task<ActionResult<CourseAssignment>> PostCourseAssignment(CourseAssignmentDTO courseAssignment)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);  
            }

            var newCourseAssignment = new CourseAssignment { 
                CourseID = courseAssignment.CourseID, 
                InstructorID = courseAssignment.InstructorID 
            };

            _context.CourseAssignments.Add(newCourseAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourseAssignment), new { instructorId = newCourseAssignment.InstructorID, courseId = newCourseAssignment.CourseID }, newCourseAssignment);
        }

        // DELETE: api/CourseAssignment/5
        [HttpDelete("{instructorId}/{courseId}")]
        public async Task<IActionResult> DeleteCourseAssignment(int instructorId, int courseId)
        {
            var courseAssignment = await _context.CourseAssignments.FindAsync(instructorId, courseId);
            if (courseAssignment == null)
            {
                return NotFound();
            }

            _context.CourseAssignments.Remove(courseAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
