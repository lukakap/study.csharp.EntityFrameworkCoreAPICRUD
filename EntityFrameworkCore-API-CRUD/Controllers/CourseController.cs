using EntityFrameworkCore_API_CRUD.Data;
using EntityFrameworkCore_API_CRUD.Models;
using EntityFrameworkCore_API_CRUD.Models.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityFrameworkCore_API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        // GET: api/<CourseController>
        private readonly SchoolContext _context;

        public CourseController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // POST: api/Course
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseDTO course)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            Course newCourse = null;

            if (course.DepartmentID != null)
            {
                newCourse = new Course
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Credits = course.Credits,
                    DepartmentID = (int)course.DepartmentID
                };
            }
            else
            {
                newCourse = new Course
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Credits = course.Credits
                };
            }

            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = newCourse.CourseID }, course);
        }

        // PUT: api/Course/id/departmentId
        [HttpPut("{id}/{departmentId}")]
        public async Task<ActionResult<Course>> AddDepartmentToCourse(int id, int departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);

            if (department == null)
            { 
                return NotFound();
            }

            var course = await _context.Courses.Where(x => x.CourseID == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            course.DepartmentID = departmentId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseID)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Courses.Any(e => e.CourseID == id))
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
    }
}
