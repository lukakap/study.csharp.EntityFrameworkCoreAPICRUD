using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_API_CRUD.Models.Input
{
    public class OfficeAssignmentDTO
    {
        public int InstructorID { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
    }
}
