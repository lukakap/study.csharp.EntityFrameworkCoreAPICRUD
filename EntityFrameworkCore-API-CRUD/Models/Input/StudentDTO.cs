using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_API_CRUD.Models.Input
{
    public class StudentDTO
    {
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
