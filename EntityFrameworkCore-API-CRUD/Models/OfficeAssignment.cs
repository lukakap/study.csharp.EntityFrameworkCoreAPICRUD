using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_API_CRUD.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        [StringLength(50)]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
