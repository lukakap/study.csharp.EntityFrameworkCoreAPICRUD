using EntityFrameworkCore_API_CRUD.Data;
using EntityFrameworkCore_API_CRUD.Models;
using EntityFrameworkCore_API_CRUD.Models.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EntityFrameworkCore_API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly SchoolContext _context;

        public DepartmentController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(DepartmentDTO department)
        {
            //When the controller's action method receives a POST request with data
            //(in your case, a DepartmentDTO object), ASP.NET Core attempts to bind the data from the request to the model.

            //If any of the model properties fail validation(e.g., due to data type mismatches,
            //required fields not provided, or any other validation attributes on the model),
            //those validation errors will be stored in the ModelState dictionary.

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDepartment = new Department { 
                Name = department.Name, 
                Budget = department.Budget, 
                StartDate = department.StartDate, 
                InstructorID = department.InstructorID
            };

            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartment), new { id = newDepartment.DepartmentID }, newDepartment);
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
